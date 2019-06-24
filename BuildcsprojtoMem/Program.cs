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
using System.Diagnostics;

namespace MSBuildAnalyzer
{
    public class Program
    {
        static void Main(string[] args)
        {
            MSBuildLocator.RegisterDefaults();
            string CsProjPath = args[0];
            //string CsProjPath = @"C:\Users\t-lilawr\source\repos\pracproj\pracproj.csproj";
            temp.MyMethod(CsProjPath);
           
        }
    }
    public class temp
    {
      
        public static List<string> configurations;
        public static List<String> platforms;

        public static void MyMethod(string CsProjPath)
        {
            Dictionary<String, String> dic = new Dictionary<string, string>
                {
                    { "Configuration", "Debug" },
                    { "Platform", "AnyCPU" } 
                };
            ProjectCollection pc = new ProjectCollection(dic, null, ToolsetDefinitionLocations.Default) ;

            var project = pc.LoadProject(CsProjPath);

        //    if (project.ConditionedProperties.Keys.Contains("Configuration") && project.ConditionedProperties.Keys.Contains("Platform"))
            {
                configurations = project.ConditionedProperties["Configuration"];

                platforms = project.ConditionedProperties["Platform"];

                Console.Write("Config:");
                foreach(var config in configurations)
                {
                    Console.Write(" " + config + " **");
                }
                Console.WriteLine(" ");
                Console.Write("Plat:");
                foreach (var plat in platforms)
                {
                    Console.Write(" "+ plat + " **");
                }
              
            }
            Console.WriteLine(" ");
            Console.Write("Assem:");
            if (project.Properties.Any(n => n.Name == "TargetPath"))
            {
                var mypath = System.Reflection.Assembly.GetEntryAssembly().Location;
                var targetPath = project.GetProperty("TargetPath");
                var targetPathString = targetPath.EvaluatedValue.ToString();
                var assembly = Assembly.LoadFrom(targetPathString); //question
             //   List<String> dependents = new List<string>();
               
                foreach (AssemblyName b in assembly.GetReferencedAssemblies())
                {
                  //  dependents.Add(b.ToString());
                    Console.Write(" "+ b + " **");
                }
              //  Console.Write(targetPathString + " ");
                Console.Write(" " + assembly);
            }

        //   Console.ReadKey();
        }

        public void ErrorHandler(object sender, BuildErrorEventArgs args)
        {}
    }
  
}


