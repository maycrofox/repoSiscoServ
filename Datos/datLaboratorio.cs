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
   public class datLaboratorio
    {
       MySqlConnection objConexion;
        entLaboratorio entIns = new Entidad.entLaboratorio();
        Conexion Miconex = new Conexion();
        MySqlCommand cmd = new MySqlCommand();
        bool exito;

        public datLaboratorio()
         {
             objConexion = new MySqlConnection(Miconex.GetConex());
         }

        public bool Insertar(entLaboratorio _entIns)
        {
            cmd.Connection = objConexion;
            cmd.CommandType =  CommandType.StoredProcedure;
            cmd.CommandText = "InsertaLaboratorio"; 
           try
           {              
               cmd.Parameters.AddWithValue("@Nombre", _entIns.Nombre_);
               cmd.Parameters.AddWithValue("@Direccion", _entIns.Direccion_);
               cmd.Parameters.AddWithValue("@Telefono", _entIns.Telefono_);  
               cmd.Parameters.AddWithValue("@Descripcion", _entIns.Descripcion_);               
                                                  
            objConexion.Open();
            cmd.ExecuteNonQuery();
            exito = true;
           }
           catch (MySqlException)
           {
               exito = false;
           }
           finally
           {
               if (objConexion.State == ConnectionState.Open)
               {
                   objConexion.Close();
               }
               cmd.Parameters.Clear();
           }
           return exito;
        }

        public List<entLaboratorio> ListarLaboratorio()
        {             
            var insumos = new List<entLaboratorio>();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))  
            {  
                var cmd = new MySqlCommand("ListaLaboratorio", objConexion) {CommandType = CommandType.StoredProcedure};
              
                objConexion.Open();  
                var dr = cmd.ExecuteReader();  
                while (dr.Read())  
                {  
                    var insum = new entLaboratorio  
                    {
                        id_laboratorio_ = Convert.ToInt32(dr[0].ToString()),                        
                        Nombre_ = dr[1].ToString(),
                        Direccion_ = dr[2].ToString(),
                        Telefono_ = dr[3].ToString(),
                        Descripcion_ = dr[4].ToString()                                                                   
                    };  
                    insumos.Add(insum);                   
                }  
            }
            return insumos;          
        }

        public string EliminarLaboratorio(string id)
        {
            entLaboratorio Insum = new entLaboratorio();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))
            {
                var cmd = new MySqlCommand("EliminaLaboratorio", objConexion) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id", id);
                objConexion.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Insum.estadoErr_ = dr[0].ToString();
                }
            }
            return Insum.estadoErr_.ToString();
        }

    }
}
