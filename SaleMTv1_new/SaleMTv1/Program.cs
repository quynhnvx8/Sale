﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SaleMTInterfaces;
using System.Reflection;
using System.Resources;
using System.Globalization;



namespace SaleMT
{
    static class Program
    {
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// \
        [STAThread]
        
        static void Main()
        {
            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmSaleMTMain(LayoutLanguage.getLanguage()));            
            //Application.Run(new SaleMTv1.Class.frmTabs());
        }

        
    }
}
