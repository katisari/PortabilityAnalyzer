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
using BuildcsprojtoMem;

namespace MSBuildAnalyzer
{
    public class Program
    {
        static void Main(string[] args)
        {
            MSBuildLocator.RegisterDefaults();
            string CsProjPath = args[0];


            //string CsProjPath = @"C:\Users\t-lilawr\source\repos\pracproj\pracproj.csproj";
            if (args.Length == 1)
            {
                temp.MyMethod(CsProjPath);
            }
           
            
            if (args.Length > 1)
            {
                string ChosenConfig = args[1];
                string ChosenPlat = args[2];
                Chosen.configure(CsProjPath, ChosenConfig, ChosenPlat);
            }
        }
    }
    public class temp
    {
      
        public static List<string> configurations;
        public static List<String> platforms;

        public static void MyMethod(string CsProjPath)
        {
            const string box1 = "Configuration";
            const string box2 = "Platform";
            Dictionary<String, String> dic = new Dictionary<string, string>
                {
                    { box1, "Debug" },
                    { box2, "AnyCPU" } 
                };
            ProjectCollection pc = new ProjectCollection(dic, null, ToolsetDefinitionLocations.Default) ;

            var project = pc.LoadProject(CsProjPath);
            project.Build();

            configurations = project.ConditionedProperties[box1];
            platforms = project.ConditionedProperties[box2];

            var con = new string[0];
            var pla = new string[0];

                Console.Write("Config:");
                foreach(var config in configurations)
                {
                     con.Append(config);
                    Console.Write(" **" + config );
                }
                Console.WriteLine(" ");
                Console.Write("Plat:");
                foreach (var plat in platforms)
                {
                     pla.Append(plat);
                    Console.Write(" **"+ plat);
                }

            Console.WriteLine(" ");
            Console.Write("Assem:");
            if (project.Properties.Any(n => n.Name == "TargetPath"))
            {
                var mypath = System.Reflection.Assembly.GetEntryAssembly().Location;
                var targetPath = project.GetProperty("TargetPath");
                var targetPathString = targetPath.EvaluatedValue.ToString();
                var assembly = Assembly.LoadFrom(targetPathString); 
                foreach (AssemblyName b in assembly.GetReferencedAssemblies())
                {
                    Console.Write(" **"+ b );
                }
                Console.Write(" **" + assembly);
            }

            Console.ReadKey();
            foreach (string q in pla)
            {
                foreach (string s in con)
                {
                    Dictionary<String, String> dictionary = new Dictionary<string, string>
                {
                    { box1, s },
                    { box2, q }
                };
                    ProjectCollection collection = new ProjectCollection(dictionary, null, ToolsetDefinitionLocations.Default);

                    var pro = collection.LoadProject(CsProjPath);
                    pro.Build();
                }
            }
        }
    }
}


