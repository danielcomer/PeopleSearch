using System.ComponentModel;
using System.Windows;
using PeopleSearch.ViewModel;
using PeopleSearch.Wpf.Client.IoC;

namespace PeopleSearch.Wpf.Client.Mvvm
{
    public class ViewModelLocator
    {
        private static readonly DependencyObject dummy = new DependencyObject();

        public PersonSearchViewModel PersonSearchViewModel
        {
            get
            {
                if (IsInDesignMode())
                {
                    return null;
                }

                return NinjectServiceLocator.Get<PersonSearchViewModel>();
            }
        }

        private static bool IsInDesignMode()
        {
            return DesignerProperties.GetIsInDesignMode(dummy);
        }
    }
}
