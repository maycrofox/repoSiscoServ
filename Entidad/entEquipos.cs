using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
   public class entEquipos
    {
        private int id_equipo; 
        private int id_empresa;
        private string Nomb_Empresa;
        private string Nombre;
        private string Descripcion;
        private string NumInventario;
        private DateTime FechaAdquisicion;
        private double Precio;
        private string Estatus;
        private string estadoErr;

        public int id_equipo_
        {
            get { return id_equipo; }
            set { id_equipo = value; }
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
        public string NumInventario_
        {
            get { return NumInventario; }
            set { NumInventario = value; }
        }
        public DateTime FechaAdquisicion_
        {
            get { return FechaAdquisicion; }
            set { FechaAdquisicion = value; }
        }
        public double Precio_
        {
            get { return Precio; }
            set { Precio = value; }
        }        
        public string Estatus_
        {
            get { return Estatus; }
            set { Estatus = value; }
        }
        public string estadoErr_
        {
            get { return estadoErr; }
            set { estadoErr = value; }
        }
       public entEquipos()
    {
    }
       public entEquipos(int id_equipo)
    {
        this.id_equipo = id_equipo;
    }
       public entEquipos(int id_equipo, int id_empresa, string Nombre, string Nomb_Empresa, string Descripcion, string NumInventario, DateTime FechaAdquisicion, double Precio, string Estatus)
    {
        this.id_equipo = id_equipo;
        this.id_empresa = id_empresa;
        this.Nomb_Empresa = Nomb_Empresa;
        this.Nombre = Nombre;
        this.Descripcion = Descripcion;
        this.NumInventario = NumInventario;
        this.FechaAdquisicion = FechaAdquisicion;
        this.Precio = Precio;
        this.Estatus = Estatus;         
    }

    }
}
