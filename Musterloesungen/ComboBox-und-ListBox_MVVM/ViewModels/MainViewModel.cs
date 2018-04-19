using ComboBox_und_ListBox_MVVM.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboBox_und_ListBox_MVVM.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        public DelegateCommand<object> AddCommand { get; set; }
        public DelegateCommand<object> RemoveCommand { get; set; }

        public ObservableCollection<string> FoodList { get; set; }
        public ObservableCollection<string> BreakfastList { get; set; }

        public string SelectedFood { get; set; }
        public string SelectedBreakfast { get; set; }

        public MainViewModel()
        {
            AddCommand = new DelegateCommand<object>(ExecuteAdd, CanExecuteAdd);
            RemoveCommand = new DelegateCommand<object>(ExecuteRemove, CanExecuteRemove);

            FoodList = new ObservableCollection<string>();
            BreakfastList = new ObservableCollection<string>();

            LoadData();
        }

        private void LoadData()
        {
            FoodList.Add("Eine Scheibe Brot");
            FoodList.Add("Apfel");
            FoodList.Add("Rührei mit Speck");
            FoodList.Add("Ein Gipfeli");
            FoodList.Add("Eine Tasse Tee");
            FoodList.Add("Ein Birchermüsli");
            FoodList.Add("Eine Tasse Kaffee");
        }

        public void ExecuteAdd(object o)
        {
            BreakfastList.Add(SelectedFood);
            FoodList.Remove(SelectedFood);
        }

        public bool CanExecuteAdd(object o)
        {
            return !string.IsNullOrEmpty(SelectedFood);
        }

        public void ExecuteRemove(object o)
        {
            FoodList.Add(SelectedBreakfast);
            BreakfastList.Remove(SelectedBreakfast);
        }

        public bool CanExecuteRemove(object o)
        {
           return !string.IsNullOrEmpty(SelectedBreakfast);
        }
    }
}
