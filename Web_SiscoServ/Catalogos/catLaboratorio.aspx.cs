using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidad;

namespace Web_SiscoServ.Catalogos
{
    public partial class catLaboratorio1 : System.Web.UI.Page
    {
        negLaboratorio negIns = new negLaboratorio();
        entLaboratorio entIns = new entLaboratorio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtNombre.Focus();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                entIns.Nombre_ = txtNombre.Text;
                entIns.Direccion_ = txtDireccion.Text;
                entIns.Telefono_ = txtTelefono.Text;
                entIns.Descripcion_ = txtDescripcion.Text;

                if (negIns.InsertarLaboratorio(entIns) == true)
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

        private void Limpiar()
        {
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "0";
            txtDescripcion.Text = "";
            txtNombre.Focus();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

    }
}