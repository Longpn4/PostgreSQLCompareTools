using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Config.BLL;

namespace SqlCompare
{
    public class WaitWndFun
    {
        private static bool showWaiting = false;
        private static WaitWndFun obj = null;
        public static WaitWndFun GetInstance()
        {
            if (obj == null)
            {
                obj = new WaitWndFun();
                return obj;
            }
            else
            {
                return obj;
            }
        }

        Thread loadthread;
        public void Show()
        {
            if (!showWaiting)
            {
                showWaiting = true;
                loadthread = new Thread(new ThreadStart(LoadingProcessEx));
                loadthread.Start();
            }
        }

        public void Close()
        {
            if (showWaiting)
            {
                showWaiting = false;
                FrmWaiting3.GetInstance().Invoke(f => f.Hide());
                loadthread = null;
            }
        }

        private void LoadingProcessEx()
        {
            FrmWaiting3.GetInstance().ShowDialog();
        }
    }
}
