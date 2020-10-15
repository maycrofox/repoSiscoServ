using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidad
{
    public class entColabEmp
    {
        private int id_colabemp;
        private int id_colaborador;
        private string NombColaborador;
        private int id_empresa;
        private string NombEmpresa;
        private int Activo;
        private string estadoErr;

        public int id_colabemp_
        {
            get { return id_colabemp; }
            set { id_colabemp = value; }
        }
        public int id_colaborador_
        {
            get { return id_colaborador; }
            set { id_colaborador = value; }
        }
        public int Activo_
        {
            get { return Activo; }
            set { Activo = value; }
        }
        public string NombColaborador_
        {
            get { return NombColaborador; }
            set { NombColaborador = value; }
        }
        public int id_empresa_
        {
            get { return id_empresa; }
            set { id_empresa = value; }
        }
        public string NombEmpresa_
        {
            get { return NombEmpresa; }
            set { NombEmpresa = value; }
        }

        public string estadoErr_
        {
            get { return estadoErr; }
            set { estadoErr = value; }
        }

        public entColabEmp()
        {
        }
        public entColabEmp(int id_colabemp)
        {
            this.id_colabemp = id_colabemp;
        }
        public entColabEmp(int id_colabemp, int id_colaborador, string NombColaborador, int id_empresa, string NombEmpresa, int  Activo)
        {
            this.id_colabemp = id_colabemp;
            this.id_colaborador = id_colaborador;
            this.NombColaborador = NombColaborador;
            this.id_empresa = id_empresa;
            this.Activo = Activo;
            this.NombEmpresa = NombEmpresa;
        }
    }
}
