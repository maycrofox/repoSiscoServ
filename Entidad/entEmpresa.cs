using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
  public  class entEmpresa
    {
        private int id_empresa;
        private string Nombre;
        private string Direccion;
        private string Telefono;
        private string Rfc;
        private string estadoErr;

        public int id_empresa_
        {
            get { return id_empresa; }
            set { id_empresa = value; }
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
        public string Rfc_
        {
            get { return Rfc; }
            set { Rfc = value; }
        }        
       public string estadoErr_
        {
            get { return estadoErr; }
            set { estadoErr = value; }
        }
       public entEmpresa()
    {
    }
       public entEmpresa(int id_empresa)
    {
        this.id_empresa = id_empresa;
    }
       public entEmpresa(int id_empresa, string Nombre, string Direccion, string Telefono, string Rfc)
    {
        this.id_empresa = id_empresa;
        this.Nombre = Nombre;
        this.Direccion = Direccion;
        this.Telefono = Telefono;
        this.Rfc = Rfc;              
    }
    }
}
