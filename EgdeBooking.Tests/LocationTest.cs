using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EgdeBookingSystemV2.Data;
using EgdeBookingSystemV2.Models;
using EgdeBookingSystemV2.Pages.Locations;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Moq;
using Xunit;

namespace EgdeBooking.Tests
{
    public class LocationTest 
    {

        [Fact]
        public async Task GetDetailsModel_OnNullInput_ExpectNotFound()
        {
            var mockContext = new Mock<EgdeBookingSystemConnection>();
            var detailsModel = new DetailsModel(mockContext.Object);
            var page = await detailsModel.OnGetAsync(null);
            page.Should().BeAssignableTo<NotFoundResult>();
        }

        [Fact]
        public async Task GetDetailsModel_ReturnsOtherId_ExpectNotFound()
        {
            var options = new DbContextOptionsBuilder<EgdeBookingSystemConnection>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            await using (var context = new EgdeBookingSystemConnection(options))
            {
                await context.Locations.AddAsync(new Location
                {
                    ID = 2,
                    Name = "Porsgrunn"
                });
                await context.SaveChangesAsync();
            }

            // Use a clean instance of the context to run the test
            await using (var context = new EgdeBookingSystemConnection(options))
            {

                var detailsModel = new DetailsModel(context);
                var page = await detailsModel.OnGetAsync(3);
                page.Should().BeAssignableTo<NotFoundResult>();
            }
        }

        [Fact]
        public async Task GetDetailsModel_ReturnsModel_ExpectResult()
        {
            var options = new DbContextOptionsBuilder<EgdeBookingSystemConnection>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            await using (var context = new EgdeBookingSystemConnection(options))
            {
                await context.Locations.AddAsync(new Location
                {
                    ID = 2,
                    Name = "Porsgrunn"
                });
                await context.SaveChangesAsync();
            }


            // Use a clean instance of the context to run the test
            await using (var context = new EgdeBookingSystemConnection(options))
            {

                var detailsModel = new DetailsModel(context);
                var page = await detailsModel.OnGetAsync(2);
                page.Should().BeAssignableTo<PageResult>();
            }
        }
    }
}