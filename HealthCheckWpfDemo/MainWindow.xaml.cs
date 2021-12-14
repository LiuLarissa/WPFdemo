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

namespace HealthCheckWpfDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel view;
        public MainWindow()
        {
            view = new ViewModel();
            InitializeComponent();
            this.DataContext = view;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TreeViewContextMenu.bloodContextMenu = this.Resources["bloodContextMenu"] as ContextMenu;
            TreeViewContextMenu.blooditemContextMenu = this.Resources["blooditemContextMenu"] as ContextMenu;
        }
    }
}
