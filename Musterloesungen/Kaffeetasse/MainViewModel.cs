using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaffeetasse
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        List<ImageModel> _imageModels;

        int _selectedValue = 0;
        public int SelectedValue
        {
            get
            {
                return _selectedValue;
            }
            set
            {
                _selectedValue = value;
                OnPropertyChanged("SelectedIndex");
                // es ändert sich auch das aktuell selektierte Model
                OnPropertyChanged("SelectedModel");
            }
        }

        public ImageModel SelectedModel
        {
            get { return _imageModels[SelectedValue]; }
        }

        public MainViewModel()
        {
            _imageModels = new List<ImageModel>();
            _imageModels.Add(new ImageModel("Assets/small.jpg", "Espresso"));
            _imageModels.Add(new ImageModel("Assets/medium.jpg", "Kaffee"));
            _imageModels.Add(new ImageModel("Assets/big.jpg", "Latte Macchiato"));
        }
    }
}
