using System;
using System.Web.UI;
using Negocio;
using Entidad;


namespace Web_SiscoServ.Catalogos
{
    public partial class catEmpresa : System.Web.UI.Page
    {
        negEmpresa negEmp = new negEmpresa();
        entEmpresa entEmp = new entEmpresa();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // 
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
            string res="";
            try
            {
                entEmp.Nombre_ = txtNombre.Text;
                entEmp.Direccion_ = txtDireccion.Text;
                entEmp.Telefono_ = txtTelefono.Text;
                entEmp.Rfc_ = txtRfc.Text;               
                    res = negEmp.InsertarEmpresa(entEmp);              
                if ( res == "true")
                {                    
                    Limpiar();
                    Label1.Text = "Almacenado Correctamente..";
                }
                else
                {
                    Label1.Text = res.ToString();                 
                }
            }
            catch (Exception exc)
            {
                Label1.Text = "Error, "+ exc.Message.ToString();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "<script language = 'javascript'>alert('Error, notifique a su administrador del sistema')</script>");
            
            }
        }


        private void Limpiar()
        {
            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "0";
            txtRfc.Text = "";
            Label1.Text = "";
            txtNombre.Focus();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}