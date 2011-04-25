using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DeWebFormsParaMvc.Dominio;

namespace WebForms
{
    public partial class Grid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                var repositorio = new RepositorioDeEstiloMusical();
                EstilosMusicais.DataSource = repositorio.ObterTodos();
                EstilosMusicais.DataBind();
            }
        }
    }
}