using System;
using PeopleSearch.Core.Messaging;
using Xunit;

namespace PeopleSearch.Core.UnitTests.Messaging
{
    internal class SampleEvent : IEvent
    {
        public int SampleProperty { get; set; }
    }


    public class DefaultEventPublisherTests
    {
        //[Theory]
        //[InlineData(typeof(SampleEvent), true)]
        //public void SubscribeTheory(Type eventTypeToPublish, bool expectedResult)
        //{
        //    var eventWasRaised = false;
        //    var eventPublisher = new DefaultEventPublisher();

        //    using (eventPublisher.GetEvent<IEvent>().Subscribe(se => eventWasRaised = true))
        //    {
        //        eventPublisher.Publish(Activator.CreateInstance(eventTypeToPublish) as IEvent);
        //    }

        //    Assert.Equal(eventWasRaised, expectedResult);
        //}

        [Fact]
        public void Subscribe_EventIsHandled_WhenPublisherPublishesCorrectEventType()
        {
            var eventWasRaised = false;

            var eventPublisher = new DefaultEventPublisher();

            eventPublisher.GetEvent<SampleEvent>().Subscribe(se => eventWasRaised = true);

            eventPublisher.Publish(new SampleEvent());

            Assert.True(eventWasRaised);
        }

    }
}
