using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using Entidad;
using MySql.Data;
using System.Data;
using Entidad;

namespace Datos
{
  public  class datCliente
    {
        MySqlConnection objConexion;
        entCliente entClient = new Entidad.entCliente();
        Conexion Miconex = new Conexion();
        MySqlCommand cmd = new MySqlCommand();
        bool exito;

         public datCliente()
         {
             objConexion = new MySqlConnection(Miconex.GetConex());
         }

        public string Insertar(entCliente _entClient)
        {
            string Result = "";
            cmd.Connection = objConexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertaCliente";
            cmd.Parameters.AddWithValue("@Nombre", _entClient.Nombre_);
            cmd.Parameters.AddWithValue("@Edad", _entClient.Edad_);
            cmd.Parameters.AddWithValue("@Sexo", _entClient.Sexo_);
            cmd.Parameters.AddWithValue("@Telefono", _entClient.Telefono_);
            cmd.Parameters.AddWithValue("@Correo", _entClient.Correo_);
            cmd.Parameters.AddWithValue("@Direccion", _entClient.Direccion_);
            cmd.Parameters.AddWithValue("@Fecha", _entClient.Fecha_);
            cmd.Parameters.AddWithValue("@Diagnostico", _entClient.Diagnostico_);
            cmd.Parameters.AddWithValue("@Peso", _entClient.Peso_);
            cmd.Parameters.AddWithValue("@Talla", _entClient.Talla_);
            cmd.Parameters.AddWithValue("@MedicoTratante", _entClient.MedicoTratante_);

            objConexion.Open();
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var colab = new entCliente
                {
                    EstadoErr_ = dr[0].ToString(),
                };
                Result = colab.EstadoErr_;
            }
            return Result;
        }

        public List<entCliente> ListarCliente()
        {             
            var clientes = new List<entCliente>();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))  
            {  
                var cmd = new MySqlCommand("ListaCliente", objConexion) {CommandType = CommandType.StoredProcedure};
              
                objConexion.Open();  
                var dr = cmd.ExecuteReader();  
                while (dr.Read())  
                {  
                    var client = new entCliente  
                    {  
                        id_cliente_ = Convert.ToInt32(dr[0].ToString()),  
                        Nombre_ = dr[1].ToString(),
                        Edad_ = Convert.ToInt16( dr[2].ToString()), 
                        Telefono_= dr[3].ToString(),  
                        Correo_ = dr[4].ToString(),  
                        Direccion_ = dr[5].ToString(),  
                        Fecha_ = Convert.ToDateTime(dr[6].ToString()),
                        Diagnostico_ = dr[7].ToString(),
                        Peso_ = Convert.ToDecimal( dr[8].ToString()),
                        Talla_ = dr[9].ToString(),
                        MedicoTratante_ = dr[10].ToString()
                    };  
                    clientes.Add(client);                   
                }  
            }
            return clientes;          
        }

        public string EliminarCliente(string id)
        {
            entCliente client = new entCliente();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))
            {
                var cmd = new MySqlCommand("EliminaCliente", objConexion) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id", id);
                objConexion.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    client.EstadoErr_ = dr[0].ToString();
                }
            }
            return client.EstadoErr_.ToString();
        }
        public List<entCliente> BuscaCliente(string Nombre)
        {
            var clientes = new List<entCliente>();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))
            {
                var cmd = new MySqlCommand("BuscaCliente", objConexion) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                objConexion.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var colab = new entCliente
                    {                       
                        id_cliente_ = Convert.ToInt32(dr[0].ToString()),
                        Nombre_ = dr[1].ToString(),
                        Edad_ = Convert.ToInt32(dr[2]),
                        Telefono_ = dr[3].ToString(),
                        Correo_ = dr[4].ToString(),
                        Direccion_ = dr[5].ToString(),
                        Fecha_ = Convert.ToDateTime(dr[6].ToString()),
                        Diagnostico_ = dr[7].ToString(),
                        Peso_ = Convert.ToDecimal( dr[8]),
                        Talla_ = dr[9].ToString(),
                        MedicoTratante_ = dr[10].ToString(),       
                        Sexo_= Convert.ToChar(dr[11])
                    };
                    clientes.Add(colab);
                }
            }
            return clientes;
        }

        public string Actualizar(entCliente _entClient)
        {
            string Result = "";
            cmd.Connection = objConexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ActualizaCliente";

            cmd.Parameters.AddWithValue("@Nombre", _entClient.Nombre_);
            cmd.Parameters.AddWithValue("@Edad", _entClient.Edad_);
            cmd.Parameters.AddWithValue("@Sexo", _entClient.Sexo_);
            cmd.Parameters.AddWithValue("@Telefono", _entClient.Telefono_);
            cmd.Parameters.AddWithValue("@Correo", _entClient.Correo_);
            cmd.Parameters.AddWithValue("@Direccion", _entClient.Direccion_);
            cmd.Parameters.AddWithValue("@Fecha", _entClient.Fecha_);
            cmd.Parameters.AddWithValue("@Diagnostico", _entClient.Diagnostico_);
            cmd.Parameters.AddWithValue("@Peso", _entClient.Peso_);
            cmd.Parameters.AddWithValue("@Talla", _entClient.Talla_);
            cmd.Parameters.AddWithValue("@MedicoTratante", _entClient.MedicoTratante_);

            objConexion.Open();
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var colab = new entColaborador
                {
                    EstadoErr_ = dr[0].ToString(),
                };
                Result = colab.EstadoErr_;
            }
            return Result;
        }
    }
}
