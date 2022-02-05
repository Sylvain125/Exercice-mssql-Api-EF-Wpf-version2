using AutoMapper;
using Exercice.Dto;
using Exercice.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Exercice.Wpf.Props
{
    /// <summary>
    /// Logique d'interaction pour OrdersControl.xaml
    /// </summary>
    public partial class OrdersControl : UserControl
    {
        MyClient myClient = new MyClient();

        private readonly IMapper _mapper = ((App)Application.Current).Mapper;
        public OrderList Orderslist { get; set; } = new OrderList();
        public OrdersControl()
        {
            InitializeComponent();
            DataContext = Orderslist;
        }


        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var maRequeteAllOrder = await myClient.GetAllOrder();
            var Orders = _mapper.Map<IEnumerable<OrderModel>>(maRequeteAllOrder);
            Orderslist.Orders = new ObservableCollection<OrderModel>(Orders);
        }

        private async void Button_Ajouter(object sender, RoutedEventArgs e)
        {
            var orderDto = new OrderDto();

            orderDto._userInfoId = Int32.Parse(UsertId.Text);
            orderDto._productId = Int32.Parse(ProductId.Text);
            orderDto._productQuantity = Int32.Parse(ProductQuantity.Text);
            orderDto._totalTax = Int32.Parse(TotalTax.Text);
            orderDto._totalShip = Int32.Parse(TotalShip.Text);
            orderDto._totalDue = Int32.Parse(TotalDue.Text);
            orderDto._date = DateTime.Now;
            orderDto._ip = Ip.Text;

            try
            {
                var maRequeteAll = await myClient.PostOrder(orderDto);
                MessageBox.Show("Ajouté avec succès", "ADD", MessageBoxButton.OK, MessageBoxImage.Information);
                Window_Loaded(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Probleme de connection !", "ADD", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async void Button_Editer(object sender, RoutedEventArgs e)
        {
            var orderDto = new OrderDto();
            
            var orderId = OrderId.Text;
            orderDto._userInfoId = Int32.Parse(UsertId.Text);
            orderDto._productId = Int32.Parse(ProductId.Text);
            orderDto._productQuantity = Int32.Parse(ProductQuantity.Text);
            orderDto._totalTax = Int32.Parse(TotalTax.Text);
            orderDto._totalShip = Int32.Parse(TotalShip.Text);
            orderDto._totalDue = Int32.Parse(TotalDue.Text);
            orderDto._date = DateTime.Now;
            orderDto._ip = Ip.Text;

            var maRequeteAll = await myClient.UpdateOrderById(orderDto, orderId);
            MessageBox.Show("Edité avec succès", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
            Window_Loaded(sender, e);

        }


        private async void Button_Supp(object sender, RoutedEventArgs e)
        {
            try { 
            string idShow = OrderId.Text;
            var maRequeteParId = await myClient.DeleteOrderById(idShow);
            MessageBox.Show("Supprimé avec succès", "Delete", MessageBoxButton.OK, MessageBoxImage.Information);
            Window_Loaded(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Probleme de connection !", "ADD", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
