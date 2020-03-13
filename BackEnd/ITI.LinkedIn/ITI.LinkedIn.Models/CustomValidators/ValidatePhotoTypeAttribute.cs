using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace ITI.LinkedIn.Models.CustomValidators
{
    public class ValidatePhotoTypeAttribute : ValidationAttribute
    {
        /*protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            HttpPostedFileBase file = value as HttpPostedFileBase;
            string defaultErrorMessage = "Only Images Allowed";

            if (file != null)
            {
                if (!Regex.IsMatch(file.FileName, @"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", RegexOptions.IgnoreCase))
                {
                    return new ValidationResult(ErrorMessage ?? defaultErrorMessage);
                }
            }
            return ValidationResult.Success;
        }*/
    }
}