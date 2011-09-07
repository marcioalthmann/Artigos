using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.Data;

namespace EstudosSimpleData
{
    class Program
    {
        private static dynamic _db;

        static void Main(string[] args)
        {
            _db = Database.OpenFile("SimpleData.sdf");

            AlterarEstiloMusicalComPoco();
            AlterarEstiloMusicalSemPoco();

            LerTodosEstilosMusicais();

            Console.Read();
        }

        static void AlterarEstiloMusicalSemPoco()
        {
            _db.EstiloMusical.UpdateByIdEstiloMusical(IdEstiloMusical: 1, Nome: "Black Metal");
        }

        static void AlterarEstiloMusicalComPoco()
        {
            var estiloMusical = new EstiloMusical
                                    {
                                        IdEstiloMusical = 2,
                                        Nome = "Blues"
                                    };
            _db.EstiloMusical.UpdateByIdEstiloMusical(estiloMusical);
        }

        static void LerTodosEstilosMusicais()
        {
            foreach (var estiloMusical in _db.EstiloMusical.All())
            {
                Console.WriteLine("Id: {0} Nome: {1}", estiloMusical.IdEstiloMusical, estiloMusical.Nome);
            }
        }

        static void IncluirEstiloMusicalSemPoco()
        {
            _db.EstiloMusical.Insert(Nome: "Jazz");
        }

        private static void ObterTodosEstilosMusicais()
        {
            var estilosMusicais = _db.EstiloMusical.All();
            foreach (var estiloMusical in estilosMusicais)
            {
                Console.WriteLine(estiloMusical.Nome);
            }
        }

        static void IncluirEstiloMusicalUtilizandoPoco()
        {
            var estiloMusical = new EstiloMusical
                                    {
                                        Nome = "Death Metal"
                                    };

            _db.EstiloMusical.Insert(estiloMusical);
        }
    }

    public class EstiloMusical
    {
        public int IdEstiloMusical { get; set; }
        public string Nome { get; set; }
    }
}
