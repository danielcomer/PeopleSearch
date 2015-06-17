using System;
using System.Threading.Tasks;

namespace PeopleSearch.ViewModel
{
    public class FakeObservableTask<TResult>
    {
        public TResult Result { get; set; }
        public TaskStatus Status { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsNotCompleted { get; set; }
        public bool IsSuccessfullyCompleted { get; set; }
        public bool IsCanceled { get; set; }
        public bool IsFaulted { get; set; }
        public AggregateException Exception { get; set; }
        public Exception InnerException { get; set; }
        public string ErrorMessage { get; set; }
    }
}
