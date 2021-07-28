using System;
using System.Threading;
using System.Windows.Forms;

namespace ExchangeParserNBU
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Global exception
            Application.ThreadException += new ThreadExceptionEventHandler(GlobalException);

            // Run Form
            Application.Run(new MainForm());
        }

        private static void GlobalException(object sender, ThreadExceptionEventArgs e)
        {
            // Global exception call MBOX with error message
            MessageBox.Show(e.Exception.Message);

            // or if needs to read whole error message
            // MessageBox.Show(e.Exception.ToString());
        }
    }
}
