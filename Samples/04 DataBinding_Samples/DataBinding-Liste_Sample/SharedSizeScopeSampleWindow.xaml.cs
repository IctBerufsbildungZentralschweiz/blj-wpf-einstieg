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

namespace DataBinding_Liste_Sample
{
    /// <summary>
    /// Interaction logic for Sample2Window.xaml
    /// </summary>
    public partial class Sample2Window : Window
    {
        Firma firma = new Firma
        {
            Name = "ICT-Berufsbilung Zentralschweiz", Mitarbeiter = new List<Person>
        {
            new Person { Name="Roger Erni", Wohnort="Kriens", Alter=45 },
            new Person { Name="Horst Lang", Wohnort="Geuensee", Alter=48 },
            new Person { Name="Julia Stadelmann", Wohnort="Luzern", Alter=24 },
            new Person { Name="Kurt Fischer", Wohnort="Kriens", Alter=65 },
            new Person { Name="Urs Nussbaumer", Wohnort="Ebikon", Alter=47 }
        }
        };

        public Sample2Window()
        {
            InitializeComponent();
            this.DataContext = firma;
        }
    }
}
