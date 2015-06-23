using System;

namespace PeopleSearch.Core.Infrastructure
{
    public interface IEventAggregator
    {
        void Publish<TEvent>(TEvent sampleEvent) where TEvent : IEvent;
        IObservable<TEvent> GetEvent<TEvent>() where TEvent : IEvent;
    }
}
