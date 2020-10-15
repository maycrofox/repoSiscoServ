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
   public class datColabEmp
    {
        MySqlConnection objConexion;
        entColabEmp entColab = new entColabEmp();
        Conexion Miconex = new Conexion();
        MySqlCommand cmd = new MySqlCommand();
        bool exito;
        public datColabEmp()
     {
         objConexion = new MySqlConnection(Miconex.GetConex());
      }

     public string Insertar(entColabEmp _entColab)
        {
            string Result = "";
            cmd.Connection = objConexion;
            cmd.CommandType =  CommandType.StoredProcedure;
            cmd.CommandText = "InsertaColabEmp";
            cmd.Parameters.AddWithValue("@id_empresa", _entColab.id_empresa_); 
            cmd.Parameters.AddWithValue("@id_colaborador", _entColab.id_colaborador_);   
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

     public List<entColabEmp> ListarColaborador(string idemp)
     {
         var colaborador = new List<entColabEmp>();
         using (var objConexion = new MySqlConnection(Miconex.GetConex()))
         {
             var cmd = new MySqlCommand("ListaColabEmp", objConexion) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@idemp", idemp);
                objConexion.Open();
             var dr = cmd.ExecuteReader();
             while (dr.Read())
             {
                 var colab = new entColabEmp
                 {
                     id_colaborador_ = Convert.ToInt32(dr[0].ToString()),
                     NombColaborador_ = dr[1].ToString(),
                     Activo_ = Convert.ToInt32(dr[2].ToString())                                 
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
             var cmd = new MySqlCommand("EliminaColabEmp", objConexion) { CommandType = CommandType.StoredProcedure };
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
