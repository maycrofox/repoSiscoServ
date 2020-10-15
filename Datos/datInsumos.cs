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
   public class datInsumos
    {
        MySqlConnection objConexion;
        entInsumos entIns = new Entidad.entInsumos();
        Conexion Miconex = new Conexion();
        MySqlCommand cmd = new MySqlCommand();
        bool exito;

        public datInsumos()
         {
             objConexion = new MySqlConnection(Miconex.GetConex());
         }

        public bool Insertar(entInsumos _entIns)
        {
            cmd.Connection = objConexion;
            cmd.CommandType =  CommandType.StoredProcedure;
            cmd.CommandText = "InsertaInsumos";
           try
           {
               cmd.Parameters.AddWithValue("@id_empresa", _entIns.id_empresa_);
               cmd.Parameters.AddWithValue("@Nombre", _entIns.Nombre_);
               cmd.Parameters.AddWithValue("@MaterialRequerido", _entIns.MaterialRequerido_);
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

        public List<entInsumos> ListarInsumos()
        {             
            var insumos = new List<entInsumos>();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))  
            {  
                var cmd = new MySqlCommand("ListaInsumos", objConexion) {CommandType = CommandType.StoredProcedure};
              
                objConexion.Open();  
                var dr = cmd.ExecuteReader();  
                while (dr.Read())  
                {  
                    var insum = new entInsumos  
                    {
                        id_insumo_ = Convert.ToInt32(dr[0].ToString()),
                        Nomb_Empresa_ = dr[1].ToString(),
                        Nombre_ = dr[2].ToString(),
                        MaterialRequerido_ = dr[3].ToString(),
                        Descripcion_ = dr[4].ToString(),   
                        Precio_ = Convert.ToDouble(dr[5].ToString())                                              
                    };  
                    insumos.Add(insum);                   
                }  
            }
            return insumos;          
        }

        public List<entConsumos> ConsumosServicios(string idservicio)
        {
            var insumos = new List<entConsumos>();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))
            {
                var cmd = new MySqlCommand("ListaInsumoServicios", objConexion) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id_servicio", idservicio);
                objConexion.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var insum = new entConsumos
                    {
                        id_consumo_ = Convert.ToInt32(dr[0].ToString()), //Traer el id_servicioconsumo                      
                        Nombre_ = dr[1].ToString(),
                        Precio_ = Convert.ToDouble(dr[2].ToString()),
                        Cantidad_ = Convert.ToInt32(dr[3].ToString()),
                        Descripcion_ = dr[4].ToString()
                    };
                    insumos.Add(insum);
                }
            }
            return insumos;
        }

        public string EliminarInsumos(string id)
        {
            entInsumos Insum = new entInsumos();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))
            {
                var cmd = new MySqlCommand("EliminaInsumos", objConexion) { CommandType = CommandType.StoredProcedure };
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

        public List<entInsumos> AlmacenaServConsumo(string idservicio, string idconsumo, string cantidad)
        {
            var insumos = new List<entInsumos>();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))
            {
                var cmd = new MySqlCommand("InsertaServConsumo", objConexion) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id_servicio", idservicio);
                cmd.Parameters.AddWithValue("@id_consumo", idconsumo);
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                objConexion.Open();
                var dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    var insum = new entInsumos
                    {
                        estadoErr_ = dr[0].ToString(),
                    };
                    insumos.Add(insum);
                }
            }
            return insumos;
        }

        public List<entConsumos> ListarMaterialConsumos(string idempresa)
        {
            var insumos = new List<entConsumos>();
            using (var objConexion = new MySqlConnection(Miconex.GetConex()))
            {
                var cmd = new MySqlCommand("ListaMaterialConsumos", objConexion) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id_empresa", idempresa);
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

    }
}
