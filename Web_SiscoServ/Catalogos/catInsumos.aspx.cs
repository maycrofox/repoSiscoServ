using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidad;
using System.Web.Services;
using System.Web.Script.Serialization;
using Newtonsoft.Json;


namespace Web_SiscoServ.Catalogos
{
    public partial class catInsumos : System.Web.UI.Page
    {
        negInsumos negIns = new negInsumos();
        entInsumos entIns = new entInsumos();
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
                MostrarEmpresa();
                txtNombre.Focus();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                entIns.id_empresa_ = Convert.ToInt16(cmbEmp.SelectedItem.Value);
                entIns.Nombre_ = txtNombre.Text;
                entIns.Descripcion_ = txtDescripcion.Text;
                entIns.Precio_ = Convert.ToDouble(txtPrecio.Text);

                if (negIns.InsertarEquipo(entIns) == true)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "<script language = 'javascript'>alert('Los datos se almacenaron correctamente')</script>");
                    // Response.Redirect("/Catalogos/catClientes.aspx");   
                    Limpiar();
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "<script language = 'javascript'>alert('Error, verifique que los datos sean correctos o se tenga acceso a la BD.')</script>");
                }
            }
            catch (Exception exc)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "<script language = 'javascript'>alert('Error, notifique a su administrador del sistema')</script>");
            }  
        }

        public void MostrarEmpresa()
        {
            negEmpresa negEmp = new negEmpresa();
            try
            {
                List<entEmpresa> listemp = new List<entEmpresa>();
                listemp = negEmp.ListarEmpresa();
                ListItem item;
                foreach (entEmpresa entEmp in listemp)
                {
                    item = new ListItem(entEmp.Nombre_, Convert.ToString(entEmp.id_empresa_));
                    cmbEmp.Items.Add(item);
                }
            }
            catch (Exception e)
            {
                //json = e.Message.ToString();
            }
        }

        [WebMethod]
        public static string MostrarConsumoServicios(string idservicio)
        {
            negInsumos negInsum = new negInsumos();
            string json = "";
            try
            {
                List<entConsumos> listemp = new List<entConsumos>();
                listemp = negInsum.ConsumosServicios(idservicio);               
                json = JsonConvert.SerializeObject(listemp);
            }
            catch (Exception e)
            {
                json = e.Message.ToString();
            }
            return json;
        }

        [WebMethod]
        public static string MostrarMaterialConsumos(string idempresa)
        {
            negInsumos negInsum = new negInsumos();
            string json = "";
            try
            {
                List<entConsumos> listemp = new List<entConsumos>();
                listemp = negInsum.MostrarMaterialConsumos(idempresa);
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
        public static string GuardaServicioConsumo(string idservicio, string idconsumo, string cantidad)
        {
            negInsumos negInsum = new negInsumos();
            string json = "";
            try
            {
                List<entInsumos> listemp = new List<entInsumos>();
                listemp = negInsum.AlmacenaServConsumo(idservicio, idconsumo, cantidad);
                var js = new JavaScriptSerializer();
                json = js.Serialize(listemp);
            }
            catch (Exception e)
            {
                json = e.Message.ToString();
            }
            return json;
        }


        private void Limpiar()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";           
            txtPrecio.Text = "0";
            txtNombre.Focus();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

    }
}