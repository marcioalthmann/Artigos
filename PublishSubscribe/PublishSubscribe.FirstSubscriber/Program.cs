using System;
using MassTransit;
using PublishSubscribe.Messages;
using Topshelf;
using Topshelf.Configuration;
using Topshelf.Configuration.Dsl;

namespace PublishSubscribe.FirstSubscriber
{
    class Program
    {
        static void Main(string[] args)
        {

            Bus.Initialize(bus =>
                               {
                                   bus.UseMsmq();
                                   bus.ReceiveFrom(
                                       "msmq://localhost/firstsubscriber");
                                   bus.UseMulticastSubscriptionClient();
                               });

            new Service().Start(Bus.Instance);

            Console.ReadLine();
        }

    }

    public class Service : Consumes<SampleRequest>.All
    {
        private IServiceBus _serviceBus;
        private UnsubscribeAction _unsubscribeToken;

        public Service()
        {

        }

        public void Dispose()
        {
            _serviceBus.Dispose();
        }

        public void Start(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus;
            _unsubscribeToken = _serviceBus.SubscribeInstance(this);
        }

        public void Stop()
        {
            _unsubscribeToken();
        }

        public void Consume(SampleRequest message)
        {
            Console.WriteLine("Mensagem com ID {0} recebida.", message.CorrelationId);
            Console.WriteLine("Enviando resposta...");
            var sampleResponse = new SampleResponse
            {
                CorrelationId= message.CorrelationId,
                Subscriber = "First Subscriber",
                Message =
                    string.Format(
                        "Resposta da mensagem {0}",
                        message.CorrelationId)
            };
            _serviceBus.Publish(sampleResponse);
            Console.WriteLine("Resposta enviada!");
        }
    }
}
