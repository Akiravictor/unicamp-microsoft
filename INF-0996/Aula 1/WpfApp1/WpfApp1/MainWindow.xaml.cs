using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SelecionarCidade selecionarCidade;

        public MainWindow()
        {
            selecionarCidade = new SelecionarCidade();
            InitializeComponent();
        }

        private void Cidade_Click(object sender, RoutedEventArgs e)
        {
            selecionarCidade.ShowInTaskbar = false;
            selecionarCidade.Show();
        }

        private void MenuSuperior_Click(object sender, RoutedEventArgs args)
        {
            var addButton = sender as FrameworkElement;
            if(addButton != null)
            {
                addButton.ContextMenu.IsOpen = true;
            }
        }

        private void Sair_Click(object sender, RoutedEventArgs args)
        {
            Application.Current.Shutdown();
        }
    }
}
