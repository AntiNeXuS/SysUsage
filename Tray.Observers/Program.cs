﻿using System;
using System.Windows.Forms;
using SysUsageTrayMonitor.Resources;

namespace SysUsageTrayMonitor
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            using (var runner = new SingleRunChecker())
            {
                if (!runner.ApplicationMayRun)
                {
                    MessageBox.Show(Localization.ApplicationIsAlreadyRunning, Localization.Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var application = new SystemTrayApplication())
                {
                    Application.Run();
                }
            }            
        }
    }
}