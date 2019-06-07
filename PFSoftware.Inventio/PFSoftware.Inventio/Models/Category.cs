using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PFSoftware.Inventio.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Display(Name ="Nombre")]
        public string Name { get; set; }
        [Display(Name = "Fecha Creacion")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
