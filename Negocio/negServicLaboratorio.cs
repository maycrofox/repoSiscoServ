using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;
using Entidad;

namespace Negocio
{
   public class negServicLaboratorio
    {
        datServicLaboratorio _datInsum = new datServicLaboratorio();

        public bool InsertarServicLaboratorio(entServicLaboratorio entIns)
        {
            return _datInsum.Insertar(entIns);
        }
        public List<entServicLaboratorio> ListarServicLaboratorio()
        {
            return _datInsum.ListarServicLaboratorio();
        }
        public string EliminarServicLaboratorio(string id)
        {
            return _datInsum.EliminarServicLaboratorio(id);
        }
    }
}
