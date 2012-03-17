using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using ProtoBuf;

namespace ProtobufTests
{
    class Program
    {
        private const int TotalDeAlbuns = 100000;
        private static readonly List<Album> Albuns = Enumerable.Range(0, TotalDeAlbuns).Select(x => CriarAlbum(x)).ToList(); 

        static void Main(string[] args)
        {
            TestesComProtobufNet();
            TestesComProtobufBinaryFormatter();
            TestesComDataContractSerializer();
            TestesComXmlSerializer();

            Console.Read();
        }

        private static void TestesComProtobufNet()
        {
            var albunsSerializados = new List<byte[]>();
            var albunsDesserializados = new List<Album>();

            Contador.Iniciar();

            foreach (var album in Albuns)
            {
                using (var memoryStream = new MemoryStream())
                {
                    Serializer.Serialize(memoryStream, album);
                    albunsSerializados.Add(memoryStream.ToArray());
                }
            }

            Contador.Parar();

            Console.WriteLine("Serializando {0} objetos com Protobuf-net: {1} ms", TotalDeAlbuns, Contador.TempoTotalEmMilisegundos);

            Contador.Iniciar();

            foreach (var album in albunsSerializados)
            {
                using (var memoryStream = new MemoryStream(album))
                {
                    albunsDesserializados.Add(Serializer.Deserialize<Album>(memoryStream));
                }
            }

            Contador.Parar();
            
            Console.WriteLine("Deserializando {0} objetos com Protobuf-net: {1} ms", TotalDeAlbuns, Contador.TempoTotalEmMilisegundos);
            Console.WriteLine();
        }

        private static void TestesComProtobufBinaryFormatter()
        {
            var albunsSerializados = new List<byte[]>();
            var albunsDesserializados = new List<Album>();

            var binaryFormatter = new BinaryFormatter();

            Contador.Iniciar();

            foreach (var album in Albuns)
            {
                using (var memoryStream = new MemoryStream())
                {
                    binaryFormatter.Serialize(memoryStream, album);
                    albunsSerializados.Add(memoryStream.ToArray());
                }
            }

            Contador.Parar();

            Console.WriteLine("Serializando {0} objetos com BinaryFormatter: {1} ms", TotalDeAlbuns, Contador.TempoTotalEmMilisegundos);

            Contador.Iniciar();

            foreach (var album in albunsSerializados)
            {
                using (var memoryStream = new MemoryStream(album))
                {
                    albunsDesserializados.Add((Album)binaryFormatter.Deserialize(memoryStream));
                }
            }

            Contador.Parar();

            Console.WriteLine("Deserializando {0} objetos com BinaryFormatter: {1} ms", TotalDeAlbuns, Contador.TempoTotalEmMilisegundos);
            Console.WriteLine();
        }

        private static void TestesComDataContractSerializer()
        {
            var albunsSerializados = new List<byte[]>();
            var albunsDesserializados = new List<Album>();

            var dataContractSerializer = new DataContractSerializer(typeof (Album));

            Contador.Iniciar();

            foreach (var album in Albuns)
            {
                using (var memoryStream = new MemoryStream())
                {
                    dataContractSerializer.WriteObject(memoryStream, album);
                    albunsSerializados.Add(memoryStream.ToArray());
                }
            }

            Contador.Parar();

            Console.WriteLine("Serializando {0} objetos com DataContractSerializer: {1} ms", TotalDeAlbuns, Contador.TempoTotalEmMilisegundos);

            Contador.Iniciar();

            foreach (var album in albunsSerializados)
            {
                using (var memoryStream = new MemoryStream(album))
                {
                    albunsDesserializados.Add((Album) dataContractSerializer.ReadObject(memoryStream));
                }
            }

            Contador.Parar();

            Console.WriteLine("Deserializando {0} objetos com DataContractSerializer: {1} ms", TotalDeAlbuns, Contador.TempoTotalEmMilisegundos);
            Console.WriteLine();
        }

        private static void TestesComXmlSerializer()
        {
            var albunsSerializados = new List<byte[]>();
            var albunsDesserializados = new List<Album>();

            var xmlSerializer = new XmlSerializer(typeof (Album));

            Contador.Iniciar();

            foreach (var album in Albuns)
            {
                using (var memoryStream = new MemoryStream())
                {
                    xmlSerializer.Serialize(memoryStream, album);
                    albunsSerializados.Add(memoryStream.ToArray());
                }
            }

            Contador.Parar();

            Console.WriteLine("Serializando {0} objetos com XmlSerializer: {1} ms", TotalDeAlbuns, Contador.TempoTotalEmMilisegundos);

            Contador.Iniciar();

            foreach (var album in albunsSerializados)
            {
                using (var memoryStream = new MemoryStream(album))
                {
                    albunsDesserializados.Add((Album)xmlSerializer.Deserialize(memoryStream));
                }
            }

            Contador.Parar();

            Console.WriteLine("Deserializando {0} objetos com XmlSerializer: {1} ms", TotalDeAlbuns, Contador.TempoTotalEmMilisegundos);
            Console.WriteLine();
        }

        private static Album CriarAlbum(int numeroDoAlbum)
        {
            return new Album {AnoDeLancamento = numeroDoAlbum, Titulo = numeroDoAlbum.ToString()};
        }
    }

    class Contador
    {
        private static int _tempoInicial;
        private static int _tempoFinal;

        public static void Iniciar()
        {
            _tempoInicial = Environment.TickCount;
        }

        public static void Parar()
        {
            _tempoFinal = Environment.TickCount;
        }

        public static int TempoTotalEmMilisegundos
        {
            get { return _tempoFinal - _tempoInicial; }
        }
    }

    [Serializable]
    [DataContract]
    public class Album
    {
        [DataMember]
        public string Titulo { get; set; }

        [DataMember]
        public int AnoDeLancamento { get; set; }
    }

}
