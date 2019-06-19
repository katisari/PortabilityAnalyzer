﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using PortAPIUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Threading;

class MainViewModel:ViewModelBase
    {
        public RelayCommand OpenCommand { get; set; }
        public RelayCommand OpenCommand2 { get; set; }
       public RelayCommand OpenCommand3 { get; set; }

    private string _selectedPath;

        public string SelectedPath
        {
            get { return _selectedPath; }
            set
            {
                _selectedPath = value;
                RaisePropertyChanged("SelectedPath");
            }
        }

     

        public MainViewModel()
        {
            RegisterCommands();
        }

       

        private void RegisterCommands()

        {
 
        
            OpenCommand = new RelayCommand(ExecuteOpenFileDialog);
            OpenCommand2 = new RelayCommand(ExecuteSaveFileDialog);
            OpenCommand3 = new RelayCommand(AnalyzeAPI);

    }


        private void AnalyzeAPI()
    {
        List<string> assemblies = MsBuildAnalyzer.GetAssemblies(SelectedPath);
        ApiAnalyzer.AnalyzeAssemblies(assemblies);

    }




        private void ExecuteOpenFileDialog()
        {

        
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.Filter = "Project File (*.csproj)|*.csproj|All files (*.*)|*.*";
            dialog.InitialDirectory = @"C:\";
            dialog.ShowDialog();
            SelectedPath = dialog.FileName;
            
        

        }

        private void ExecuteSaveFileDialog()
        {
            var savedialog = new Microsoft.Win32.SaveFileDialog();
            savedialog.FileName = "PortablityAnalysisReoprt";
            savedialog.DefaultExt = ".text";
            savedialog.Filter = "HTML file (*.html)|*.html|Json (*.json)|*.json| Excel (*.excel)|*.excel";
            Nullable<bool> result = savedialog.ShowDialog();
            if (result == true)
            {
                string filename = savedialog.FileName;
            }

        }
    
}

