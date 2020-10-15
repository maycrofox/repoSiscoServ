using System;
using System.Collections.Generic;
using System.Web.UI;
using Negocio;
using Entidad;

namespace Web_SiscoServ
{
    public partial class catColaborador : System.Web.UI.Page
    {
        negColaborador negColab = new negColaborador();
        entColaborador entColab = new entColaborador();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtFechaAlta.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtFechaBaja.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtNombre.Focus();
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {               
                    entColab.Nombre_ = txtNombre.Text;
                entColab.Edad_ = Convert.ToInt16(txtEdad.Text);
                entColab.Sexo_ = Convert.ToChar(cmbSexo.SelectedItem.Text); //modificado
                entColab.Telefono_ = txtTelefono.Text;
                entColab.Correo_ = txtCorreo.Text;
                entColab.Direccion_ = txtDireccion.Text;
                entColab.FechaAlta_ = Convert.ToDateTime(txtFechaAlta.Text);
                entColab.FechaBaja_ = Convert.ToDateTime(txtFechaBaja.Text);
                entColab.Cedula_ = txtCedula.Text;
                entColab.Activo_ = cmbEstatus.SelectedIndex.ToString();
                entColab.Usuario_ = txtUsuario.Text;
                entColab.Contrasena_ = txtContrasena.Text;
                if (txtUsuario.Text != "" && txtContrasena.Text != "")
                {
                    string Result = negColab.InsertarColab(entColab);
                if (Result == "true")
                {                    
                    Limpiar();
                    Label1.Text = "Almacenado Correctamente..";
                }
                else
                {
                    Label1.Text = Result.ToString();
                }
                } else
                {
                    Label1.Text = "Se requiere un usuario y contraseña";
                }
            }
            catch (Exception exc)
            {
                Label1.Text = "Error, " + exc.Message.ToString();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "<script language = 'javascript'>alert('Error, notifique a su administrador del sistema')</script>");              
            }  
        }

        private void Limpiar()
        {
            txtNombre.Text = "";
            txtEdad.Text = "0";
            txtTelefono.Text = "0";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            txtFechaAlta.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFechaBaja.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtCedula.Text = "0";
            txtUsuario.Text = "";
            txtContrasena.Text = "";
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
                List<entColaborador> listcolab = new List<entColaborador>();
                listcolab = negColab.BuscaColab(txtNombre.Text.ToString());

                foreach (entColaborador entidad in listcolab)
                {
                    txtNombre.Text = entidad.Nombre_;
                    txtEdad.Text = entidad.Edad_.ToString(); 
                    cmbSexo.SelectedItem.Text =  entidad.Sexo_.ToString();
                    txtTelefono.Text= entidad.Telefono_;
                    txtCorreo.Text= entidad.Correo_;
                    txtDireccion.Text= entidad.Direccion_;
                    txtFechaAlta.Text= entidad.FechaAlta_.ToShortDateString();
                    txtFechaBaja.Text = entidad.FechaBaja_.ToShortDateString();
                    txtCedula.Text= entidad.Cedula_;
                    cmbEstatus.Text= entidad.Activo_;
                    txtUsuario.Text= entidad.Usuario_;
                    txtContrasena.Text= entidad.Contrasena_;
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
                entColab.Nombre_ = txtNombre.Text;
                entColab.Edad_ = Convert.ToInt16(txtEdad.Text);
                entColab.Sexo_ = Convert.ToChar(cmbSexo.SelectedItem.Text); //modificado
                entColab.Telefono_ = txtTelefono.Text;
                entColab.Correo_ = txtCorreo.Text;
                entColab.Direccion_ = txtDireccion.Text;
                entColab.FechaAlta_ = Convert.ToDateTime(txtFechaAlta.Text);
                entColab.FechaBaja_ = Convert.ToDateTime(txtFechaBaja.Text);
                entColab.Cedula_ = txtCedula.Text;
                entColab.Activo_ = cmbEstatus.SelectedIndex.ToString();
                entColab.Usuario_ = txtUsuario.Text;
                entColab.Contrasena_ = txtContrasena.Text;
                if (txtUsuario.Text != "" && txtContrasena.Text != "")
                {
                    string Result = negColab.ActualizaColab(entColab);
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
                else
                {
                    Label1.Text = "Se requiere un usuario y contraseña";
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