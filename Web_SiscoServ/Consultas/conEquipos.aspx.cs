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
using Newtonsoft.Json;

namespace Web_SiscoServ.Consultas
{
    public partial class conEquipos : System.Web.UI.Page
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
        public static string MostrarEquipo()
        {
            negEquipo negEmp = new negEquipo();
            string json = "";
            try
            {
                List<entEquipos> listemp = new List<entEquipos>();
                listemp = negEmp.ListarEquipos();
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
        public static string EliminarEquipo(string id)
        {
            negEquipo neg = new negEquipo();
            string result = "";
            try
            {
                string datos = neg.EliminarEquipos(id);
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