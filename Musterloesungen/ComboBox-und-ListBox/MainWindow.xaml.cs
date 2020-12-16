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

namespace ComboBox_und_ListBox
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

        private void AddItem()
        {
            if (ComboBoxFood.SelectedItem != null)
            {
                ComboBoxItem cbItem = ComboBoxFood.SelectedItem as ComboBoxItem;
                ComboBoxFood.Items.Remove(ComboBoxFood.SelectedItem);

                ListBoxItem lbItem = (ListBoxItem)ConvertContentControl(cbItem, typeof(ListBoxItem));
                ListBoxBreakfast.Items.Add(lbItem);

                ComboBoxFood.Focus();
            }
        }

        private void RemoveItem()
        {
            if (ListBoxBreakfast.SelectedItem != null)
            {
                int i = ListBoxBreakfast.SelectedIndex;

                ListBoxItem lbItem = ListBoxBreakfast.SelectedItem as ListBoxItem;
                ListBoxBreakfast.Items.Remove(ListBoxBreakfast.SelectedItem);

                ComboBoxItem cbItem = (ComboBoxItem)ConvertContentControl(lbItem, typeof(ComboBoxItem));
                ComboBoxFood.Items.Add(cbItem);

                ListBoxBreakfast.Focus();

                if (ListBoxBreakfast.Items.Count > 0)
                {
                    if (ListBoxBreakfast.Items.Count > i)
                        // den darunter liegenden Eintrag selektieren
                        ListBoxBreakfast.SelectedIndex = i;
                    else
                        // den darüber liegenden Eintrag selektieren
                        ListBoxBreakfast.SelectedIndex = i - 1;
                }
            }
        }

        private ContentControl ConvertContentControl(ContentControl fromItem, Type toItem)
        {
            ContentControl item;

            if (toItem == typeof(ListBoxItem))
                item = new ListBoxItem();
            else if (toItem == typeof(ComboBoxItem))
                item = new ComboBoxItem();
            else
                throw new FormatException("The 'ConvertContentControl' method converts a ComboBoxItem to a ListBoxItem and vice versa. "
                    + "Cloning to type '" + toItem.ToString() + "' is not supported.");

            item.Content = fromItem.Content;
            return item;
        }

        #region event handler 
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            AddItem();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            RemoveItem();
        }

        private void ListBoxBreakfast_GotFocus(object sender, RoutedEventArgs e)
        {
            RemoveButton.IsDefault = true;
            AddButton.IsDefault = false;
        }

        private void ComboBoxFood_GotFocus(object sender, RoutedEventArgs e)
        {
            RemoveButton.IsDefault = false;
            AddButton.IsDefault = true;
        }

        private void ComboBoxFood_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AddButton.IsEnabled = ComboBoxFood.SelectedItem != null;
            RemoveButton.IsEnabled = false;
        }

        private void ListBoxBreakfast_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RemoveButton.IsEnabled = ListBoxBreakfast.SelectedItem != null;
            AddButton.IsEnabled = false;
        }

        private void ListBoxBreakfast_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
                RemoveItem();
        }

        private void ListBoxBreakfast_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            RemoveItem();
        }

        #endregion 
    }
}
