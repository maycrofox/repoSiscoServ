using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using Negocio;
using Entidad;

namespace Web_SiscoServ.Consultas
{
    public partial class conEmpresa : System.Web.UI.Page
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
        public static string MostrarEmpresa()
        {
            negEmpresa negEmp = new negEmpresa();
            string json = "";
            try
            {
                List<entEmpresa> listemp = new List<entEmpresa>();
                listemp = negEmp.ListarEmpresa();
                var js = new JavaScriptSerializer();
                json = js.Serialize(listemp);
            }
            catch (Exception e)
            {
                json = e.Message.ToString();
            }
            return json;
        }

        [WebMethod]
        public static string EliminarEmpresa(string id)
        {
            negEmpresa neg = new negEmpresa();
            string result = "";
            try
            {
                string datos = neg.EliminarEmpresa(id);
                var js = new JavaScriptSerializer();
                result = js.Serialize(datos);
            }
            catch (Exception e)
            {
                result = e.Message.ToString();
            }
            return result;
        }

    }
}