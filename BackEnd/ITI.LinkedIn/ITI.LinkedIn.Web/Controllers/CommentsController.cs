using ITI.LinkedIn.Core;
using ITI.LinkedIn.Models;
using ITI.LinkedIn.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITI.LinkedIn.Web.Controllers
{
    public class CommentsController : Controller
    {
        public UnitOfWork unit
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitOfWork>();
            }
        }
        // GET: Comments
        //Just for testing
        public ActionResult Index()
        {
            IEnumerable<Comment> comments = unit.CommentManager.GetAll();
            return View(comments);
        }

        //for testing

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentViewModel model)
        {
            if (ModelState.IsValid && (model.Body != null || model.CommentPhoto != null))
            {


                //get photos from request and save them to a local folder in the server
                CommentPhoto commentPhoto = unit.CommentPhotoManager.SavePhotos(model.CommentPhoto, Server);



                Comment comment = new Comment
                {
                    Body = model.Body,
                    CommentPhoto = commentPhoto,
                    UserId = User.Identity.GetUserId(),
                    PostId = 5
                };
                unit.CommentManager.Add(comment);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Comment comment = unit.CommentManager.GetById(id);
            if (comment == null)
            {
                return View("Not Found");
            }
            return View(comment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Comment comment)
        {
            if (ModelState.IsValid)
            {
                unit.CommentManager.Update(comment);
                return RedirectToAction("Index");
            }
            return View(comment);
        }

        public ActionResult Delete(int id)
        {
            Comment comment = unit.CommentManager.GetAll().Include(i => i.CommentPhoto).SingleOrDefault(i => i.CommentId == id);

            if (comment == null)
            {
                return View("Not Found");
            }
            return View(comment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            var comment = unit.CommentManager.GetById(id);
            if (comment != null)
            {
                //delete photos from the local folder 
                unit.CommentPhotoManager.DeletePhotos(comment.CommentPhoto, Server);

                unit.CommentManager.Remove(comment);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}