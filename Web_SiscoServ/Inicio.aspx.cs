using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web_SiscoServ
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", " divmenu(1);", true);
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion2", " userlogueado();", true);                
            }
        }
    }
}