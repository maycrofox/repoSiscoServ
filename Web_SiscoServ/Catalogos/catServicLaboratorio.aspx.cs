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
    public partial class catServicLaboratorio1 : System.Web.UI.Page
    {
        negServicLaboratorio negIns = new negServicLaboratorio();
        entServicLaboratorio entIns = new entServicLaboratorio();
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
                MostrarLaboratorio();
                txtNombre.Focus();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                entIns.id_empresa_ = Convert.ToInt16(cmbEmp.SelectedItem.Value);
                entIns.id_Laboratorio_ = Convert.ToInt16(cmbLaboratorio.SelectedItem.Value);
                entIns.Codigo_ = txtCodigo.Text;
                entIns.Nombre_ = txtNombre.Text;
                entIns.Descripcion_ = txtDescripcion.Text;
                entIns.Precio_ = Convert.ToDouble(txtPrecio.Text);

                if (negIns.InsertarServicLaboratorio(entIns) == true)
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

        public void MostrarEmpresa()  // Adecuar para el envio de IdUser
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
        public void MostrarLaboratorio()
        {
            negLaboratorio negEmp = new negLaboratorio();
            try
            {
                List<entLaboratorio> listLab = new List<entLaboratorio>();
                listLab = negEmp.ListarLaboratorio();
                ListItem item;
                foreach (entLaboratorio entLab in listLab)
                {
                    item = new ListItem(entLab.Nombre_, Convert.ToString(entLab.id_laboratorio_));
                    cmbLaboratorio.Items.Add(item);
                }
            }
            catch (Exception e)
            {
                //json = e.Message.ToString();
            }
        }

        private void Limpiar()
        {
            txtCodigo.Text = "";
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