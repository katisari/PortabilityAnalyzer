using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using PortAPIUI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

class MainViewModel:ViewModelBase
    {
        public RelayCommand OpenCommand { get; set; }
        
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
       
         }


        private void ExecuteOpenFileDialog()
        {

        
        var dialog = new Microsoft.Win32.OpenFileDialog();
        dialog.Filter = "Project File (*.csproj)|*.csproj|All files (*.*)|*.*";
        dialog.InitialDirectory = @"C:\";
        dialog.ShowDialog();

        SelectedPath = dialog.FileName;
        

        }
    
}

