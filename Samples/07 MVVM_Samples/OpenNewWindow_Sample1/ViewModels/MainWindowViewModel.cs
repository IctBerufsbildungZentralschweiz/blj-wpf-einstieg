using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OpenNewWindow_Sample.ViewModels
{
    class MainWindowViewModel
    {
        public string InputText { get; set; }
        public OpenWindowModalCommand OpenWindowCommand { get; private set; }
        DetailsWindow _detailsView;
    
        public MainWindowViewModel()
        {
            OpenWindowCommand = new OpenWindowModalCommand(this);
        }

        
        public void ShowDetailsWindow()
        {
            //ddViewModel addViewModel = new AddViewModel();
            // detailsView.DataContext = addViewModel;
            _detailsView = new DetailsWindow();

            _detailsView.DataContext = this;
            _detailsView.Title = "gaga";
            if (_detailsView.ShowDialog() == true)
            {
                MessageBox.Show("details window closed.");
            }
            
        }

        public void CloseDetailsWindow()
        {
            _detailsView.Close();
        }
    }

    #region commands 

    class OpenWindowModalCommand : ICommand
    {
        MainWindowViewModel _vm;

        public OpenWindowModalCommand(MainWindowViewModel vm)
        {
            _vm = vm;
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
                this.CanExecuteChanged(this, null);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _vm.ShowDetailsWindow();
        }
    }

    class CloseWindowCommand : ICommand
    {
        MainWindowViewModel _vm;

        public CloseWindowCommand(MainWindowViewModel vm)
        {
            _vm = vm;
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
                this.CanExecuteChanged(this, null);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _vm.ShowDetailsWindow();
        }
    }

    #endregion 
}
