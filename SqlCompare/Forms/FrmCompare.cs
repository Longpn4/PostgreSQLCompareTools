
using DiffPlex;
using Config.Model;
using Config.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static Config.BLL.Enums;

namespace SqlCompare
{
    public partial class FrmCompare : Form
    {
        public static ISideBySideDiffBuilder diffBuilder = new SideBySideDiffBuilder();
        DatabaseBLL databaseBLL = new DatabaseBLL();
        WaitWndFun waitForm = WaitWndFun.GetInstance();

        DatabaseInfo listDatabaseA = null;
        DatabaseInfo listDatabaseB = null;

        public FrmCompare(DatabaseInfo DatabaseA, DatabaseInfo DatabaseB)
        {
            InitializeComponent();

            this.listDatabaseA = DatabaseA;
            this.listDatabaseB = DatabaseB;
            waitForm.Show();
            try
            {
                btnChangePositionCompare.Enabled = false;
                btnMultiSync.Enabled = false;

                this.WindowState = FormWindowState.Maximized;

                initCombobox();
                bangCompare.MouseDown += new MouseEventHandler(this.bangCompare_MouseClick);
            }
            catch { }
            finally
            {
                waitForm.Close();
            }
        }

        private void FrmAuto_Load(object sender, EventArgs e)
        {
            //splitContainerTableCompare.SplitterDistance = 350;
            //StylesBLL.changeStyle(this.Controls);

            txtCompareOnly.Dock = System.Windows.Forms.DockStyle.Fill;
            bangResultCompareDiffence.Dock = System.Windows.Forms.DockStyle.Fill;

            bangResultCompareDiffence.Visible = false;
            txtCompareOnly.Visible = true;

            btnCompareTwoDb_Click(sender, e);
        }

        public void CompareDatabase()
        {
            btnCompareTwoDb_Click(null, null);
        }

        private void FrmAuto_SizeChanged(object sender, EventArgs e)
        {
            //splitContainerTableCompare.SplitterDistance = 350;
        }

        public void initCombobox()
        {
            Data.getBangConnection();
        }

        private void listFileDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        CheckBox ckAllToLeft = new CheckBox();
        bool addCkAllToLeft = false;
        CheckBox ckAllToRight = new CheckBox();
        bool addCkAllToRight = false;

        public void addCheckBoxAll()
        {
            if (bangCompare.Rows.Count > 0)
            {
                Rectangle rect = bangCompare.GetCellDisplayRectangle((int)ColumnCompare.CkSyncToRight, -1, true);//0 Column index -1(header row) is row index

                //Mention size of the checkbox
                ckAllToRight.Size = new Size(18, 18);
                //set position of header checkbox where to places

                //rect.Offset(0, 0);
                ckAllToRight.Location = rect.Location;
                ckAllToRight.Location = new Point(ckAllToRight.Location.X + (rect.Width - ckAllToRight.Width) / 2 + 2, ckAllToRight.Location.Y + (rect.Height - ckAllToRight.Height) / 2);

                if (!addCkAllToRight)
                {
                    bangCompare.Controls.Add(ckAllToRight);
                    ckAllToRight.CheckedChanged += new EventHandler(ckAllToRight_CheckedChanged);
                    addCkAllToRight = true;
                }

                //ckAllToRight.Checked = false;
                //if (bangCompare.Rows.Count > 0)
                //{
                //    if (bangCompare.Rows.Cast<DataGridViewRow>().Any(r => r.Cells[(int)ColumnCompare.CkSyncToRight].Value != null &&
                //     !string.IsNullOrWhiteSpace(r.Cells[(int)ColumnCompare.CkSyncToRight].Value.ToString())))
                //    {
                //        ckAllToRight.Checked = true;
                //    }
                //}

                rect = bangCompare.GetCellDisplayRectangle((int)ColumnCompare.CkSyncToLeft, -1, true);//0 Column index -1(header row) is row index

                //Mention size of the checkbox
                ckAllToLeft.Size = new Size(18, 18);
                //set position of header checkbox where to places

                //rect.Offset(0, 0);
                ckAllToLeft.Location = rect.Location;
                ckAllToLeft.Location = new Point(ckAllToLeft.Location.X + (rect.Width - ckAllToLeft.Width) / 2 + 2, ckAllToLeft.Location.Y + (rect.Height - ckAllToLeft.Height) / 2);

                if (!addCkAllToLeft)
                {
                    bangCompare.Controls.Add(ckAllToLeft);
                    ckAllToLeft.CheckedChanged += new EventHandler(ckAllToLeft_CheckedChanged);
                    addCkAllToLeft = true;
                }

                ckAllToLeft.Checked = false;
                //if (bangCompare.Rows.Count > 0)
                //{
                //    if (bangCompare.Rows.Cast<DataGridViewRow>().Any(r => r.Cells[(int)ColumnCompare.CkSyncToLeft].Value != null &&
                //     !string.IsNullOrWhiteSpace(r.Cells[(int)ColumnCompare.CkSyncToLeft].Value.ToString())))
                //    {
                //        ckAllToLeft.Checked = true;
                //    }
                //}

                ckAllToLeft.Visible = true;
                ckAllToRight.Visible = true;
            }
            else
            {
                ckAllToLeft.Visible = false;
                ckAllToRight.Visible = false;
            }
        }

        void ckAllToLeft_CheckedChanged(object sender, EventArgs e)
        {
            var check = this.ckAllToLeft.Checked;
            for (int i = 0; i < this.bangCompare.Rows.Count; i++)
            {
                if (bangCompare.Rows[i].Cells[(int)ColumnCompare.CkSyncToLeft].Value != null
                        && !string.IsNullOrWhiteSpace(bangCompare.Rows[i].Cells[(int)ColumnCompare.CkSyncToLeft].Value.ToString()))
                {
                    this.bangCompare.Rows[i].Cells[(int)ColumnCompare.CkSyncToLeft].Value = check;
                }
            }
        }

        void ckAllToRight_CheckedChanged(object sender, EventArgs e)
        {
            var check = this.ckAllToRight.Checked;
            for (int i = 0; i < this.bangCompare.RowCount; i++)
            {
                if (bangCompare.Rows[i].Cells[(int)ColumnCompare.CkSyncToRight].Value != null
                        && !string.IsNullOrWhiteSpace(bangCompare.Rows[i].Cells[(int)ColumnCompare.CkSyncToRight].Value.ToString()))
                {
                    this.bangCompare.Rows[i].Cells[(int)ColumnCompare.CkSyncToRight].Value = check;
                }
            }
        }

        private void btnCompareTwoDb_Click(object sender, EventArgs e)
        {
            try
            {
                waitForm.Show();
                btnCompareTwoDb.Enabled = false;

                if (Constant.REFRESH_DATABASE_BEFORE_COMPARE)
                {
                    if (!listDatabaseA.Name.Contains(".txt"))
                    {
                        Data.RefreshOnlyDatabase(listDatabaseA);
                    }

                    if (!listDatabaseB.Name.Contains(".txt"))
                    {
                        Data.RefreshOnlyDatabase(listDatabaseB);
                    }
                }

                Common.CompareTwoDatabase(bangCompare, listDatabaseA, listDatabaseB);

                if (bangCompare.Rows.Count == 0)
                {
                    MessageBox.Show("2 Database Has No Different");
                    btnChangePositionCompare.Enabled = false;
                    btnMultiSync.Enabled = false;
                }
                else
                {
                    addCheckBoxAll();
                    btnChangePositionCompare.Enabled = true;
                    btnMultiSync.Enabled = true;
                }
            }
            finally
            {
                btnCompareTwoDb.Enabled = true;
                waitForm.Close();
            }
        }

        private void splitContainer5_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (bangResultCompareDiffence.Columns.Count > 0)
            {
                var totalWidth = bangCompare.Columns[(int)ColumnCompare.SyncToRight].Width + bangCompare.Columns[(int)ColumnCompare.SyncToLeft].Width +
                bangCompare.Columns[(int)ColumnCompare.CkSyncToRight].Width + bangCompare.Columns[(int)ColumnCompare.CkSyncToLeft].Width;
                bangCompare.Columns[listDatabaseA.Name].Width = (bangCompare.Width - totalWidth) / 2;
                bangCompare.Columns[listDatabaseB.Name].Width = (bangCompare.Width - totalWidth) / 2;
            }

            addCheckBoxAll();
        }


        public string getStringObject(object obj)
        {
            if (obj == null) return string.Empty;
            return obj.ToString();
        }

        private void btnChangePositionCompare_Click(object sender, EventArgs e)
        {
            btnChangePositionCompare.Enabled = false;
            try
            {
                waitForm.Show();
                if (listDatabaseA != null && listDatabaseB != null)
                {
                    DatabaseInfo temp = listDatabaseA;
                    listDatabaseA = listDatabaseB;
                    listDatabaseB = temp;

                    bool ckLeft = ckAllToLeft.Checked;
                    ckAllToLeft.Checked = ckAllToRight.Checked;
                    ckAllToRight.Checked = ckLeft;

                    Common.CompareTwoDatabase(bangCompare, listDatabaseA, listDatabaseB);
                }
            }
            catch { }
            finally
            {
                waitForm.Close();
                btnChangePositionCompare.Enabled = true;
            }
        }

        private void bangCompareLeft_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tabControlCompare.SelectedTab = tabPageCompareDetail;

                int dong = e.RowIndex;
                if (dong < 0)
                {
                    return;
                }

                if (listDatabaseA != null && listDatabaseB != null)
                {
                    var nameA = getStringObject(bangCompare.Rows[dong].Cells[(int)ColumnCompare.NameOfDatabaseA].Value);
                    var nameB = getStringObject(bangCompare.Rows[dong].Cells[(int)ColumnCompare.NameOfDatabaseB].Value);
                    var type = getStringObject(bangCompare.Rows[dong].Cells[(int)ColumnCompare.Type].Value);
                    var codeA = getStringObject(bangCompare.Rows[dong].Cells[(int)ColumnCompare.CodeA].Value);
                    var codeB = getStringObject(bangCompare.Rows[dong].Cells[(int)ColumnCompare.CodeB].Value);

                    if (!string.IsNullOrWhiteSpace(codeA) && !string.IsNullOrWhiteSpace(codeB))
                    {
                        txtCompareOnly.Visible = false;
                        bangResultCompareDiffence.Visible = true;
                        Common.Compare(bangResultCompareDiffence, codeA, codeB, listDatabaseA.Name + " - " + nameA, listDatabaseB.Name + " - " + nameB);
                    }
                    else
                    {
                        txtCompareOnly.Visible = true;
                        bangResultCompareDiffence.Visible = false;

                        txtCompareOnly.Text = !string.IsNullOrWhiteSpace(codeA) ? codeA : codeB;
                    }
                }

                if (e.ColumnIndex == bangCompare.Columns[(int)ColumnCompare.CkSyncToRight].Index)
                {
                    var CkSyncToRight = false;
                    if (bangCompare.Rows[dong].Cells[(int)ColumnCompare.CkSyncToRight].Value != null && !string.IsNullOrWhiteSpace(bangCompare.Rows[dong].Cells[(int)ColumnCompare.CkSyncToRight].Value.ToString()))
                    {
                        bangCompare.Rows[dong].Cells[(int)ColumnCompare.CkSyncToRight].Value = !(bool)bangCompare.Rows[dong].Cells[(int)ColumnCompare.CkSyncToRight].Value;
                        CkSyncToRight = (bool)bangCompare.Rows[dong].Cells[(int)ColumnCompare.CkSyncToRight].Value;
                    }

                    var CkSyncToLeft = false;
                    if (bangCompare.Rows[dong].Cells[(int)ColumnCompare.CkSyncToLeft].Value != null && !string.IsNullOrWhiteSpace(bangCompare.Rows[dong].Cells[(int)ColumnCompare.CkSyncToLeft].Value.ToString()))
                    {
                        CkSyncToLeft = (bool)bangCompare.Rows[dong].Cells[(int)ColumnCompare.CkSyncToLeft].Value;
                    }

                    if (CkSyncToRight && CkSyncToLeft)
                    {
                        bangCompare.Rows[dong].Cells[(int)ColumnCompare.CkSyncToLeft].Value = false;
                    }
                }

                if (e.ColumnIndex == bangCompare.Columns[(int)ColumnCompare.CkSyncToLeft].Index)
                {
                    var CkSyncToRight = false;
                    if (bangCompare.Rows[dong].Cells[(int)ColumnCompare.CkSyncToRight].Value != null && !string.IsNullOrWhiteSpace(bangCompare.Rows[dong].Cells[(int)ColumnCompare.CkSyncToRight].Value.ToString()))
                    {
                        CkSyncToRight = (bool)bangCompare.Rows[dong].Cells[(int)ColumnCompare.CkSyncToRight].Value;
                    }

                    var CkSyncToLeft = false;
                    if (bangCompare.Rows[dong].Cells[(int)ColumnCompare.CkSyncToLeft].Value != null && !string.IsNullOrWhiteSpace(bangCompare.Rows[dong].Cells[(int)ColumnCompare.CkSyncToLeft].Value.ToString()))
                    {
                        bangCompare.Rows[dong].Cells[(int)ColumnCompare.CkSyncToLeft].Value = !(bool)bangCompare.Rows[dong].Cells[(int)ColumnCompare.CkSyncToLeft].Value;
                        CkSyncToLeft = (bool)bangCompare.Rows[dong].Cells[(int)ColumnCompare.CkSyncToLeft].Value;
                    }

                    if (CkSyncToRight && CkSyncToLeft)
                    {
                        bangCompare.Rows[dong].Cells[(int)ColumnCompare.CkSyncToRight].Value = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void bangCompareLeft_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int dong = e.RowIndex;
                if (dong < 0)
                {
                    return;
                }

                var nameA = bangCompare.Rows[dong].Cells[listDatabaseA.Name].Value.ToString();
                var nameB = bangCompare.Rows[dong].Cells[listDatabaseB.Name].Value.ToString();

                if (listDatabaseA != null && listDatabaseB != null)
                {
                    if (e.ColumnIndex == bangCompare.Columns["SyncToRight"].Index)
                    {
                        if (!string.IsNullOrWhiteSpace(bangCompare.Rows[dong].Cells["SyncToRight"].Value.ToString()) &&
                            bangCompare.Rows[dong].Cells["SyncToRight"].Value.ToString() == "=>")
                        {
                            string confirm = string.Format("Xác nhận đồng bộ \"{2}\" từ {0} sang {1}?", listDatabaseA.Name, listDatabaseB.Name, nameA);
                            if (DialogResult.OK == MessageBox.Show(confirm, "Sync Database", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                            {
                                string Code = bangCompare.Rows[dong].Cells["CodeA"].Value.ToString();
                                string ConnectionTo = listDatabaseB.Connection;
                                try
                                {
                                    waitForm.Show();
                                    ResultExecute result = new ResultExecute(Code, ConnectionTo, "Sync");
                                    databaseBLL.ExecuteSql(result);
                                    if (!result.Result)
                                    {
                                        MessageBox.Show(result.Message);
                                        return;
                                    }

                                    var dbInfo = Data.listDbInfo.SingleOrDefault(s => s.Name == listDatabaseB.Name);
                                    if (dbInfo != null)
                                    {
                                        Data.RefreshOnlyDatabase(dbInfo);
                                        listDatabaseB = dbInfo;
                                    }

                                    Common.CompareTwoDatabase(bangCompare, listDatabaseA, listDatabaseB);
                                    waitForm.Close();
                                    MessageBox.Show("Đồng bộ thành công");
                                }
                                catch (Exception ex)
                                {
                                    waitForm.Close();
                                    MessageBox.Show(ex.ToString());
                                }
                            }
                        }
                    }

                    if (e.ColumnIndex == bangCompare.Columns["SyncToLeft"].Index)
                    {
                        if (!string.IsNullOrWhiteSpace(bangCompare.Rows[dong].Cells["SyncToLeft"].Value.ToString()) &&
                            bangCompare.Rows[dong].Cells["SyncToLeft"].Value.ToString() == "<=")
                        {
                            string confirm = string.Format("Xác nhận đồng bộ \"{2}\" từ {0} sang {1}?", listDatabaseB.Name, listDatabaseA.Name, nameB);
                            if (DialogResult.OK == MessageBox.Show(confirm, "Sync Database", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                            {
                                waitForm.Show();
                                string Code = bangCompare.Rows[dong].Cells["CodeB"].Value.ToString();
                                string ConnectionTo = listDatabaseA.Connection;
                                try
                                {
                                    ResultExecute result = new ResultExecute(Code, ConnectionTo, "Sync");
                                    databaseBLL.ExecuteSql(result);
                                    if (!result.Result)
                                    {
                                        MessageBox.Show(result.Message);
                                        return;
                                    }

                                    var dbInfo = Data.listDbInfo.SingleOrDefault(s => s.Name == listDatabaseA.Name);
                                    if (dbInfo != null)
                                    {
                                        Data.RefreshOnlyDatabase(dbInfo);
                                        listDatabaseA = dbInfo;
                                    }

                                    Common.CompareTwoDatabase(bangCompare, listDatabaseA, listDatabaseB);
                                    waitForm.Close();
                                    MessageBox.Show("Đồng bộ thành công");
                                }
                                catch (Exception ex)
                                {
                                    waitForm.Close();
                                    MessageBox.Show(ex.ToString());
                                }
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void btnMultiSync_Click(object sender, EventArgs e)
        {
            try
            {
                btnMultiSync.Enabled = false;
                string confirm = string.Format("Xác nhận đồng bộ các function, table được chọn?");
                if (DialogResult.OK == MessageBox.Show(confirm, "Sync Database", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                {
                    waitForm.Show();
                    List<string> listQueryToA = new List<string>();
                    List<string> listQueryToB = new List<string>();
                    List<ResultExecute> listResultExecuteToA = new List<ResultExecute>();
                    List<ResultExecute> listResultExecuteToB = new List<ResultExecute>();
                    for (int i = 0; i < bangCompare.Rows.Count; i++)
                    {
                        var CkSyncToRight = false;
                        if (bangCompare.Rows[i].Cells[(int)ColumnCompare.CkSyncToRight].Value != null
                            && !string.IsNullOrWhiteSpace(bangCompare.Rows[i].Cells[(int)ColumnCompare.CkSyncToRight].Value.ToString()))
                        {
                            CkSyncToRight = (bool)bangCompare.Rows[i].Cells[(int)ColumnCompare.CkSyncToRight].Value;
                        }

                        var CkSyncToLeft = false;
                        if (bangCompare.Rows[i].Cells[(int)ColumnCompare.CkSyncToLeft].Value != null
                            && !string.IsNullOrWhiteSpace(bangCompare.Rows[i].Cells[(int)ColumnCompare.CkSyncToLeft].Value.ToString()))
                        {
                            CkSyncToLeft = (bool)bangCompare.Rows[i].Cells[(int)ColumnCompare.CkSyncToLeft].Value;
                        }

                        if (CkSyncToRight && CkSyncToLeft) continue;

                        if (CkSyncToRight)
                        {
                            //listQueryToB.Add(bangCompare.Rows[i].Cells["CodeA"].Value.ToString());
                            listResultExecuteToB.Add(new ResultExecute()
                            {
                                Query = bangCompare.Rows[i].Cells[(int)ColumnCompare.CodeA].Value.ToString(),
                                Connection = listDatabaseB.Connection,
                                Description = "Sync " + Common.GetTypeCompare((int)bangCompare.Rows[i].Cells[(int)ColumnCompare.Type].Value) + " " + bangCompare.Rows[i].Cells[(int)ColumnCompare.NameOfDatabaseA].Value.ToString() + " From " + listDatabaseA.Name + " To " + listDatabaseB.Name
                            });
                        }
                        else if (CkSyncToLeft)
                        {
                            listResultExecuteToA.Add(new ResultExecute()
                            {
                                Query = bangCompare.Rows[i].Cells[(int)ColumnCompare.CodeB].Value.ToString(),
                                Connection = listDatabaseA.Connection,
                                Description = "Sync " + Common.GetTypeCompare((int)bangCompare.Rows[i].Cells[(int)ColumnCompare.Type].Value) + " " + bangCompare.Rows[i].Cells[(int)ColumnCompare.NameOfDatabaseB].Value.ToString() + " From " + listDatabaseB.Name + " To " + listDatabaseA.Name
                            });

                            //listQueryToA.Add(bangCompare.Rows[i].Cells["CodeB"].Value.ToString());
                        }
                    }

                    StringBuilder builder = new StringBuilder();
                    int numberSuccess = 0;
                    int total = listResultExecuteToB.Count + listResultExecuteToA.Count;
                    if (listResultExecuteToB.Count > 0)
                    {
                        databaseBLL.ExecuteMultiSql(listResultExecuteToB, listDatabaseB.Connection);
                        var dbInfo = Data.listDbInfo.Single(s => s.Name == listDatabaseB.Name);
                        Data.RefreshOnlyDatabase(dbInfo);
                        listDatabaseB = dbInfo;
                        showResultSync(listResultExecuteToB, builder);
                        numberSuccess += listResultExecuteToB.Where(s => s.Result == true).Count();
                    }

                    if (listResultExecuteToA.Count > 0)
                    {
                        databaseBLL.ExecuteMultiSql(listResultExecuteToA, listDatabaseA.Connection);
                        var dbInfo = Data.listDbInfo.Single(s => s.Name == listDatabaseA.Name);
                        Data.RefreshOnlyDatabase(dbInfo);
                        listDatabaseA = dbInfo;
                        showResultSync(listResultExecuteToA, builder);
                        numberSuccess += listResultExecuteToA.Where(s => s.Result == true).Count();
                    }

                    txtSyncResult.Text = builder.ToString();
                    tabControlCompare.SelectedTab = tabPageSyncResult;
                    Common.CompareTwoDatabase(bangCompare, listDatabaseA, listDatabaseB);
                    MessageBox.Show("Sync Success " + numberSuccess + "/" + total + " Records");
                }
            }
            finally
            {
                btnMultiSync.Enabled = true;
                waitForm.Close();
            }
        }

        public void showResultSync(List<ResultExecute> listResultExecute, StringBuilder builder)
        {
            foreach (var Execute in listResultExecute)
            {
                //if (listResultExecute.Count > 10)
                //{
                //if (Execute.Result)
                //{
                //    continue;
                //}
                //}

                builder.AppendLine("Content: " + Execute.Description);
                builder.AppendLine("Result: " + Execute.Result);
                if (!Execute.Result)
                {
                    builder.AppendLine("Error: " + Execute.Message);
                }

                builder.AppendLine("-------------------------------------------------------------------");
            }
        }

        private void btnMenu_DbManager_Click(object sender, EventArgs e)
        {
            //FrmDatabaseManager.GetInstance().ShowDialog();
        }

        private void btnMenu_BackupManager_Click(object sender, EventArgs e)
        {
            // FrmBackupManager.GetInstance().ShowDialog();
        }

        private void btnMenu_Search_Click(object sender, EventArgs e)
        {
            //Forms.FrmSearchInfo.GetInstance().ShowDialog();
        }

        private void supportSqlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Forms.FrmGenerateSql.GetInstance().ShowDialog();
        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bangCompare_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex > -1)
            {
                bangCompare.CurrentCell = bangCompare.Rows[e.RowIndex].Cells[e.ColumnIndex];
                e.ContextMenuStrip = menuStripCompare;
            }
        }

        private void bangCompare_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (bangCompare.Rows.Count > 0 && listDatabaseA != null && listDatabaseB != null)
                {
                    var hti = bangCompare.HitTest(e.X, e.Y);
                    if (hti.RowIndex >= 0 && hti.ColumnIndex >= 0)
                    {
                        if (bangCompare.Columns[hti.ColumnIndex].Name.Equals(listDatabaseA.Name) ||
                            bangCompare.Columns[hti.ColumnIndex].Name.Equals(listDatabaseB.Name))
                        {
                            bangCompare.ClearSelection();
                            bangCompare.Rows[hti.RowIndex].Cells[hti.ColumnIndex].Selected = true;
                            bangCompare.CurrentCell = bangCompare.Rows[hti.RowIndex].Cells[hti.ColumnIndex];

                            if (!string.IsNullOrEmpty(getStringObject(bangCompare.CurrentCell.Value)))
                            {
                                menuStripCompare.Show(bangCompare, new Point(e.X, e.Y));
                                if (bangCompare.Rows[hti.RowIndex].Cells[(int)ColumnCompare.TypeDifferent].Value.ToString() == "1")
                                {
                                    syncColumnToolStripMenuItem.Visible = true;
                                }
                                else
                                {
                                    syncColumnToolStripMenuItem.Visible = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bangCompare.Columns[bangCompare.CurrentCell.ColumnIndex].Name.Equals(listDatabaseA.Name) ||
                bangCompare.Columns[bangCompare.CurrentCell.ColumnIndex].Name.Equals(listDatabaseB.Name))
            {
                if (DialogResult.OK == MessageBox.Show("Confirm Delete", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                {
                    var type = bangCompare.Rows[bangCompare.CurrentCell.RowIndex].Cells[(int)ColumnCompare.Type].Value;
                    ResultExecute result = new ResultExecute();
                    var NameObject = string.Empty;

                    if (bangCompare.Columns[bangCompare.CurrentCell.ColumnIndex].Name.Equals(listDatabaseA.Name))
                    {
                        result.Connection = listDatabaseA.Connection;
                        NameObject = bangCompare.Rows[bangCompare.CurrentCell.RowIndex].Cells[(int)ColumnCompare.NameOfDatabaseA].Value.ToString();
                    }
                    else if (bangCompare.Columns[bangCompare.CurrentCell.ColumnIndex].Name.Equals(listDatabaseB.Name))
                    {
                        result.Connection = listDatabaseB.Connection;
                        NameObject = bangCompare.Rows[bangCompare.CurrentCell.RowIndex].Cells[(int)ColumnCompare.NameOfDatabaseB].Value.ToString();
                    }

                    if (type.Equals(Constant.TYPE_FUNCTION))
                    {
                        result.Query = "DROP FUNCTION IF EXISTS " + NameObject;
                    }
                    else if (type.Equals(Constant.TYPE_TABLE))
                    {
                        result.Query = "DROP TABLE " + "\"" + NameObject + "\"";
                    }

                    MessageBox.Show(result.Query);

                    //databaseBLL.ExecuteSql(result);
                    //btnCompareTwoDb_Click(sender, e);
                }
            }
        }

        private void copyCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bangCompare.Columns[bangCompare.CurrentCell.ColumnIndex].Name.Equals(listDatabaseA.Name) ||
                bangCompare.Columns[bangCompare.CurrentCell.ColumnIndex].Name.Equals(listDatabaseB.Name))
            {
                var type = bangCompare.Rows[bangCompare.CurrentCell.RowIndex].Cells[(int)ColumnCompare.Type].Value;
                ResultExecute result = new ResultExecute();
                var Code = string.Empty;

                if (bangCompare.Columns[bangCompare.CurrentCell.ColumnIndex].Name.Equals(listDatabaseA.Name))
                {
                    Code = bangCompare.Rows[bangCompare.CurrentCell.RowIndex].Cells[(int)ColumnCompare.CodeA].Value.ToString();
                }
                else if (bangCompare.Columns[bangCompare.CurrentCell.ColumnIndex].Name.Equals(listDatabaseB.Name))
                {
                    Code = bangCompare.Rows[bangCompare.CurrentCell.RowIndex].Cells[(int)ColumnCompare.CodeB].Value.ToString();
                }

                Clipboard.SetText(Code);
                MessageBox.Show(Code);
            }
        }

        private void copyNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bangCompare.Columns[bangCompare.CurrentCell.ColumnIndex].Name.Equals(listDatabaseA.Name) ||
               bangCompare.Columns[bangCompare.CurrentCell.ColumnIndex].Name.Equals(listDatabaseB.Name))
            {
                var type = bangCompare.Rows[bangCompare.CurrentCell.RowIndex].Cells[(int)ColumnCompare.Type].Value;
                ResultExecute result = new ResultExecute();
                var Name = string.Empty;

                if (bangCompare.Columns[bangCompare.CurrentCell.ColumnIndex].Name.Equals(listDatabaseA.Name))
                {
                    Name = bangCompare.Rows[bangCompare.CurrentCell.RowIndex].Cells[(int)ColumnCompare.NameOfDatabaseA].Value.ToString();
                }
                else if (bangCompare.Columns[bangCompare.CurrentCell.ColumnIndex].Name.Equals(listDatabaseB.Name))
                {
                    Name = bangCompare.Rows[bangCompare.CurrentCell.RowIndex].Cells[(int)ColumnCompare.NameOfDatabaseB].Value.ToString();
                }

                Clipboard.SetText(Name);
                MessageBox.Show(Name);
            }
        }

        private void btnMenu_Config_Click(object sender, EventArgs e)
        {

        }

        private void btnMenu_Exit_Click(object sender, EventArgs e)
        {

        }

        private void bangCompare_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            //synthesizer.Volume = 100;  // 0...100
            //synthesizer.Rate = -2;     // -10...10

            //// Synchronous
            //synthesizer.Speak("Hello World");

            //// Asynchronous
            //synthesizer.SpeakAsync("Hello World");

        }

        private void syncColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bangCompare.Columns[bangCompare.CurrentCell.ColumnIndex].Name.Equals(listDatabaseA.Name) ||
               bangCompare.Columns[bangCompare.CurrentCell.ColumnIndex].Name.Equals(listDatabaseB.Name))
            {
                var type = bangCompare.Rows[bangCompare.CurrentCell.RowIndex].Cells[(int)ColumnCompare.Type].Value;
                ResultExecute result = new ResultExecute();
                var Name = string.Empty;
                StringBuilder resultCompare = new StringBuilder();

                if (bangCompare.Columns[bangCompare.CurrentCell.ColumnIndex].Name.Equals(listDatabaseA.Name))
                {
                    Name = bangCompare.Rows[bangCompare.CurrentCell.RowIndex].Cells[(int)ColumnCompare.NameOfDatabaseA].Value.ToString();
                    resultCompare = Common.CompareTable(Name, listDatabaseA, listDatabaseB, false);

                    if (!string.IsNullOrWhiteSpace(resultCompare.ToString()))
                    {
                        string description = String.Format("Sync table {0} from database \"{1}\" to \"{2}\"", Name, listDatabaseA.Name, listDatabaseB.Name);
                        FrmExecute frm = new FrmExecute(listDatabaseB, resultCompare.ToString(), description);
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Nothing to sync");
                    }
                }
                else if (bangCompare.Columns[bangCompare.CurrentCell.ColumnIndex].Name.Equals(listDatabaseB.Name))
                {
                    Name = bangCompare.Rows[bangCompare.CurrentCell.RowIndex].Cells[(int)ColumnCompare.NameOfDatabaseB].Value.ToString();
                    resultCompare = Common.CompareTable(Name, listDatabaseB, listDatabaseA, false);
                    if (!string.IsNullOrWhiteSpace(resultCompare.ToString()))
                    {
                        string description = String.Format("Sync table {0} from database \"{1}\" to \"{2}\"", Name, listDatabaseB.Name, listDatabaseA.Name);
                        FrmExecute frm = new FrmExecute(listDatabaseA, resultCompare.ToString(), description);
                        frm.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Nothing to sync");
                    }
                }
                //Clipboard.SetText(Name);
            }
        }
    }
}
