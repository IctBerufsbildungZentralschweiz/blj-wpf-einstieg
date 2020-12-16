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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Layout_erstellen
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

        private void NavButton_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;

            if (clickedButton == null)
                return;

            switch (clickedButton.Name)
            {
                case "HomeButton":
                    ContentAreaControl.Content = "'Home' wurde angeklickt.";
                    break;
                case "SearchButton":
                    ContentAreaControl.Content = "'Search' wurde angeklickt.";
                    break;
                case "SettingsButton":
                    ContentAreaControl.Content = "'Settings' wurde angeklickt.";
                    break;
                default:
                    break;
            }

        }
    }
}
