using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using CheckBox_und_RadioButton_MVVM.ViewModels;

namespace CheckBox_und_RadioButton_MVVM.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindowViewModel viewModel = this.DataContext as MainWindowViewModel;

            string message = "Ausgewählt wurde: " + Environment.NewLine;

            message += viewModel.FavColor + Environment.NewLine;
            message += viewModel.FavAnimal + Environment.NewLine;
            foreach (string s in viewModel.Hobbies)
                message += s + Environment.NewLine;

            MessageBox.Show(message);
        }
    }
}
