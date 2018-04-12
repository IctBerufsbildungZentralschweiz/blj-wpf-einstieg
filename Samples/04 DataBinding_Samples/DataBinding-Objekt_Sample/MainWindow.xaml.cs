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

namespace DataBinding_Objekte_Sample1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Person p = new Person { Name = "John Doe", Wohnort = "New York", Alter = 35 };

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = p;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            p.Name = "Hans Muster";
            p.Alter = 55;
            p.Wohnort = "Berlin";
        }
    }
}
