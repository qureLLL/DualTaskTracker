using System;
using System.Windows.Forms;

namespace DualTaskTracker
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            // початкова точка входу
        }
    }
}
