using DelegateCommand_Sample2.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DelegateCommand_Sample2.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// Der Command, der an den Button gebunden wird.
        /// </summary>
        public DelegateCommand<object> SayHelloCommand { get; set; }

        string _message; 
        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged("Message"); }
        }

        string _yourName;
        public string YourName
        {
            get { return _yourName; }
            set { _yourName = value; OnPropertyChanged("YourName"); }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainWindowViewModel()
        {
            SayHelloCommand = new DelegateCommand<object>(
                SetMessage,
                CanSayHelloCommandExecute
                // oder: Implementierung der Execute-Methode als anonyme Methode mit Lambda-Syntax
                //(s) => Message = string.Format("Hallo {0}!", YourName),
                // sowie: Implementierung der CanExecute-Methode als anonyme Methode mit Lambda-Syntax
                //(s) => !String.IsNullOrEmpty(s)                 
            );
        }

        public void SetMessage(object o)
        {
            Message = "Hallo " + YourName + "!";
        }

        public bool CanSayHelloCommandExecute(object o)
        {
            return !String.IsNullOrEmpty(YourName);
        }

    }
}
