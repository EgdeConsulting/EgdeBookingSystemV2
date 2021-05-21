using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EgdeBookingSystemV2.Data;
using EgdeBookingSystemV2.Models;

namespace EgdeBookingSystemV2.Pages.Categories
{
    // Controller for Create siden til 'Categories'.
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

        // Henter informasjon om objektet 'Category'.
        [BindProperty]
        public Category Category { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            // Sjekker om 'Category' objektet er gyldig.
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Legger kategorien i databasen.
            _context.Categories.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
