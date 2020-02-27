using ITI.MVC.Layers.Core;
using ITI.MVC.Layers.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITI.MVC.Layers.Controllers
{
    public class CertificationsController : Controller
    {
        // GET: Countries
        public UnitOfWork UnitOfWork
        {
            get
            {
                return HttpContext.GetOwinContext().Get<UnitOfWork>();
            }

        }
        [HttpGet]
        public ActionResult Index()
        {
             var certifications = UnitOfWork.CertificationManager.GetAllBind();
           
            return View("Index", certifications);
        }
        [HttpGet]
        public ActionResult Add()
        {
            CertificationViewModel certificationVM = new CertificationViewModel()
            {

                Companies = UnitOfWork.CompanyManager.GetAllBind()
            };
            return View("Add", certificationVM);
        }
        [HttpPost]
        public ActionResult Add(Models.Certification certification)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.CertificationManager.Add(certification);
                return RedirectToAction("index");
            }
            else
            {
                CertificationViewModel certificationVM = new CertificationViewModel()
                {

                    Companies = UnitOfWork.CompanyManager.GetAllBind()
                };
                return View("Add", certificationVM);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ViewBag.Action = "Edit";
            var certification = UnitOfWork.CertificationManager.GetById(id);
           
            if (certification != null)
            {
                CertificationViewModel certificationVM = new CertificationViewModel()
                {
                    Certification = certification,
                    Companies = UnitOfWork.CompanyManager.GetAllBind()
                };

                return View("Edit", certificationVM);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Models.Certification certification, int id)
        {

            if (certification != null && certification.Id == id)
            {
                if (ModelState.IsValid)
                {
                    UnitOfWork.CertificationManager.Update(certification);
                    return RedirectToAction("Index");
                }
                CertificationViewModel certificationVM = new CertificationViewModel()
                {
                    Certification = certification,
                    Companies = UnitOfWork.CompanyManager.GetAllBind()
                };

                return View("Edit", certificationVM);
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            Models.Certification certification = UnitOfWork.CertificationManager.GetById(id);
            if (certification != null)
            {

                UnitOfWork.CertificationManager.Remove(certification);

            }

            return RedirectToAction("Index");
        }


    }
}