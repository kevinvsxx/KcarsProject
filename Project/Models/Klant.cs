using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Klant
    {
        [Key]
        public int KlantID { get; set; }
        [Required]
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        [Display(Name = "Datum aangemaakt")]
        [DataType(DataType.Date)]
        public DateTime AangemaaktDatum { get; set; }
        public ICollection<Bestelling> Bestellingen { get; set; }
        [NotMapped]
        public string KlantDisplay
        {
            get
            {
                return $"{Voornaam} {Naam}";
            }
        }
    }
}
