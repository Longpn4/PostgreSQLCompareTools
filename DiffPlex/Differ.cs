using System;
using System.Collections.Generic;

namespace DiffPlex
{
    public class Differ : IDiffer
    {
        private static readonly string[] emptyStringArray = new string[0];

        public DiffResult CreateLineDiffs(string oldText, string newText, bool ignoreWhitespace)
        {
            return CreateLineDiffs(oldText, newText, ignoreWhitespace, false);
        }

        public DiffResult CreateLineDiffs(string oldText, string newText, bool ignoreWhitespace, bool ignoreCase)
        {
            if (oldText == null) throw new ArgumentNullException(nameof(oldText));
            if (newText == null) throw new ArgumentNullException(nameof(newText));


            return CreateCustomDiffs(oldText, newText, ignoreWhitespace, ignoreCase, str => str.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None));
        }

        public DiffResult CreateCharacterDiffs(string oldText, string newText, bool ignoreWhitespace)
        {
            return CreateCharacterDiffs(oldText, newText, ignoreWhitespace, false);
        }

        public DiffResult CreateCharacterDiffs(string oldText, string newText, bool ignoreWhitespace, bool ignoreCase)
        {
            if (oldText == null) throw new ArgumentNullException(nameof(oldText));
            if (newText == null) throw new ArgumentNullException(nameof(newText));


            return CreateCustomDiffs(
                oldText,
                newText,
                ignoreWhitespace,
                ignoreCase,
                str =>
                    {
                        var s = new string[str.Length];
                        for (int i = 0; i < str.Length; i++) s[i] = str[i].ToString();
                        return s;
                    });
        }

        public DiffResult CreateWordDiffs(string oldText, string newText, bool ignoreWhitespace, char[] separators)
        {
            return CreateWordDiffs(oldText, newText, ignoreWhitespace, false, separators);
        }

        public DiffResult CreateWordDiffs(string oldText, string newText, bool ignoreWhitespace, bool ignoreCase, char[] separators)
        {
            if (oldText == null) throw new ArgumentNullException(nameof(oldText));
            if (newText == null) throw new ArgumentNullException(nameof(newText));


            return CreateCustomDiffs(
                oldText,
                newText,
                ignoreWhitespace,
                ignoreCase,
                str => SmartSplit(str, separators));
        }

        public DiffResult CreateCustomDiffs(string oldText, string newText, bool ignoreWhiteSpace, Func<string, string[]> chunker)
        {
            return CreateCustomDiffs(oldText, newText, ignoreWhiteSpace, false, chunker);
        }

        public DiffResult CreateCustomDiffs(string oldText, string newText, bool ignoreWhiteSpace, bool ignoreCase, Func<string, string[]> chunker)
        {
            if (oldText == null) throw new ArgumentNullException(nameof(oldText));
            if (newText == null) throw new ArgumentNullException(nameof(newText));
            if (chunker == null) throw new ArgumentNullException(nameof(chunker));

            var pieceHash = new Dictionary<string, int>();
            var lineDiffs = new List<DiffBlock>();

            var modOld = new ModificationData(oldText);
            var modNew = new ModificationData(newText);

            BuildPieceHashes(pieceHash, modOld, ignoreWhiteSpace, ignoreCase, chunker);
            BuildPieceHashes(pieceHash, modNew, ignoreWhiteSpace, ignoreCase, chunker);

            BuildModificationData(modOld, modNew);

            int piecesALength = modOld.HashedPieces.Length;
            int piecesBLength = modNew.HashedPieces.Length;
            int posA = 0;
            int posB = 0;

            do
            {
                while (posA < piecesALength
                       && posB < piecesBLength
                       && !modOld.Modifications[posA]
                       && !modNew.Modifications[posB])
                {
                    posA++;
                    posB++;
                }

                int beginA = posA;
                int beginB = posB;
                for (; posA < piecesALength && modOld.Modifications[posA]; posA++) ;

                for (; posB < piecesBLength && modNew.Modifications[posB]; posB++) ;

                int deleteCount = posA - beginA;
                int insertCount = posB - beginB;
                if (deleteCount > 0 || insertCount > 0)
                {
                    lineDiffs.Add(new DiffBlock(beginA, deleteCount, beginB, insertCount));
                }
            } while (posA < piecesALength && posB < piecesBLength);

            return new DiffResult(modOld.Pieces, modNew.Pieces, lineDiffs);
        }

        private static string[] SmartSplit(string str, char[] delims)
        {
            var list = new List<string>();
            int begin = 0;
            bool processingDelim = false;
            int delimBegin = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (Array.IndexOf(delims, str[i]) != -1)
                {
                    if (i >= str.Length - 1)
                    {
                        if (processingDelim)
                        {
                            list.Add(str.Substring(delimBegin, (i + 1 - delimBegin)));
                        }
                        else
                        {
                            list.Add(str.Substring(begin, (i - begin)));
                            list.Add(str.Substring(i, 1));
                        }
                    }
                    else
                    {
                        if (!processingDelim)
                        {
                            list.Add(str.Substring(begin, (i - begin)));
                            processingDelim = true;
                            delimBegin = i;
                        }
                    }
                    
                    begin = i + 1;
                }
                else
                {
                    if (processingDelim)
                    {
                        if (i - delimBegin > 0)
                        {
                            list.Add(str.Substring(delimBegin, (i - delimBegin)));
                        }

                        processingDelim = false;
                    }

                    if (i >= str.Length - 1)
                    {
                        list.Add(str.Substring(begin, (i + 1 - begin)));
                    }
                }
            }

            return list.ToArray();
        }

        /// <summary>
        /// Finds the middle snake and the minimum length of the edit script comparing string A and B
        /// </summary>
        /// <param name="A"></param>
        /// <param name="startA">Lower bound inclusive</param>
        /// <param name="endA">Upper bound exclusive</param>
        /// <param name="B"></param>
        /// <param name="startB">lower bound inclusive</param>
        /// <param name="endB">upper bound exclusive</param>
        /// <returns></returns>
        protected static EditLengthResult CalculateEditLength(int[] A, int startA, int endA, int[] B, int startB, int endB)
        {
            int N = endA - startA;
            int M = endB - startB;
            int MAX = M + N + 1;

            var forwardDiagonal = new int[MAX + 1];
            var reverseDiagonal = new int[MAX + 1];
            return CalculateEditLength(A, startA, endA, B, startB, endB, forwardDiagonal, reverseDiagonal);
        }

        private static EditLengthResult CalculateEditLength(int[] A, int startA, int endA, int[] B, int startB, int endB, int[] forwardDiagonal, int[] reverseDiagonal)
        {
            if (null == A) throw new ArgumentNullException(nameof(A));
            if (null == B) throw new ArgumentNullException(nameof(B));

            if (A.Length == 0 && B.Length == 0)
            {
                return new EditLengthResult();
            }

            int N = endA - startA;
            int M = endB - startB;
            int MAX = M + N + 1;
            int HALF = MAX / 2;
            int delta = N - M;
            bool deltaEven = delta % 2 == 0;
            forwardDiagonal[1 + HALF] = 0;
            reverseDiagonal[1 + HALF] = N + 1;

            Log.WriteLine("Comparing strings");
            Log.WriteLine("\t{0} of length {1}", A, A.Length);
            Log.WriteLine("\t{0} of length {1}", B, B.Length);

            for (int D = 0; D <= HALF; D++)
            {
                Log.WriteLine("\nSearching for a {0}-Path", D);
                // forward D-path
                Log.WriteLine("\tSearching for forward path");
                Edit lastEdit;
                for (int k = -D; k <= D; k += 2)
                {
                    Log.WriteLine("\n\t\tSearching diagonal {0}", k);
                    int kIndex = k + HALF;
                    int x, y;
                    if (k == -D || (k != D && forwardDiagonal[kIndex - 1] < forwardDiagonal[kIndex + 1]))
                    {
                        x = forwardDiagonal[kIndex + 1]; // y up    move down from previous diagonal
                        lastEdit = Edit.InsertDown;
                        Log.Write("\t\tMoved down from diagonal {0} at ({1},{2}) to ", k + 1, x, (x - (k + 1)));
                    }
                    else
                    {
                        x = forwardDiagonal[kIndex - 1] + 1; // x up     move right from previous diagonal
                        lastEdit = Edit.DeleteRight;
                        Log.Write("\t\tMoved right from diagonal {0} at ({1},{2}) to ", k - 1, x - 1, (x - 1 - (k - 1)));
                    }
                    y = x - k;
                    int startX = x;
                    int startY = y;
                    Log.WriteLine("({0},{1})", x, y);
                    while (x < N && y < M && A[x + startA] == B[y + startB])
                    {
                        x += 1;
                        y += 1;
                    }
                    Log.WriteLine("\t\tFollowed snake to ({0},{1})", x, y);

                    forwardDiagonal[kIndex] = x;

                    if (!deltaEven && k - delta >= -D + 1 && k - delta <= D - 1)
                    {
                        int revKIndex = (k - delta) + HALF;
                        int revX = reverseDiagonal[revKIndex];
                        int revY = revX - k;
                        if (revX <= x && revY <= y)
                        {
                            return new EditLengthResult
                            {
                                EditLength = 2*D - 1,
                                StartX = startX + startA,
                                StartY = startY + startB,
                                EndX = x + startA,
                                EndY = y + startB,
                                LastEdit = lastEdit
                            };
                        }
                    }
                }

                // reverse D-path
                Log.WriteLine("\n\tSearching for a reverse path");
                for (int k = -D; k <= D; k += 2)
                {
                    Log.WriteLine("\n\t\tSearching diagonal {0} ({1})", k, k + delta);
                    int kIndex = k + HALF;
                    int x, y;
                    if (k == -D || (k != D && reverseDiagonal[kIndex + 1] <= reverseDiagonal[kIndex - 1]))
                    {
                        x = reverseDiagonal[kIndex + 1] - 1; // move left from k+1 diagonal
                        lastEdit = Edit.DeleteLeft;
                        Log.Write("\t\tMoved left from diagonal {0} at ({1},{2}) to ", k + 1, x + 1, ((x + 1) - (k + 1 + delta)));
                    }
                    else
                    {
                        x = reverseDiagonal[kIndex - 1]; //move up from k-1 diagonal
                        lastEdit = Edit.InsertUp;
                        Log.Write("\t\tMoved up from diagonal {0} at ({1},{2}) to ", k - 1, x, (x - (k - 1 + delta)));
                    }
                    y = x - (k + delta);

                    int endX = x;
                    int endY = y;

                    Log.WriteLine("({0},{1})", x, y);
                    while (x > 0 && y > 0 && A[startA + x - 1] == B[startB + y - 1])
                    {
                        x -= 1;
                        y -= 1;
                    }

                    Log.WriteLine("\t\tFollowed snake to ({0},{1})", x, y);
                    reverseDiagonal[kIndex] = x;

                    if (deltaEven && k + delta >= -D && k + delta <= D)
                    {
                        int forKIndex = (k + delta) + HALF;
                        int forX = forwardDiagonal[forKIndex];
                        int forY = forX - (k + delta);
                        if (forX >= x && forY >= y)
                        {
                            return new EditLengthResult
                            {
                                EditLength = 2*D,
                                StartX = x + startA,
                                StartY = y + startB,
                                EndX = endX + startA,
                                EndY = endY + startB,
                                LastEdit = lastEdit
                            };
                        }
                    }
                }
            }

            throw new Exception("Should never get here");
        }

        protected static void BuildModificationData(ModificationData A, ModificationData B)
        {
            int N = A.HashedPieces.Length;
            int M = B.HashedPieces.Length;
            int MAX = M + N + 1;
            var forwardDiagonal = new int[MAX + 1];
            var reverseDiagonal = new int[MAX + 1];
            BuildModificationData(A, 0, N, B, 0, M, forwardDiagonal, reverseDiagonal);
        }

        private static void BuildModificationData
            (ModificationData A,
             int startA,
             int endA,
             ModificationData B,
             int startB,
             int endB,
             int[] forwardDiagonal,
             int[] reverseDiagonal)
        {
            while (startA < endA && startB < endB && A.HashedPieces[startA].Equals(B.HashedPieces[startB]))
            {
                startA++;
                startB++;
            }
            while (startA < endA && startB < endB && A.HashedPieces[endA - 1].Equals(B.HashedPieces[endB - 1]))
            {
                endA--;
                endB--;
            }

            int aLength = endA - startA;
            int bLength = endB - startB;
            if (aLength > 0 && bLength > 0)
            {
                EditLengthResult res = CalculateEditLength(A.HashedPieces, startA, endA, B.HashedPieces, startB, endB, forwardDiagonal, reverseDiagonal);
                if (res.EditLength <= 0) return;

                if (res.LastEdit == Edit.DeleteRight && res.StartX - 1 > startA)
                    A.Modifications[--res.StartX] = true;
                else if (res.LastEdit == Edit.InsertDown && res.StartY - 1 > startB)
                    B.Modifications[--res.StartY] = true;
                else if (res.LastEdit == Edit.DeleteLeft && res.EndX < endA)
                    A.Modifications[res.EndX++] = true;
                else if (res.LastEdit == Edit.InsertUp && res.EndY < endB)
                    B.Modifications[res.EndY++] = true;

                BuildModificationData(A, startA, res.StartX, B, startB, res.StartY, forwardDiagonal, reverseDiagonal);

                BuildModificationData(A, res.EndX, endA, B, res.EndY, endB, forwardDiagonal, reverseDiagonal);
            }
            else if (aLength > 0)
            {
                for (int i = startA; i < endA; i++)
                    A.Modifications[i] = true;
            }
            else if (bLength > 0)
            {
                for (int i = startB; i < endB; i++)
                    B.Modifications[i] = true;
            }
        }

        private static void BuildPieceHashes(IDictionary<string, int> pieceHash, ModificationData data, bool ignoreWhitespace, bool ignoreCase, Func<string, string[]> chunker)
        {
            var pieces = string.IsNullOrWhiteSpace(data.RawData)
                ? emptyStringArray
                : chunker(data.RawData);

            data.Pieces = pieces;
            data.HashedPieces = new int[pieces.Length];
            data.Modifications = new bool[pieces.Length];

            for (int i = 0; i < pieces.Length; i++)
            {
                string piece = pieces[i];
                if (ignoreWhitespace) piece = piece.Trim();
                if (ignoreCase) piece = piece.ToUpperInvariant();

                if (pieceHash.ContainsKey(piece))
                {
                    data.HashedPieces[i] = pieceHash[piece];
                }
                else
                {
                    data.HashedPieces[i] = pieceHash.Count;
                    pieceHash[piece] = pieceHash.Count;
                }
            }
        }
    }
}