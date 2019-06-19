using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Documents;

namespace PortAPIUI
{
    class ApiAnalyzer
    {
        public static void AnalyzeAssemblies(List<string> assemblies)
        {
            MessageBox.Show("Hi from Katie");
        }
//        var ourPath = Environment.GetCommandLineArgs()[0];
//        var ourDirectory = System.IO.Path.GetDirectoryName(ourPath);
//        var parentPath = System.IO.Directory.GetParent(ourDirectory);
//        //var grandma = System.IO.Directory.GetParent(parentPath);
//        //var grandparentPath = System.IO.Directory.GetParent(parentPath);
//        var apiPortPath = System.IO.Path.Combine(ourDirectory, "ApiPort", "net461", "ApiPort.exe");
//        //var apiPortPath = System.IO.Path.Combine(System.IO.Directory.GetParent(), "dotnet.exe");

//        var p = new Process();
//        p.StartInfo.FileName = apiPortPath;

//        //var reportPath = GenerateReportPath();

//        //output to Desktop

//        p.StartInfo.Arguments = $"analyze -f \"C:\\Users\\t-jaele\\Downloads\\Paint\" -o \"C:\\Users\\t-jaele\\Desktop\\ApiPortResults\" -t \".NET Core, Version=3.0\"";
//        var Hello = p.StartInfo.Arguments;
//        p.StartInfo.CreateNoWindow = true;
//        p.StartInfo.UseShellExecute = false;
//        p.StartInfo.RedirectStandardOutput = true;
//        p.EnableRaisingEvents = true;

//        List<string> msg = new List<string>();

//        p.OutputDataReceived += (s, o) =>
//        {
//            if (o.Data != null)
//            {
//                Dispatcher.Invoke(() =>
//                {
//                    msg.Add(o.Data);
//                });

//            }
//            //AnalzeBtn.IsEnabled = true;
//        };

//        p.Exited += delegate
//        {
//            Dispatcher.Invoke(() =>
//            {
               

//                string text;

//                if (msg.Count != 17) // Was not successful
//                {
//                    //OpenReportButton.Visible = false;

//                    if (msg.Count< 10) // Exception was thrown in the API console tool
//                    {
//                        text = $"Unable to analyze. The access to the specified path might be denied.";
//                    }
//                    else
//                    {
//                        text = msg.FindLast(o => !String.IsNullOrEmpty(o));
//                        text = text.Trim(new char[] { '*', ' ' });
//                        if (!text.Equals("No files were found to analyze.", StringComparison.InvariantCultureIgnoreCase))
//                        {
//                            msg.RemoveRange(0, 10);
//                            var details = String.Join(Environment.NewLine, msg.ToArray());
//text = $"Unable to analyze.{Environment.NewLine}Details:{Environment.NewLine}{details}";
//                        }
//                    }
//                }
//                else // Was successful
//                {
//                    //text = $"Report saved in: {Environment.NewLine}{reportPath}";
//                    //OpenReportButton.Visible = true;
//                }

//                //OutputTextBox.Text = text;
//                //UIline1.Visible = true;
//            });

//        };

//        p.Start();

//        //UIline1.Visible = true;
//        //OutputTextBox.Text = "Analyzing...";

//        p.BeginOutputReadLine();
    }
}
