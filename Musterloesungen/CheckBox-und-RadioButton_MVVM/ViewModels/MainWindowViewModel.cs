﻿using CheckBox_und_RadioButton_MVVM.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CheckBox_und_RadioButton_MVVM.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        #region properties 

        public DelegateCommand<string> ColorRadioButtonCommand { get; set; }
        public DelegateCommand<string> AnimalRadioButtonCommand { get; set; }
        public DelegateCommand<object[]> HobbyCheckBoxCommand { get; set; }

        string _favColor = string.Empty;
        public string FavColor
        {
            get { return _favColor; }
            set { _favColor = value; OnPropertyChanged("FavColor"); }
        }

        string _favAnimal = string.Empty;
        public string FavAnimal
        {
            get { return _favAnimal; }
            set { _favAnimal = value; OnPropertyChanged("FavAnimal"); }
        }

        List<string> _hobbies = new List<string>();
        public List<string> Hobbies
        {
            get { return _hobbies; }
        }

        #endregion

        #region constructor 

        public MainWindowViewModel()
        {
            ColorRadioButtonCommand = new DelegateCommand<string>(ColorRadioButtonCommand_Execute, ColorRadioButtonCommand_CanExecute);
            AnimalRadioButtonCommand = new DelegateCommand<string>(AnimalRadioButtonCommand_Execute, AnimalRadioButtonCommand_CanExecute);
            HobbyCheckBoxCommand = new DelegateCommand<object[]>(HobbyCheckBoxCommand_Execute, HobbyCheckBoxCommand_CanExecute);
        }
        
        #endregion 

        #region command handler

        private bool ColorRadioButtonCommand_CanExecute(string parameter)
        {
            return true;
        }

        private void ColorRadioButtonCommand_Execute(string parameter)
        {
            FavColor = parameter;
        }

        private bool AnimalRadioButtonCommand_CanExecute(string parameter)
        {
            return true;
        }

        private void AnimalRadioButtonCommand_Execute(string parameter)
        {
            FavAnimal = parameter;
        }

        private bool HobbyCheckBoxCommand_CanExecute(object[] parameter)
        {
            return true;
        }

        private void HobbyCheckBoxCommand_Execute(object[] parameter)
        {
            if (Convert.ToBoolean(parameter[0]))
                Hobbies.Add(parameter[1].ToString());
            else
                Hobbies.Remove(parameter[1].ToString());
        }

        #endregion 

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
