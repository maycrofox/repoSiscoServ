using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;
using Entidad;

namespace Negocio
{
   public class negColaborador
    {
        datColaborador _datColab = new datColaborador();

        public string InsertarColab(entColaborador negColab)
        {
            return _datColab.Insertar(negColab);
        }
                
        public string ActualizaColab(entColaborador negColab)
        {
            return _datColab.Actualizar(negColab);
        }

        public List<entColaborador> BuscaColab(string Nombre)
        {
            return _datColab.BuscaColaborador(Nombre);
        }
        public List<entColaborador> ListarColaborador()
        {
            return _datColab.ListarColaborador();
        }
        public string EliminarColaborador(string id)
        {
            return _datColab.EliminarColaborador(id);
        }

        #region Operaciones
       /*
        public bool ActualizarCliente(ClientesEntidad CliNegocio)
        {
            return _ClienteDatos.ActualizarCliente(CliNegocio);
        }           
              
        public ClientesEntidad ConsultarCliente(string codigo)
        {
            return _ClienteDatos.ConsultarCliente(codigo);
        }
       */
        #endregion


    }
}
