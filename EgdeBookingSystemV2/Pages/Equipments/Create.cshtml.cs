using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EgdeBookingSystemV2.Data;
using EgdeBookingSystemV2.Models;

namespace EgdeBookingSystemV2.Pages.Equipments
{
    // Controller for Create siden til 'Equipment'.
    public class CreateModel : PageModel
    {
        // Databasekobling.
        private readonly EgdeBookingSystemV2.Data.EgdeBookingSystemConnection _context;

        // Constructor til klassen. Oppretter context som tilkobling til databasen.
        public CreateModel(EgdeBookingSystemV2.Data.EgdeBookingSystemConnection context)
        {
            _context = context;
        }

        // Blir kjørt når siden lastes inn.
        public IActionResult OnGet()
        {

        // Gir mulighet til å velge kategori og lokasjon til utstyr i form av nedtrekslister.
        ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "Name");
        ViewData["LocationID"] = new SelectList(_context.Locations, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Equipment Equipment { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // Sjekker om 'Equipment' objektet er gyldig.
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Lagrer utstyret i databasen.
            _context.Equipments.Add(Equipment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
