using ITI.LinkedIn.Context;
using ITI.LinkedIn.Models;
using ITI.LinkedIn.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ITI.LinkedIn.Core.Managers
{
    public class ReplyPhotoManager : Repository<ReplyPhoto, ApplicationDbContext>, IDisposable
    {
        private static ReplyPhotoManager manager;

        private ReplyPhotoManager(ApplicationDbContext context) : base(context)
        {
        }

        public static ReplyPhotoManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new ReplyPhotoManager(context);
            }
            return manager;
        }

        // needs rework
        /*public ReplyPhoto SavePhotos(HttpPostedFileBase replyPhotoFile, HttpServerUtilityBase server)
        {
            ReplyPhoto replyPhoto = new ReplyPhoto();

            if (replyPhotoFile != null)
            {
                var replyPhotoName = Path.GetFileName(replyPhotoFile.FileName);
                // those will be deleted and set the path of the img instead
                replyPhoto.CommentPhotoName = commentPhotoName;
                replyPhoto.CommentPhotoExtension = Path.GetExtension(commentPhotoName);


                var path = Path.Combine(server.MapPath("~/Content/Assets/Images/CommentPhotos/"), replyPhoto.Date.Ticks + replyPhoto.CommentPhotoName);
                replyPhotoFile.SaveAs(path);
            }
            return commentPhoto;
        }

        public void DeletePhotos(ReplyPhoto replyPhoto, HttpServerUtilityBase server)
        {
            string savedPhotoName = server.MapPath("~/Content/Assets/Images/CommentPhotos/" + commentPhoto.Date.Ticks + commentPhoto.CommentPhotoName);
            if (File.Exists(savedPhotoName))
            {
                File.Delete(savedPhotoName);
            }
        }*/

        public void Dispose()
        {
            manager = null;
        }
    }
}