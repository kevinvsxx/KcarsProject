using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Circuit
    {
        [Key]
        public int CircuitID { get; set; }
        [Required]
        public string NaamCircuit { get; set; }
        public string Land { get; set; }
        public ICollection<Race> Races { get; set; }
    }
}
