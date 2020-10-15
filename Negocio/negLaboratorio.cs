using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;
using Entidad;

namespace Negocio
{
   public class negLaboratorio
    {
        datLaboratorio _datInsum = new datLaboratorio();

        public bool InsertarLaboratorio(entLaboratorio entIns)
        {
            return _datInsum.Insertar(entIns);
        }
        public List<entLaboratorio> ListarLaboratorio()
        {
            return _datInsum.ListarLaboratorio();
        }
        public string EliminarLaboratorio(string id)
        {
            return _datInsum.EliminarLaboratorio(id);
        }

    }
}
