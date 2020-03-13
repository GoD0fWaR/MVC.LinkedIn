using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ITI.LinkedIn.Models.CustomValidators
{
    public class ValidatePhotoSizeAttribute : ValidationAttribute
    {
        /*protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int maxContent = 1024 * 1024;
            HttpPostedFileBase file = value as HttpPostedFileBase;

            if (file != null)
            {
                if (file.ContentLength > maxContent)
                {
                    ErrorMessage = "Your Photo is too large , the max size is " + (maxContent / 1024) + "MB";
                    return new ValidationResult(ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }*/
    }
}