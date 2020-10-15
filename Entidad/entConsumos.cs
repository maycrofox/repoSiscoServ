using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
   public class entConsumos
    {
        private int id_consumo; 
        private int id_empresa;
        private string Nomb_Empresa;
        private string Nombre;
        private string Descripcion;
        private double Precio;
        private int Existencia;               
        private int Stock; 
        private int Optimo;
        private int Cantidad;
        private DateTime FechaCaducidad; 
        private string estadoErr;

        public int id_consumo_
        {
            get { return id_consumo; }
            set { id_consumo = value; }
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
        public int Existencia_
        {
            get { return Existencia; }
            set { Existencia = value; }
        }
        public int Stock_
        {
            get { return Stock; }
            set { Stock = value; }
        }
       public int Optimo_
        {
            get { return Optimo; }
            set { Optimo = value; }
        }
       public DateTime FechaCaducidad_
        {
            get { return FechaCaducidad; }
            set { FechaCaducidad = value; }
        }
        public int Cantidad_
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }

        public string estadoErr_
        {
            get { return estadoErr; }
            set { estadoErr = value; }
        }     
       
       public entConsumos()
    {
    }
       public entConsumos(int id_consumo)
    {
        this.id_consumo = id_consumo;
    }
       public entConsumos(int id_consumo, int id_empresa, string Nombre, string Nomb_Empresa, string Descripcion, double Precio, int Existencia, int Stock, int Optimo, DateTime FechaCaducidad, int Cantidad)
    { 
        this.id_consumo = id_consumo;
        this.id_empresa = id_empresa;
        this.Nomb_Empresa = Nomb_Empresa;
        this.Nombre = Nombre;
        this.Descripcion = Descripcion;
        this.Precio = Precio;  
        this.Existencia = Existencia;
        this.Stock = Stock;
        this.Optimo = Optimo;
        this.FechaCaducidad = FechaCaducidad;
        this.Cantidad = Cantidad;
        }
    }
}
