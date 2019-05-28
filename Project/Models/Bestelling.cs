using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Bestelling
    {
        [Key]
        public int BestellingID { get; set; }
        public int KlantID { get; set; }
        public Klant Klant { get; set; }
        public ICollection<BestellingArtikel> BestellingArtikels { get; set; }
    }
}
