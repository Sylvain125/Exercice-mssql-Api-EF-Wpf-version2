using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Exercice.Entity
{
    [Table("OrderInfo")]
    public class OrderEntity
    {
        [Key, DataMember]
        [Column("OrderInfoId")]
        [Required, StringLength(20)]
        public int _orderId { get; set; }

        [Column("UserInfoId")]
        [StringLength(20)]
        public int _userInfoId { get; set; }

        [Column("ProductId")]
        [StringLength(20)]
        public int _productId { get; set; }

        [Column("ProductQuantity")]
        [Required, StringLength(20)]
        public int _productQuantity { get; set; }

        [Column("TotalTax")]
        [StringLength(80)]
        public int _totalTax { get; set; }

        [Column("TotalShip")]
        [StringLength(80)]
        public int _totalShip { get; set; }

        [Column("TotalDue")]
        [StringLength(80)]
        public int _totalDue { get; set; }

        [Column("Date")]
        [StringLength(60)]
        public DateTime _date { get; set; }

        [Column("Ip")]
        [StringLength(50)]
        public string _ip { get; set; }
    }
}
