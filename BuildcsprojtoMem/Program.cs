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

namespace MSBuildAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
            MSBuildLocator.RegisterDefaults();
           string CsProjPath = args[0];
           // string CsProjPath = @"C:\Users\t-lilawr\source\repos\pracproj\pracproj.csproj";
            temp.MyMethod(CsProjPath);
           
        }
    }
    class temp
    {
      
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

            if (project.ConditionedProperties.Keys.Contains("Configuration") && project.ConditionedProperties.Keys.Contains("Platform"))
            {
                configurations = project.ConditionedProperties["Configuration"];

                platforms = project.ConditionedProperties["Platform"];
            }
            //if (!project.Build())
            //{
            //    Console.WriteLine("Error");
            //}
            if (project.Properties.Any(n => n.Name == "TargetPath"))
            {
                var mypath = System.Reflection.Assembly.GetEntryAssembly().Location;
                var targetPath = project.GetProperty("TargetPath");
                var targetPathString = targetPath.EvaluatedValue.ToString();
                var assembly = Assembly.LoadFrom(targetPathString); //question
                List<String> dependents = new List<string>();
                foreach (AssemblyName b in assembly.GetReferencedAssemblies())
                {
                    dependents.Add(b.ToString());
                }
                Console.WriteLine(targetPathString);
            }
         
            
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


