using System;

namespace SingletonComIoC
{
    public class Configuracoes
    {
        public DateTime DataDeCriacao { get; private set; }

        public Configuracoes()
        {
            DataDeCriacao = DateTime.Now;
        }
    }
}