using ITI.MVC.Layers.Core;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITI.MVC.Layers.Controllers
{
    public class EmploymentTypesController : Controller
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
            var types = UnitOfWork.EmploymentTypeManager.GetAllBind();

            return View("Index", types);
        }
        [HttpGet]
        public ActionResult Add()
        {

            return View("Add");
        }
        [HttpPost]
        public ActionResult Add(Models.EmploymentType employmentType)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.EmploymentTypeManager.Add(employmentType);

                return RedirectToAction("index");
            } else
            {
                return View("Add", employmentType);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ViewBag.Action = "Edit";
            var employmentType = UnitOfWork.EmploymentTypeManager.GetById(id);
            if (employmentType != null)
            {

                return View("Edit", employmentType);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Models.EmploymentType employmentType, int id)
        {

            if (employmentType != null && employmentType.Id == id)
            {
                if (ModelState.IsValid)
                {
                    UnitOfWork.EmploymentTypeManager.Update(employmentType);
                    return RedirectToAction("Index");
                }

                return View("Edit", employmentType);
            }
            return View();
        }

        public bool Delete(int id)
        {
            Models.EmploymentType employmentType = UnitOfWork.EmploymentTypeManager.GetById(id);
            if (employmentType != null)
            {

                UnitOfWork.EmploymentTypeManager.Remove(employmentType);

            }

            return true;
        }


    }
}