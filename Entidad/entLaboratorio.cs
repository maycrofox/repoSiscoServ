using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
  public  class entLaboratorio
    {
       private int id_laboratorio;      
       private string Nombre;
       private string Direccion;
       private string Telefono;
       private string Descripcion;
       private string estadoErr;

        public int id_laboratorio_
        {
            get { return id_laboratorio; }
            set { id_laboratorio = value; }
        }        
        public string Nombre_
        {
            get { return Nombre; }
            set { Nombre = value; }
        } 
        public string Direccion_
        {
            get { return Direccion; }
            set { Direccion = value; }
        }
        public string Telefono_
        {
            get { return Telefono; }
            set { Telefono = value; }
        }            
        public string Descripcion_
        {
            get { return Descripcion; }
            set { Descripcion = value; }
        }            
        public string estadoErr_
        {
            get { return estadoErr; }
            set { estadoErr = value; }
        }     
       
       public entLaboratorio()
    {
    }
       public entLaboratorio(int id_laboratorio)
    {
        this.id_laboratorio = id_laboratorio;
    }
       public entLaboratorio(int id_laboratorio, string Nombre, string Descripcion, string Direccion)
    {
        this.id_laboratorio = id_laboratorio;      
        this.Nombre = Nombre;      
        this.Descripcion = Descripcion;
        this.Direccion = Direccion;              
    }

    }
}
