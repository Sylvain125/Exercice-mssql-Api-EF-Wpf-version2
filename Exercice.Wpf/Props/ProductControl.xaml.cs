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
    /// Logique d'interaction pour ProductControl.xaml
    /// </summary>
    public partial class ProductControl : UserControl
    {
        MyClient myClient = new MyClient();

        private readonly IMapper _mapper = ((App)Application.Current).Mapper;
        public ProductList Productslist { get; set; } = new ProductList();
        public ProductControl()
        {
            InitializeComponent();
            DataContext = Productslist;
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var maRequeteAllProduct = await myClient.GetAllProduct();
            var Products = _mapper.Map<IEnumerable<ProductModel>>(maRequeteAllProduct);
            Productslist.Products = new ObservableCollection<ProductModel>(Products);
        }

        private async void Button_Ajouter(object sender, RoutedEventArgs e)
        {
            var productDto = new ProductDto();

            productDto._name= Name.Text;
            productDto._price = Int32.Parse(Price.Text);
            productDto._description = Description.Text;
            productDto._image = ImageProduct.Text;

            try { 
            var maRequeteAll = await myClient.PostProduct(productDto);
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
            try { 
                var productDto = new ProductDto();
                var productDtoId = ProductId.Text;
                productDto._name = Name.Text;
                productDto._price = Int32.Parse(Price.Text);
                productDto._description = Description.Text;
                productDto._image = ImageProduct.Text;

                var maRequeteAll = await myClient.UpdateProductById(productDto, productDtoId);
                MessageBox.Show("Edité avec succès", "Update", MessageBoxButton.OK, MessageBoxImage.Information);
                Window_Loaded(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Probleme de connection !", "ADD", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private async void Button_Supp(object sender, RoutedEventArgs e)
        {
            try { 
            string idShow = ProductId.Text;
            var maRequeteParId = await myClient.DeleteProductById(idShow);
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
