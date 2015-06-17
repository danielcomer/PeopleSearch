using System;
using System.Windows.Input;

namespace PeopleSearch.Wpf.Client.Mvvm
{
    public class WpfDelegateCommand<T> : ICommand
    {
        #region Private Fields

        private readonly Action<T> _execute;
        private readonly Func<T, bool> _canExecute;

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion

        #region Constructors

        public WpfDelegateCommand(Action<T> execute) : this(execute, param => true)
        {
        }

        public WpfDelegateCommand(Action<T> execute, Func<T, bool> canExecute)
        {
            if (execute == null) throw new ArgumentNullException(nameof(execute));
            if (canExecute == null) throw new ArgumentNullException(nameof(canExecute));

            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region Public Methods

        public bool CanExecute(object parameter)
        {
            return _canExecute((T) parameter);
        }

        public void Execute(object parameter)
        {
            if (!_canExecute((T) parameter)) return;

            _execute((T) parameter);
        }

        #endregion
    }
}
