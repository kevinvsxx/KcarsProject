using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Race
    {
        [Key]
        public int RaceID { get; set; }
        public DateTime RaceDag { get; set; }
        public int CircuitID { get; set; }
        public Circuit Circuit { get; set; }
        public ICollection<AutoRace> AutoRaces { get; set; }
    }
}
