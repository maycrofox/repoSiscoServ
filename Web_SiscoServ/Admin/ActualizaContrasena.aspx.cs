using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_SiscoServ.Admin
{
    public partial class ActualizaContrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtContras.Text = "";
            txtActual.Text = "";
            txtConfirma.Text = "";
            txtContras.Focus();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}