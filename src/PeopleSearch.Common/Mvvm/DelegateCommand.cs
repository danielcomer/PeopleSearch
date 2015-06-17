using System;
using System.Windows.Input;

namespace PeopleSearch.Common.Mvvm
{
    public class DelegateCommand : ICommand
    {
        #region Private Fields

        private readonly Action<object> _execute;
        private bool _isEnabled;

        #endregion

        #region Public Properties

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (value == _isEnabled) return;

                _isEnabled = value;
                CanExecuteChanged.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged = delegate { };

        #endregion

        #region Constructors

        public DelegateCommand(Action<object> execute)
        {
            if (execute == null) throw new ArgumentNullException(nameof(execute));

            _execute = execute;
            _isEnabled = true;
        }

        #endregion

        #region Public Methods

        public bool CanExecute(object parameter)
        {
            return IsEnabled;
        }

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter)) return;

            _execute(parameter);
        }

        #endregion
    }
}
