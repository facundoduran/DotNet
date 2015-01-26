using AdvancedTechniques.UP.Business.Model;
using AdvancedTechniques.UP.Services;
using AdvancedTechniques.UP.Business.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdvancedTechniques.Web.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerService customerService;
        private IBookingService bookingService;

        public CustomerController(ICustomerService customerService, IBookingService bookingService) 
        {
            this.customerService = customerService;
            this.bookingService = bookingService;
        }
        //
        // GET: /Customer/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                Customer newCustomer = new Customer() 
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Telephone = customer.Telephone,
                    Email = customer.Email                    
                };

                this.customerService.Add(newCustomer);
            }

            return View();
        }

        public ActionResult Edit(int customerId)
        {
            Customer customer = this.customerService.GetById(customerId);

            if (customer != null)
            {
                CustomerViewModel customerViewModel = new CustomerViewModel()
                {
                    Id = customer.CustomerId,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Telephone = customer.Telephone,
                    Email = customer.Email
                };

                return View(customerViewModel);
            }

            return View();
        }

       [HttpPost]
       public ActionResult Edit(CustomerViewModel customerViewModel)
        {
            if (ModelState.IsValid)
            {
                Customer customer = this.customerService.GetById(customerViewModel.Id);

                if (customer != null)
                {
                    customer.FirstName = customerViewModel.FirstName;
                    customer.LastName = customerViewModel.LastName;
                    customer.Telephone = customerViewModel.Telephone;
                    customer.Email = customerViewModel.Email;

                    this.customerService.Edit(customer);
                }
            }

            return View();
        }

        public ActionResult Search(string customerName) 
        {
            IList<Customer> customers = this.customerService.GetCustomerByName(customerName);
            
            return View(customers);
        }

        public ActionResult MyBookings(int customerId) 
        {
            IList<Booking> bookings = this.bookingService.GetBookingsByCustomer(customerId);

            return View(bookings);
        }
	}
}