using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Artikel
    {
        [Key]
        public int ArtikelID { get; set; }
        [Required]
        public string Naam { get; set; }
        public string Beschrijving { get; set; }
        public ICollection<BestellingArtikel> BestellingArtikels { get; set; }
    }
}
