using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
   public class entServicLaboratorio
    {
     private int id_servicLaboratorio;
     private int id_Laboratorio;
     private string Nomb_Laboratorio;
     private int id_empresa;
     private string Nomb_Empresa;
     private string Codigo;
     private string Nombre;
     private string Descripcion;
     private double Precio;
     private string estadoErr;

        public int id_servicLaboratorio_
        {
            get { return id_servicLaboratorio; }
            set { id_servicLaboratorio = value; }
        } 
        public int id_Laboratorio_
        {
            get { return id_Laboratorio; }
            set { id_Laboratorio = value; }
        }
        public string Nomb_Laboratorio_
        {
            get { return Nomb_Laboratorio; }
            set { Nomb_Laboratorio = value; }
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
        public string Codigo_
        {
            get { return Codigo; }
            set { Codigo = value; }
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
        public string estadoErr_
        {
            get { return estadoErr; }
            set { estadoErr = value; }
        }     
       
       public entServicLaboratorio()
    {
    }
       public entServicLaboratorio(int id_servicLaboratorio)
    {
        this.id_servicLaboratorio = id_servicLaboratorio;
    }
       public entServicLaboratorio(int id_servicLaboratorio, int id_Laboratorio, string Nomb_Laboratorio, int id_empresa, string Nomb_Empresa, string Codigo, string Nombre, string Descripcion, double Precio)
    {
        this.id_servicLaboratorio = id_servicLaboratorio;
        this.id_Laboratorio = id_Laboratorio;
        this.Nomb_Laboratorio = Nomb_Laboratorio;
        this.id_empresa = id_empresa;
        this.Nomb_Empresa = Nomb_Empresa;
        this.Codigo = Codigo;   
        this.Nombre = Nombre;       
        this.Descripcion = Descripcion;
        this.Precio = Precio;              
    }

    }
}
