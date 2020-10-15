using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidad;
using System.Text;
using System.Web.Script.Serialization;

namespace Web_SiscoServ.Catalogos
{
    public partial class catEquipos : System.Web.UI.Page
    {
        negEquipo negEq = new negEquipo();
        entEquipos entEq = new entEquipos();
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
                txtFechaAdquisicion.Text = DateTime.Now.ToString("dd/MM/yyyy");
                MostrarEmpresa();
                txtNombre.Focus();
            } 
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {            
            try
            {
                entEq.id_empresa_ = Convert.ToInt16(cmbEmp.SelectedItem.Value);
                entEq.Nombre_ = txtNombre.Text;
                entEq.Descripcion_ = txtDescripcion.Text;
                entEq.NumInventario_ = txtNumInventario.Text;
                entEq.FechaAdquisicion_ = Convert.ToDateTime(txtFechaAdquisicion.Text);
                entEq.Precio_ = Convert.ToDouble(txtPrecio.Text);
                entEq.Estatus_ = cmbEstatus.Text;
                string Result = negEq.InsertarEquipo(entEq);

                if (Result == "true")
                {
                    Limpiar();
                    Label1.Text = "Almacenado Correctamente..";
                }
                else
                {
                    Label1.Text = Result.ToString();
                }
            }
            catch (Exception exc)
            {
                Label1.Text = "Error, " + exc.Message.ToString();
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
                 foreach(entEmpresa entEmp in listemp)
                 {
                     item = new ListItem(entEmp.Nombre_, Convert.ToString(entEmp.id_empresa_));
                    cmbEmp.Items.Add(item);                         
                 }                                  
            }
            catch (Exception e)
            {
                Label1.Text = "Error, " + e.Message.ToString();
                //json = e.Message.ToString();
            }         
        }

        private void Limpiar()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtNumInventario.Text = "";
            txtFechaAdquisicion.Text = DateTime.Now.ToString("dd/MM/yyyy");
            cmbEstatus.Text = "";
            txtPrecio.Text = "0";
            Label1.Text = "";
            txtNombre.Focus();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                List<entEquipos> listcolab = new List<entEquipos>();
                listcolab = negEq.BuscaEquipo(txtNombre.Text.ToString());

                foreach (entEquipos entidad in listcolab)
                {
                    cmbEmp.SelectedValue = entidad.id_empresa_.ToString();

                    txtNombre.Text= entidad.Nombre_;
                    txtDescripcion.Text= entidad.Descripcion_;
                    txtNumInventario.Text= entidad.NumInventario_;
                    txtFechaAdquisicion.Text= entidad.FechaAdquisicion_.ToShortDateString();
                    txtPrecio.Text= entidad.Precio_.ToString();
                    cmbEstatus.Text= entidad.Estatus_;                    
                }

            }
            catch (Exception exc)
            {
                Label1.Text = "Error, " + exc.Message.ToString();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "<script language = 'javascript'>alert('Error, notifique a su administrador del sistema')</script>");
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                entEq.id_empresa_ = Convert.ToInt16(cmbEmp.SelectedItem.Value);
                entEq.Nombre_ = txtNombre.Text;
                entEq.Descripcion_ = txtDescripcion.Text;
                entEq.NumInventario_ = txtNumInventario.Text;
                entEq.FechaAdquisicion_ = Convert.ToDateTime(txtFechaAdquisicion.Text);
                entEq.Precio_ = Convert.ToDouble(txtPrecio.Text);
                entEq.Estatus_ = cmbEstatus.Text;
                              
                    string Result = negEq.ActualizaEquipo(entEq);
                    if (Result == "true")
                    {
                        Limpiar();
                        Label1.Text = "Actualizado Correctamente..";
                    }
                    else
                    {
                        Label1.Text = Result.ToString();
                    }                
            }
            catch (Exception exc)
            {
                Label1.Text = "Error, " + exc.Message.ToString();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "<script language = 'javascript'>alert('Error, notifique a su administrador del sistema')</script>");
            }
        }
    }
}