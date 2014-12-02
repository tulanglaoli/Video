using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DotNet.Utilities
{
    public class ShowException
    {
        public static void ShowtheException(string messagetype,Exception e)
        {
            MessageBox.Show(e.ToString());
            AppLogs.AppExceptionLog.Instance.WriteExceptionLog("./", messagetype, messagetype, e);
        }

        public static void ShowtheExceptionNoMessage(string messagetype, Exception e)
        {
           
            AppLogs.AppExceptionLog.Instance.WriteExceptionLog("./", messagetype, messagetype, e);
        }
    }
}
