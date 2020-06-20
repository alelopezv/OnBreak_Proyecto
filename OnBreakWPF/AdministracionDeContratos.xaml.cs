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
    /// Lógica de interacción para AdministracionDeContratos.xaml
    /// </summary>
    public partial class AdministracionDeContratos : Window
    {
        public AdministracionDeContratos()
        {
            InitializeComponent();
            LimpiarControles();
        }

        private void LimpiarControles()
        {

            CargarTipoEventos();
            CargarModalidadServicio();

        }

        private void Bt_listadodeclientes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CargarTipoEventos()
        {

            List<TipoEvento> ListEvento = new List<TipoEvento>();
            ListEvento.Add(new TipoEvento { IdTipoEvento = 10, Descripcion = "Coffee Break" });
            ListEvento.Add(new TipoEvento { IdTipoEvento = 20, Descripcion = "Cocktail" });
            ListEvento.Add(new TipoEvento { IdTipoEvento = 30, Descripcion = "Cenas" });
            this.cb_tipoevento.DisplayMemberPath = "Descripcion";
            this.cb_tipoevento.SelectedValuePath = "IdTipoEvento";
            this.cb_tipoevento.ItemsSource = ListEvento;
            cb_tipoevento.SelectedIndex = 0;
        }

        private void CargarModalidadServicio()
        {

            List<ModalidadServicio> ListModalidad = new List<ModalidadServicio>();
            ListModalidad.Add(new ModalidadServicio { IdModalidad= "CB001", IdTipoEvento=10,Nombre= "Light Break", ValorBase=3,PersonalBase=2 });
            ListModalidad.Add(new ModalidadServicio { IdModalidad = "CB002", IdTipoEvento =10, Nombre = "Journal Break", ValorBase =8, PersonalBase =6 });
            ListModalidad.Add(new ModalidadServicio { IdModalidad = "CB003", IdTipoEvento =10, Nombre = "Day Break", ValorBase =12, PersonalBase =6 });
            ListModalidad.Add(new ModalidadServicio { IdModalidad = "CE001", IdTipoEvento =30, Nombre = "Ejecutiva", ValorBase =25, PersonalBase =10 });
            ListModalidad.Add(new ModalidadServicio { IdModalidad = "CE002", IdTipoEvento =30, Nombre = "Celebración", ValorBase =35, PersonalBase =14 });
            ListModalidad.Add(new ModalidadServicio { IdModalidad = "CO001", IdTipoEvento =20, Nombre = "Quick Cocktail", ValorBase =6, PersonalBase =4 });
            ListModalidad.Add(new ModalidadServicio { IdModalidad = "CO002", IdTipoEvento =20, Nombre = "Ambient Cocktail", ValorBase =10, PersonalBase =5 });
            this.cb_modalidad.DisplayMemberPath = "Nombre";
            this.cb_modalidad.SelectedValuePath = "IdModalidad";
            this.cb_modalidad.ItemsSource = ListModalidad;
            cb_modalidad.SelectedIndex = 0;
        }


    }
}
