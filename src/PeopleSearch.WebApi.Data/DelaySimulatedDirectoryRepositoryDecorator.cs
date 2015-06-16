using System;
using System.Collections.Generic;
using System.Threading;
using PeopleSearch.WebApi.Data.Entities;

namespace PeopleSearch.WebApi.Data
{
    public class DelaySimulatedDirectoryRepositoryDecorator : IDirectoryRepository
    {
        private readonly IDirectoryRepository _decoratedRepository;
        private readonly TimeSpan _delay;

        public DelaySimulatedDirectoryRepositoryDecorator(IDirectoryRepository decoratedRepository,
            int delayInMilliseconds)
            : this(decoratedRepository, TimeSpan.FromMilliseconds(delayInMilliseconds))
        {
        }

        public DelaySimulatedDirectoryRepositoryDecorator(IDirectoryRepository decoratedRepository, TimeSpan delay)
        {
            _decoratedRepository = decoratedRepository;
            _delay = delay;
        }

        public IEnumerable<Person> GetAllPeople()
        {
            Thread.Sleep(_delay);
            return _decoratedRepository.GetAllPeople();
        }

        public Person GetPerson(int personId)
        {
            Thread.Sleep(_delay);
            return _decoratedRepository.GetPerson(personId);
        }

        public Person AddPerson(Person person)
        {
            Thread.Sleep(_delay);
            return _decoratedRepository.AddPerson(person);
        }

        public bool DeletePerson(int personId)
        {
            Thread.Sleep(_delay);
            return _decoratedRepository.DeletePerson(personId);
        }
    }
}
