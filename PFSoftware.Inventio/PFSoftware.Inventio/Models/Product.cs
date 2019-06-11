using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PFSoftware.Inventio.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Category Category { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }
        public float BuyPrice { get; set; }
        public float SellPrice { get; set; }
        public int Sales { get; set; }
        public ICollection<SaleProduct> SaleProducts { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
