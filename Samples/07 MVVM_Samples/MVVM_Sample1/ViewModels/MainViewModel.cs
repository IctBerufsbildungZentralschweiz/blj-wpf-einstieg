using MVVM_Sample1.Common;
using MVVM_Sample1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace MVVM_Sample1.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region fields

        ICollectionView _friendsCV;


        #endregion 

        #region properties 

        public DelegateCommand<object> NextCommand { get; set; }
        public DelegateCommand<object> PreviousCommand { get; set; }
        public List<Friend> Friends { get; private set; }

        #endregion

        #region constructor 

        public MainViewModel()
        {
            NextCommand = new DelegateCommand<object>(OnNextExecute, OnNextCanExecute);
            PreviousCommand = new DelegateCommand<object>(OnPreviousExecute, OnPreviousCanExecute);

            LoadData();
            _friendsCV = CollectionViewSource.GetDefaultView(Friends);
            _friendsCV.MoveCurrentToFirst();
        }

        #endregion

        #region methods 

        private void OnNextExecute(object parameter)
        {
            _friendsCV.MoveCurrentToNext();
        }

        private bool OnNextCanExecute(object parameter)
        {
            return _friendsCV.CurrentPosition < Friends.Count -1;
        }

        private void OnPreviousExecute(object parameter)
        {
            _friendsCV.MoveCurrentToPrevious();
        }

        private bool OnPreviousCanExecute(object parameter)
        {
            return _friendsCV.CurrentPosition > 0;
        }

        private void LoadData()
        {
            Friends = new List<Friend>();
            Friends.Add(new Friend { Firstname = "Julia", Lastname = "Barker" });
            Friends.Add(new Friend { Firstname = "Erkan", Lastname = "Egin" });
            Friends.Add(new Friend { Firstname = "Thomas", Lastname = "Huber" });
        }

        #endregion 
    }
}
