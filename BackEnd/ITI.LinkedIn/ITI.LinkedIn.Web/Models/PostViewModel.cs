
using ITI.LinkedIn.Models;
using ITI.LinkedIn.Models.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITI.LinkedIn.Web.Models
{
    public class PostViewModel
    {
        public PostViewModel()
        {
            PostPhotos = new List<HttpPostedFileBase>();
        }
        public IQueryable<Post> Posts { get; set; }

        public int PostId { get; set; }

        
        public string Body { get; set; }


        //To validate type of photo to be only images
        //[RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png|.jpg|.gif)$", ErrorMessage = "Only Image files allowed.")]
        [ValidatePhotosType]
        [ValidatePhotosSize]
        public virtual List<HttpPostedFileBase> PostPhotos { get; set; }

    }
}