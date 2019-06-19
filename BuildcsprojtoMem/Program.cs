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
using System.Reflection;
using System.IO;
using System.Runtime.CompilerServices;
using Microsoft.Build.Tasks;

namespace BuildcsprojtoMem
{
    class Program
    {
        static void Main(string[] args)
        {
            MSBuildLocator.RegisterDefaults();
            string CsProjPath = args[0];
            temp.MyMethod(CsProjPath);
        }
    }
    class temp
    {
        private static string ProjPath = @"C:\Users\t-lilawr\source\repos\pracproj\pracproj.csproj";
        private static List<string> configurations;
        public static List<String> platforms;

        public static void MyMethod(string CsProjPath)
        {
            var logger = new ConsoleLogger();
            Dictionary<String, String> dic = new Dictionary<string, string>
                {
                    { "Configuration", "Debug" },
                    { "Platform", "AnyCPU" } 
                };
            ProjectCollection pc = new ProjectCollection(dic, new List<ILogger> { logger }, ToolsetDefinitionLocations.Default);

            var project = pc.LoadProject(CsProjPath);

            configurations = project.ConditionedProperties["Configuration"];
            platforms = project.ConditionedProperties["Platform"];

            if (!project.Build())
            {
                Console.WriteLine("Error");
            }

            var assembly = Assembly.LoadFrom(CsProjPath);
            var dependents = assembly.GetReferencedAssemblies();
           
            var name = project.GetProperty("TargetPath");
            
            Console.ReadKey();
        }

        public void ErrorHandler(object sender, BuildErrorEventArgs args)
        {}
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
        {}

        public void Shutdown()
        {}
    }
}


