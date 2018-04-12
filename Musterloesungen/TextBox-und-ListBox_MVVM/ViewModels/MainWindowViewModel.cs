using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TextBox_und_ListBox_MVVM.Common;
using TextBox_und_ListBox_MVVM.Models;

namespace TextBox_und_ListBox_MVVM.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        #region fields

        #endregion 

        #region properties 

        public DelegateCommand<object> AddCommand { get; set; }
        public DelegateCommand<object> ClearCommand { get; set; }
        public DelegateCommand<object> CloseCommand { get; set; }

        /// <summary>
        /// Die Klasse ObservableCollection implementiert die Interfaces 'INotifyPropertyChanged' und 'INotifyCollectionChanged'. 
        /// Dadurch eignet sie sich für die Datenbindung, weil sie Oberflächenelemente über Änderungen (Hinzufügen/Löschen 
        /// von Elementen) informiert. 
        /// </summary>
        public ObservableCollection<string> Items { get; private set; }

        string _new = string.Empty;
        public string NewItem
        {
            get { return _new; }
            set { _new = value; OnPropertyChanged("NewItem"); AddCommand.RaiseCanExecuteChanged();  }
        }

        #endregion

        #region constructors 

        /// <summary>
        ///  Constructor.
        /// </summary>
        public MainWindowViewModel()
        {
            // Liste initialisieren
            Items = new ObservableCollection<string>();

            AddCommand = new DelegateCommand<object>(AddCommand_Excecute, AddCommand_CanExecute);
            ClearCommand = new DelegateCommand<object>(ClearCommand_Excecute, ClearCommand_CanExecute);
            CloseCommand = new DelegateCommand<object>(CloseCommand_Excecute, CloseCommand_CanExecute);
        }

        #endregion

        #region methods 

        public void AddCommand_Excecute(object o)
        {
            Items.Add(NewItem);
            NewItem = string.Empty;
            ClearCommand.RaiseCanExecuteChanged();
        }

        public bool AddCommand_CanExecute(object o)
        {
            return !string.IsNullOrEmpty(NewItem);
        }


        public void ClearCommand_Excecute(object o)
        {
            Items.Clear();
            ClearCommand.RaiseCanExecuteChanged();
        }

        public bool ClearCommand_CanExecute(object o)
        {

            return Items.Count > 0;
        }

        public void CloseCommand_Excecute(object o)
        {
            Application.Current.MainWindow.Close();
        }

        public bool CloseCommand_CanExecute(object o)
        {
            return true;
        }

        #endregion
    }
}
