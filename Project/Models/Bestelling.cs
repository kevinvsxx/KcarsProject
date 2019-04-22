using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Bestelling
    {
        public int BestellingID { get; set; }
        public String Artikel { get; set; }
        public decimal prijs { get; set; }
        public int klantID { get; set; }
        public Klant klant { get; set; }
    }
}
