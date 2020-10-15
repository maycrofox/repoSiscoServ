using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
  public  class entAdminUsu
    {
        private int id_colaborador;
        private int id_catmenu;
        private string Nombre;
        private string idmenu;
        private string Descripcion;
        private string estadoErr;
        private int Activo;
        private string Acceso;

        public int id_catmenu_
        {
            get { return id_catmenu; }
            set { id_catmenu = value; }
        }        
        public int id_colaborador_
        {
            get { return id_colaborador; }
            set { id_colaborador = value; }
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
        public string idmenu_
        {
            get { return idmenu; }
            set { idmenu = value; }
        }        
        public string estadoErr_
        {
            get { return estadoErr; }
            set { estadoErr = value; }
        }
        public int Activo_
        {
            get { return Activo; }
            set { Activo = value; }
        }
        public string Acceso_
        {
            get { return Acceso; }
            set { Acceso = value; }
        }
      public  entAdminUsu()
    {
    }
      public entAdminUsu(int id_colaborador)
    {
        this.id_colaborador = id_colaborador;
    }
      public entAdminUsu(int id_colaborador, string Nombre, string idmenu, string estadoErr, int Activo, int id_catmenu, string Descripcion, string Acceso)
    {
        this.id_catmenu = id_catmenu;
        this.id_colaborador = id_colaborador;
        this.Nombre = Nombre;
        this.idmenu = idmenu;
        this.Descripcion = Descripcion;
        this.Activo = Activo;
        this.Acceso = Acceso;
        this.estadoErr = estadoErr;
  }
      
    }
}
