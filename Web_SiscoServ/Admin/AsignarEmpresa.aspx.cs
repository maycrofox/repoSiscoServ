using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Negocio;
using Entidad;
using Newtonsoft.Json;
namespace Web_SiscoServ.Admin
{
    public partial class AsignarEmpresa : System.Web.UI.Page
    {
        negColabEmp negColab = new negColabEmp();
        entColabEmp entColab = new entColabEmp();
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarEmpresa();
            //MostrarColaborador();
        }
        //protected void btnGuardar_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //entColab.id_colaborador_ = Convert.ToInt32(cmbColaborador.SelectedItem.Value);
        //        //entColab.id_empresa_ = Convert.ToInt32(cmbEmp.SelectedItem.Value);
        //        //string Result = negColab.InsertarColab(entColab);
        //        //Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "<script language = 'javascript'>alert('" + Result + "')</script>");
        //    }
        //    catch (Exception exc)
        //    {
        //        Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "<script language = 'javascript'>alert('Error, notifique a su administrador del sistema')</script>");
        //    }
        //}

        [WebMethod]
        public static string MostrarColabEmp(string idemp)
        {
            negColabEmp negInsum = new negColabEmp();
            string json = "";
            try
            {
                List<entColabEmp> listemp = new List<entColabEmp>();
                listemp = negInsum.ListarColabEmp(idemp);
                json = JsonConvert.SerializeObject(listemp);
            }
            catch (Exception e)
            {
                json = e.Message.ToString();
            }
            return json;
        }

        [WebMethod]
        public static string EliminarColabEmp(string id)
        {
            negColabEmp negColab = new negColabEmp();
            string result = "";
            try
            {
                string datos = negColab.EliminarColabEmp(id);
                result = JsonConvert.SerializeObject(datos);
            }
            catch (Exception e)
            {
                result = e.Message.ToString();
            }
            return result;
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
               // Page.ClientScript.RegisterStartupScript(Page.GetType(), "Message", "<script language = 'javascript'>validaAcceso('" + Session["sessionIdUser"].ToString() + "');</script>");
            }
        }

        //public void MostrarColaborador()
        //{
        //    negColaborador negColab = new negColaborador();
        //    try
        //    {
        //        List<entColaborador> listColab = new List<entColaborador>();
        //        listColab = negColab.ListarColaborador();
        //        ListItem item;
        //        foreach (entColaborador entCol in listColab)
        //        {
        //            item = new ListItem(entCol.Nombre_, Convert.ToString(entCol.id_colaborador_));
        //            cmbColaborador.Items.Add(item);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        //json = e.Message.ToString();
        //    }
        //}

    }
}