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
    class MsBuildAnalyzer
    {
        private static StringBuilder output = null;
        private static int numOutputLines = 0;
        public static List<string> GetAssemblies(string path)
        {
            // Initialize the process and its StartInfo properties.
            // The sort command is a console application that
            // reads and sorts text input.
            var ourPath = System.Reflection.Assembly.GetEntryAssembly().Location;
            var ourDirectory = System.IO.Path.GetDirectoryName(ourPath);

            var AnalyzerPath = System.IO.Path.Combine(ourDirectory, "MSBuildAnalyzer\\Libba.exe");

            Process process = new Process();
            process.StartInfo.FileName = AnalyzerPath;
            process.StartInfo.Arguments = path;
            // Set UseShellExecute to false for redirection.
            process.StartInfo.UseShellExecute = false;

            // Redirect the standard output of the sort command.  
            // This stream is read asynchronously using an event handler.
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


            List<string> a = new List<string>();
            a.Add(output.ToString());

            return a;
        }

        private static void SortOutputHandler(object sendingProcess,
            DataReceivedEventArgs outLine)
        {

            // Collect the sort command output.
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                //numOutputLines++;

                //String[] w = (outLine.Data).Split(" ");
                //// Add the text to the collected output.
            //    foreach (String s in w)
                {
                    output.Append(outLine.Data);
                }
            }
        }
    }
}


