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
    public partial class conLaboratorio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //  Mostrar();
            }
            if (Session["sessionIdUser"] != null)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "<script language = 'javascript'>validaAcceso('" + Session["sessionIdUser"].ToString() + "');</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "<script language = 'javascript'>alert('Sesión de usuario está caducada, Intente loguearse nuevamente')</script>");
                Response.Redirect("/default.aspx");
            }
        }
        [WebMethod]
        public static string MostrarLaboratorio()
        {
            negLaboratorio negInsum = new negLaboratorio();
            string json = "";
            try
            {
                List<entLaboratorio> listemp = new List<entLaboratorio>();
                listemp = negInsum.ListarLaboratorio();
                json = JsonConvert.SerializeObject(listemp);
            }
            catch (Exception e)
            {
                json = e.Message.ToString();
            }
            return json;
        }

        [WebMethod]
        public static string EliminarLaboratorio(string id)
        {
            negLaboratorio neg = new negLaboratorio();
            string result = "";
            try
            {
                string datos = neg.EliminarLaboratorio(id);
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