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
    public class UserLikedCommentsController : Controller
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
        public ActionResult Create(UserLikedCommentViewModel userLikedCommentModel)
        {
            if (ModelState.IsValid)
            {

                UserLikedComment likedComment = unit.UserLikedCommentManager.GetById(userLikedCommentModel.UserId, userLikedCommentModel.CommentId);
                if (likedComment == null)
                {
                    likedComment = new UserLikedComment()
                    {
                        UserId = userLikedCommentModel.UserId,
                        CommentId = userLikedCommentModel.CommentId
                    };
                    unit.UserLikedCommentManager.Add(likedComment);
                }
            }
            return RedirectToAction("Index", "Comments");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(UserLikedCommentViewModel userLikedCommentModel)
        {
            if (ModelState.IsValid)
            {
                UserLikedComment likedComment = unit.UserLikedCommentManager.GetById(userLikedCommentModel.UserId, userLikedCommentModel.CommentId);
                if (likedComment != null)
                {
                    unit.UserLikedCommentManager.Remove(likedComment);
                }
            }
            return RedirectToAction("Index", "Comments");
        }
    }
}