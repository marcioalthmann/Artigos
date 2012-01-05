using System;
using MassTransit;

namespace PublishSubscribe.Messages
{
    public class SampleResponse
    {
        public Guid CorrelationId { get; set; }
        public string Subscriber { get; set; }
        public string Message { get; set; }
    }
}