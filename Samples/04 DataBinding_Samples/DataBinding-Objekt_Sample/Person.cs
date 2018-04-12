using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBinding_Objekte_Sample1
{
    class gaga : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }

    class Person : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private string _name;
        private string _wohnort;
        private int _alter; 

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged(new PropertyChangedEventArgs("Name")); }
        }

        public string Wohnort
        {
            get { return _wohnort; }
            set { _wohnort = value; OnPropertyChanged(new PropertyChangedEventArgs("Wohnort")); }
        }

        public int Alter
        {
            get { return _alter; }
            set { _alter = value; OnPropertyChanged(new PropertyChangedEventArgs("Alter")); }
        }
    }
}
