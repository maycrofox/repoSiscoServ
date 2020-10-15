using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
  public  class entColaborador
    {  //click derecho sobre los campos declarados con private, seleccionar Refactor / Encapsulate Field, para crear las entidades
        private int id_colaborador;
        public int id_colaborador_
        {
            get { return id_colaborador; }
            set { id_colaborador = value; }
        }
        private string Nombre;
        public string Nombre_
        {
            get { return Nombre; }
            set { Nombre = value; }
        }
        private int Edad;
        public int Edad_
        {
            get { return Edad; }
            set { Edad = value; }
        }
        private char Sexo;
        public char Sexo_
        {
            get { return Sexo; }
            set { Sexo = value; }
        }
        private string Telefono;
        public string Telefono_
        {
            get { return Telefono; }
            set { Telefono = value; }
        }
        private string Correo;
        public string Correo_
        {
            get { return Correo; }
            set { Correo = value; }
        }
        private string Direccion;
        public string Direccion_
        {
            get { return Direccion; }
            set { Direccion = value; }
        }
        private DateTime FechaAlta;
        public DateTime FechaAlta_
        {
            get { return FechaAlta; }
            set { FechaAlta = value; }
        }
        private DateTime FechaBaja;
        public DateTime FechaBaja_
        {
            get { return FechaBaja; }
            set { FechaBaja = value; }
        }
        private string Cedula;
        public string Cedula_
        {
            get { return Cedula; }
            set { Cedula = value; }
        }
        private string Activo;
        public string Activo_
        {
            get { return Activo; }
            set { Activo = value; }
        }
        private int id_empresa;
        public int id_empresa_
        {
            get { return id_empresa; }
            set { id_empresa = value; }
        }
        private string Usuario;
        public string Usuario_
        {
            get { return Usuario; }
            set { Usuario = value; }
        }
    private string Contrasena;
    public string Contrasena_
    {
        get { return Contrasena; }
        set { Contrasena = value; }
    }

    //para cachar errores
    private string estadoErr;
    public string EstadoErr_
    {
        get { return estadoErr; }
        set { estadoErr = value; }
    }

  
    public  entColaborador()
    {
    }
    public entColaborador(int id_colaborador)
    {
        this.id_colaborador = id_colaborador;
    }
    public entColaborador(int id_colaborador, string Nombre, int Edad, char Sexo, string Telefono, string Correo, string Direccion, DateTime FechaAlta, DateTime FechaBaja, string Cedula, string Activo, int id_empresa, string Usuario, string Contrasena)
    {
        this.id_colaborador = id_colaborador;
        this.Nombre = Nombre;
        this.Edad = Edad;
        this.Sexo = Sexo;
        this.Telefono = Telefono;
        this.Correo = Correo;
        this.Direccion = Direccion;
        this.FechaAlta = FechaAlta;
        this.FechaBaja = FechaBaja;
        this.Cedula = Cedula;
        this.Activo = Activo;
        this.id_empresa = id_empresa;
        this.Usuario = Usuario;
        this.Contrasena = Contrasena;
    }

    }
}
