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

namespace CommandBindings_Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Command statt mit XAML mittels C#-Code binden: 
            /*
            CommandBinding binding = new CommandBinding(ApplicationCommands.Help);
            this.CommandBindings.Add(binding);
            binding.Executed += Help_Executed;
            binding.CanExecute += Help_CanExecute;
            */
        }

        private void Help_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Help_Executed(object sender, ExecutedRoutedEventArgs e)
        {   
            MessageBox.Show("Help executed. " + Environment.NewLine + Environment.NewLine + e.Parameter.ToString());
        }
    }
}
