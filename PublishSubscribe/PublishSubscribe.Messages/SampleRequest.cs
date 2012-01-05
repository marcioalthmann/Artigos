using System;
using MassTransit;

namespace PublishSubscribe.Messages
{
    public class SampleRequest
    {
        public SampleRequest()
        {
            CorrelationId = Guid.NewGuid();
        }

        public Guid CorrelationId { get; private set; }
        public string Message { get; set; }
    }
}
