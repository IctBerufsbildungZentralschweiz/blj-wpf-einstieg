using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace _03_ICommand_Sample1
{

    class MyViewModel
    {
        public ClickCommand ClickCmd { get; set; }

        public MyViewModel()
        {
            ClickCmd = new ClickCommand();
        }

    }

    class ClickCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           MessageBox.Show("Hallo Welt");
        }
    }


}
