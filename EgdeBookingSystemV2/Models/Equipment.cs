using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgdeBookingSystemV2.Models
{
    // Denne modellen oppretter tabellen 'Equipment' i databasen.
    public class Equipment
    {
        // Oppretter ID til et utstyr.
        public int ID { get; set; }


        // Oppretter navnet til et utstyr.
        [Required(ErrorMessage = "Utstyrsnavn er påkrevd")]
        [Display(Name = "Utstyrsnavn")]
        [StringLength(50, ErrorMessage = "Utstyrsnavnet må bestå av 3 til 50 tegn", MinimumLength = 3)]
        public string Name { get; set; }

        // Oppretter informasjon til et utstyr.
        [Display(Name = "Informasjon")]
        public string Info { get; set; }

        // Oppretter Serienummer til et utstyr.
        [Display(Name = "Serienummer")]
        public string ModelNumber { get; set; }

        // Oppretter objekter fra andre klasser som fremmednøkkel 'CategoryID'.
        [Required] 
        [Display(Name = "Kategori")]
        public int CategoryID { get; set; }
        [Display(Name = "Kategori")]
        public Category Category { get; set; }

        // Oppretter objekter fra andre klasser som fremmednøkkel 'LocationID'.
        [Required]
        [Display(Name = "Lokasjon")]
        public int LocationID { get; set; }
        public Location Location { get; set; }

        // Lister over bookinger.Bookings BRUKES IKKE LENGER!
        //public ICollection<Booking> Bookings { get; set; }
        
    }
}
