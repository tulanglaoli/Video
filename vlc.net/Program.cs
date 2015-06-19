using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DotNet.Utilities;

namespace vlc.net
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SoftReg SR = new SoftReg();
            string key = ConfigHelper.GetConfigString("lience");
            if (key == SR.getRNum())
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else
            {
                MessageBox.Show("Lience有误！请激活！");
            }
        }
    }
}
