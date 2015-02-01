using AdvancedTechniques.UP.Common.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTechniques.UP.Common.Helper
{
    public class ValidationHelper
    {
        public static EntityValidationResult ValidateEntity<T>(T entity)
            where T : class
        {
            return new EntityValidator<T>().Validate(entity);
        }
    }
}
