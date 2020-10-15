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
  public  class datEquipo
    {
        MySqlConnection objConexion;
        entEquipos entEq = new Entidad.entEquipos();
        Conexion Miconex = new Conexion();
        MySqlCommand cmd = new MySqlCommand();
        bool exito;

        public datEquipo()
         {
             objConexion = new MySqlConnection(Miconex.GetConex());
         }

        public string Insertar(entEquipos _entEq)
        {
            string Result = "";
            cmd.Connection = objConexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertaEquipos";
            cmd.Parameters.AddWithValue("@id_empresa", _entEq.id_empresa_);
            cmd.Parameters.AddWithValue("@Nombre", _entEq.Nombre_);
            cmd.Parameters.AddWithValue("@Descripcion", _entEq.Descripcion_);
            cmd.Parameters.AddWithValue("@NumInventario", _entEq.NumInventario_);
            cmd.Parameters.AddWithValue("@FechaAdquisicion", _entEq.FechaAdquisicion_);
            cmd.Parameters.AddWithValue("@Precio", _entEq.Precio_);
            cmd.Parameters.AddWithValue("@Estatus", _entEq.Estatus_);

            objConexion.Open();
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var colab = new entEquipos
                {
                    estadoErr_ = dr[0].ToString(),
                };
                Result = colab.estadoErr_;
            }
            return Result;           
        }

        public List<entEquipos> ListarEquipos()
        {             
            var equipos = new List<entEquipos>();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))  
            {  
                var cmd = new MySqlCommand("ListaEquipos", objConexion) {CommandType = CommandType.StoredProcedure};
              
                objConexion.Open();  
                var dr = cmd.ExecuteReader();  
                while (dr.Read())  
                {  
                    var equip = new entEquipos  
                    {
                        id_equipo_ = Convert.ToInt32(dr[0].ToString()),
                        Nomb_Empresa_ = dr[1].ToString(),
                        Nombre_ = dr[2].ToString(),
                        Descripcion_ = dr[3].ToString(),
                        NumInventario_ = dr[4].ToString(),
                        FechaAdquisicion_ = Convert.ToDateTime(dr[5].ToString()),
                        Precio_ = Convert.ToDouble(dr[6].ToString()),
                        Estatus_ = dr[7].ToString(),                       
                    };  
                    equipos.Add(equip);                   
                }  
            }
            return equipos;          
        }

        public string EliminarEquipo(string id)
        {
            entEquipos eq = new entEquipos();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))
            {
                var cmd = new MySqlCommand("EliminaEquipo", objConexion) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id", id);
                objConexion.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    eq.estadoErr_ = dr[0].ToString();
                }
            }
            return eq.estadoErr_.ToString();
        }
        public string Actualizar(entEquipos _entEq)
        {
            string Result = "";
            cmd.Connection = objConexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ActualizaEquipo";
            cmd.Parameters.AddWithValue("@id_empresa", _entEq.id_empresa_);
            cmd.Parameters.AddWithValue("@Nombre", _entEq.Nombre_);
            cmd.Parameters.AddWithValue("@Descripcion", _entEq.Descripcion_);
            cmd.Parameters.AddWithValue("@NumInventario", _entEq.NumInventario_);
            cmd.Parameters.AddWithValue("@FechaAdquisicion", _entEq.FechaAdquisicion_);
            cmd.Parameters.AddWithValue("@Precio", _entEq.Precio_);
            cmd.Parameters.AddWithValue("@Estatus", _entEq.Estatus_);
            
            objConexion.Open();
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var colab = new entEquipos
                {
                    estadoErr_ = dr[0].ToString(),
                };
                Result = colab.estadoErr_;
            }
            return Result;
        }
        public List<entEquipos> BuscaEquipo(string Nombre)
        {
            var colaborador = new List<entEquipos>();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))
            {
                var cmd = new MySqlCommand("BuscaEquipo", objConexion) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                objConexion.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var colab = new entEquipos
                    {
                        id_equipo_ = Convert.ToInt32(dr[0].ToString()),
                        Nomb_Empresa_ = dr[1].ToString(),
                        Nombre_ = dr[2].ToString(),
                        Descripcion_ = dr[3].ToString(),
                        NumInventario_ = dr[4].ToString(),
                        FechaAdquisicion_ = Convert.ToDateTime(dr[5].ToString()),
                        Precio_ = Convert.ToDouble(dr[6].ToString()),
                        Estatus_ = dr[7].ToString(),
                        id_empresa_ = Convert.ToInt32( dr[8])
                    };
                    colaborador.Add(colab);
                }
            }
            return colaborador;
        }

    }
}
