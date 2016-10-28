using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DistributedCacheWinform
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            Application.ThreadException += Application_ThreadException;////UI线程异常
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;////多线程异常
        }
         /// <summary>
        /// 多线程异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
           //可以记录日志并转向错误bug窗口友好提示用户
            Exception ex = e.ExceptionObject as Exception;
            MessageBox.Show(ex.Message);
        }
        /// <summary>
        /// UI线程异常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
//可以记录日志并转向错误bug窗口友好提示用户
            MessageBox.Show(e.Exception.Message);
         
        }
    
    }
}
