using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgdeBookingSystemV2.Models
{
    // Denne modellen oppretter tabellen 'Location' i databasen.
    public class Location
    {
        //Oppretter ID til en lokasjon.
        public int ID { get; set; }
        [Required(ErrorMessage = "Stedsnavn er påkrevd")]
        [StringLength(50, ErrorMessage = "Stedsnavnet må bestå av 3 til 50tegn", MinimumLength = 3)]
        [Display(Name = "Lokasjon")]

        // Oppretter navnet til en lokasjon.
        public string Name { get; set; }

    }
}