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
 public   class datEmpresa
    {
        MySqlConnection objConexion;
        entEmpresa entEmpresa = new Entidad.entEmpresa();
        Conexion Miconex = new Conexion();
        MySqlCommand cmd = new MySqlCommand();
        bool exito;

         public datEmpresa()
         {
             objConexion = new MySqlConnection(Miconex.GetConex());
         }

        public string Insertar(entEmpresa _entEmpresa)
        {
            entEmpresa emp = new entEmpresa();            
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))
            {
                var cmd = new MySqlCommand("InsertaEmpresa", objConexion) { CommandType = CommandType.StoredProcedure };                
                cmd.Parameters.AddWithValue("@Nombre", _entEmpresa.Nombre_);
                cmd.Parameters.AddWithValue("@Direccion", _entEmpresa.Direccion_);
                cmd.Parameters.AddWithValue("@Telefono", _entEmpresa.Telefono_);
                cmd.Parameters.AddWithValue("@Rfc", _entEmpresa.Rfc_);
                objConexion.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    emp.estadoErr_ = dr[0].ToString();
                }
            }
            return emp.estadoErr_.ToString();           
        }

        public List<entEmpresa> ListarEmpresa()
        {             
            var empresa = new List<entEmpresa>();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))  
            {
                var cmd = new MySqlCommand("ListaEmpresa", objConexion) { CommandType = CommandType.StoredProcedure };
              
                objConexion.Open();  
                var dr = cmd.ExecuteReader();  
                while (dr.Read())  
                {  
                    var emp = new entEmpresa  
                    {  
                        id_empresa_ = Convert.ToInt32(dr[0].ToString()),  
                        Nombre_ = dr[1].ToString(),
                        Direccion_ = dr[2].ToString(),
                        Telefono_= dr[3].ToString(),                          
                        Rfc_= dr[4].ToString()                       
                    };
                    empresa.Add(emp);                   
                }  
            }
            return empresa;          
        }

        public string EliminarEmpresa(string id)
        {
            entEmpresa emp = new entEmpresa();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))
            {
                var cmd = new MySqlCommand("EliminaEmpresa", objConexion) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id", id);
                objConexion.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    emp.estadoErr_ = dr[0].ToString();
                }
            }
            return emp.estadoErr_.ToString();
        }

    }
}
