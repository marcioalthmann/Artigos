using System.Collections.Generic;

namespace DeWebFormsParaMvc.Dominio
{
    public class RepositorioDeEstiloMusical
    {
        public IList<EstiloMusical> ObterTodos()
        {
            return new List<EstiloMusical>
                       {
                           new EstiloMusical {Id = 1, Nome = "Heavy Metal"},
                           new EstiloMusical {Id = 2, Nome = "Death Metal"},
                           new EstiloMusical {Id = 3, Nome = "Black Metal"},
                           new EstiloMusical {Id = 4, Nome = "Jazz"},
                           new EstiloMusical {Id = 5, Nome = "Blues"},
                           new EstiloMusical {Id = 6, Nome = "Música Clássica"}
                       };
        }
    }
}