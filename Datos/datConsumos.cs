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
   public class datConsumos
    {
        MySqlConnection objConexion;
        entConsumos entCons = new Entidad.entConsumos();
        Conexion Miconex = new Conexion();
        MySqlCommand cmd = new MySqlCommand();
        bool exito;

        public datConsumos()
         {
             objConexion = new MySqlConnection(Miconex.GetConex());
         }

        public string Insertar(entConsumos _entIns)
        {
            string Result = "";
            cmd.Connection = objConexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertaConsumos";
            cmd.Parameters.AddWithValue("@id_empresa", _entIns.id_empresa_);
            cmd.Parameters.AddWithValue("@Nombre", _entIns.Nombre_);
            cmd.Parameters.AddWithValue("@Descripcion", _entIns.Descripcion_);
            cmd.Parameters.AddWithValue("@Precio", _entIns.Precio_);
            cmd.Parameters.AddWithValue("@Existencia", _entIns.Existencia_);
            cmd.Parameters.AddWithValue("@Stock", _entIns.Stock_);
            cmd.Parameters.AddWithValue("@Optimo", _entIns.Optimo_);
            cmd.Parameters.AddWithValue("@FechaCaducidad", _entIns.FechaCaducidad_);
            objConexion.Open();
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var colab = new entConsumos
                {
                    estadoErr_ = dr[0].ToString(),
                };
                Result = colab.estadoErr_;
            }
            return Result;            
        }

        public List<entConsumos> ListarConsumos()
        {             
            var insumos = new List<entConsumos>();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))  
            {  
                var cmd = new MySqlCommand("ListaConsumos", objConexion) {CommandType = CommandType.StoredProcedure};
              
                objConexion.Open();  
                var dr = cmd.ExecuteReader();  
                while (dr.Read())  
                {  
                    var insum = new entConsumos  
                    {
                        id_consumo_ = Convert.ToInt32(dr[0].ToString()),
                        Nomb_Empresa_ = dr[1].ToString(),
                        Nombre_ = dr[2].ToString(),                       
                        Descripcion_ = dr[3].ToString(),   
                        Precio_ = Convert.ToDouble(dr[4].ToString()),                                            
                        Existencia_ = Convert.ToInt32(dr[5].ToString()),
                        Stock_ = Convert.ToInt32(dr[6].ToString()),
                        Optimo_ = Convert.ToInt32(dr[7].ToString()),
                        FechaCaducidad_ = Convert.ToDateTime(dr[8].ToString())
                    };  
                    insumos.Add(insum);                   
                }  
            }
            return insumos;          
        }

        public string EliminarConsumos(string id)
        {
            entInsumos Insum = new entInsumos();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))
            {
                var cmd = new MySqlCommand("EliminaConsumos", objConexion) { CommandType = CommandType.StoredProcedure };
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

        public string Actualizar(entConsumos _entIns)
        {
            string Result = "";
            cmd.Connection = objConexion;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "ActualizaConsumo";

            cmd.Parameters.AddWithValue("@id_empresa", _entIns.id_empresa_);
            cmd.Parameters.AddWithValue("@Nombre", _entIns.Nombre_);
            cmd.Parameters.AddWithValue("@Descripcion", _entIns.Descripcion_);
            cmd.Parameters.AddWithValue("@Precio", _entIns.Precio_);
            cmd.Parameters.AddWithValue("@Existencia", _entIns.Existencia_);
            cmd.Parameters.AddWithValue("@Stock", _entIns.Stock_);
            cmd.Parameters.AddWithValue("@Optimo", _entIns.Optimo_);
            cmd.Parameters.AddWithValue("@FechaCaducidad", _entIns.FechaCaducidad_);

            objConexion.Open();
            var dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                var colab = new entConsumos
                {
                    estadoErr_ = dr[0].ToString(),
                };
                Result = colab.estadoErr_;
            }
            return Result;
        }
        public List<entConsumos> BuscaConsumo(string Nombre)
        {
            var colaborador = new List<entConsumos>();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))
            {
                var cmd = new MySqlCommand("BuscaConsumo", objConexion) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@Nombre", Nombre);
                objConexion.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var colab = new entConsumos
                    {                        
                        id_consumo_ = Convert.ToInt32(dr[0].ToString()),
                        Nomb_Empresa_ = dr[1].ToString(),
                        Nombre_ = dr[2].ToString(),
                        Descripcion_ = dr[3].ToString(),
                        Precio_ = Convert.ToDouble(dr[4].ToString()),
                        Existencia_ = Convert.ToInt32(dr[5].ToString()),
                        Stock_ = Convert.ToInt32(dr[6].ToString()),
                        Optimo_ = Convert.ToInt32(dr[7].ToString()),
                        FechaCaducidad_ = Convert.ToDateTime(dr[8].ToString()),
                        id_empresa_ = Convert.ToInt32(dr[9].ToString())
                    };
                    colaborador.Add(colab);
                }
            }
            return colaborador;
        }

    }
}
