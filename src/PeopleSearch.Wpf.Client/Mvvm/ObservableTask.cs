using System;
using System.Threading.Tasks;
using PeopleSearch.Core.ComponentModel;

namespace PeopleSearch.Wpf.Client.Mvvm
{
    public sealed class ObservableTask<TResult> : PropertyChangedNotifier
    {
        #region Public Properties

        public Task<TResult> Task { get; }
        public TResult Result => (Task.Status == TaskStatus.RanToCompletion) ? Task.Result : default(TResult);
        public TaskStatus Status => Task.Status;
        public bool IsCompleted => Task.IsCompleted;
        public bool IsNotCompleted => !Task.IsCompleted;
        public bool IsSuccessfullyCompleted => Task.Status == TaskStatus.RanToCompletion;
        public bool IsCanceled => Task.IsCanceled;
        public bool IsFaulted => Task.IsFaulted;
        public AggregateException Exception => Task.Exception;
        public Exception InnerException => Exception?.InnerException;
        public string ErrorMessage => InnerException?.Message;

        #endregion

        #region Constructors

        public ObservableTask(Task<TResult> task)
        {
            Task = task;
            if (!task.IsCompleted)
            {
                var _ = WatchTaskAsync(task);
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

            RaisePropertyChanged(nameof(Status));
            RaisePropertyChanged(nameof(IsCompleted));
            RaisePropertyChanged(nameof(IsNotCompleted));

            if (task.IsCanceled)
            {
                RaisePropertyChanged(nameof(IsCanceled));
            }
            else if (task.IsFaulted)
            {
                RaisePropertyChanged(nameof(IsFaulted));
                RaisePropertyChanged(nameof(Exception));
                RaisePropertyChanged(nameof(InnerException));
                RaisePropertyChanged(nameof(ErrorMessage));
            }
            else
            {
                RaisePropertyChanged(nameof(IsSuccessfullyCompleted));
                RaisePropertyChanged(nameof(Result));
            }
        }

        #endregion
    }
}
