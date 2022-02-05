using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace Exercice.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Quitter(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Order(object sender, RoutedEventArgs e)
        {
            MyTab.SelectedIndex = 3;
           
        }

        private void Button_User(object sender, RoutedEventArgs e)
        {
            Process p = new Process();
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.FileName = "https://github.com/Sylvain125";
            p.Start();
        }

        private void Button_Product(object sender, RoutedEventArgs e)
        {
            MyTab.SelectedIndex = 2;
        }
    }
}
