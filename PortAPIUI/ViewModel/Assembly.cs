using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Text;

namespace PortAPIUI.Model
{
    internal class AssemblyModel : ViewModelBase
    {
        private string _name;


        public override string ToString()
        {
            return _name;
        }

        public AssemblyModel(string assembly)
        {
            _name = assembly;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }
        
    }
}
