using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class Autor
    {
        public int IdAutor { get; set; }
        public string Nome { get; set; }
    }

    public class Livraria
    {
        public List<Autor> Autores { get; set; }
    }
}