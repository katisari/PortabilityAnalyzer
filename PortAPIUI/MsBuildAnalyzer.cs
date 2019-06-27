 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Threading;

namespace PortAPIUI
{
    public static class Rebuild
    {
<<<<<<< HEAD
        private static StringBuilder o = null;
=======
        private static StringBuilder outputConsole = null;
>>>>>>> 331be255e0deddbcf29e011029527a048a52f71a
        public static List<string> ChosenBuild(String path)
        {
            var ourPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            var ourDirectory = System.IO.Path.GetDirectoryName(ourPath);
            var AnalyzerPath = System.IO.Path.Combine(ourDirectory, "MSBuildAnalyzer\\BuildProj.exe");
            Process process = new Process();
            process.StartInfo.FileName = AnalyzerPath;
            process.StartInfo.Arguments = $"{path} {MainViewModel._selectedConfig} {MainViewModel._selectedPlatform}";
<<<<<<< HEAD
            // Set UseShellExecute to false for redirection.
=======
>>>>>>> 331be255e0deddbcf29e011029527a048a52f71a
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            outputConsole = new StringBuilder();
            process.OutputDataReceived += OutputHandler;
            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();
            process.Close();
            List<string> assemblies = new List<string>();
<<<<<<< HEAD
            var name = o.ToString();
            var sec = name.Split(" **");
            for (int i = 1; i < sec.Length; i++)
=======
            var splitAssembly = outputConsole.ToString().Split(" **");
            for (int i = 1; i < splitAssembly.Length; i++)
>>>>>>> 331be255e0deddbcf29e011029527a048a52f71a
            {
                assemblies.Add(splitAssembly[i]);
            }
            return assemblies;
        }
        private static void OutputHandler(object sendingProcess, DataReceivedEventArgs line)
        {
            if (!String.IsNullOrEmpty(line.Data))
            {
                outputConsole.Append(line.Data);
            }
        }
    }
    public class info
    {
        public List<string> Configuration { get; set; }
        public List<string> Platform { get; set; }
        public List<string> Assembly { get; set; }
        public info(List<string> configuration, List<string> platform, List<string> assembly)
        {
<<<<<<< HEAD
            Config = config;
            Plat = plat;
            Asse = asse;
        }
    }


=======
            Configuration = configuration;
            Platform = platform;
            Assembly = assembly;
        }
    }
>>>>>>> 331be255e0deddbcf29e011029527a048a52f71a
    class MsBuildAnalyzer
    {
        private static StringBuilder output = null;
        public static PortAPIUI.info GetAssemblies(string path)
        {
            var ourPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            var ourDirectory = System.IO.Path.GetDirectoryName(ourPath);
            var AnalyzerPath = System.IO.Path.Combine(ourDirectory, "MSBuildAnalyzer\\BuildProj.exe");
            Process process = new Process();
            process.StartInfo.FileName = AnalyzerPath;
            process.StartInfo.Arguments = path;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            output = new StringBuilder();
            process.OutputDataReceived += SortOutputHandler;
            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();
            process.Close();
<<<<<<< HEAD

            //output has all info

            var f = output.ToString();
            var start = f.IndexOf("Plat:");
            var end = f.IndexOf("Assem:");
            var c = f.Substring(f.IndexOf("Config:"), start);
            var co = c.Split(" **");
            List<string> config = new List<string>();
            for (int i = 1; i < co.Length; i++)
=======
            var ConsoleOutput = output.ToString();
            var start = ConsoleOutput.IndexOf("Plat:");
            var end = ConsoleOutput.IndexOf("Assembly:");
            var _configurations = ConsoleOutput.Substring(ConsoleOutput.IndexOf("Config:"), start).Split(" **");
            List<string> config = new List<string>();
            for (int i = 1; i < _configurations.Length; i++)
>>>>>>> 331be255e0deddbcf29e011029527a048a52f71a
            {
                config.Add(_configurations[i]);
            }
<<<<<<< HEAD
            var p = f.Substring(start, end - start);
            var po = p.Split(" **");
=======
            var _platforms = ConsoleOutput.Substring(start, end - start).Split(" **");
>>>>>>> 331be255e0deddbcf29e011029527a048a52f71a
            List<string> plat = new List<string>();
            for (int i = 1; i < _platforms.Length; i++)
            {
                plat.Add(_platforms[i]);
            }
            var _assemblies = ConsoleOutput.Substring(end).Split(" **");
            List<string> assem = new List<string>();
            for (int i = 1; i < _assemblies.Length; i++)
            {
                assem.Add(_assemblies[i]);
            }
            PortAPIUI.info info = new PortAPIUI.info(config, plat, assem);
<<<<<<< HEAD

=======
>>>>>>> 331be255e0deddbcf29e011029527a048a52f71a
            return info;
        }
        private static void SortOutputHandler(object sendingProcess,
            DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                output.Append(outLine.Data);
            }
        }
    }
}
