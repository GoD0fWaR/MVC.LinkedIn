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
    public class CommentPhotoManager : Repository<CommentPhoto, ApplicationDbContext>, IDisposable
    {
        private static CommentPhotoManager manager;

        private CommentPhotoManager(ApplicationDbContext context) : base(context)
        {
        }

        public static CommentPhotoManager GetInstance(ApplicationDbContext context)
        {
            if (manager == null)
            {
                manager = new CommentPhotoManager(context);
            }
            return manager;
        }

        // needs rework
        /*public CommentPhoto SavePhotos(HttpPostedFileBase commentPhotoFile, HttpServerUtilityBase server)
        {
            CommentPhoto commentPhoto = new CommentPhoto();

            if (commentPhotoFile != null)
            {
                var commentPhotoName = Path.GetFileName(commentPhotoFile.FileName);

                commentPhoto.CommentPhotoName = commentPhotoName;
                commentPhoto.CommentPhotoExtension = Path.GetExtension(commentPhotoName);


                var path = Path.Combine(server.MapPath("~/Content/Assets/Images/CommentPhotos/"), commentPhoto.Date.Ticks + commentPhoto.CommentPhotoName);
                commentPhotoFile.SaveAs(path);
            }
            return commentPhoto;
        }

        public void DeletePhotos(CommentPhoto commentPhoto, HttpServerUtilityBase server)
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