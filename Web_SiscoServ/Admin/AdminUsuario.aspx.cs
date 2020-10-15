using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Negocio;
using Entidad;
using System.Text;
using System.Web.Script.Serialization;

namespace Web_SiscoServ.Admin
{
    public partial class AdminUsuario : System.Web.UI.Page
    {
        negAdminUsu neg = new negAdminUsu();
        entAdminUsu ent = new entAdminUsu();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MostrarColaborador();
            }
        }
        public void MostrarColaborador()
        {
            negColaborador negColab = new negColaborador();
            try
            {
                List<entColaborador> listcolab = new List<entColaborador>();
                listcolab = negColab.ListarColaborador();
                ListItem item;
                foreach (entColaborador entColab in listcolab)
                {
                    item = new ListItem(entColab.Nombre_, Convert.ToString(entColab.id_colaborador_));
                    cmbColaborador.Items.Add(item);
                }
            }
            catch (Exception e)
            {
                var err = e.Message;
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "<script language = 'javascript'>alert('" + err.ToString() + "')</script>");
            }
        }

        [WebMethod]
        public static string MostrarAccesos(string id)
        {
            if (id == "0") return "";
            negAdminUsu neg = new negAdminUsu();
            string json = "";
            try
            {
                List<entAdminUsu> listemp = new List<entAdminUsu>();
                listemp = neg.ListarAdminUsu(id);
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
        public static string AlmacenaDatosAcceso(string idcatMenu, string activo, string idcolaborador)
        {           
            negAdminUsu neg = new negAdminUsu();
            string json = "";
            try
            {
                string res = "";
                res = neg.Insertar(idcatMenu, activo, idcolaborador);
                var js = new JavaScriptSerializer();
                json = js.Serialize(res);
            }
            catch (Exception e)
            {
                json = e.Message.ToString();
            }
            return json;
        }

         [WebMethod]
         public static string ActualizaColaboradorActivo(string idcolaborador, string activo)
         {
             negAdminUsu neg = new negAdminUsu();
             string json = "";
             try
             {
                 string res = "";
                 res = neg.ActualizaColaboradorActivo(idcolaborador, activo);
                 var js = new JavaScriptSerializer();
                 json = js.Serialize(res);
             }
             catch (Exception e)
             {
                 json = e.Message.ToString();
             }
             return json;
         }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string id = cmbColaborador.SelectedItem.Value;
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "<script language = 'javascript'> MostrarAccesos('" + id + "'); </script>");

        }
       

    }
}