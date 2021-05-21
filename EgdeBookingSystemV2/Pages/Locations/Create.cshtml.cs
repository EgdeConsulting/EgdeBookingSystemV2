using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EgdeBookingSystemV2.Data;
using EgdeBookingSystemV2.Models;

namespace EgdeBookingSystemV2.Pages.Locations
{
    // Controller for Create siden til 'Location'.
    public class CreateModel : PageModel
    {
        // Databasekobling.
        private readonly EgdeBookingSystemV2.Data.EgdeBookingSystemConnection _context;

        // Constructor til klassen. Oppretter context som tilkobling til databasen.
        public CreateModel(EgdeBookingSystemV2.Data.EgdeBookingSystemConnection context)
        {
            _context = context;
        }

        // Kjøres når siden lastes inn.
        public IActionResult OnGet()
        {
            return Page();
        }

        // Henter informasjon om objektet. 
        [BindProperty]
        public Location Location { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // Sjekker om 'Location' objektet er gyldig.

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Legger kategorien i databasen
            _context.Locations.Add(Location);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
