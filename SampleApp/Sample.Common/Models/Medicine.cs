using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sample.Common.Models
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        [Required]
        public string MedicineName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Brand { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        [Required]
        [MaxLength(250)]
        public string Notes { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
