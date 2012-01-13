using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JQuery.Controllers
{
    public class PlUploadController : Controller
    {
        //
        // GET: /PlUpload/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public void Upload(HttpPostedFileBase file)
        {
            // Lógica para salvar a foto
        }

    }
}
