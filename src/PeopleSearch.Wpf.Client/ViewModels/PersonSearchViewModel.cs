using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using PeopleSearch.Core.Infrastructure;
using PeopleSearch.Data.Entity;
using PeopleSearch.Data.Entity.Model;
using PeopleSearch.Wpf.Client.Mvvm;
using PeopleSearch.Wpf.Client.ViewModels.Events;

namespace PeopleSearch.Wpf.Client.ViewModels
{
    public class PersonSearchViewModel : ViewModelBase, IPersonSearchViewModel, IDisposable
    {
        #region Members

        private readonly IPeopleServiceContext _dbContext;
        private readonly IObservableTaskFactory _taskFactory;
        private readonly IEventAggregator _aggregator;
        private CancellationTokenSource _queryCancellationTokenSource;
         
        private IObservableTask<IList<Person>> _people;
        private Person _selectedPerson;

        #endregion Members

        #region Properties

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set { SetBackingMemberValue(ref _selectedPerson, value);}
        }

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

        public PersonSearchViewModel(IPeopleServiceContext dbContext, IObservableTaskFactory taskFactory, IEventAggregator aggregator)
        {
            _dbContext = dbContext;
            _taskFactory = taskFactory;
            _aggregator = aggregator;

            SearchByName = new RelayCommand<string>(ExecuteSearchByName);
            
            ExecuteSearchByName();
        }

        #endregion

        #region Methods

        #region Overrides

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(SelectedPerson))
            {
                _aggregator.Publish(new PersonSelected(SelectedPerson));
            }
        }

        #endregion Overrides

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

        #region Public

        public void Dispose()
        {
            _queryCancellationTokenSource?.Dispose();
        }

        #endregion Public

        #endregion Methods


    }
}
