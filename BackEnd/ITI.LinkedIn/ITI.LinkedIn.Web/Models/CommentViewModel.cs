using ITI.LinkedIn.Models.CustomValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITI.LinkedIn.Web.Models
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }

        public string Body { get; set; }

        [ValidatePhotoSize]
        [ValidatePhotoType]
        public HttpPostedFileBase CommentPhoto { get; set; }
        //public int PostId { get; set; }
    }
}