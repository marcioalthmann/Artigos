using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Models;
using Norm.BSON.DbTypes;

namespace MongoDB.Testes
{
    [TestClass]
    public class EstiloMusicalTestes
    {
        [Ignore]
        [TestMethod]
        public void IncluiUmNovoEstiloMusical()
        {
            var estiloMusical = new EstiloMusical
            {
                Nome = "Heavy Metal",
                Descricao = "Heavy Metal"
            };

            var mongoDb = new Models.MongoDB();
            mongoDb.Incluir(estiloMusical);

            Assert.IsNotNull(estiloMusical.Id);
        }

        [Ignore]
        [TestMethod]
        public void IncluiUmNovoAlbum()
        {
            var mongoDb = new Models.MongoDB();
            var estiloMusical = mongoDb.Obter<EstiloMusical>(e => e.Nome == "Heavy Metal");

            var album = new Album
                            {
                                EstiloMusical = new DbReference<EstiloMusical>(estiloMusical.Id),
                                Nome = "Powerslave"
                            };

            mongoDb.Incluir(album);

            Assert.IsNotNull(album.IdAlbum);
        }

        [TestMethod]
        public void ObterOAlbumPowerslave()
        {
            var mongoDb = new Models.MongoDB();

            var album = mongoDb.Obter<Album>(a => a.Nome == "Powerslave");
            var estilo = mongoDb.Obter<EstiloMusical>(e => e.Id == album.EstiloMusical.Id);

            Assert.AreEqual("Powerslave", album.Nome);
            Assert.AreEqual("Heavy Metal", estilo.Nome);
        }
    }
}
