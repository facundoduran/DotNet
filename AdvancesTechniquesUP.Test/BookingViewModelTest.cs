using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdvancedTechniquesUP.Test.Helper;
using AdvancedTechniques.UP.Business.ViewModel;

namespace AdvancedTechniquesUP.Test
{
    [TestClass]
    public class BookingViewModelTest
    {
        [TestMethod]
        public void BookingViewModel_IsValid()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel()
            {
                FirstName = "Facundo",
                LastName = "Duran",
                Telephone = "1165693414",
                Email = "facundoduran@gmail.com"
            };

            BookingViewModel bookingViewModel = new BookingViewModel()
            {
                Customer = customerViewModel,
                FromTime =  DateTime.Now,
                ToTime = DateTime.Now.AddHours(1),
                DinersQuantity = 2
            };

            var listErrors = AttributeHelper.ValidateModel(bookingViewModel);

            Assert.AreEqual(0, listErrors.Count);
        }

        [TestMethod]
        public void BookingViewModel_HasInvalidDate()
        {
            CustomerViewModel customerViewModel = new CustomerViewModel()
            {
                FirstName = "Facundo",
                LastName = "Duran",
                Telephone = "1165693414",
                Email = "facundoduran@gmail.com"
            };

            BookingViewModel bookingViewModel = new BookingViewModel()
            {
                Customer = customerViewModel,
                FromTime = DateTime.Now,
                ToTime = DateTime.Now.AddDays(1),
                DinersQuantity = 2
            };

            var listErrors = AttributeHelper.ValidateModel(bookingViewModel);

            Assert.AreEqual(1, listErrors.Count);
        }
    }
}
