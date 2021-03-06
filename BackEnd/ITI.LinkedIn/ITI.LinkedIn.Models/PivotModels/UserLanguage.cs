﻿using ITI.LinkedIn.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.LinkedIn.Models
{
    [Table("UserLanguage")]
    public class UserLanguage
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Language")]
        public int LanguageId { get; set; }
        public virtual Language Language { get; set; }

        public Proficiency Proficiency { get; set; }
    }
}