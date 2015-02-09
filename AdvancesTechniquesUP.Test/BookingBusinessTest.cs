using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdvancedTechniques.UP.Business.Model;
using System.Globalization;

namespace AdvancedTechniquesUP.Test
{
    [TestClass]
    public class BookingBusinessTest
    {
        [TestMethod]
        public void Overlap_IsBetweenTest()
        {
            Booking booking = new Booking();
            booking.FromTime = DateTime.ParseExact("21/01/2014 06:30", "dd/MM/yyyy hh:mm",new CultureInfo("es-AR"), DateTimeStyles.None);
            booking.ToTime = DateTime.ParseExact("21/01/2014 09:00", "dd/MM/yyyy hh:mm",new CultureInfo("es-AR"), DateTimeStyles.None);

            DateTime overlapFromTime = DateTime.ParseExact("21/01/2014 07:30", "dd/MM/yyyy hh:mm", new CultureInfo("es-AR"), DateTimeStyles.None);
            DateTime overlapToTime = DateTime.ParseExact("21/01/2014 08:30", "dd/MM/yyyy hh:mm", new CultureInfo("es-AR"), DateTimeStyles.None);

            Assert.AreEqual(true, booking.IsOverlap(overlapFromTime, overlapToTime));
        }

        [TestMethod]
        public void Overlap_IsOutsideTest()
        {
            Booking booking = new Booking();
            booking.FromTime = DateTime.ParseExact("21/01/2014 06:30", "dd/MM/yyyy hh:mm", new CultureInfo("es-AR"), DateTimeStyles.None);
            booking.ToTime = DateTime.ParseExact("21/01/2014 09:00", "dd/MM/yyyy hh:mm", new CultureInfo("es-AR"), DateTimeStyles.None);

            DateTime overlapFromTime = DateTime.ParseExact("21/01/2014 05:30", "dd/MM/yyyy hh:mm", new CultureInfo("es-AR"), DateTimeStyles.None);
            DateTime overlapToTime = DateTime.ParseExact("21/01/2014 10:30", "dd/MM/yyyy hh:mm", new CultureInfo("es-AR"), DateTimeStyles.None);

            Assert.AreEqual(true, booking.IsOverlap(overlapFromTime, overlapToTime));
        }

        [TestMethod]
        public void Overlap_FromIsOutside()
        {
            Booking booking = new Booking();
            booking.FromTime = DateTime.ParseExact("21/01/2014 06:30", "dd/MM/yyyy hh:mm", new CultureInfo("es-AR"), DateTimeStyles.None);
            booking.ToTime = DateTime.ParseExact("21/01/2014 09:00", "dd/MM/yyyy hh:mm", new CultureInfo("es-AR"), DateTimeStyles.None);

            DateTime overlapFromTime = DateTime.ParseExact("21/01/2014 05:30", "dd/MM/yyyy hh:mm", new CultureInfo("es-AR"), DateTimeStyles.None);
            DateTime overlapToTime = DateTime.ParseExact("21/01/2014 08:30", "dd/MM/yyyy hh:mm", new CultureInfo("es-AR"), DateTimeStyles.None);

            Assert.AreEqual(true, booking.IsOverlap(overlapFromTime, overlapToTime));
        }

        [TestMethod]
        public void Overlap_ToDateIsOutside()
        {
            Booking booking = new Booking();
            booking.FromTime = DateTime.ParseExact("21/01/2014 08:00", "dd/MM/yyyy hh:mm", new CultureInfo("es-AR"), DateTimeStyles.None);
            booking.ToTime = DateTime.ParseExact("21/01/2014 10:00", "dd/MM/yyyy hh:mm", new CultureInfo("es-AR"), DateTimeStyles.None);

            DateTime overlapFromTime = DateTime.ParseExact("21/01/2014 09:00", "dd/MM/yyyy hh:mm", new CultureInfo("es-AR"), DateTimeStyles.None);
            DateTime overlapToTime = DateTime.ParseExact("21/01/2014 11:00", "dd/MM/yyyy hh:mm", new CultureInfo("es-AR"), DateTimeStyles.None);

            Assert.AreEqual(true, booking.IsOverlap(overlapFromTime, overlapToTime));
        }

        [TestMethod]
        public void Overlap_NotExistOverlap()
        {
            Booking booking = new Booking();
            booking.FromTime = DateTime.ParseExact("21/01/2014 08:00", "dd/MM/yyyy hh:mm", new CultureInfo("es-AR"), DateTimeStyles.None);
            booking.ToTime = DateTime.ParseExact("21/01/2014 10:00", "dd/MM/yyyy hh:mm", new CultureInfo("es-AR"), DateTimeStyles.None);

            DateTime overlapFromTime = DateTime.ParseExact("21/01/2014 10:00", "dd/MM/yyyy hh:mm", new CultureInfo("es-AR"), DateTimeStyles.None);
            DateTime overlapToTime = DateTime.ParseExact("21/01/2014 11:00", "dd/MM/yyyy hh:mm", new CultureInfo("es-AR"), DateTimeStyles.None);

            Assert.AreEqual(false, booking.IsOverlap(overlapFromTime, overlapToTime));
        }
    }
}
