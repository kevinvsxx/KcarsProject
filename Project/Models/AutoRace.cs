using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class AutoRace
    {
        [Key]
        public int AutoRaceID { get; set; }

        public int AutoID { get; set; }
        public Auto Auto { get; set; }
        public int? RaceID { get; set; }
        public Race Race { get; set; }


    }
}
