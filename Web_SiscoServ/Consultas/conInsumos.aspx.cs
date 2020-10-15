using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.Script.Serialization;
using System.Web.Services;
using Negocio;
using Entidad;

namespace Web_SiscoServ.Consultas
{
    public partial class conInsumos : System.Web.UI.Page
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
        public static string MostrarInsumos()
        {
            negInsumos negInsum = new negInsumos();
            string json = "";
            try
            {
                List<entInsumos> listemp = new List<entInsumos>();
                listemp = negInsum.ListarInsumos();
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
        public static string EliminarInsumos(string id)
        {
            negInsumos neg = new negInsumos();
            string result = "";
            try
            {
                string datos = neg.EliminarInsumos(id);
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