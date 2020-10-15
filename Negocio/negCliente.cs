using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Datos;
using Entidad;

namespace Negocio
{
  public  class negCliente
    {
        datCliente _datClient = new datCliente();

        public string InsertarClient(entCliente negClient)
        {
            return _datClient.Insertar(negClient);
        }
        public string ActualizarCliente(entCliente _entClient)
        {
            return _datClient.Actualizar(_entClient);
        }
        public List<entCliente> BuscaCliente(string Nombre)
        {
            return _datClient.BuscaCliente(Nombre);
        }
        public List<entCliente> ListarClientes()
        {
            return _datClient.ListarCliente();
        }
        public string EliminarCliente(string id)
        {
            return _datClient.EliminarCliente(id);
        }

        #region Operaciones
        /*
        public bool ActualizarCliente(ClientesEntidad CliNegocio)
        {
            return _ClienteDatos.ActualizarCliente(CliNegocio);
        }

        public bool EliminarCliente(ClientesEntidad CliNegocio)
        {
            return _ClienteDatos.EliminarCliente(CliNegocio);
        }
              
        public ClientesEntidad ConsultarCliente(string codigo)
        {
            return _ClienteDatos.ConsultarCliente(codigo);
        }
       */
        #endregion
    }
}
