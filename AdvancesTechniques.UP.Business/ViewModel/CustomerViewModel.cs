using AdvancedTechniques.UP.Business.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTechniques.UP.Business.ViewModel
{
    public class CustomerViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field First Name is mandatory", AllowEmptyStrings = false)]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Telephone { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
