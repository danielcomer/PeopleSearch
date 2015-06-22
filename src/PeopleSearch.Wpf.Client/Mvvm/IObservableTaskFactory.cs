using System.Threading.Tasks;

namespace PeopleSearch.Wpf.Client.Mvvm
{
    public interface IObservableTaskFactory
    {
        IObservableTask<TResult> Create<TResult>(Task<TResult> theTask);
    }
}
