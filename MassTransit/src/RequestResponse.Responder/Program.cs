using System;
using MassTransit;
using RequestResponse.Messages;

namespace RequestResponse.Responder
{
    class Program
    {
        static void Main(string[] args)
        {
            Bus.Initialize(sbc =>
                               {
                                   sbc.UseMsmq();
                                   sbc.VerifyMsmqConfiguration();
                                   sbc.UseMulticastSubscriptionClient();
                                   sbc.ReceiveFrom("msmq://localhost/responser");
                                   sbc.Subscribe(subs => subs.Handler<SolicitarCalculoSalario>(
                                       msg =>
                                           {
                                               Console.WriteLine("Solicitação {0} recebida, iniciando calculo do funcionário {1}", 
                                                   msg.CorrelationId, msg.IdFuncionario);

                                               var resposta = new RespostaCalculoSalario
                                                                  {
                                                                      CorrelationId = msg.CorrelationId,
                                                                      Salario =
                                                                          (decimal)
                                                                          (msg.IdFuncionario*DateTime.Now.Millisecond*
                                                                           3.14)
                                                                  };

                                               Console.WriteLine("Enviando resposta");
                                               Bus.Instance.MessageContext<SolicitarCalculoSalario>().Respond(resposta);
                                           }));
                               });

            Console.WriteLine("Aguardando mensagens");
            Console.Read();
        }
    }
}
