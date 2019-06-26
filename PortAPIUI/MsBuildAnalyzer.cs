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
        private static StringBuilder o = null;
        public static List<string> ChosenBuild(String path) {
            var ourPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            var ourDirectory = System.IO.Path.GetDirectoryName(ourPath);
            var AnalyzerPath = System.IO.Path.Combine(ourDirectory, "MSBuildAnalyzer\\BuildProj.exe");
            Process process = new Process();
            process.StartInfo.FileName = AnalyzerPath;
            MainViewModel mv = new MainViewModel();
            process.StartInfo.Arguments = $"{path} {mv._selectedConfig} {mv._selectedPlatfrom}";  
            // Set UseShellExecute to false for redirection.
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            // Read the sort output.
            o = new StringBuilder();
            process.OutputDataReceived += OutputHandler;
            // Start the process.
            process.Start();
            // Start read of the sort output stream.
            process.BeginOutputReadLine();
            // Wait for the sort process to write the sorted text lines.
            process.WaitForExit();
            process.Close();

            List<string> assemblies = new List<string>();
            var name = o.ToString();
            var sec = name.Split(" **");
            for(int i = 1; i < sec.Length; i++)
            {
                assemblies.Add(sec[i]);
            }
            return assemblies;
        }
        private static void OutputHandler(object sendingProcess,DataReceivedEventArgs line)
        {
            if (!String.IsNullOrEmpty(line.Data))
            {
                o.Append(line.Data);
            }
        }
    }



    public class info
    {
        public List<string> Config { get; set; }
        public List<string> Plat { get; set; }
        public List<string> Asse { get; set; }
        public info(List<string> config, List<string> plat, List<string> asse)
        {
            Config = config;
            Plat = plat;
            Asse = asse; 
        }
    }

    
    class MsBuildAnalyzer
    {
        private static StringBuilder output = null;
        public static PortAPIUI.info GetAssemblies(string path)
        {
            // Initialize the process and its StartInfo properties.
            var ourPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            var ourDirectory = System.IO.Path.GetDirectoryName(ourPath);
            var AnalyzerPath = System.IO.Path.Combine(ourDirectory, "MSBuildAnalyzer\\BuildProj.exe");

            Process process = new Process();
            process.StartInfo.FileName = AnalyzerPath;
            process.StartInfo.Arguments = path;
            // Set UseShellExecute to false for redirection.
            process.StartInfo.UseShellExecute = false;

            // Redirect the standard output of the sort command.  
            process.StartInfo.RedirectStandardOutput = true;
            output = new StringBuilder();

            // Read the sort output.
            process.OutputDataReceived += SortOutputHandler;

            // Start the process.
            process.Start();

            // Start read of the sort output stream.
            process.BeginOutputReadLine();

            // Wait for the sort process to write the sorted text lines.
            process.WaitForExit();

            process.Close();

            //output has all info
            
            var f = output.ToString();
            var start = f.IndexOf("Plat:");
            var end = f.IndexOf("Assem:");
            var c = f.Substring(f.IndexOf("Config:"),start);
            var co = c.Split(" **");
            List<string> config = new List<string>();
            for(int i = 1; i < co.Length; i++)
            {
                config.Add(co[i]);
            }
            var p = f.Substring(start,end-start);
            var po = p.Split(" **");
            List<string> plat = new List<string>();
            for (int i = 1; i < po.Length; i++)
            {
                plat.Add(po[i]);
            }
            var a = f.Substring(end);
            var ao = a.Split(" **");
            List<string> assem = new List<string>();
            for (int i = 1; i < ao.Length; i++)
            {
                assem.Add(ao[i]);
            }
            PortAPIUI.info info = new PortAPIUI.info(config,plat,assem);

            return info;
        }

        private static void SortOutputHandler(object sendingProcess,
            DataReceivedEventArgs outLine)
        {
            // Collect the sort command output.
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                    output.Append(outLine.Data);
            }
        }
    }
}


