using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.LinkedIn.Models
{
    [Table("UserConnection")]
    public class UserConnection
    {
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Sender")]
        public string SenderId { get; set; }
        public virtual ApplicationUser Sender { get; set; }

        [Key]
        [Column(Order = 2)]
        [ForeignKey("Receiver")]
        public string ReceiverId { get; set; }
        public virtual ApplicationUser Receiver { get; set; }

        public bool IsAccepted { get; set; }
    }
}
