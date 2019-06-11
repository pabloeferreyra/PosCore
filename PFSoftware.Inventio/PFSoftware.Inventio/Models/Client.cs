using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PFSoftware.Inventio.Models
{
    public class Client 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public int BuyCount { get; set; }
        [DataType(DataType.Date)]
        public DateTime LastBuy { get; set; }
        //public ICollection<Sale> Sales { get; set; }
    }
}