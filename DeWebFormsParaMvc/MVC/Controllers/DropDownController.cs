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
                                  new Autor {IdAutor = 1, Nome = "Friedrich Nietzsche"}
                              };

            return View(new Livraria{Autores = autores});
        }

    }
}
