using AdvancedTechniques.UP.Business.Model;
using AdvancesTechniques.UP.Business.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTechniques.UP.Business.ViewModel
{
    public class BookingViewModel
    {
        public int Id { get; set; }

        [DateTimeAttribute(ErrorMessage = "The field check in mus be a date")]
        public DateTime? FromTime { get; set; }

        [DateTimeAttribute(ErrorMessage = "The field check out mus be a date")]
        [DateEqualTo("FromTime", "The field check out must be the equal than Check-in")]
        public DateTime? ToTime { get; set; }

        public CustomerViewModel Customer { get; set; }

        [Required]
        [NumericAttribute(ErrorMessage = "The field Adults is required")]
        public int DinersQuantity { get; set; }

        public int CustomerId { get; set; }

        public int TableId { get; set; }

        public SalesChannel salesChannel { get; set; }
    }
}
