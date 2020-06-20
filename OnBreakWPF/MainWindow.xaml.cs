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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnBreakWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Bt_administraciondeclientes_Click(object sender, RoutedEventArgs e)
        {
            AdministracionDeClientes adc = new AdministracionDeClientes();
            adc.Owner = this;
            adc.Show();
        }

        private void Bt_administraciondecontratos_Click(object sender, RoutedEventArgs e)
        {
           AdministracionDeContratos adco = new AdministracionDeContratos();
            adco.Owner = this;
            adco.Show();
        }
    }
}
