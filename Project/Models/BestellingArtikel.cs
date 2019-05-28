using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class BestellingArtikel
    {
        [Key]
        public int BestellingArtikelID { get; set; }
        public int BestellingID { get; set; }
        public Bestelling Bestelling { get; set; }

        public int ArtikelID { get; set; }
        public Artikel Artikel { get; set; }
    }
}
