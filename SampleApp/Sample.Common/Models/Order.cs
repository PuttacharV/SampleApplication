using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sample.Common.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required]
        public int MedicineId { get; set; }
        [Required]
        public int OrderQuantity { get; set; }
        [Required]
        [MaxLength(250)]
        public string OrderedBy { get; set; }
        [Required]
        public DateTime OrderCreatedOn { get; set; }
        public string OrderStatus { get; set; }
    }
}
