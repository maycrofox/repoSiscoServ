using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;
using Entidad;

namespace Negocio
{
   public class negInsumos
   {
       datInsumos _datInsum = new datInsumos();

       public bool InsertarEquipo(entInsumos entIns)
       {
           return _datInsum.Insertar(entIns);
       }
       public List<entInsumos> ListarInsumos()
       {
           return _datInsum.ListarInsumos();
       }
        public List<entConsumos> ConsumosServicios(string idservicio)
        {
            return _datInsum.ConsumosServicios(idservicio);
        }
        public string EliminarInsumos(string id)
       {
           return _datInsum.EliminarInsumos(id);
       }
        public List<entConsumos> MostrarMaterialConsumos(string idempresa)
        {
            return _datInsum.ListarMaterialConsumos(idempresa);
        }
        public List<entInsumos> AlmacenaServConsumo(string idservicio, string idconsumo, string cantidad)
        {
            return _datInsum.AlmacenaServConsumo(idservicio, idconsumo, cantidad);
        }

    }
}
