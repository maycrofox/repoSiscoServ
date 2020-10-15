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
 public   class datColaborador
    {

     MySqlConnection objConexion;
     entColaborador entColab = new entColaborador();
     Conexion Miconex = new Conexion();
     MySqlCommand cmd = new MySqlCommand();
     bool exito;

     public datColaborador()
     {
         objConexion = new MySqlConnection(Miconex.GetConex());
      }

     public string Insertar(entColaborador _entColab)
        {
            string Result = "";
            cmd.Connection = objConexion;
            cmd.CommandType =  CommandType.StoredProcedure;
            cmd.CommandText = "InsertaColaborador";         
            cmd.Parameters.AddWithValue("@Nombre", _entColab.Nombre_);
            cmd.Parameters.AddWithValue("@Edad", _entColab.Edad_);
            cmd.Parameters.AddWithValue("@Sexo", _entColab.Sexo_);
            cmd.Parameters.AddWithValue("@Telefono", _entColab.Telefono_);
            cmd.Parameters.AddWithValue("@Correo", _entColab.Correo_);
            cmd.Parameters.AddWithValue("@Direccion", _entColab.Direccion_);
            cmd.Parameters.AddWithValue("@FechaAlta", _entColab.FechaAlta_);
            cmd.Parameters.AddWithValue("@FechaBaja", _entColab.FechaBaja_);
            cmd.Parameters.AddWithValue("@Cedula", _entColab.Cedula_);
            cmd.Parameters.AddWithValue("@Activo", _entColab.Activo_);          
            cmd.Parameters.AddWithValue("@Usuario", _entColab.Usuario_);
            cmd.Parameters.AddWithValue("@contrasena", _entColab.Contrasena_);

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

        public string Actualizar(entColaborador _entColab)
        {
            string Result = "";
            cmd.Connection = objConexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ActualizaColaborador";
            cmd.Parameters.AddWithValue("@Nombre_", _entColab.Nombre_);
            cmd.Parameters.AddWithValue("@Edad_", _entColab.Edad_);
            cmd.Parameters.AddWithValue("@Sexo_", _entColab.Sexo_);
            cmd.Parameters.AddWithValue("@Telefono_", _entColab.Telefono_);
            cmd.Parameters.AddWithValue("@Correo_", _entColab.Correo_);
            cmd.Parameters.AddWithValue("@Direccion_", _entColab.Direccion_);
            cmd.Parameters.AddWithValue("@FechaAlta_", _entColab.FechaAlta_);
            cmd.Parameters.AddWithValue("@FechaBaja_", _entColab.FechaBaja_);
            cmd.Parameters.AddWithValue("@Cedula_", _entColab.Cedula_);
            cmd.Parameters.AddWithValue("@Activo_", _entColab.Activo_);
            cmd.Parameters.AddWithValue("@Usuario_", _entColab.Usuario_);
            cmd.Parameters.AddWithValue("@contrasena_", _entColab.Contrasena_);

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

        public List<entColaborador> ListarColaborador()
        {             
            var colaborador = new List<entColaborador>();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))  
            {  
                var cmd = new MySqlCommand("ListaColaborador", objConexion) {CommandType = CommandType.StoredProcedure};
                
                objConexion.Open();  
                var dr = cmd.ExecuteReader();  
                while (dr.Read())  
                {  
                    var colab = new entColaborador  
                    {  
                        id_colaborador_ = Convert.ToInt32(dr[0].ToString()),  
                        Nombre_ = dr[1].ToString(),  
                        Telefono_= dr[2].ToString(),  
                        Correo_ = dr[3].ToString(),  
                        Direccion_ = dr[4].ToString(),  
                        FechaAlta_ = Convert.ToDateTime( dr[5].ToString()),
                        FechaBaja_ = Convert.ToDateTime( dr[6].ToString()),  
                        Activo_ = dr[7].ToString(),
                        Usuario_ = dr[8].ToString()
                    };  
                    colaborador.Add(colab);  
                }  
            }               
            return colaborador;          
        }
                
             public List<entColaborador> BuscaColaborador(string Nombre)
        {
            var colaborador = new List<entColaborador>();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))
            {
                var cmd = new MySqlCommand("BuscaColaborador", objConexion) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                objConexion.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var colab = new entColaborador
                    {
                        id_colaborador_ = Convert.ToInt32(dr[0].ToString()),

                        Nombre_ = dr[1].ToString(),
                        Telefono_ = dr[2].ToString(),
                        Correo_ = dr[3].ToString(),
                        Direccion_ = dr[4].ToString(),
                        FechaAlta_ = Convert.ToDateTime(dr[5].ToString()),
                        FechaBaja_ = Convert.ToDateTime(dr[6].ToString()),
                        Activo_ = dr[7].ToString(),
                        Usuario_ = dr[8].ToString(),
                        Edad_ = Convert.ToInt32(dr[9]),
                        Sexo_ = Convert.ToChar(dr[10]),
                        Cedula_ = dr[11].ToString(),
                        Contrasena_ = dr[12].ToString()
                    };
                    colaborador.Add(colab);
                }
            }
            return colaborador;
        }

        public string EliminarColaborador(string id)
        {
            entColaborador colab = new entColaborador();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))
            {                
                var cmd = new MySqlCommand("EliminaColaborador", objConexion) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id", id);
                objConexion.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    colab.EstadoErr_ = dr[0].ToString();
                }                
            }
            return colab.EstadoErr_.ToString();
        }
    
    }
}
