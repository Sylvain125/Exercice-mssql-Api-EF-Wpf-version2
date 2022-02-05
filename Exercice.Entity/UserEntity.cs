using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Exercice.Entity
{
    [Table("UserInfo")]
    public class UserEntity
    {
        [Key, DataMember]
        [Column("UserInfoId")]
        [Required, StringLength(20)]
        public int _userId { get; set; }

        [Column("FirstName")]
        [StringLength(100)]
        public string _userFirstName { get; set; }

        [Column("LastName")]
        [StringLength(100)]
        public string _userLastName { get; set; }

        [Column("EmailAddress")]
        [Required, StringLength(160), DataType(DataType.EmailAddress)]
        public string _emailAddress { get; set; }

        [Column("Address")]
        [Required, StringLength(160)]
        public string _address { get; set; }

        [Column("CompanyName")]
        [StringLength(100)]
        public string _companyName { get; set; }

        [Column("Phone")]
        [StringLength(100)]
        public string _phone { get; set; }

        [Column("ImgUrl")]
        [StringLength(200)]
        public string _imgUrl { get; set; }

        [Column("Role")]
        [StringLength(100)]
        public string _role { get; set; }
    }
}