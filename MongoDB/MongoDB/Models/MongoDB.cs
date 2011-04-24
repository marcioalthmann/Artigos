using System;
using System.Linq;
using Norm;

namespace MongoDB.Models
{
    public class MongoDB
    {
        private const string StringDeConexao = "mongodb://localhost/EstudoMongoDB";

        public T Obter<T>(Func<T, bool> expressao) where T : class
        {
            using (var mongo = Mongo.Create(StringDeConexao))
            {
                return mongo.GetCollection<T>().AsQueryable().Where(expressao).SingleOrDefault();
            }
        }

        public IQueryable<T> ObterTodos<T>() where T : class
        {
            using (var mongo = Mongo.Create(StringDeConexao))
            {
                return mongo.GetCollection<T>().AsQueryable();
            }
        }

        public void Incluir<T>(T objeto) where T : class
        {
            using (var mongo = Mongo.Create(StringDeConexao))
            {
                mongo.GetCollection<T>().Insert(objeto);
            }
        }

        public void Excluir<T>(T objeto) where T : class
        {
            using (var mongo = Mongo.Create(StringDeConexao))
            {
                mongo.GetCollection<T>().Delete(objeto);
            }
        }

        public void Salvar<T>(T objeto) where T : class
        {
            using (var mongo = Mongo.Create(StringDeConexao))
            {
                mongo.GetCollection<T>().Save(objeto);
            }
        }
    }
}