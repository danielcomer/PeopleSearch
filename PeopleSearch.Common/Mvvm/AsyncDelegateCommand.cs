using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PeopleSearch.Common.Mvvm
{
    public class AsyncDelegateCommand : ICommand
    {
        #region Private Fields

        private bool _isEnabled;
        private readonly Func<object, Task> _executedHandler;

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged = delegate { };

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

        #region Constructors

        public AsyncDelegateCommand(Func<object, Task> executedHandler)
        {
            if (executedHandler == null)
            {
                throw new ArgumentNullException(nameof(executedHandler));
            }

            _executedHandler = executedHandler;
        }

        #endregion

        #region Public Methods

        public Task ExecuteAsync(object parameter)
        {
            return _executedHandler(parameter);
        }
        
        public bool CanExecute(object parameter)
        {
            return IsEnabled;
        }

        async void ICommand.Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }

        #endregion
    }

}
