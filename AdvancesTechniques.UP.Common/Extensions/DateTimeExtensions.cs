using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTechniques.UP.Common.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime? ParseDateTime(this string value)
        {
            try
            {
                return DateTime.ParseExact(value, "dd/MM/yyyy HH:mm", new CultureInfo("es-AR"), DateTimeStyles.None);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
