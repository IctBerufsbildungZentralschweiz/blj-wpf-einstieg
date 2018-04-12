using ICommand_Sample.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ICommand_Sample.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {

        public ButtonClickCommand ClickCommand { get; set; }
        public ButtonMoveTextCommand MoveCommand { get; set; }

        /// <summary>
        /// Gets the text for the Button
        /// </summary>
        public string ButtonContent
        {
            get { return "Click me"; }
        }

        UpDownTextItem _textItem;
        public UpDownTextItem TextItem
        {
            get { return _textItem; }
            set { _textItem = value; OnPropertyChanged("TextItem"); MoveCommand.RaiseCanExecuteChanged(); }
        }

        public MainWindowViewModel()
        {
            ClickCommand = new ButtonClickCommand();
            _textItem = new UpDownTextItem();
            MoveCommand = new ButtonMoveTextCommand(_textItem);
            _textItem.MoveCommand = MoveCommand;
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    class UpDownTextItem : INotifyPropertyChanged
    {
        
        string _upText;
        string _downText;

        public string UpText
        {
            get { return _upText; }
            set { _upText = value; OnPropertyChanged("UpText"); MoveCommand.RaiseCanExecuteChanged(); }
        }
        public string DownText
        {
            get { return _downText; }
            set { _downText = value; OnPropertyChanged("DownText"); MoveCommand.RaiseCanExecuteChanged(); }
        }

        public ButtonMoveTextCommand MoveCommand
        {
            get;
            set;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

 
