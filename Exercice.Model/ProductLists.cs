using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice.Model
{
    public class ProductList : ObservableObject
    {
        private ObservableCollection<ProductModel>? products;

        private ProductModel? currentProduct;

        public ProductModel CurrentProduct
        {
            get { return currentProduct; }
            set
            {
                if (currentProduct != value)
                {
                    currentProduct = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public ObservableCollection<ProductModel> Products
        {
            get { return products; }
            set
            {
                if (products != value)
                {
                    products = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
    }
}
