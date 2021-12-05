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
    public partial class FrmWaiting3 : Form
    {
        private static FrmWaiting3 obj = null;
        public static FrmWaiting3 GetInstance()
        {
            if (obj == null)
            {
                obj = new FrmWaiting3();
                return obj;
            }
            else
            {
                return obj;
            }
        }

        public FrmWaiting3()
        {
            InitializeComponent();
        }

        private void FrmWaiting3_Load(object sender, EventArgs e)
        {

        }
    }
}
