using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidad;

namespace Web_SiscoServ.Catalogos
{
    public partial class catConsumo : System.Web.UI.Page
    {
        negConsumos negIns = new negConsumos();
        entConsumos entIns = new entConsumos();
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
                txtFechaCaducidad.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
                entIns.Existencia_ = Convert.ToInt32(txtExistencia.Text);
                entIns.Stock_ = Convert.ToInt32(txtStock.Text);
                entIns.Optimo_ = Convert.ToInt32(txtOptimo.Text);
                entIns.FechaCaducidad_ = Convert.ToDateTime(txtFechaCaducidad.Text);

                string Result = negIns.InsertarConsumos(entIns);

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
        private void Limpiar()
        {
            txtNombre.Text = "";
            txtDescripcion.Text = "";
            txtPrecio.Text = "0";
            txtExistencia.Text = "0";
            txtStock.Text = "0";
            txtOptimo.Text = "0";
            txtFechaCaducidad.Text = DateTime.Now.ToString("dd/MM/yyyy");
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
                List<entConsumos> listcolab = new List<entConsumos>();
                listcolab = negIns.BuscaConsumos (txtNombre.Text.ToString());

                foreach (entConsumos entIns in listcolab)
                {
                    cmbEmp.SelectedValue = entIns.id_empresa_.ToString();

                     txtNombre.Text= entIns.Nombre_;
                     txtDescripcion.Text= entIns.Descripcion_;
                     txtPrecio.Text= entIns.Precio_.ToString();
                     txtExistencia.Text= entIns.Existencia_.ToString();
                     txtStock.Text= entIns.Stock_.ToString();
                     txtOptimo.Text= entIns.Optimo_.ToString();
                    txtFechaCaducidad.Text = entIns.FechaCaducidad_.ToShortDateString();
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
                entIns.id_empresa_ = Convert.ToInt16(cmbEmp.SelectedItem.Value);
                entIns.Nombre_ = txtNombre.Text;
                entIns.Descripcion_ = txtDescripcion.Text;
                entIns.Precio_ = Convert.ToDouble(txtPrecio.Text);
                entIns.Existencia_ = Convert.ToInt32(txtExistencia.Text);
                entIns.Stock_ = Convert.ToInt32(txtStock.Text);
                entIns.Optimo_ = Convert.ToInt32(txtOptimo.Text);
                entIns.FechaCaducidad_ = Convert.ToDateTime(txtFechaCaducidad.Text);

                string Result = negIns.ActualizaConsumos(entIns);
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