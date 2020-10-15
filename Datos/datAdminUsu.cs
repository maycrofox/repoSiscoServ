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
   
  public  class datAdminUsu
    {
     MySqlConnection objConexion;
     entColaborador entColab = new entColaborador();
     Conexion Miconex = new Conexion();
     MySqlCommand cmd = new MySqlCommand();
     bool exito;

     public datAdminUsu()
     {
         objConexion = new MySqlConnection(Miconex.GetConex());
      }

     public List<entAdminUsu> ListarAdminUsu(string id_colaborador)
        {             
            var menu = new List<entAdminUsu>();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))  
            {  
                var cmd = new MySqlCommand("ListaAdminUsu", objConexion) {CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("@id", id_colaborador);
                objConexion.Open();  
                var dr = cmd.ExecuteReader();  
                while (dr.Read())  
                {  
                    var men = new entAdminUsu  
                    {
                        id_catmenu_ = Convert.ToInt32(dr[0].ToString()),
                        idmenu_ = dr[1].ToString(),
                        Descripcion_ = dr[2].ToString(),
                        Acceso_ = dr[3].ToString(),
                        Activo_ = Convert.ToInt32(dr[4].ToString())      
                    };  
                    menu.Add(men);  
                }  
            }               
            return menu;          
        }

     public string Insertar(string idcatMenu, string activo, string idcolaborador)
     {
         string result ="";
         using (var objConexion = new MySqlConnection(Miconex.GetConex()))
         {
             var cmd = new MySqlCommand("InsertaAdminUsu", objConexion) { CommandType = CommandType.StoredProcedure };
             cmd.Parameters.AddWithValue("@idcatMenu", idcatMenu);
             cmd.Parameters.AddWithValue("@activo", activo);
             cmd.Parameters.AddWithValue("@idcolaborador", idcolaborador);
             objConexion.Open();
             var dr = cmd.ExecuteReader();
             while (dr.Read())
             {
                 var men = new entAdminUsu
                 {
                     estadoErr_ = dr[0].ToString()                    
                 };
                 result = men.estadoErr_;
             }
         }
         return result;
     }

     public string ActualizaColaboradorActivo(string idcolaborador, string activo)
     {
         string result = "";
         using (var objConexion = new MySqlConnection(Miconex.GetConex()))
         {
             var cmd = new MySqlCommand("ActualizaColaboradorActivo", objConexion) { CommandType = CommandType.StoredProcedure };             
             cmd.Parameters.AddWithValue("@idcolaborador", idcolaborador);
             cmd.Parameters.AddWithValue("@activo", activo);
             objConexion.Open();
             var dr = cmd.ExecuteReader();
             while (dr.Read())
             {
                 var men = new entAdminUsu
                 {
                     estadoErr_ = dr[0].ToString()
                 };
                 result = men.estadoErr_;
             }
         }
         return result;
     }

     public entColaborador ValidaUsu (string usu, string passw)
     {
         var menu = new entColaborador();
         using (var objConexion = new MySqlConnection(Miconex.GetConex()))
         {
             var cmd = new MySqlCommand("ObtenUsuPassw", objConexion) { CommandType = CommandType.StoredProcedure };
             cmd.Parameters.AddWithValue("@usu", usu);
             cmd.Parameters.AddWithValue("@passw", passw);
             objConexion.Open();
             var dr = cmd.ExecuteReader();
             while (dr.Read())
             {
                 menu.id_colaborador_ = Convert.ToInt32(dr[0].ToString());
                 menu.Activo_ = dr[1].ToString();
                 menu.Usuario_ = dr[2].ToString();                             
             }
         }
         return menu;
     }
}
}
