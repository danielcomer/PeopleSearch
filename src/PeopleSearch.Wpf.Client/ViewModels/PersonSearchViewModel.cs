using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using PeopleSearch.Data.Entity;
using PeopleSearch.Data.Entity.Model;
using PeopleSearch.Wpf.Client.Mvvm;

namespace PeopleSearch.Wpf.Client.ViewModels
{
    public class PersonSearchViewModel : ViewModelBase, IPersonSearchViewModel
    {
        #region Members

        private readonly IPeopleServiceContext _dbContext;
        private readonly IObservableTaskFactory _taskFactory;
        private CancellationTokenSource _queryCancellationTokenSource;
         
        private IObservableTask<IList<Person>> _people;

        #endregion Members

        #region Properties

        public IObservableTask<IList<Person>> People
        {
            get { return _people; }
            private set { SetBackingMemberValue(ref _people, value); }
        }

        #endregion Properties

        #region Commmands

        public ICommand SearchByName { get; }

        #endregion

        #region Constructors

        public PersonSearchViewModel(IPeopleServiceContext dbContext, IObservableTaskFactory taskFactory)
        {
            _dbContext = dbContext;
            _taskFactory = taskFactory;

            SearchByName = new RelayCommand<string>(ExecuteSearchByName);

            ExecuteSearchByName();
        }

        #endregion

        #region Methods

        #region Private

        private void ExecuteSearchByName(string personName = null)
        {
            Task.Run(() =>
            {
                if (_queryCancellationTokenSource == null) return;

                _queryCancellationTokenSource.Cancel();
                _queryCancellationTokenSource.Token.WaitHandle.WaitOne();
            })
            .ContinueWith(async task =>
            {
                await task;

                _queryCancellationTokenSource?.Dispose();
                _queryCancellationTokenSource = new CancellationTokenSource();

                People = _taskFactory.Create(CreateQuery(personName).ToListAsync(_queryCancellationTokenSource.Token));
            });
        }

        private IQueryable<Person> CreateQuery(string personName = null)
        {
            var query = _dbContext.People.Include(p => p.HomeAddress);

            if (!string.IsNullOrEmpty(personName))
            {
                query = query.Where(p =>
                    p.FirstName.ToUpper().Contains(personName.ToUpper()) ||
                    p.LastName.ToUpper().Contains(personName.ToUpper()));
            }

            return query;
        }

        #endregion Private

        #endregion Methods
    }
}
