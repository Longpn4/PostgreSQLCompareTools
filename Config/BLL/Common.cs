using Config.Model;
using DiffPlex;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Config.BLL.Enums;

namespace Config.BLL
{
    public static class Common
    {
        static ISideBySideDiffBuilder diffBuilder = new SideBySideDiffBuilder();
        public static string getStringObject(object value)
        {
            if (value == null)
            {
                return string.Empty;
            }

            return value.ToString();
        }

        public static bool CheckCompare(string A, string B)
        {
            if (string.IsNullOrWhiteSpace(A) || string.IsNullOrWhiteSpace(B))
            {
                return false;
            }

            var diff = diffBuilder.BuildDiffModel(A.Trim(), B.Trim());

            if (diff.NewText.Lines.Exists(s => s.Type != ChangeType.Unchanged) || diff.OldText.Lines.Exists(s => s.Type != ChangeType.Unchanged))
            {
                return false;
            }

            return true;
        }

        public static void CompareTwoDatabase(DataGridView bangCompare, DatabaseInfo listDatabaseA, DatabaseInfo listDatabaseB)
        {
            bangCompare.RowHeadersVisible = false;
            bangCompare.Rows.Clear();
            bangCompare.Columns.Clear();

            bangCompare.Columns.Add(listDatabaseA.Name, listDatabaseA.Name);
            bangCompare.Columns.Add("CkSyncRight", "");
            bangCompare.Columns.Add("SyncToRight", "");
            bangCompare.Columns.Add("SyncToLeft", "");
            bangCompare.Columns.Add("CkSyncLeft", "");
            bangCompare.Columns.Add(listDatabaseB.Name, listDatabaseB.Name);
            bangCompare.Columns.Add("Type", "Type");
            bangCompare.Columns.Add("CodeA", "CodeA");
            bangCompare.Columns.Add("CodeB", "CodeB");
            bangCompare.Columns.Add("TypeDifferent", "TypeDifferent");

            bangCompare.Columns["Type"].Visible = false;
            bangCompare.Columns["CodeA"].Visible = false;
            bangCompare.Columns["CodeB"].Visible = false;
            bangCompare.Columns["TypeDifferent"].Visible = false;

            bangCompare.Columns[(int)ColumnCompare.SyncToRight].Width = 40;
            bangCompare.Columns[(int)ColumnCompare.SyncToLeft].Width = 40;
            bangCompare.Columns[(int)ColumnCompare.CkSyncToRight].Width = 40;
            bangCompare.Columns[(int)ColumnCompare.CkSyncToLeft].Width = 40;

            bangCompare.Columns[(int)ColumnCompare.SyncToRight].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            bangCompare.Columns[(int)ColumnCompare.SyncToLeft].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            bangCompare.Columns[(int)ColumnCompare.CkSyncToRight].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            bangCompare.Columns[(int)ColumnCompare.CkSyncToLeft].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            bangCompare.Columns[(int)ColumnCompare.SyncToRight].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bangCompare.Columns[(int)ColumnCompare.SyncToLeft].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bangCompare.Columns[(int)ColumnCompare.CkSyncToRight].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bangCompare.Columns[(int)ColumnCompare.CkSyncToLeft].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            var totalWidth = bangCompare.Columns[(int)ColumnCompare.SyncToRight].Width + bangCompare.Columns[(int)ColumnCompare.SyncToLeft].Width +
                bangCompare.Columns[(int)ColumnCompare.CkSyncToRight].Width + bangCompare.Columns[(int)ColumnCompare.CkSyncToLeft].Width;
            bangCompare.Columns[listDatabaseA.Name].Width = (bangCompare.Width - totalWidth) / 2;
            bangCompare.Columns[listDatabaseB.Name].Width = (bangCompare.Width - totalWidth) / 2;

            foreach (DataGridViewColumn column in bangCompare.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            //bangCompare.CellClick += bangCompare_CellClick_Sync;

            //Lấy danh sách các function chỉ có 1 trong 2 db
            var listFunctionOnlyA = listDatabaseA.ListFunction.Where(s => !listDatabaseB.ListFunction.Exists(a => a.Name.ToLower() == s.Name.ToLower()));
            var listFunctionOnlyB = listDatabaseB.ListFunction.Where(s => !listDatabaseA.ListFunction.Exists(a => a.Name.ToLower() == s.Name.ToLower()));

            //Lấy danh sách các table chỉ có 1 trong 2 db
            var listTableOnlyA = listDatabaseA.ListTable.Where(s => !listDatabaseB.ListTable.Exists(a => a.TableName.ToLower() == s.TableName.ToLower()));
            var listTableOnlyB = listDatabaseB.ListTable.Where(s => !listDatabaseA.ListTable.Exists(a => a.TableName.ToLower() == s.TableName.ToLower()));

            //Lấy danh sách function có ở 2 bên nhưng khác nhau
            var listFunctionDifference = listDatabaseA.ListFunction.Where(s => listDatabaseB.ListFunction.Exists(a => a.Name.ToLower() == s.Name.ToLower() && !CheckCompare(a.Code.ToLower(), s.Code.ToLower())));
            var listTableDifference = listDatabaseA.ListTable.Where(s => listDatabaseB.ListTable.Exists(a => a.TableName.ToLower() == s.TableName.ToLower() && a.Code.ToLower().Trim() != s.Code.ToLower().Trim()));

            //lấy ra danh sách code table khác nhau
            foreach (var item in listTableOnlyA)
            {
                DataGridViewRow row = new DataGridViewRow();
                if (!listDatabaseB.Name.Contains(".txt"))
                {
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(106, 0, 213);
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = item.TableName.ToLower() });
                    //row.Cells.Add(new DataGridViewCheckBoxCell() { Value = true });
                    row.Cells.Add(new DataGridViewCheckBoxCell() { Value = false });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "=>" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = string.Empty });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = Constant.TYPE_TABLE });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = item.Code });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = string.Empty });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(106, 0, 213);
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = item.TableName.ToLower() });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = string.Empty });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = Constant.TYPE_TABLE });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = item.Code });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = string.Empty });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                }

                bangCompare.Rows.Add(row);
            }

            foreach (var item in listTableOnlyB)
            {
                DataGridViewRow row = new DataGridViewRow();
                if (!listDatabaseA.Name.Contains(".txt"))
                {
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(106, 0, 213);
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = string.Empty });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "<=" });
                    row.Cells.Add(new DataGridViewCheckBoxCell() { Value = false });
                    //row.Cells.Add(new DataGridViewCheckBoxCell() { Value = true });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = item.TableName.ToLower() });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = Constant.TYPE_TABLE });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = string.Empty });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = item.Code });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                }
                else
                {
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(106, 0, 213);
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = string.Empty });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = item.TableName.ToLower() });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = Constant.TYPE_TABLE });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = string.Empty });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = item.Code });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                }
                bangCompare.Rows.Add(row);
            }

            foreach (var item in listTableDifference)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.DefaultCellStyle.ForeColor = Color.Red;
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = item.TableName.ToLower() });

                //if (!listDatabaseB.Name.Contains(".txt"))
                //{
                //    row.Cells.Add(new DataGridViewCheckBoxCell() { Value = false });
                //    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "=>" });
                //}
                //else
                //{
                //    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                //    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                //}

                //if (!listDatabaseA.Name.Contains(".txt"))
                //{
                //    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "<=" });
                //    row.Cells.Add(new DataGridViewCheckBoxCell() { Value = false });
                //}
                //else
                //{
                //    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                //    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                //}

                row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });

                row.Cells.Add(new DataGridViewTextBoxCell() { Value = item.TableName.ToLower() });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = Constant.TYPE_TABLE });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = item.Code });
                var tableB = listDatabaseB.ListTable.SingleOrDefault(s => s.TableName.ToLower() == item.TableName.ToLower());
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = tableB != null ? tableB.Code : string.Empty });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = "1" });
                bangCompare.Rows.Add(row);
            }

            foreach (var item in listFunctionOnlyA)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.DefaultCellStyle.ForeColor = Color.FromArgb(106, 0, 213);

                if (!listDatabaseB.Name.Contains(".txt"))
                {
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = item.Name });
                    //row.Cells.Add(new DataGridViewCheckBoxCell() { Value = true });
                    row.Cells.Add(new DataGridViewCheckBoxCell() { Value = false });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "=>", ToolTipText = "Double click để Copy Function sang Db " + listDatabaseB.Name });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = string.Empty });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = Constant.TYPE_FUNCTION });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = item.Code });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = string.Empty });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                }
                else
                {
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = item.Name });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = string.Empty });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = Constant.TYPE_FUNCTION });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = item.Code });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = string.Empty });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                }

                bangCompare.Rows.Add(row);
            }

            foreach (var item in listFunctionOnlyB)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.DefaultCellStyle.ForeColor = Color.FromArgb(106, 0, 213);

                if (!listDatabaseA.Name.Contains(".txt"))
                {
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = string.Empty });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "<=", ToolTipText = "Copy Function " + item.Name + " to Database " + listDatabaseA.Name });
                    //row.Cells.Add(new DataGridViewCheckBoxCell() { Value = true });
                    row.Cells.Add(new DataGridViewCheckBoxCell() { Value = false });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = item.Name });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = Constant.TYPE_FUNCTION });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = string.Empty });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = item.Code });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                }
                else
                {
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = string.Empty });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = item.Name });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = Constant.TYPE_FUNCTION });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = string.Empty });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = item.Code });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                }
                bangCompare.Rows.Add(row);
            }

            foreach (var item in listFunctionDifference)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.DefaultCellStyle.ForeColor = Color.Red;

                row.Cells.Add(new DataGridViewTextBoxCell() { Value = item.Name });

                if (!listDatabaseB.Name.Contains(".txt"))
                {
                    row.Cells.Add(new DataGridViewCheckBoxCell() { Value = false });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "=>" });
                }
                else
                {
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                }

                if (!listDatabaseA.Name.Contains(".txt"))
                {
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "<=" });
                    row.Cells.Add(new DataGridViewCheckBoxCell() { Value = false });
                }
                else
                {
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });
                }

                row.Cells.Add(new DataGridViewTextBoxCell() { Value = item.Name });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = Constant.TYPE_FUNCTION });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = item.Code });
                var functionB = listDatabaseB.ListFunction.SingleOrDefault(s => s.Name == item.Name);
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = functionB != null ? functionB.Code : string.Empty });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = "" });

                bangCompare.Rows.Add(row);
            }
        }

        public static void getTableDifferentInfo(List<Table> ListTableDifferent, DatabaseInfo listDatabaseA, DatabaseInfo listDatabaseB)
        {
            foreach (var table in ListTableDifferent)
            {

            }
        }

        public static StringBuilder CompareTable(string tableName, DatabaseInfo listDatabaseA, DatabaseInfo listDatabaseB, bool twoParty = true)
        {
            var tableA = listDatabaseA.ListTable.SingleOrDefault(s => s.TableName == tableName);
            var tableB = listDatabaseB.ListTable.SingleOrDefault(s => s.TableName == tableName);
            return CompareTable(tableA, tableB, twoParty);
        }

        public static StringBuilder CompareTable(Table tableFrom, Table tableTo)
        {
            StringBuilder CodeA = new StringBuilder();
            List<string> listCode = new List<string>();

            //Lấy danh sách các Column chỉ có 1 trong 2 table
            var listColumnOnlyA = tableFrom.ListColumn.Where(s => !tableTo.ListColumn.Exists(a => a.ColumnName.ToLower() == s.ColumnName.ToLower()));
            if (listColumnOnlyA != null && listColumnOnlyA.Count() > 0)
            {
                CodeA = new StringBuilder("ALTER TABLE " + tableFrom.TableName + "\n");

                //Lọc Constraint chỉ lấy những contrain do 1 cột tạo
                var ListConstraint = tableFrom.ListConstraint.Where(s => s.Columns.Count() == 1).ToList();
                foreach (var column in listColumnOnlyA)
                {
                    //Chỉ đồng bộ các Constraint do 1 column
                    var contrain = ListConstraint.SingleOrDefault(s => s.Columns.ToLower().Contains(column.ColumnName.ToLower()));
                    listCode.Add(string.Format("ADD COLUMN {0} {1} {2}", column.ColumnName, GenerateSQL.getTypeString(column.DataType.ToLower(), column.MaxLength, column.DatetimePrecision), contrain != null ? contrain.ConstraintType : String.Empty).Trim());
                }

                if (listCode != null && listCode.Count > 0)
                {
                    CodeA.Append(string.Join(",\n", listCode));
                }

                CodeA.AppendLine(";");
            }

            //Lấy danh sách các Comment chỉ có 1 trong 2 table
            var listCommentOnlyA = tableFrom.ListComment.Where(s => !tableTo.ListComment.Exists(a => a.ColumnName.ToLower() == s.ColumnName.ToLower()));
            if (listCommentOnlyA != null && listCommentOnlyA.Count() > 0)
            {
                foreach (var comment in listCommentOnlyA)
                {
                    CodeA.AppendLine(string.Format("COMMENT ON COLUMN {0}.{1} is '{2}';", tableFrom.TableName, comment.ColumnName, comment.Description));
                }
            }

            return CodeA;
        }

        public static StringBuilder CompareTable(Table tableA, Table tableB, bool twoParty = true)
        {
            StringBuilder Result = new StringBuilder();
            StringBuilder CodeA = new StringBuilder();
            StringBuilder CodeB = new StringBuilder();

            CodeA = CompareTable(tableA, tableB);
            if (twoParty)
            {
                CodeB = CompareTable(tableB, tableA);
            }

            Result.Append(CodeA.ToString());
            Result.Append(CodeB.ToString());

            return Result;
        }

        public static void Compare(DataGridView bangCompare, string A, string B, string headerA, string headerB)
        {
            initTableCompare(bangCompare, headerA, headerB);
            var diff = diffBuilder.BuildDiffModel(A, B);

            for (int i = 0; i < diff.OldText.Lines.Count; i++)
            {
                var lineNumberA = diff.OldText.Lines[i].Position.HasValue ? diff.OldText.Lines[i].Position.ToString().Trim() : string.Empty;
                var lineTextA = diff.OldText.Lines[i].Text;

                var lineNumberB = diff.NewText.Lines[i].Position.HasValue ? diff.NewText.Lines[i].Position.ToString().Trim() : string.Empty;
                var lineTextB = diff.NewText.Lines[i].Text;

                DataGridViewRow row = new DataGridViewRow();

                DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
                cell.Value = lineNumberA;
                cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                row.Cells.Add(cell);

                row.Cells.Add(getCellInfo(diff.OldText.Lines[i].Type, diff.OldText.Lines[i].Text));

                cell = new DataGridViewTextBoxCell();
                cell.Value = lineNumberB;
                cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                row.Cells.Add(cell);

                row.Cells.Add(getCellInfo(diff.NewText.Lines[i].Type, diff.NewText.Lines[i].Text));

                bangCompare.Rows.Add(row);
            }
        }

        public static void initTableCompare(DataGridView bang, string nameA, string nameB)
        {
            bang.Rows.Clear();
            bang.Columns.Clear();

            bang.Columns.Add("STT1", string.Empty);
            bang.Columns.Add("Value1", nameA);
            bang.Columns.Add("STT2", string.Empty);
            bang.Columns.Add("Value2", nameB);

            bang.Columns[0].Width = 30;
            bang.Columns[2].Width = 30;
            var lenth = (bang.Width - bang.Columns[0].Width * 2) / 2;
            bang.Columns[1].Width = lenth;
            bang.Columns[3].Width = lenth;

            bang.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            bang.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            bang.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            bang.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;

            bang.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bang.Columns[1].HeaderCell.Style.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

            bang.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            bang.Columns[3].HeaderCell.Style.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

            bang.CellBorderStyle = DataGridViewCellBorderStyle.None;
        }

        public static DataGridViewTextBoxCell getCellInfo(ChangeType changeType, string value)
        {
            DataGridViewTextBoxCell cell = new DataGridViewTextBoxCell();
            cell.Value = value;
            //cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            if (changeType == DiffPlex.ChangeType.Deleted)
            {
                cell.Style.ForeColor = Color.Black;
                cell.Style.BackColor = Color.FromArgb(255, 200, 100);
            }
            else if (changeType == DiffPlex.ChangeType.Imaginary)
            {
                cell.Style.ForeColor = Color.Black;
                cell.Style.BackColor = Color.FromArgb(200, 200, 200);
            }
            else if (changeType == DiffPlex.ChangeType.Unchanged)
            {
                cell.Style.ForeColor = Color.Black;
            }
            else if (changeType == DiffPlex.ChangeType.Inserted)
            {
                cell.Style.ForeColor = Color.Black;
                cell.Style.BackColor = Color.FromArgb(255, 255, 0);
            }
            else if (changeType == DiffPlex.ChangeType.Modified)
            {
                cell.Style.ForeColor = Color.Black;
                cell.Style.BackColor = Color.FromArgb(220, 220, 255);
            }

            return cell;
        }

        public static string GetTypeCompare(int Type)
        {
            if (Type == Constant.TYPE_FUNCTION)
            {
                return "Function";
            }
            else return "Table";
        }

        public static void RemoveDbInfoWithName(this ListBox listBox, string dbName)
        {
            if (string.IsNullOrWhiteSpace(dbName))
            {
                return;
            }

            for (int j = 0; j < listBox.Items.Count; j++)
            {
                if (((DatabaseInfo)listBox.Items[j]).Name.ToLower() == dbName.ToLower())
                {
                    listBox.Items.Remove(listBox.Items[j]);
                    j--;
                }
            }
        }

        public static void InvokeAction(Control control, MethodInvoker action)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
