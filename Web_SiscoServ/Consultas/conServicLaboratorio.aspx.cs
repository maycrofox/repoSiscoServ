using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Negocio;
using Entidad;
using Newtonsoft.Json;

namespace Web_SiscoServ.Consultas
{
    public partial class conServicLaboratorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sessionIdUser"] != null)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "<script language = 'javascript'>validaAcceso('" + Session["sessionIdUser"].ToString() + "');</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "<script language = 'javascript'>alert('Sesión de usuario está caducada, Intente loguearse nuevamente')</script>");
                Response.Redirect("/default.aspx");
            }
            if (!Page.IsPostBack)
            {
                //  Mostrar();
            }
        }
        [WebMethod]
        public static string MostrarServicLaboratorio()
        {
            negServicLaboratorio negInsum = new negServicLaboratorio();
            string json = "";
            try
            {
                List<entServicLaboratorio> listemp = new List<entServicLaboratorio>();
                listemp = negInsum.ListarServicLaboratorio();
                json = JsonConvert.SerializeObject(listemp);
            }
            catch (Exception e)
            {
                json = e.Message.ToString();
            }
            return json;
        }

        [WebMethod]
        public static string EliminarServicLaboratorio(string id)
        {
            negServicLaboratorio neg = new negServicLaboratorio();
            string result = "";
            try
            {
                string datos = neg.EliminarServicLaboratorio(id);
                result = JsonConvert.SerializeObject(datos);
            }
            catch (Exception e)
            {
                result = e.Message.ToString();
            }
            return result;
        }
    }
}