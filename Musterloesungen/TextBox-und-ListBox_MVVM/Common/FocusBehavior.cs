using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace TextBox_und_ListBox_MVVM.Common
{
    // ***************************************************************************************************************************
    // Let's assume a simple scenario: 
    // A TextBox text property is bound to a string in ViewModel, and when you change it, you wish to put focus on the TextBox. 
    // How to accomplish this considering that all your logic is actually in the ViewModel separated from the View? 
    // How to implement this without writing code in code-behind? 
    // ---------------------------------------------------------------------------------------------------------------------------
    // See here: http://igrali.com/2013/09/19/focus-a-textbox-from-viewmodel-using-a-simple-behavior/ 
    // ***************************************************************************************************************************
    class FocusBehavior : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            AssociatedObject.GotFocus += (sender, args) => IsFocused = true;
            AssociatedObject.LostFocus += (sender, args) => IsFocused = false;
            AssociatedObject.TextChanged += (sender, args) =>
            {
                if (!IsFocused)
                {
                    AssociatedObject.Focus();
                    AssociatedObject.Select(AssociatedObject.Text.Length, 0);
                }
            };

            base.OnAttached();
        }

        public static readonly DependencyProperty IsFocusedProperty = 
            DependencyProperty.Register(
                "IsFocused",
                typeof(bool),
                typeof(FocusBehavior),
                new PropertyMetadata(false));

        public bool IsFocused
        {
            get { return (bool)GetValue(IsFocusedProperty); }
            set { SetValue(IsFocusedProperty, value); }
        }
    }
}
