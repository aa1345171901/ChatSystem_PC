// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace QQ_piracy
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    /// <summary>
    /// 程序的入口
    /// </summary>
    public static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool FlashWindow(IntPtr hWnd, bool bInvert);
        [DllImport("user32.dll")]

        private static extern bool FlashWindowEx(int pfwi);

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool runone;
            // 只能有一个实例
            System.Threading.Mutex run = new System.Threading.Mutex(true, "chat_system", out runone);
            if (runone)
            {
                run.ReleaseMutex();
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                ManagerController manager = new ManagerController();
                LoginForm loginForm = new LoginForm();
                int hdc = loginForm.Handle.ToInt32(); // write to ...
                Application.Run(loginForm);
                IntPtr a = new IntPtr(hdc);
            }
        }
    }
}
