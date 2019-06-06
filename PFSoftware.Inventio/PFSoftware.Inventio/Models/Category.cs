using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFSoftware.Inventio.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
}
