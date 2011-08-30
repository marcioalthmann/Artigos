using System;
using Magnum.Extensions;
using MassTransit;
using RequestResponse.Messages;

namespace RequestResponse.Requester
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
                                   sbc.ReceiveFrom("msmq://localhost/requester");
                               });

            Console.WriteLine("Informe o ID do funcionário para calcular o salário:");
            var idFuncionario = 0;
            int.TryParse(Console.ReadLine(), out idFuncionario);

            while (idFuncionario != -1)
            {
                Bus.Instance.PublishRequest(
                    new SolicitarCalculoSalario { IdFuncionario = idFuncionario },
                    callBack =>
                    {
                        callBack.Handle<RespostaCalculoSalario>(message =>
                                                      {
                                                          Console.WriteLine("Resposta da Mensagem {0} recebida", message.CorrelationId);
                                                          Console.WriteLine("Salario: {0}", message.Salario);
                                                      });
                        callBack.SetTimeout(10.Seconds());
                    });

                int.TryParse(Console.ReadLine(), out idFuncionario);
            }
        }
    }
}
