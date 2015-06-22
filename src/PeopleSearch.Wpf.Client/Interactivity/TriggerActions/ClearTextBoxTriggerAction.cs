using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace PeopleSearch.Wpf.Client.Interactivity.TriggerActions
{
    public class ClearTextBoxTriggerAction : TriggerAction<Button>
    {
        public static readonly DependencyProperty TargetProperty = DependencyProperty.Register("Target",
            typeof (TextBox), typeof (ClearTextBoxTriggerAction), new UIPropertyMetadata(null));

        public TextBox Target
        {
            get { return (TextBox)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        protected override void Invoke(object parameter)
        {
            Target.Clear();
            Target.Focus();
        }
    }
}
