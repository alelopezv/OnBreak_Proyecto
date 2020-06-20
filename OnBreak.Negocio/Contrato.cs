using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBreak.Negocio
{
    public class Contrato
    {
        public string Numero { get; set; }
        public System.DateTime Creacion { get; set; }
        public System.DateTime Termino { get; set; }
        public string RutCliente { get; set; }
        public string IdModalidad { get; set; }
        public int IdTipoEvento { get; set; }
        public System.DateTime FechaHoraInicio { get; set; }
        public System.DateTime FechaHoraTermino { get; set; }
        public int Asistentes { get; set; }
        public int PersonalAdicional { get; set; }
        public bool Realizado { get; set; }
        public double ValorTotalContrato { get; set; }
        public string Observaciones { get; set; }

        public Contrato()
        {
            this.Init();
        }

        private void Init()
        {
            Numero = string.Empty;
            Creacion = DateTime.Now;
            Termino = DateTime.Now;
            RutCliente = string.Empty;
            IdModalidad = string.Empty;
            IdTipoEvento = 0;
            FechaHoraInicio = DateTime.Now;
            FechaHoraTermino = DateTime.Now;
            Asistentes = 0;
            PersonalAdicional = 0;
            Realizado =false;
            ValorTotalContrato = 0.0;
            Observaciones = string.Empty;



        }

        //crea un nuevo registro de contratos
        public bool Create()
        {
            Onbreak.Datos.OnBreakEntities bbdd = new Onbreak.Datos.OnBreakEntities();
            Onbreak.Datos.Contrato co = new Onbreak.Datos.Contrato();

            try
            {
                CommonBC.Syncronize(this, co);

                bbdd.Contrato.Add(co);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                bbdd.Contrato.Remove(co);
                return false;
            }





        }

        //lee un registro de contratos
        public bool Read()
        {
            Onbreak.Datos.OnBreakEntities bbdd = new Onbreak.Datos.OnBreakEntities();

            try
            {
                Onbreak.Datos.Contrato con = bbdd.Contrato.First(c => c.Numero == Numero);
                CommonBC.Syncronize(this, con);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //actualiza un registro de contratos
        public bool Update()
        {
            Onbreak.Datos.OnBreakEntities bbdd = new Onbreak.Datos.OnBreakEntities();

            try
            {
                Onbreak.Datos.Contrato con = bbdd.Contrato.First(c => c.Numero == Numero);
                CommonBC.Syncronize(this, con);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        //elimina un registro de cliente
        public bool Delete()
        {
            Onbreak.Datos.OnBreakEntities bbdd = new Onbreak.Datos.OnBreakEntities();

            try
            {
                Onbreak.Datos.Contrato con = bbdd.Contrato.First(c => c.Numero == Numero);
                bbdd.Contrato.Remove(con);
                bbdd.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //lee todos los registros de un contrato
        public List<Contrato> ReadAll()
        {
            Onbreak.Datos.OnBreakEntities bbdd = new Onbreak.Datos.OnBreakEntities();

            try
            {
                List<Onbreak.Datos.Contrato> listaDatos = bbdd.Contrato.ToList<Onbreak.Datos.Contrato>();
                List<Contrato> listadoContratos = GenerarListado(listaDatos);
                return listadoContratos;
            }
            catch (Exception ex)
            {
                return new List<Contrato>();
            }

        }

        private List<Contrato> GenerarListado(List<Onbreak.Datos.Contrato> listaDatos)
        {
            List<Contrato> listadoContratos = new List<Contrato>();

            foreach (Onbreak.Datos.Contrato dato in listaDatos)
            {
                Contrato clientes = new Contrato();
                CommonBC.Syncronize(dato, clientes);
                listadoContratos.Add(clientes);
            }
            return listadoContratos;
        }


    }
}

