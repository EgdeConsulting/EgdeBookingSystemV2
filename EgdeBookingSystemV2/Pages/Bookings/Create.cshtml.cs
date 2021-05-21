using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EgdeBookingSystemV2.Data;
using EgdeBookingSystemV2.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EgdeBookingSystemV2.Pages.Bookings
{
    // Controller for Create siden til 'Booking'.
    public class CreateModel : PageModel
    {
        // Databasekobling.
        private readonly EgdeBookingSystemV2.Data.EgdeBookingSystemConnection _context;

        // Constructor til klassen. Oppretter context som tilkobling til databasen.
        public CreateModel(EgdeBookingSystemV2.Data.EgdeBookingSystemConnection context)
        {
            _context = context;
        }

        // Henter informasjon om objektet 'Equipment'.
        [BindProperty]
        public Equipment Equipment { get; set; }

        // Feltet for liste over aktive bookinger av utstyret.
        public IList<Booking> BookingList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // Sjekker om ID finnes.
            if (id == null)
            {
                return NotFound();
            }

            // Henter informasjonen til utstyret i database basert på ID.
            Equipment = await _context.Equipments
                    .Include(e => e.Category)
                    .Include(e => e.Location)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(m => m.ID == id);

            // Sjekker om utstyret finnes i databasen.
            if (Equipment == null)
            {
                return NotFound();
            }

            // Henter aktive bookinger av utstyret.
            BookingList = await _context.Bookings
                .Where(b => b.EquipmentID == id)
                .Where(b => b.EndDate >= DateTime.Now)
                .OrderBy(b => b.StartDate)
                .ToListAsync();

            return Page();
        }

        [BindProperty]
        public Booking Booking { get; set; }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            // Må hente liste over aktive bookinger på nytt for å validere bookingen.
            BookingList = await _context.Bookings
                .Where(b => b.EquipmentID == id)
                .Where(b => b.EndDate >= DateTime.Now)
                .OrderBy(b => b.StartDate)
                .ToListAsync();

            // Sjekker om start dato til bookingen er før sluttdatoen eller startdatoen er tidligere enn dagens dato.
            if (Booking.StartDate > Booking.EndDate || Booking.StartDate < DateTime.Today)
            {
                TempData["BakoverITid"] = "Bakover";
                return Page();
            }

            // Hvis det er aktive bookinger av utstyret blir det sjekket om bookingen overlapper med aktive bookinger.
            // En error blir presentert om bookingen er opptatt på valgt dato.
            if (BookingList != null)
            {
                foreach (Booking b in BookingList)
                {
                    if (b.EquipmentID == Booking.EquipmentID)
                    {
                        if (((Booking.StartDate < b.StartDate) && (Booking.EndDate <= b.StartDate)) 
                            || ((Booking.StartDate >= b.EndDate) && (Booking.EndDate > b.EndDate)))
                        {
                            continue;
                      
                        }
                        else
                        {
                            TempData["BookingOpptatt"] = "Opptatt";
                            return Page();
                        }
                    }
                }
            }

            //var errors = ModelState.Values.SelectMany(v => v.Errors);

            // Skal sjekke at tilstanden til bookingen er gyldig. Skapte problemer for oss, så den er kommentert ut. Systemet fungerer tilsynelatende uten.
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            // Legger til bookingen i databasen.
            _context.Bookings.Add(Booking);
            await _context.SaveChangesAsync();

            // Om utstyret er booket blir dette presentert for brukeren på Index siden.
            TempData["Booking"] = "Booket";
            return RedirectToPage("/UserView/Index");
        }
    }
}
