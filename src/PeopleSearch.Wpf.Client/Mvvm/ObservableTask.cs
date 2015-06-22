using System;
using System.Threading.Tasks;
using PeopleSearch.Core.ComponentModel;

namespace PeopleSearch.Wpf.Client.Mvvm
{
    public sealed class ObservableTask<TResult> : PropertyChangedNotifier, IObservableTask<TResult>
    {
        #region Members

        private Task<TResult> _theTask;

        #endregion

        #region Public Properties

        public Task<TResult> TheTask
        {
            get { return _theTask; }
            set
            {
                SetBackingMemberValue(ref _theTask, value);
                RaiseAllTaskPropertiesChanged();
            }
        }

        public TResult Result => (TheTask?.Status == TaskStatus.RanToCompletion) ? TheTask.Result : default(TResult);
        public TaskStatus Status => TheTask.Status;
        public bool IsCompleted => TheTask?.IsCompleted ?? false;
        public bool IsNotCompleted => !TheTask?.IsCompleted ?? true;
        public bool IsSuccessfullyCompleted => TheTask?.Status == TaskStatus.RanToCompletion;
        public bool IsCanceled => TheTask?.IsCanceled ?? false;
        public bool IsFaulted => TheTask?.IsFaulted ?? false;
        public AggregateException Exception => TheTask?.Exception;
        public Exception InnerException => Exception?.InnerException;
        public string ErrorMessage => InnerException?.Message;

        #endregion

        #region Constructors

        public ObservableTask(Task<TResult> theTask, TimeSpan? simulatedDelaySpan = null)
        {
            if (simulatedDelaySpan != null)
            {
                var delay = Task.Delay(simulatedDelaySpan.Value);
                delay.ContinueWith(t => TheTask = theTask);
                var _ = WatchTaskAsync(delay);
            }
            else
            {
                TheTask = theTask;
                var _ = WatchTaskAsync(theTask);
            }
        }

        #endregion

        #region Private Methods

        private async Task WatchTaskAsync(Task task)
        {
            try
            {
                await task;
            }
            // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
            }

            RaiseAllTaskPropertiesChanged();
        }

        private void RaiseAllTaskPropertiesChanged()
        {
            RaisePropertyChanged(nameof(Status));
            RaisePropertyChanged(nameof(IsCompleted));
            RaisePropertyChanged(nameof(IsNotCompleted));
            RaisePropertyChanged(nameof(IsCanceled));
            RaisePropertyChanged(nameof(IsFaulted));
            RaisePropertyChanged(nameof(Exception));
            RaisePropertyChanged(nameof(InnerException));
            RaisePropertyChanged(nameof(ErrorMessage));
            RaisePropertyChanged(nameof(IsSuccessfullyCompleted));
            RaisePropertyChanged(nameof(Result));
        }

        #endregion
    }
}
