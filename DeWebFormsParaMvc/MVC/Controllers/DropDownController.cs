using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeWebFormsParaMvc.Dominio;
using MVC.Models;

namespace MVC.Controllers
{
    public class DropDownController : Controller
    {
        //
        // GET: /DropDown/

        public ActionResult Index()
        {
            var autores = new List<Autor>
                              {
                                  new Autor {IdAutor = 1, Nome = "Fiódor Dostoiévski"},
                                  new Autor {IdAutor = 2, Nome = "Friedrich Nietzsche"}
                              };

            return View(new Livraria{Autores = autores});
        }

        public JsonResult ObterLivrosDoAutor(int id)
        {
            var livros = new List<Livro>
                             {
                                 new Livro{IdAutor = 2, IdLivro = 1, Titulo = "O Anticristo"},
                                 new Livro{IdAutor = 2, IdLivro = 2, Titulo = "Assim Falou Zaratustra"},
                                 new Livro{IdAutor = 2, IdLivro = 3, Titulo = "Para Além do Bem e do Mal"},
                                 new Livro{IdAutor = 1, IdLivro = 4, Titulo = "Os Irmãos Karamazov"},
                                 new Livro{IdAutor = 1, IdLivro = 5, Titulo = "O Jogador"},
                                 new Livro{IdAutor = 1, IdLivro = 6, Titulo = "Recordações da Casa dos Mortos"}
                             };

            return Json(livros.Where(l => l.IdAutor == id), JsonRequestBehavior.AllowGet);
        }

    }
}
