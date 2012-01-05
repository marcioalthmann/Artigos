using System;
using System.IO;
using MassTransit;
using PublishSubscribe.Messages;
using Topshelf;
using Topshelf.Configuration;
using Topshelf.Configuration.Dsl;
using log4net;
using log4net.Config;

namespace PublishSubscribe.Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            Bus.Initialize(bus =>
                               {
                                   bus.UseMsmq();
                                   bus.ReceiveFrom(
                                       "msmq://localhost/publisher");
                                   bus.UseMulticastSubscriptionClient();
                               });

            new Service().Start(Bus.Instance);

            Console.ReadLine();
        }

    }

    public class Service : Consumes<SampleResponse>.All
    {
        private IServiceBus _serviceBus;
        private UnsubscribeAction _unsubscribeToken;


        public void Dispose()
        {
            _serviceBus.Dispose();
        }

        public void Start(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus;
            _unsubscribeToken = _serviceBus.SubscribeInstance(this);

            while (true)
            {
                Console.WriteLine("Escreva uma mensagem: ");
                var message = Console.ReadLine();
                if (message == "exit")
                    break;

                var sampleMessage = new SampleRequest
                                        {
                                            Message = message
                                        };
                _serviceBus.Publish(sampleMessage);
            }
        }

        public void Stop()
        {
            _unsubscribeToken();
        }

        public void Consume(SampleResponse message)
        {
            Console.WriteLine("Resposta do da mensagem com ID {0} recebida:", message.CorrelationId);
            Console.WriteLine("Quem respondeu: {0}", message.Subscriber);
            Console.WriteLine("Mensagem de resposta: {0}", message.Message);
        }
    }
}
