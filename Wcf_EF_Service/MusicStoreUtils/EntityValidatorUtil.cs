using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreUtils
{
    public class EntityValidatorUtil
    {
        public static bool Validate<T>(T entity)
        {
            var validationContext = new ValidationContext(entity);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(entity,validationContext, results, true);
            return isValid;
        }
    }
}
