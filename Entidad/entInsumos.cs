using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
  public  class entInsumos
    {
       private int id_insumo; 
        private int id_empresa;
        private string Nomb_Empresa;
        private string Nombre;
        private string MaterialRequerido;
        private string Descripcion;        
        private double Precio;        
        private string estadoErr;

        public int id_insumo_
        {
            get { return id_insumo; }
            set { id_insumo = value; }
        } 
        public int id_empresa_
        {
            get { return id_empresa; }
            set { id_empresa = value; }
        }
        public string Nomb_Empresa_
        {
            get { return Nomb_Empresa; }
            set { Nomb_Empresa = value; }
        } 
        public string Nombre_
        {
            get { return Nombre; }
            set { Nombre = value; }
        } 
        public string MaterialRequerido_
        {
            get { return MaterialRequerido; }
            set { MaterialRequerido = value; }
        }
        public string Descripcion_
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }     
        public double Precio_
        {
            get { return Precio; }
            set { Precio = value; }
        }
        public string estadoErr_
        {
            get { return estadoErr; }
            set { estadoErr = value; }
        }     
       
       public entInsumos()
    {
    }
       public entInsumos(int id_insumo)
    {
        this.id_insumo = id_insumo;
    }
       public entInsumos(int id_insumo, int id_empresa, string Nombre, string Nomb_Empresa, string MaterialRequerido, string Descripcion, double Precio)
    {
        this.id_insumo = id_insumo;
        this.id_empresa = id_empresa;
        this.Nomb_Empresa = Nomb_Empresa;
        this.Nombre = Nombre;
        this.MaterialRequerido = MaterialRequerido;
        this.Descripcion = Descripcion;
        this.Precio = Precio;              
    }
    }
}
