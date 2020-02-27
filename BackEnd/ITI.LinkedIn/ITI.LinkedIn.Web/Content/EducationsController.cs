using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITI.LinkedIn.Context;
using ITI.LinkedIn.Models;
using Microsoft.AspNet.Identity;
using ITI.LinkedIn.Core;
using Microsoft.AspNet.Identity.Owin;

namespace ITI.LinkedIn.Web.Controllers
{
    public class EducationsController : Controller
    {
        public UnitOfWork UnitOfWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitOfWork>();
            }
        }

        // GET: Educations
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: Educations/Details/5
    //    public ActionResult Details(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Education education = db.Education.Find(id);
    //        if (education == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(education);
    //    }

    //    // GET: Educations/Create
    //    public ActionResult Create()
    //    {
    //        ViewBag.UserId = User.Identity.GetUserId();
    //        return View();
    //    }

    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create([Bind(Include = "Id,UserId,Name,Degree,FieldOfStudy,Grade,StartYear,EndYear,Description")] Education education)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            education.UserId = User.Identity.GetUserId();
    //            UnitOfWork.EducationManager.Add(education);
    //            return RedirectToAction("Index");
    //        }
    //        return View(education);
    //    }

    //    // GET: Educations/Edit/5
    //    public ActionResult Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Education education = db.Education.Find(id);
    //        if (education == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", education.UserId);
    //        return View(education);
    //    }

    //     [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit([Bind(Include = "Id,UserId,Name,Degree,FieldOfStudy,Grade,StartYear,EndYear,Description")] Education education)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Entry(education).State = EntityState.Modified;
    //            db.SaveChanges();
    //            return RedirectToAction("Index");
    //        }
    //        ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", education.UserId);
    //        return View(education);
    //    }

    //    // GET: Educations/Delete/5
    //    public ActionResult Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Education education = db.Education.Find(id);
    //        if (education == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(education);
    //    }

    //    // POST: Educations/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult DeleteConfirmed(int id)
    //    {
    //        Education education = db.Education.Find(id);
    //        db.Education.Remove(education);
    //        db.SaveChanges();
    //        return RedirectToAction("Index");
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            db.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }
    }
}
