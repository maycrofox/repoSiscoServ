using System;
using System.Web.UI;
using Negocio;
using Entidad;

namespace Web_SiscoServ
{
    public partial class _default : System.Web.UI.Page
    {
        negAdminUsu negColab = new negAdminUsu();
        entColaborador entColab = new entColaborador();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               //
            }

            ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", " divmenu(0);", true);
            Session["sessionUser"] = null;
            Session["sessionIdUser"] = null;
        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {                  
            try
            {
                entColab = negColab.ValidaLogin(txtUser.Text, txtpassw.Text);
                if (entColab.Usuario_ == txtUser.Text && entColab.Activo_ == "1")
                {
                    Session["sessionUser"] = entColab.Usuario_;
                    Session["sessionIdUser"] = entColab.id_colaborador_;
                  Response.Redirect("/Inicio.aspx");  
                }
                else
                {
                    Session["sessionUser"] = null;
                    Session["sessionIdUser"] = null;
                    if (entColab.Activo_ != "1")
                    {
                        Label1.Text = "Usuario se encuentra Inactivo..";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", " alert('Usuario se encuentra Inactivo..');", true);
                    }
                    else 
                    {
                        Label1.Text = "Usuario no encontrado o contraseña no corresponde..";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", " alert('Usuario no encontrado o contraseña no corresponde..');", true);                         
                    }
                }
            }
            catch (Exception err)
            {
               var json = err.Message.ToString();
                ScriptManager.RegisterStartupScript(this, typeof(Page), "invocarfuncion", " alert('"+ json + "');", true);
            }
            
        }

    }
}