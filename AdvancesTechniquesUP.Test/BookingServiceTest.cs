using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AdvancedTechniques.UP.Business.Model;
using AdvancedTechniques.UP.Services;
using System.Collections.Generic;
using AdvancedTechniques.UP.Persistence.Sql;
using System.Data.Entity;
using System.Linq;

namespace AdvancedTechniquesUP.Test
{
    [TestClass]
    public class BookingServiceTest
    {
        [TestMethod]
        public void GetAllBooking()
        {
            Booking booking = new Booking();

            var bookings = new List<Booking>() { booking }.AsQueryable();

            //Mocks
            var bookingDbSet = new Mock<IDbSet<Booking>>();
            bookingDbSet.Setup(m => m.GetEnumerator()).Returns(bookings.GetEnumerator());

            Mock<IDbContext> dbContextMock = new Mock<IDbContext>();
            dbContextMock.Setup(x => x.Set<Booking>()).Returns(bookingDbSet.Object);

            var unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(x => x.GetDbContext()).Returns(dbContextMock.Object);

            //Service instance
            IBookingService bookingService = new BookingService(unitOfWorkMock.Object);

            var allbookings = bookingService.GetAll();

            Assert.AreEqual(allbookings.Any(), true);
        }
    }
}
