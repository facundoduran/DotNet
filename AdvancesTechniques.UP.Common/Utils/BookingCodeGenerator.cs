using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTechniques.UP.Common.Utils
{
    public static class BookingCodeGenerator    
    {
        public static string GetBookingCode() 
        {
            Guid guid = Guid.NewGuid();

            string[] guidParts = guid.ToString().Split(new string [] { "-" }, StringSplitOptions.RemoveEmptyEntries);

            string bookingCode =  string.Join(string.Empty, guidParts.Select(x => x[0]));

            return bookingCode.ToUpper();
        }
    }
}
