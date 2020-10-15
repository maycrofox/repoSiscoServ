using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
  public  class entCliente
    {
        private int id_cliente;
        private string Nombre;
        private int Edad;
        private char Sexo;
        private string Telefono;
        private string Correo;
        private string Direccion;
        private DateTime Fecha;
        private string Diagnostico;
        private decimal Peso;
        private string Talla;
        private string MedicoTratante;

        public int id_cliente_
        {
            get { return id_cliente; }
            set { id_cliente = value; }
        }     
        public string Nombre_
        {
            get { return Nombre; }
            set { Nombre = value; }
        }        
        public int Edad_
        {
            get { return Edad; }
            set { Edad = value; }
        }        
        public char Sexo_
        {
            get { return Sexo; }
            set { Sexo = value; }
        }       
        public string Telefono_
        {
            get { return Telefono; }
            set { Telefono = value; }
        }        
        public string Correo_
        {
            get { return Correo; }
            set { Correo = value; }
        }        
        public string Direccion_
        {
            get { return Direccion; }
            set { Direccion = value; }
        }        
        public DateTime Fecha_
        {
            get { return Fecha; }
            set { Fecha = value; }
        }
        public string Diagnostico_
        {
            get { return Diagnostico; }
            set { Diagnostico = value; }
        }        
        public decimal Peso_
        {
            get { return Peso; }
            set { Peso = value; }
        }
        public string Talla_
        {
            get { return Talla; }
            set { Talla = value; }
        }        
        public string MedicoTratante_
        {
            get { return MedicoTratante; }
            set { MedicoTratante = value; }
        }       
    //para cachar errores
    private string estadoErr;
    public string EstadoErr_
    {
        get { return estadoErr; }
        set { estadoErr = value; }
    }
    public entCliente()
    {
    }
    public entCliente(int id_cliente)
    {
        this.id_cliente = id_cliente;
    }                                                                                  
    public entCliente(int id_cliente, string Nombre, int Edad, char Sexo, string Telefono, string Correo, string Direccion, DateTime Fecha, string Diagnostico, decimal Peso, string Talla, string MedicoTratante)
    {
        this.id_cliente = id_cliente;
        this.Nombre = Nombre;
        this.Edad = Edad;
        this.Sexo = Sexo;
        this.Telefono = Telefono;
        this.Correo = Correo;
        this.Direccion = Direccion;
        this.Fecha = Fecha;
        this.Diagnostico = Diagnostico;
        this.Peso = Peso;
        this.Talla = Talla;
        this.MedicoTratante = MedicoTratante;      
    }

    }
}
