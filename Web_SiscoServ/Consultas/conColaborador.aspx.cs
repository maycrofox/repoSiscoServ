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
    public partial class conColaborador : System.Web.UI.Page
    {
        negColaborador negColab = new negColaborador();
        entColaborador entColab = new entColaborador();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              //  MostrarColaborador();
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
        public static string MostrarColaborador()
        {
            negColaborador negColab = new negColaborador();
            string json="";
            try
            {
              List<entColaborador> listcolab = new List<entColaborador>();
                listcolab= negColab.ListarColaborador();
                json = JsonConvert.SerializeObject(listcolab);
                //var js = new JavaScriptSerializer();                //Context.Response.Write(js.Serialize(listcolab));
                //json = js.Serialize(listcolab);                          
            }
            catch (Exception e)
            {
                json = e.Message.ToString(); 
            }
            return json;    
        }

       [WebMethod]
       public static string EliminarColaborador(string id)
       {
           negColaborador negColab = new negColaborador();
           string result = "";          
           try
           {
               string datos = negColab.EliminarColaborador(id);
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