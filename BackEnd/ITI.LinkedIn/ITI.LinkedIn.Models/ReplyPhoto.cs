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
        [Column(Order = 1)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Reply")]
        public int ReplyId { get; set; }
        public virtual Reply Reply { get; set; }

        public string Path { get; set; }
    }
}