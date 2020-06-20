using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Onbreak.Datos;

namespace OnBreak.Negocio
{
    public class Cliente
    {

        public string RutCliente { get; set; }
        public string RazonSocial { get; set; }
        public string NombreContacto { get; set; }
        public string MailContacto { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdActividadEmpresa { get; set; }
        public int IdTipoEmpresa { get; set; }

        public Cliente()
        {
            this.Init();
        }

        private void Init()
        {
            RutCliente = string.Empty;
            RazonSocial = string.Empty;
            NombreContacto = string.Empty;
            MailContacto = string.Empty;
            Direccion = string.Empty;
            Telefono = string.Empty;
            IdActividadEmpresa = 0;
            IdTipoEmpresa = 0;

        }

        //crea un nuevo registro de cliente
        public bool Create()
        {
            Onbreak.Datos.OnBreakEntities bbdd = new Onbreak.Datos.OnBreakEntities();
            Onbreak.Datos.Cliente c = new Onbreak.Datos.Cliente();

            try
            {
                CommonBC.Syncronize(this, c);

                bbdd.Cliente.Add(c);
                bbdd.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                bbdd.Cliente.Remove(c);
                return false;
            }
           

            
        
        
        }

        //lee un registro de cliente
        public bool Read()
        {
            Onbreak.Datos.OnBreakEntities bbdd = new Onbreak.Datos.OnBreakEntities();
            
            try
            {
                Onbreak.Datos.Cliente cli = bbdd.Cliente.First(c => c.RutCliente == RutCliente);
                CommonBC.Syncronize(this, cli);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        //actualiza un registro de empleado
        public bool Update()
        {
            Onbreak.Datos.OnBreakEntities bbdd = new Onbreak.Datos.OnBreakEntities();

            try
            {
                Onbreak.Datos.Cliente cli = bbdd.Cliente.First(c => c.RutCliente == RutCliente);
                CommonBC.Syncronize(this, cli);
                bbdd.SaveChanges();
                return true;
            }
            catch(Exception ex)
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
                Onbreak.Datos.Cliente cli = bbdd.Cliente.First(c => c.RutCliente == RutCliente);
                bbdd.Cliente.Remove(cli);
                bbdd.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //lee todos los registros de un cliente
        public List<Cliente> ReadAll()
        {
            Onbreak.Datos.OnBreakEntities bbdd = new Onbreak.Datos.OnBreakEntities();

            try
            {
                List<Onbreak.Datos.Cliente> listaDatos = bbdd.Cliente.ToList<Onbreak.Datos.Cliente>();
                List<Cliente> listadoClientes = GenerarListado(listaDatos);
                return listadoClientes;
            }catch(Exception ex)
            {
                return new List<Cliente>();
            }

        }

        private List<Cliente> GenerarListado(List<Onbreak.Datos.Cliente> listaDatos)
        {
            List<Cliente> listadoClientes = new List<Cliente>();

            foreach (Onbreak.Datos.Cliente dato in listaDatos)
            {
                Cliente clientes = new Cliente();
                CommonBC.Syncronize(dato, clientes);
                listadoClientes.Add(clientes);
            }
            return listadoClientes;
        }


    }
}
