using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PFSoftware.Inventio.Models
{
    public class Sale
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public int Code { get; set; }
        public Client Client { get; set; }
        public float Tax { get; set; }
        public string PaymentMethod { get; set; }
        public ICollection<SaleProduct> SaleProducts { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
