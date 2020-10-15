using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;
using Entidad;


namespace Negocio
{
   public class negAdminUsu
    {
        datAdminUsu _datColab = new datAdminUsu();

        public string Insertar(string idcatMenu, string activo, string idcolaborador)
        {
            return _datColab.Insertar(idcatMenu, activo, idcolaborador);
        }

        public string ActualizaColaboradorActivo(string idcolaborador, string activo)
        {
            return _datColab.ActualizaColaboradorActivo(idcolaborador, activo);
        }

        public List<entAdminUsu> ListarAdminUsu(string id)
        {
            return _datColab.ListarAdminUsu(id);
        }

        public entColaborador ValidaLogin(string user, string passw)
        {
            return _datColab.ValidaUsu(user, passw);
        }
             
    }
}
 