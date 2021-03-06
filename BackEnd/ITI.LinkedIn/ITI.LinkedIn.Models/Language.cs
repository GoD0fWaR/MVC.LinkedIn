﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.LinkedIn.Models
{
    [Table("Language")]
    public class Language
    {
        public Language()
        {
            UserLanguages = new HashSet<UserLanguage>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(50, ErrorMessage = " Name must be less than 50 characters")]
        public string Name { get; set; }

        public virtual ICollection<UserLanguage> UserLanguages { get; set; }
    }
}