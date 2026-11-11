using System;
using System.Windows.Forms;
using DualTaskTracker.Forms;

namespace DualTaskTracker
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
