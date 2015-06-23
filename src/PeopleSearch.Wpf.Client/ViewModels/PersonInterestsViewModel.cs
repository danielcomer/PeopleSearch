using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PeopleSearch.Core.Infrastructure;
using PeopleSearch.Data.Entity;
using PeopleSearch.Data.Entity.Model;
using PeopleSearch.Wpf.Client.Mvvm;
using PeopleSearch.Wpf.Client.ViewModels.Events;

namespace PeopleSearch.Wpf.Client.ViewModels
{
    public class PersonInterestsViewModel : ViewModelBase, IPersonInterestsViewModel, IDisposable
    {
        #region Members

        private readonly IEnumerable<IDisposable> _subscriptions;
        private IObservableTask<List<Interest>> _interests;
        private readonly IPeopleServiceContext _dbContext;
        private readonly IObservableTaskFactory _taskFactory;
        private CancellationTokenSource _queryCancellationTokenSource;

        #endregion Members

        #region Properties

        public IObservableTask<List<Interest>> Interests
        {
            get { return _interests; }
            private set { SetBackingMemberValue(ref _interests, value); }
        }

        #endregion Properties

        #region Constructors

        public PersonInterestsViewModel(IPeopleServiceContext dbContext, IObservableTaskFactory taskFactory, IEventAggregator aggregator)
        {
            _dbContext = dbContext;
            _taskFactory = taskFactory;

            _subscriptions = new []
            {
                aggregator.GetEvent<PersonSelected>().Subscribe(HandlePersonSelected)
            };
        }

        #endregion Constructors

        #region Event Handlers

        private void HandlePersonSelected(PersonSelected @event)
        {
            if (@event.Person == null)
            {
                Interests = null;
            }
            else
            {
                ExecuteLoadInterests(@event.Person.Id);
            }
        }

        #endregion

        #region Methods

        #region Private

        private async Task ExecuteLoadInterests(int personId)
        {
            if (_queryCancellationTokenSource != null)
            {
                _queryCancellationTokenSource.Cancel();
                _queryCancellationTokenSource.Dispose();
            }

            if (Interests?.TheTask != null)
            {
                await Interests?.TheTask;
                Interests?.TheTask?.Dispose();
            }

            _queryCancellationTokenSource = new CancellationTokenSource();

            Interests = _taskFactory.Create(CreateQuery(personId).ToListAsync(_queryCancellationTokenSource.Token));
        }

        private IQueryable<Interest> CreateQuery(int personId)
        {
            var interestsQuery =
                _dbContext.Interests
                    .Where(i => i.People.Select(p => p.Id).Contains(personId));

            return interestsQuery;
        }

        #endregion 

        public void Dispose()
        {
            Interests?.TheTask?.Dispose();

            foreach (var subscription in _subscriptions)
            {
                subscription.Dispose();
            }
        }

        #endregion Methods
    }
}
