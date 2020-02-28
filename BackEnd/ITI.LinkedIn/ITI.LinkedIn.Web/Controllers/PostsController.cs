using ITI.LinkedIn.Core;
using ITI.LinkedIn.Models;
using ITI.LinkedIn.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace ITI.LinkedIn.Web.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        public UnitOfWork unit
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitOfWork>();
            }
        }

        // GET: Post
        [HttpGet]
        [AllowAnonymous]
        public ActionResult List()
        {
            PostViewModel postModel = new PostViewModel()
            {

                Posts = unit.PostManager.GetAll()
            };
            return View("NewsFeed",postModel);
        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Post post = unit.PostManager.GetAll().Include(i => i.PostPhotos).SingleOrDefault(i => i.PostId == id);

            if (post == null)
            {
                return View("Not Found");
            }
            return View(post);
        }
        //[HttpGet]
        //public ActionResult Create()
        //{
        //    return View();
        //}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostViewModel model)
        {
            if (ModelState.IsValid && (model.Body !=null ||model.PostPhotos[0]!=null))
            {

                //get photos from request and save them to a local folder in the server
                List<PostPhoto> postPhotos = unit.PostPhotoManager.SavePhotos(model.PostPhotos, Server);
                
                Post post = new Post
                {
                    Body = model.Body,
                    PostPhotos = postPhotos,
                    UserId = User.Identity.GetUserId(),
                };
                unit.PostManager.Add(post);
                post.User = unit.ApplicationUserManager.FindById(post.UserId);
                return PartialView("_NewPost",post);
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Post post = unit.PostManager.GetById(id);
            if (post == null)
            {
                return View("Not Found");
            }
            return View(post);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                unit.PostManager.Update(post);
                return RedirectToAction("List");
            }
            return View(post);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Post post = unit.PostManager.GetAll().Include(i => i.PostPhotos).SingleOrDefault(i => i.PostId == id);

            if (post == null)
            {
                return View("Not Found");
            }
            return View(post);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            var post = unit.PostManager.GetById(id);
            if(post !=null)
            {

                var postPhotos = post.PostPhotos;

                //delete photos from the local folder 
                unit.PostPhotoManager.DeletePhotos(postPhotos, Server);
            
                unit.PostManager.Remove(post);
                return RedirectToAction("List");
            }
            return View();
        }
    }
}
