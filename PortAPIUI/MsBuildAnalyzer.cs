using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Documents;

namespace PortAPIUI
{
    class MsBuildAnalyzer
    {
        public static List<string> GetAssemblies(string projectPath)
        {
            MessageBox.Show("Hi from Libba");
            GetConfig();
            GetPlatform();
            return new List<string>();
        }

        internal static List<string> GetConfig()
        {
            return new List<string>();
        }

        internal static List<string> GetPlatform()
        {
            return new List<string>();
        }
    }
}
