using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using System.Web.Services;
using Negocio;
using Entidad;
using Newtonsoft.Json;

namespace Web_SiscoServ.Consultas
{
    public partial class conConsumo : System.Web.UI.Page
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
        public static string MostrarConsumos()
        {
            negConsumos negInsum = new negConsumos();
            string json = "";
            try
            {
                List<entConsumos> listemp = new List<entConsumos>();
                listemp = negInsum.ListarConsumos();
                json = JsonConvert.SerializeObject(listemp);
                //var js = new JavaScriptSerializer();
                //json = js.Serialize(listemp);
            }
            catch (Exception e)
            {
                json = e.Message.ToString();
            }
            return json;
        }

        [WebMethod]
        public static string EliminarConsumos(string id)
        {
            negConsumos neg = new negConsumos();
            string result = "";
            try
            {
                string datos = neg.EliminarConsumos(id);
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