using System;
using System.Threading.Tasks;

namespace PeopleSearch.Wpf.Client.Mvvm
{
    public class DefaultObservableTaskFactory : IObservableTaskFactory
    {
        private readonly TimeSpan? _simulatedDelay;

        public DefaultObservableTaskFactory(TimeSpan? simulatedDelay)
        {
            

            _simulatedDelay = simulatedDelay;
        }

        public IObservableTask<TResult> Create<TResult>(Task<TResult> theTask)
        {
            return new ObservableTask<TResult>(theTask, _simulatedDelay);
        }
    }
}
