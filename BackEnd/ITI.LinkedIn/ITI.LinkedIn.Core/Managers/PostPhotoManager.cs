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
    public class PostPhotoManager : Repository<PostPhoto, ApplicationDbContext>, IDisposable
    {
       
            private static PostPhotoManager manager;
            private PostPhotoManager(ApplicationDbContext context) : base(context)
            {
            }

            public static PostPhotoManager GetInstance(ApplicationDbContext context)
            {
                if (manager == null)
                {
                    manager = new PostPhotoManager(context);
                }
                return manager;
            }
            

        public List<PostPhoto> SavePhotos(List<HttpPostedFileBase> postPhotos,HttpServerUtilityBase server)
        {
            List<PostPhoto> postPhotosToReturn = new List<PostPhoto>();
            for (int i = 0; i < postPhotos.Count; i++)
            {
                var file = postPhotos[i];

                if (file != null )
                {
                    var postPhotoName = Path.GetFileName(file.FileName);
                    PostPhoto postPhoto = new PostPhoto()
                    {
                        PostPhotoName = postPhotoName,
                        PostPhotoExtension = Path.GetExtension(postPhotoName),


                    };
                    postPhotosToReturn.Add(postPhoto);
                    var path = Path.Combine(server.MapPath("~/Content/Assets/Images/PostPhotos/"), postPhoto.Date.Ticks + postPhoto.PostPhotoName);
                    file.SaveAs(path);
                }
            }
            return postPhotosToReturn;
        }
        public void Dispose()
        {
            manager = null;
        }

        public void DeletePhotos(ICollection<PostPhoto> postPhotos, HttpServerUtilityBase server)
        {
            foreach (var item in postPhotos)
            {
                string savedPhotoName = server.MapPath("~/Content/Assets/Images/PostPhotos/" + item.Date.Ticks + item.PostPhotoName);
                if (File.Exists(savedPhotoName))
                {

                    File.Delete(savedPhotoName);
                }

            }
        }
    }
    
}
