namespace Exercice.Model
{
    public class OrderModel
    {
        public int _orderId { get; set; }
        public int _userInfoId { get; set; }
        public int _productId { get; set; }
        public int _productQuantity { get; set; }
        public int _totalTax { get; set; }
        public int _totalShip { get; set; }
        public int _totalDue { get; set; }
        public DateTime _date { get; set; }
        public string _ip { get; set; }
    }
}
