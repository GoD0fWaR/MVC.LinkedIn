﻿using ITI.LinkedIn.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITI.LinkedIn.Models
{
    [Table("ReplyPhoto")]
    public class ReplyPhoto
    {
        [Key]
        public int Id { get; set; }

        public string Path { get; set; }

        [ForeignKey("Reply")]
        public int ReplyId { get; set; }
        public virtual Reply Reply { get; set; }
    }
}