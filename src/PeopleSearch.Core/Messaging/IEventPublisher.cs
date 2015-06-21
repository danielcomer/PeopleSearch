using System;

namespace PeopleSearch.Core.Messaging
{
    public interface IEventPublisher
    {
        void Publish<TEvent>(TEvent sampleEvent) where TEvent : IEvent;
        IObservable<TEvent> GetEvent<TEvent>() where TEvent : IEvent;
    }
}
