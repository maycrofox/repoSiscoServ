using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;
using Entidad;

namespace Negocio
{
   public class negColabEmp
    {
        datColabEmp _datColab = new datColabEmp();

        public string InsertarColab(entColabEmp negColab)
        {
            return _datColab.Insertar(negColab);
        }
        public List<entColabEmp> ListarColabEmp(string idemp )
        {
            return _datColab.ListarColaborador(idemp);
        }
        public string EliminarColabEmp(string id)
        {
            return _datColab.EliminarColaborador(id);
        }

    }
}
