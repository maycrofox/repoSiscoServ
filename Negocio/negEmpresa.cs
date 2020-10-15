using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;
using Entidad;

namespace Negocio
{
  public  class negEmpresa
    {
        datEmpresa _datemp = new datEmpresa();

        public string InsertarEmpresa(entEmpresa negEmp)
        {
            return _datemp.Insertar(negEmp);
        }
        public List<entEmpresa> ListarEmpresa()
        {
            return _datemp.ListarEmpresa();
        }
        public string EliminarEmpresa(string id)
        {
            return _datemp.EliminarEmpresa(id);
        }
    }
}
