using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;
using Entidad;

namespace Negocio
{
   public class negConsumos
    {
        datConsumos _datConsum = new datConsumos();

        public string InsertarConsumos(entConsumos entIns)
        {
            return _datConsum.Insertar(entIns);
        }
        public string ActualizaConsumos(entConsumos entIns)
        {
            return _datConsum.Actualizar(entIns);
        }
        public List<entConsumos> BuscaConsumos(string Nombre)
        {
            return _datConsum.BuscaConsumo(Nombre);
        }
        public List<entConsumos> ListarConsumos()
        {
            return _datConsum.ListarConsumos();
        }
        public string EliminarConsumos(string id)
        {
            return _datConsum.EliminarConsumos(id);
        }
    }
}
