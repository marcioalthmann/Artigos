using System;
using MassTransit;

namespace RequestResponse.Messages
{
    public class SolicitarCalculoSalario : CorrelatedBy<Guid>
    {
        public Guid CorrelationId { get; set; }
        public int IdFuncionario { get; set; }

        public SolicitarCalculoSalario()
        {
            CorrelationId = Guid.NewGuid();
        }
    }
}
