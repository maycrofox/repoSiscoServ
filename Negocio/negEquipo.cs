using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;
using Entidad;

namespace Negocio
{
  public  class negEquipo
    {
        datEquipo _datEq = new datEquipo();

        public string InsertarEquipo(entEquipos negEq)
        {
            return _datEq.Insertar(negEq);
        }
        public string ActualizaEquipo(entEquipos Eq)
        {
            return _datEq.Actualizar(Eq);
        }
        public List<entEquipos> ListarEquipos()
        {
            return _datEq.ListarEquipos();
        }
        public List<entEquipos> BuscaEquipo(string Nombre)
        {
            return _datEq.BuscaEquipo(Nombre);
        }
        public string EliminarEquipos(string id)
        {
            return _datEq.EliminarEquipo(id);
        }
    }
}
