using ComboBox_und_ListBox_MVVM.ViewModels;
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

namespace ComboBox_und_ListBox_MVVM.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void ListBox_GotFocus(object sender, RoutedEventArgs e)
        {
            /* 
             * ListBox und ComboBox implementieren ICommandSource nicht; d.h. für Elemente dieses Typs
             * ist Command-Binding nicht möglich. MVVM-Puristen, die Code-Behind konsequent vermeiden möchten
             * müssen sich mit Implementation einer Depedency Property behelfen; ein Beispiel hier: 
             * https://www.codeproject.com/Articles/363568/Command-binding-with-Events-a-way-from-simple-to-a 
             * 
             * Für mich (Urs Nussbaumer) ist es total OK, wenn wir hier Code-Behind schreiben; 
             * denn es ist ja sehr View-spezifisches Verhalten, was wir hier implementieren.  
            */
            RemoveButton.IsDefault = true;
        }

        private void ComboBox_GotFocus(object sender, RoutedEventArgs e)
        {
            AddButton.IsDefault = true;
        }
    }
}
