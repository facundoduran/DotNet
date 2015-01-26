using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using AdvancedTechniques.UP.Business.Model;
using AdvancedTechniques.UP.Services;
using System.Collections.Generic;
using AdvancedTechniques.UP.Persistence.Sql;
using System.Data.Entity;


namespace AdvancedTechniquesUP.Test
{
    [TestClass]
    public class BookingServiceTest
    {
        [TestMethod]
        public void GetAllBooking()
        {
            /*
            Booking booking = new Booking();

            IList<Booking> bookingList = new List<Booking>() { booking };
                
            Mock<IDbContext> dbContextMock = new Mock<IDbContext>();
            dbContextMock.Setup(x => x.Set<Booking>()).Returns(dbSetMock.Object);

            Mock<IRepository<Booking>> bookingRepository = new Mock<IRepository<Booking>>();
            bookingRepository.Setup(x => x.GetAll()).Returns(bookingList);

            Mock<IUnitOfWork> unitOfWorkMock = new Mock<IUnitOfWork>();
            unitOfWorkMock.Setup(x => x.GetDbContext()).Returns(dbContextMock.Object);

            IBookingService bookingService = new BookingService(unitOfWorkMock.Object);

            Assert.AreEqual(bookingService.GetAll(), 1);
            */
        }
    }
}
