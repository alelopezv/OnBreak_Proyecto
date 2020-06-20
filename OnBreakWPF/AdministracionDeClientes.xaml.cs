using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using OnBreak.Negocio;


namespace OnBreakWPF
{
    /// <summary>
    /// Lógica de interacción para AdministracionDeClientes.xaml
    /// </summary>
    public partial class AdministracionDeClientes : Window
    {
        public AdministracionDeClientes()
        {
            InitializeComponent();
            LimpiarControles();


        }

        private void LimpiarControles()
        {
            tb_rut.Text = String.Empty;
            tb_razonsocial.Text = String.Empty;
            tb_nombre.Text = String.Empty;
            tb_direccion.Text = String.Empty;
            tb_telefono.Text = String.Empty;
            tb_email.Text = String.Empty;
            CargarTipoActividad();
            CargarTipoEmpresas();
            CargarCliente();
        }

        private void Dg_listadoclientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Cb_tipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Cb_actividad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Bt_registrar_Click(object sender, RoutedEventArgs e)
        {
            Cliente c = new Cliente()
            {
                RutCliente = tb_rut.Text,
                RazonSocial = tb_razonsocial.Text,
                NombreContacto = tb_nombre.Text,
                MailContacto = tb_email.Text,
                Direccion = tb_direccion.Text,
                Telefono = tb_telefono.Text,
                IdTipoEmpresa = (int)cb_tipo.SelectedValue,
                IdActividadEmpresa = (int)cb_actividad.SelectedValue

            };

            if (c.Create())
            {
                MessageBox.Show("Cliente Creado");
                LimpiarControles();
            }
            else
            {
                MessageBox.Show("El cliente no pudo ser creado");
            }
        }

        private void Bt_limpiarcasillas_Click(object sender, RoutedEventArgs e)
        {
            tb_rut.Text = String.Empty;
            tb_razonsocial.Text = String.Empty;
            tb_nombre.Text = String.Empty;
            tb_email.Text = String.Empty;
            tb_direccion.Text = String.Empty;
            tb_telefono.Text = String.Empty;

            CargarTipoEmpresas();
            CargarTipoActividad();
        }
        
        private void CargarTipoEmpresas()
        {
            
            List<TipoEmpresa> ListEmpresa = new List<TipoEmpresa>();
            ListEmpresa.Add(new TipoEmpresa { IdTipoEmpresa = 10, Descripcion = "SPA" });
            ListEmpresa.Add(new TipoEmpresa { IdTipoEmpresa = 20, Descripcion = "EIRL" });
            ListEmpresa.Add(new TipoEmpresa { IdTipoEmpresa = 30, Descripcion = "Limitada" });
            ListEmpresa.Add(new TipoEmpresa { IdTipoEmpresa = 40, Descripcion = "Sociedad Anónima" });
            this.cb_tipo.DisplayMemberPath = "Descripcion";
            this.cb_tipo.SelectedValuePath = "IdTipoEmpresa";
            this.cb_tipo.ItemsSource = ListEmpresa;
            cb_tipo.SelectedIndex = 0;
        }

        private void CargarTipoActividad()
        {
            List<ActividadEmpresa> ListActividadesEmpresa = new List<ActividadEmpresa>();
            ListActividadesEmpresa.Add(new ActividadEmpresa { IdActividadEmpresa = 1, Descripcion = "Agropecuaria" });
            ListActividadesEmpresa.Add(new ActividadEmpresa { IdActividadEmpresa = 2, Descripcion = "Minería" });
            ListActividadesEmpresa.Add(new ActividadEmpresa { IdActividadEmpresa = 3, Descripcion = "Manufactura" });
            ListActividadesEmpresa.Add(new ActividadEmpresa { IdActividadEmpresa = 4, Descripcion = "Comercio" });
            ListActividadesEmpresa.Add(new ActividadEmpresa { IdActividadEmpresa = 5, Descripcion = "Hotelería" });
            ListActividadesEmpresa.Add(new ActividadEmpresa { IdActividadEmpresa = 6, Descripcion = "Alimentos" });
            ListActividadesEmpresa.Add(new ActividadEmpresa { IdActividadEmpresa = 7, Descripcion = "Transporte" });
            ListActividadesEmpresa.Add(new ActividadEmpresa { IdActividadEmpresa = 8, Descripcion = "Servicios" });
            this.cb_actividad.DisplayMemberPath = "Descripcion";//Propiedad a mostrar
            this.cb_actividad.SelectedValuePath = "IdActividadEmpresa";//Valor que guardara
            this.cb_actividad.ItemsSource = ListActividadesEmpresa;//Muestra los datos en el combobox
            cb_actividad.SelectedIndex = 0;//Posiciona en el primer registro
        }

        public void CargarCliente()
        {
            Cliente clientes = new Cliente();
            dg_listadoclientes.ItemsSource = clientes.ReadAll();

        }

        private void Bt_listadodecontrato_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Bt_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Cliente c = new Cliente()
            {
                RutCliente = tb_rut.Text
            };
            if(c.Delete())
            {
                MessageBox.Show("Cliente Eliminado");
                LimpiarControles();
            }
            else
            {
                MessageBox.Show("Cliente no pudo ser eliminado");
            }
        }

        private void Bt_actualizar_Click(object sender, RoutedEventArgs e)
        {
            Cliente cli = new Cliente()
            {
                RutCliente = tb_rut.Text,
                RazonSocial = tb_razonsocial.Text,
                NombreContacto = tb_nombre.Text,
                MailContacto = tb_email.Text,
                Direccion = tb_direccion.Text,
                Telefono = tb_telefono.Text,
                IdTipoEmpresa = (int)cb_tipo.SelectedValue,
                IdActividadEmpresa = (int)cb_actividad.SelectedValue
            };
            if(cli.Update())
            {
                MessageBox.Show("Cliente actualizado con exito");
                LimpiarControles();
            }
            else
            {
                MessageBox.Show("El cliente no pudo ser actualizado");
            }
        }
    }
}
