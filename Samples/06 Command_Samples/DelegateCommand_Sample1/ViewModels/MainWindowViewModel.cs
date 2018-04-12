using DelegateCommand_Sample1.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DelegateCommand_Sample1.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {

        string _upText;
        public string UpText
        {
            get { return _upText;  }
            set { _upText = value; OnPropertyChanged("UpText");  }
        }

        string _downText;
        public string DownText
        {
            get { return _downText;  }
            set { _downText = value; OnPropertyChanged("DownText");  }
        }

        public string ClickButtonContent
        {
            get { return "Click me"; }
        }

        string _moveButtonContent = "Move down";
        public string MoveButtonContent
        {
            get { return _moveButtonContent; }
            set { _moveButtonContent = value; OnPropertyChanged("MoveButtonContent"); }
        }

   
        // <summary>
        /// Command, der an den Click-Button gebunden wird.
        /// </summary>
        public DelegateCommand<string> ClickCommand { get; set; }

        /// <summary>
        /// Command, der an den Move-Button gebunden wird.
        /// </summary>
        public DelegateCommand<object> MoveCommand { get; set; }


        /// <summary>
        /// Constructor.
        /// </summary>
        public MainWindowViewModel()
        {
            ClickCommand = new DelegateCommand<string>(ClickCommand_Execute, ClickCommand_CanExecute);
            MoveCommand = new DelegateCommand<object>(MoveCommand_Execute, MoveCommand_CanExecute);

            MoveButtonContent = "Move down";
        }

        public bool ClickCommand_CanExecute(string i)
        {
            return true;
        }

        public void ClickCommand_Execute(string i)
        {
            MessageBox.Show("Hello World! CommandParameter: " + i.ToString());
        }


        public void MoveCommand_Execute(object s)
        {
            if (!string.IsNullOrEmpty(UpText))
            {
                DownText = UpText;
                UpText = string.Empty;
                MoveButtonContent = "Move up";
            }
            else if (!string.IsNullOrEmpty(DownText))
            {
                UpText = DownText;
                DownText = string.Empty;
                MoveButtonContent = "Move down";
            }
        }

        public bool MoveCommand_CanExecute(object s)
        {
            return !string.IsNullOrEmpty(UpText) || !string.IsNullOrEmpty(DownText);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
