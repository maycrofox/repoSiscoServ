using System;
using System.Collections.Generic;
using System.Web.UI;
using Negocio;
using Entidad;

namespace Web_SiscoServ.Catalogos
{
    public partial class catClientes : System.Web.UI.Page
    {
        negCliente negClient = new negCliente();
        entCliente entClient = new entCliente();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                txtNombre.Focus();
            }
            if (Session["sessionIdUser"] != null)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "<script language = 'javascript'>validaAcceso('" + Session["sessionIdUser"].ToString() + "');</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "<script language = 'javascript'>alert('Sesión de usuario está caducada, Buelva a loguearse')</script>");
                Response.Redirect("/default.aspx");
            }            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                entClient.Nombre_ = txtNombre.Text;
                entClient.Edad_ = Convert.ToInt16(txtEdad.Text);
                entClient.Sexo_ = Convert.ToChar(cmbSexo.SelectedItem.Text); 
                entClient.Telefono_ = txtTelefono.Text;
                entClient.Correo_ = txtCorreo.Text;
                entClient.Direccion_ = txtDireccion.Text;
                entClient.Fecha_ = Convert.ToDateTime(txtFecha.Text);                 
                entClient.Diagnostico_ = txtDiagnostico.Text;
                entClient.Peso_ = Convert.ToDecimal(txtPeso.Text);
                entClient.Talla_ = txtTalla.Text;
                entClient.MedicoTratante_ = txtMedicoTratante.Text;
                string Result = negClient.InsertarClient(entClient);
                if (Result == "true")
                {
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

        private void Limpiar()
        {
            txtNombre.Text = "";
            txtEdad.Text = "0";
            txtTelefono.Text = "0";
            txtCorreo.Text = "";
            txtDireccion.Text = "";
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDiagnostico.Text = "";
            txtPeso.Text = "0";
            txtTalla.Text = "0";
            txtMedicoTratante.Text = "";
            Label1.Text = "";
            txtNombre.Focus();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
            try
            {
                List<entCliente> listcolab = new List<entCliente>();
                listcolab = negClient.BuscaCliente(txtNombre.Text.ToString());

                foreach (entCliente entidad in listcolab)
                {
                    txtNombre.Text = entidad.Nombre_;
                    txtEdad.Text = entidad.Edad_.ToString();
                    cmbSexo.SelectedItem.Text = entidad.Sexo_.ToString();
                    txtTelefono.Text = entidad.Telefono_;
                    txtCorreo.Text = entidad.Correo_;
                    txtDireccion.Text = entidad.Direccion_;
                    txtFecha.Text = entidad.Fecha_.ToShortDateString();
                    txtDiagnostico.Text = entidad.Diagnostico_;
                    txtPeso.Text = entidad.Peso_.ToString();
                    txtTalla.Text = entidad.Talla_;
                    txtMedicoTratante.Text = entidad.MedicoTratante_;                    
                }

            }
            catch (Exception exc)
            {
                Label1.Text = "Error, " + exc.Message.ToString();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "<script language = 'javascript'>alert('Error, notifique a su administrador del sistema')</script>");
            }
        }

        protected void btnActualizar_Click1(object sender, EventArgs e)
        {
            try
            {
                entClient.Nombre_ = txtNombre.Text;
                entClient.Edad_ = Convert.ToInt16(txtEdad.Text);
                entClient.Sexo_ = Convert.ToChar(cmbSexo.SelectedItem.Text);
                entClient.Telefono_ = txtTelefono.Text;
                entClient.Correo_ = txtCorreo.Text;
                entClient.Direccion_ = txtDireccion.Text;
                entClient.Fecha_ = Convert.ToDateTime(txtFecha.Text);
                entClient.Diagnostico_ = txtDiagnostico.Text;
                entClient.Peso_ = Convert.ToDecimal(txtPeso.Text);
                entClient.Talla_ = txtTalla.Text;
                entClient.MedicoTratante_ = txtMedicoTratante.Text;
               
                    string Result = negClient.ActualizarCliente(entClient);
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