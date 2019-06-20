using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Threading;

namespace PortAPIUI
{
    class MsBuildAnalyzer
    {



        public static List<String> GetAssemblies(string projectPath)
        {
            StreamWriter file = new StreamWriter("Blank.txt");
            file.Write("Hello");
            file.Close();
            MessageBox.Show("Analyzing...");
            List<String> assemblies = new List<string>();
            LaunchProcess lp = new LaunchProcess();
            lp.launch(projectPath);
            return assemblies;
        }
    }
        class LaunchProcess {
        Process process = new Process();
        public void launch(String projectPath) {
            //var InputPath = projectPath;
            var ourPath = Environment.GetCommandLineArgs()[0];
            var ourDirectory = System.IO.Path.GetDirectoryName(ourPath);
            var parentPath = System.IO.Directory.GetParent(ourDirectory);
            var AnalyzerPath = System.IO.Path.Combine(ourDirectory, "MSBuildAnalyzer\\MSBuildAnalyzer.exe");

            
            process.EnableRaisingEvents = true;
            process.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(process_OutputDataReceived);
            process.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(process_ErrorDataReceived);
            process.Exited += new System.EventHandler(process_Exited);

            process.StartInfo.FileName = AnalyzerPath;
            process.StartInfo.Arguments = projectPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardOutput = true;

            process.Start();
            process.BeginErrorReadLine();
            process.BeginOutputReadLine();

            //below line is optional if we want a blocking call
            //process.WaitForExit();

        }
        void process_Exited(object sender, EventArgs e)
        {
            LaunchProcess lp = new LaunchProcess();
            
            Console.WriteLine(string.Format("process exited with code {0}\n", lp.process.ExitCode.ToString()));
            StreamWriter file1 = new StreamWriter("Blank1.txt");
            file1.Write(string.Format("process exited with code {0}\n", lp.process.ExitCode.ToString()));
            file1.Close();
        }

        void process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data + "\n");
            StreamWriter file2 = new StreamWriter("Blank2.txt");
            file2.Write(e.Data );
            file2.Close();
        }

        void process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Console.WriteLine(e.Data + "\n");
           
        }

    }
        

    }

