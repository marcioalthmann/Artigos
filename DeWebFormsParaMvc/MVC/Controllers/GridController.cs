using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DeWebFormsParaMvc.Dominio;

namespace MVC.Controllers
{
    public class GridController : Controller
    {
        //
        // GET: /Grid/

        public ActionResult Index()
        {
            var repositorio = new RepositorioDeEstiloMusical();
            return View(repositorio.ObterTodos());
        }

    }
}
