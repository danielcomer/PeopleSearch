using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace PeopleSearch.Wpf.Client.Controls
{
    public class TextBoxSelectorService
    {
        public static readonly DependencyProperty SelectAllOnFocusProperty =
            DependencyProperty.RegisterAttached(
                "SelectAllOnFocus",
                typeof (bool),
                typeof (TextBoxSelectorService),
                new PropertyMetadata(false, SelectAllOnFocusChanged));

        private static void SelectAllOnFocusChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var control = dependencyObject as Control;

            if (control == null) return;

            var selectAllOnFocus = (bool)dependencyPropertyChangedEventArgs.NewValue;

            if (selectAllOnFocus)
            {
                control.GotFocus += ControlOnGotFocus;
                control.TargetUpdated += ControlOnTargetUpdated;
            }
            else
            {
                control.GotFocus -= ControlOnGotFocus;
                control.TargetUpdated -= ControlOnTargetUpdated;
            }
        }

        private static void ControlOnTargetUpdated(object sender, DataTransferEventArgs dataTransferEventArgs)
        {
            var control = sender as Control;

            if (control == null) return;

            if (!control.IsFocused) return;

            (control as TextBox)?.SelectAll();
            (control as PasswordBox)?.SelectAll();
        }

        private static void ControlOnGotFocus(object sender, RoutedEventArgs routedEventArgs)
        {
            var control = sender as Control;

            if (control == null) return;

            (control as TextBox)?.SelectAll();
            (control as PasswordBox)?.SelectAll();
        }

        public static void SetSelectAllOnFocus(DependencyObject element, bool value)
        {
            element.SetValue(SelectAllOnFocusProperty, value);
        }

        public static bool GetSelectAllOnFocus(DependencyObject element)
        {
            return (bool)element.GetValue(SelectAllOnFocusProperty);
        }
    }
}