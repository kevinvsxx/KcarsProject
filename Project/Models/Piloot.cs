using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Piloot
    {
        [Key]
        public int PilootID { get; set; }
        [Required]
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public int AutoID { get; set; }
        public Auto Auto { get; set; }
    }
}
