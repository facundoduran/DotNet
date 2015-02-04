using AdvancedTechniques.UP.Business.Model;
using AdvancedTechniques.UP.Business.Validators;
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

        [DateTimeAttribute(ErrorMessage = "The field check in must be a date")]
        public DateTime? FromTime { get; set; }

        [DateTimeAttribute(ErrorMessage = "The field check out must be a date")]
        [DateEqualTo("FromTime", "The field check out must be the equal than Check-in")]
        public DateTime? ToTime { get; set; }

        [Required(ErrorMessage = "The field customer is required")]
        public CustomerViewModel Customer { get; set; }

        [Required]
        [NumericAttribute(ErrorMessage = "The field Adults is required")]
        public int DinersQuantity { get; set; }

        public int CustomerId { get; set; }

        public int TableId { get; set; }

        public SalesChannel salesChannel { get; set; }
    }
}
