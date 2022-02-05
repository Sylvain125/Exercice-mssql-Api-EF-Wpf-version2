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
        [Table("Product")]
        public class ProductEntity
        {
            [Key, DataMember]
            [Column("ProductId")]
            [Required, StringLength(20)]
            public int _productId { get; set; }

            [Column("Name")]
            [StringLength(100)]
            public string _name { get; set; }

            [Column("Description")]
            [StringLength(250)]
            public string _description { get; set; }

            [Column("Price")]
            [StringLength(100)]
            public int _price { get; set; }

            [Column("Image")]
            [StringLength(100)]
            public string _image { get; set; }
        }
}
