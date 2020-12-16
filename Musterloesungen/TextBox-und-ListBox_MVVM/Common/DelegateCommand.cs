using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TextBox_und_ListBox_MVVM.Common
{
    /// <summary>
    /// Universell vewendbare Implementation der ICommand-Schnittstelle. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DelegateCommand<T> : ICommand
    {
        // Diese beiden Delegaten werden vom Konstruktor verlangt.  
        // Sie sind quasi Verweise auf die Methoden, die dann den Logik-Code ausführen. 
        Action<T> executeHdl { get; set; }
        Predicate<T> canExecuteHdl { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="executeHdl">Methode, welche die Implementation der Command-Logik enthält</param>
        /// <param name="canExecuteHdl">Methode, welche die Implementation der Prüf-Logik, ob die Command-Logik ausgeführt werden kann, enthält.</param>
        public DelegateCommand(Action<T> executeHdl, Predicate<T> canExecuteHdl)
        {
            this.canExecuteHdl = canExecuteHdl;

            if (executeHdl == null)
                throw new ArgumentNullException("executeHdl", "Please specifiy the command.");

            this.executeHdl = executeHdl;
        }

        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Diese Methode feuert das CanExecuteChanged-Ereignis
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            if (this.CanExecuteChanged != null)
                this.CanExecuteChanged(this, null);
        }

        /// <summary>
        /// Liefert true, wenn kein externer Code hinterlegt ist (wenn also der Delegat null ist) oder wenn 
        /// die externe Methode, die dieser Klasse übergeben wurde (die vom Delegat aufgerufen wird) true liefert. 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return canExecuteHdl == null || canExecuteHdl((T)parameter) == true;
        }

        /// <summary>
        /// Diese Methode delegiert den Aufruf an den extern implementierten Code.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            executeHdl((T)parameter);
        }
    }
}
