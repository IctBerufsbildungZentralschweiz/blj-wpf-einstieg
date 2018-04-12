using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Attached_Dependcy_Property_Sample
{
    public class myTools : DependencyObject
    {
        // ---------------------------------------------------------------
        // Using a DependencyProperty as the backing store for RowHeights.
        // This enables animation, styling, binding, etc.
        // ---------------------------------------------------------------
        public static readonly DependencyProperty RowHeightsProperty 
            = DependencyProperty.RegisterAttached(
                "RowHeights"
                , typeof(string)
                , typeof(myTools)
                , new PropertyMetadata("", RowHeightsChanged));

        public static string GetRowHeights(DependencyObject obj)
        {
            return (string)obj.GetValue(RowHeightsProperty);
        }

        public static void SetRowHeights(DependencyObject obj, string value)
        {
            obj.SetValue(RowHeightsProperty, value);
        }

        private static void RowHeightsChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            // prüfen, ob die Property für ein Grid registriert ist.
            var grid = d as Grid;
            if (grid == null)
                return;

            // clearen der RowDefinitions des Grid
            grid.RowDefinitions.Clear();

            // die neuen RowDefinitions kommen über das Event-Argument
            var definitions = args.NewValue.ToString();
            // ff ginge auch 
            // var definitions = GetRowHeights(grid);

            if (string.IsNullOrEmpty(definitions))
                return;

            var heights = definitions.Split(',');
            foreach (var height in heights)
            {
                if (height == "Auto")
                {
                    grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                }
                else if (height.EndsWith("*"))
                {
                    var height2 = height.Replace("*", "");

                    if (string.IsNullOrEmpty(height2))
                        height2 = "1";

                    var numHeight = int.Parse(height2);
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(numHeight, GridUnitType.Star) });
                }
                else
                {
                    var numHeight = int.Parse(height);
                    grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(numHeight, GridUnitType.Pixel) });
                }
            }
        }
    }
}
