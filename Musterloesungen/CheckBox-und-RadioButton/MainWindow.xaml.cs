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

namespace CheckBox_und_RadioButton
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
            string message = "Ausgewählt wurde: " + Environment.NewLine;

            foreach (UIElement elem in container.Children)
            {
                if (elem is GroupBox)
                {
                    GroupBox gb = elem as GroupBox;

                    foreach (UIElement elem2 in ((gb.Content) as StackPanel).Children)
                    {
                        RadioButton rb = elem2 as RadioButton;
                        CheckBox chk = elem2 as CheckBox; 

                        if (rb != null && rb.IsChecked == true)
                            message += rb.Content.ToString() + Environment.NewLine;
                        else if (chk != null && chk.IsChecked == true)
                            message += chk.Content.ToString() + Environment.NewLine;
                    }
                }
             }



            MessageBox.Show(message, "Message");
        }
    }
}
