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
    public class ValidatePhotosTypeAttribute : ValidationAttribute
    {
        /*protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            List<HttpPostedFileBase> files = value as List<HttpPostedFileBase>;
            string defaultErrorMessage = "Only Images Allowed";

            foreach (var file in files)
            {
                if (file != null)
                {
                    if (!Regex.IsMatch(file.FileName, @"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", RegexOptions.IgnoreCase))
                    {
                        return new ValidationResult(ErrorMessage ?? defaultErrorMessage);
                    }
                }
            }
            return ValidationResult.Success;
        }*/
    }
}