using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgdeBookingSystemV2.Models
{
    // Denne modellen oppretter tabellen 'Booking' i databasen.
    public class Booking
    {
        // Oppretter ID til en booking.
        public int ID { get; set; }
        [Required]
        [Display(Name = "Brukernavn")]
        [StringLength(100, MinimumLength = 3)]
        public string UserEmail { get; set; }

        // Oppretter startdatoen til en booking.
        [Required(ErrorMessage = "Vennligst spesifiser startdato")]
        [Display(Name = "Startdato")]
        [DataType(DataType.Date)]        
        public DateTime StartDate { get; set; }

        // Oppretter sluttdatoen til en booking.
        [Required(ErrorMessage = "Vennligst spesifiser sluttdato")]
        [Display(Name = "Sluttdato")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        
        // Oppretter en kobling med tabellen 'Equipment' der EquipmentID settes til fremmednøkkel.
        [Required]
        public int EquipmentID { get; set; }
        public Equipment Equipment { get; set; }
    }
}


