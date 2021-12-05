using Config.BLL;
using Config.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlCompare
{
    public partial class FrmGenerateSql : Form
    {
        public FrmGenerateSql()
        {
            InitializeComponent();
            //StylesBLL.changeStyle(this.Controls);
            cboDatabase.Sorted = true;
            cboBang.Sorted = true;
            cboDatabase.DisplayMember = "Name";
            cboDatabase.setDataSource(Data.listDbInfo, "Name");

            lbColumGet.Sorted = true;
            lbColumGet.SelectionMode = SelectionMode.MultiExtended;

            lbConditions.Sorted = true;
            lbConditions.SelectionMode = SelectionMode.MultiExtended;
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder();
            var table = (Table)cboBang.SelectedItem;
            if (table == null)
            {
                return;
            }

            if (ckCreateTable.Checked)
            {
                query.Append(GenerateSQL.generateCreateTable(table));
            }

            if (ckUpdateTable.Checked)
            {
                query.Append(GenerateSQL.generateUpdateTable(table));
            }

            if (ckInsertNoReturn.Checked)
            {
                query.Append(GenerateSQL.generateInsertNoReturn(table));
            }

            if (ckInsertReturnId.Checked)
            {
                query.Append(GenerateSQL.generateInsertReturnId(table));
            }

            if (ckDelete.Checked)
            {
                query.Append(GenerateSQL.generateDeleteById(table));
            }

            if (ckGetListCondition.Checked)
            {
                query.Append(GenerateSQL.generateGetListCondition(table, ckPaging.Checked, lbConditions, lbColumGet));
            }

            if (ckCount.Checked)
            {
                query.Append(GenerateSQL.generateGetCount(table, ckOrCondition.Checked, lbConditions));
            }

            txtGenerateSql.Text = query.ToString();
        }

        private void ckSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            var checkSelect = ckSelectAll.Checked;
            ckCreateTable.Checked = checkSelect;
            ckUpdateTable.Checked = checkSelect;
            ckInsertReturnId.Checked = checkSelect;
            ckInsertNoReturn.Checked = checkSelect;
            ckDelete.Checked = checkSelect;
            ckGetListCondition.Checked = checkSelect;
            ckCount.Checked = checkSelect;
        }

        private void FrmGenerateSql_Load(object sender, EventArgs e)
        {

        }

        private void cboBang_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbColumGet.Items.Clear();
            lbConditions.Items.Clear();

            var table = (Table)cboBang.SelectedItem;
            if (table != null)
            {
                table.ListColumn.ForEach(s =>
                {
                    lbColumGet.Items.Add(s);
                    lbConditions.Items.Add(s);
                    lbColumGet.DisplayMember = "ColumnName";
                    lbConditions.DisplayMember = "ColumnName";
                });
            }
        }

        private void cboDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            var database = (DatabaseInfo)cboDatabase.SelectedItem;
            if (database != null)
            {
                cboBang.DataSource = database.ListTable;
                cboBang.DisplayMember = "TableName";
                cboBang.ValueMember = "TableName";
            }
        }
    }
}
