using ITI.LinkedIn.Core;
using ITI.LinkedIn.Models;
using ITI.LinkedIn.Web.Models;
using Microsoft.AspNet.Identity.Owin;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITI.LinkedIn.Web.Controllers
{
    public class UserLikedPostsController : Controller
    {
        public UnitOfWork unit
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitOfWork>();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserLikedPostViewModel userLikedPostModel)
        {
            if (ModelState.IsValid)
            {

                UserLikedPost likedPost = unit.UserLikedPostManager.GetById(userLikedPostModel.UserId, userLikedPostModel.PostId);
                if(likedPost==null)
                {
                    likedPost = new UserLikedPost()
                    {
                        UserId = userLikedPostModel.UserId,
                        PostId = userLikedPostModel.PostId,
                    };
                    unit.UserLikedPostManager.Add(likedPost);
                }
            }
            return RedirectToAction("Details","Posts", new { id = userLikedPostModel.PostId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UserLikedPostViewModel userLikedPostModel)
        {
            if (ModelState.IsValid)
            {
                UserLikedPost likedPost = unit.UserLikedPostManager.GetById(userLikedPostModel.UserId, userLikedPostModel.PostId);
                if (likedPost != null)
                {
                    unit.UserLikedPostManager.Remove(likedPost);
                }
            }
            return RedirectToAction("Details", "Posts", new { id = userLikedPostModel.PostId });
        }
    }
}