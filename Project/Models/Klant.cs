using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class Klant
    {
        public int Id { get; set; }
        [Required]
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        [Display(Name = "Datum aangemaakt")]
        [DataType(DataType.Date)]
        public DateTime AangemaaktDatum { get; set; }
        public ICollection<Bestelling> Bestellingen { get; set; }
        public string klantDisplay
        {
            get
            {
                return $"{Voornaam} {Naam}";
            }
        }
    }
}
