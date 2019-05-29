using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Auto
    {
        [Key]
        public int AutoID { get; set; }
        [Required]
        public string Merk { get; set; }

        public ICollection<Piloot> Piloots { get; set; }
        public ICollection<AutoRace> AutoRaces { get; set; }
    }
}
