using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("OrderId")]
        public int OrderId { get; set; }

        [Column("OrderDate")]
        [DataType(dataType:DataType.DateTime)]
        [Required]
        public DateTime OrderDate { get; set; }

        [Column("EmailId")]
        [Required]
        [StringLength(maximumLength:100,MinimumLength =2)]
        public string EmailId { get; set; }
    }
}
