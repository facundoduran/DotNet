using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using AdvancedTechniques.UP.Services;
using System.Threading.Tasks;

namespace AdvancedTechniques.Web.SignalR
{
    public class OffersByDateHub : Hub
    {
        private IBookingService bookingService;

        public OffersByDateHub(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        public void GetOffersByDate() 
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<OffersByDateHub>();
            if (hubContext != null)
            {
                var offersByDay = this.bookingService.GetOffersByDay(DateTime.Now);

                hubContext.Clients.All.getOffersByDate(offersByDay);
            }
        }
    }
}