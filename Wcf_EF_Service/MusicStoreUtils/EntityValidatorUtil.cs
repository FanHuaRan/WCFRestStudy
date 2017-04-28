using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreUtils
{
    /// <summary>
    /// 数据校验辅助类
    /// 2017/04/01
    /// </summary>
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
