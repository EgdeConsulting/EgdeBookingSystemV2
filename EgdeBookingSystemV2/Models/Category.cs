using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EgdeBookingSystemV2.Models
{
    // Denne modellen oppretter tabellen 'Category' i databasen.
    public class Category
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Kategorinavn er påkrevd")]
        [Display(Name = "Kategorinavn")]
        [StringLength(50, ErrorMessage = "Kategorinavnet må bestå av 3 til 50 tegn", MinimumLength = 3)]
        public string Name { get; set; }

    }

}