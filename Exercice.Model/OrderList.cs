using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercice.Model
{
    public class OrderList : ObservableObject
    {
        private ObservableCollection<OrderModel>? orders;

        private OrderModel? currentOrder;

        public OrderModel CurrentOrder
        {
            get { return currentOrder; }
            set
            {
                if (currentOrder != value)
                {
                    currentOrder = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
        public ObservableCollection<OrderModel> Orders
        {
            get { return orders; }
            set
            {
                if (orders != value)
                {
                    orders = value;
                    OnNotifyPropertyChanged();
                }
            }
        }
    }
}
