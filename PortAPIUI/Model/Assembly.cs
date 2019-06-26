using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace PortAPIUI.Model
{
    class AssemblyModel : ViewModelBase
    {
        private string _name;
        private string _compaptality;


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
        public string Compatablity
        {
            get
            {
                return _compaptality;
            }
            set
            {
                _compaptality = value;
                RaisePropertyChanged("Name");
            }
        }



    }
}
