using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Entidad;
using MySql.Data;
using System.Data;
using Entidad;

namespace Datos
{
  public  class datServicLaboratorio
    {
       MySqlConnection objConexion;
        entServicLaboratorio entIns = new Entidad.entServicLaboratorio();
        Conexion Miconex = new Conexion();
        MySqlCommand cmd = new MySqlCommand();
        bool exito;

        public datServicLaboratorio()
         {
             objConexion = new MySqlConnection(Miconex.GetConex());
         }

        public bool Insertar(entServicLaboratorio _entIns)
        {
            cmd.Connection = objConexion;
            cmd.CommandType =  CommandType.StoredProcedure;
            cmd.CommandText = "InsertaServicLaboratorio"; 
           try
           {
               cmd.Parameters.AddWithValue("@id_Laboratorio", _entIns.id_Laboratorio_);
               cmd.Parameters.AddWithValue("@id_empresa", _entIns.id_empresa_);
               cmd.Parameters.AddWithValue("@Codigo", _entIns.Codigo_);    
               cmd.Parameters.AddWithValue("@Nombre", _entIns.Nombre_);                 
               cmd.Parameters.AddWithValue("@Descripcion", _entIns.Descripcion_);               
               cmd.Parameters.AddWithValue("@Precio", _entIns.Precio_);                                     
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

        public List<entServicLaboratorio> ListarServicLaboratorio()
        {             
            var insumos = new List<entServicLaboratorio>();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))  
            {  
                var cmd = new MySqlCommand("ListaServicLaboratorio", objConexion) {CommandType = CommandType.StoredProcedure};
              
                objConexion.Open();  
                var dr = cmd.ExecuteReader();  
                while (dr.Read())  
                {  
                    var insum = new entServicLaboratorio  
                    {
                        id_servicLaboratorio_ = Convert.ToInt32(dr[0].ToString()),
                        Nomb_Laboratorio_ = dr[1].ToString(),
                        Nomb_Empresa_ = dr[2].ToString(),
                        Codigo_ = dr[3].ToString(),
                        Nombre_ = dr[4].ToString(),                        
                        Descripcion_ = dr[5].ToString(),   
                        Precio_ = Convert.ToDouble(dr[6].ToString())                                              
                    };  
                    insumos.Add(insum);                   
                }  
            }
            return insumos;          
        }

        public string EliminarServicLaboratorio(string id)
        {
            entServicLaboratorio Insum = new entServicLaboratorio();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))
            {
                var cmd = new MySqlCommand("EliminaServicLaboratorio", objConexion) { CommandType = CommandType.StoredProcedure };
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
