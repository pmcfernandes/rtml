using System;
using System.Windows.Forms;

namespace TestSubscriber
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.SetCompatibleTextRenderingDefault(true);
            Application.Run(new frmMain());
        }
    }
}
