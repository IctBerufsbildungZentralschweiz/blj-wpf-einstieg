
using ICommand_Sample.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ICommand_Sample.Commands
{
    class ButtonMoveTextCommand : ICommand 
    {

        UpDownTextItem _textItem;


        public ButtonMoveTextCommand(UpDownTextItem textItem)
        {
            _textItem = textItem;
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
                this.CanExecuteChanged(this, null);
        }

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_textItem.UpText) || !string.IsNullOrEmpty(_textItem.DownText);
        }

        public void Execute(object parameter)
        {
            if (!string.IsNullOrEmpty(_textItem.UpText))
            {
                _textItem.DownText = _textItem.UpText;
                _textItem.UpText = string.Empty;
            }
            else if (!string.IsNullOrEmpty(_textItem.DownText))
            {
                _textItem.UpText = _textItem.DownText;
                _textItem.DownText = string.Empty;
            }
        }
    }
}
