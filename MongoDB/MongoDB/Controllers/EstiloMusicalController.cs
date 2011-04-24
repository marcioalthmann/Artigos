using System.Web.Mvc;
using MongoDB.Models;
using Norm;

namespace MongoDB.Controllers
{
    public class EstiloMusicalController : Controller
    {
        private Models.MongoDB mongoDb = new Models.MongoDB();

        //
        // GET: /EstiloMusical/

        public ActionResult Index()
        {
            return View(mongoDb.ObterTodos<EstiloMusical>());
        }

        //
        // GET: /EstiloMusical/Incluir

        public ActionResult Incluir()
        {
            return View();
        }

        //
        // POST: /EstiloMusical/Incluir

        [HttpPost]
        public ActionResult Incluir(EstiloMusical estiloMusical)
        {
            try
            {
                // TODO: Add insert logic here
                mongoDb.Incluir(estiloMusical);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /EstiloMusical/Editar/1

        public ActionResult Editar(ObjectId id)
        {
            return View(mongoDb.Obter<EstiloMusical>(e => e.Id.Equals(id)));
        }

        //
        // POST: /EstiloMusical/Editar/1

        [HttpPost]
        public ActionResult Editar(EstiloMusical estiloMusical)
        {
            try
            {
                // TODO: Add update logic here
                mongoDb.Salvar(estiloMusical);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /EstiloMusical/Excluir/1

        public ActionResult Excluir(ObjectId id)
        {
            return View(mongoDb.Obter<EstiloMusical>(e => e.Id.Equals(id)));
        }

        //
        // POST: /EstiloMusical/Excluir/1

        [HttpPost]
        public ActionResult Excluir(EstiloMusical estiloMusical)
        {
            try
            {
                // TODO: Add delete logic here
                mongoDb.Excluir(estiloMusical);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}