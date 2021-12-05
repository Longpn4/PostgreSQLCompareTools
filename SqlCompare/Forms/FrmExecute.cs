
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
    public partial class FrmExecute : Form
    {
        public static ISideBySideDiffBuilder diffBuilder = new SideBySideDiffBuilder();
        DatabaseBLL databaseBLL = new DatabaseBLL();
        WaitWndFun waitForm = WaitWndFun.GetInstance();
        DatabaseInfo DatabaseA = null;

        public FrmExecute(DatabaseInfo DatabaseA, string Code, string Description)
        {
            InitializeComponent();
            this.DatabaseA = DatabaseA;
            txtExecute.Text = Code;
            lblSync.Text = Description;
        }

        private void btnMultiSync_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("Confirm execute command", "Sync Table", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
            {
                ResultExecute result = new ResultExecute(txtExecute.Text, DatabaseA.Connection, "Sync Table");
                databaseBLL.ExecuteSql(result);
                if (!result.Result)
                {
                    MessageBox.Show(result.Message);
                    return;
                }

                MessageBox.Show("Execute Success!", "Execute Command", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
