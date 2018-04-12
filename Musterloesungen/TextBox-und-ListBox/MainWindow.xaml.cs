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

namespace TextBox_und_ListBox
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

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(InputTextBox.Text))
            {
                int counter = ViewItemsListBox.Items.Count + 1;

                ViewItemsListBox.Items.Add(counter.ToString() + ": " + InputTextBox.Text);

                InputTextBox.Clear();
                InputTextBox.Focus();
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ViewItemsListBox.Items.Clear();
        }

        private void ViewItemsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ViewItemsListBox.SelectedItem == null)
                return; 

            SelectedItemTextBlock.Text = ViewItemsListBox.SelectedItem.ToString();
        }
    }
}
