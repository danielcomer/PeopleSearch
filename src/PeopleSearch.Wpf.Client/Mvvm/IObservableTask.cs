using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace PeopleSearch.Wpf.Client.Mvvm
{
    public interface IObservableTask<TResult> : INotifyPropertyChanged
    {
        Task<TResult> TheTask { get; }
        TResult Result { get; }
        TaskStatus Status { get; }
        bool IsCompleted { get; }
        bool IsNotCompleted { get; }
        bool IsSuccessfullyCompleted { get; }
        bool IsCanceled { get; }
        bool IsFaulted { get; }
        AggregateException Exception { get; }
        Exception InnerException { get; }
        string ErrorMessage { get; }
    }
}
