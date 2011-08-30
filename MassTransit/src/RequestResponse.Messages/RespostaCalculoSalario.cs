using System;
using MassTransit;

namespace RequestResponse.Messages
{
    public class RespostaCalculoSalario : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; set; }
        public decimal Salario { get; set; }
    }
}