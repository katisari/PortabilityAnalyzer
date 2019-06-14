using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Construction;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using Microsoft.Build.Framework;
using Microsoft.Build.Logging;
using Microsoft.Build.Locator;
using Microsoft.Build.Utilities;
using System.Net.Http.Headers;
using System.IO;
using System.Reflection;

namespace BuildcsprojtoMem
{
    class Program
    {

        
        static void Main(string[] args)
        {
            MSBuildLocator.RegisterDefaults();
            temp.MyMethod();

        }
    }
    class temp
    {
        private static string Path = @"C:\Users\t-lilawr\source\repos\pracproj";
        private static string ProjPath = @"C:\Users\t-lilawr\source\repos\pracproj\pracproj.csproj";
        private static string LogFile = @"C:\Users\t-lilawr\source\repos\pracproj\logfile.log";
       
        public static void MyMethod()
        {
           
            var logger = new ConsoleLogger();
            Dictionary<String, String> dic = new Dictionary<string, string>
                {
                    { "Configuration", "Debug" },
                    { "Platform", "AnyCPU" }
                };
            ProjectCollection pc = new ProjectCollection(dic, new List<ILogger> { logger }, ToolsetDefinitionLocations.Default);

            var project = pc.LoadProject(ProjPath);

            if (!project.Build())
            {
                Console.WriteLine("Error");
            }

            Console.WriteLine("{0}", System.IO.Path.GetFileName(ProjPath)); //Gets a file name if you give it the path 
            string fullName = Assembly.GetEntryAssembly().Location;
            string myName = System.IO.Path.GetFileNameWithoutExtension(fullName);
            Console.WriteLine(myName);
            Console.WriteLine("Done");
            Console.ReadKey();

        }

        public void ErrorHandler(object sender, BuildErrorEventArgs args)
        {

        }
    }
    public class ConsoleLogger : ILogger
    {
        public LoggerVerbosity Verbosity { get; set; }
        public string Parameters { get; set; }

        public void Initialize(IEventSource eventSource)
        {
            eventSource.AnyEventRaised += EventSource_AnyEventRaised;
            eventSource.ErrorRaised += EventSource_ErrorRaised;
        }

        private void EventSource_AnyEventRaised(object sender, BuildEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        private void EventSource_ErrorRaised(object sender, BuildErrorEventArgs e)
        {
            
        }

        public void Shutdown()
        {
            
        }
    }
}


