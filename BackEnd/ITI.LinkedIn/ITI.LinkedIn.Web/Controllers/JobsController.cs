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
    public class JobsController : Controller
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
            var jobs = UnitOfWork.JobManager.GetAllBind();

            return View("Index", jobs);
        }
        [HttpGet]
        public ActionResult Add()
        {
            JobViewModel vm = new JobViewModel()
            {
                Countries = UnitOfWork.CountryManager.GetAllBind(),
                Companies = UnitOfWork.CompanyManager.GetAllBind(),
                EmploymentTypes = UnitOfWork.EmploymentTypeManager.GetAllBind()
            };
            return View("Add", vm);
        }
        [HttpPost]
        public ActionResult Add(Models.Job job)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.JobManager.Add(job);
                return RedirectToAction("index");
            }
            else
            {
                JobViewModel vm = new JobViewModel()
                {
                    Countries = UnitOfWork.CountryManager.GetAllBind(),
                    Companies = UnitOfWork.CompanyManager.GetAllBind(),
                    EmploymentTypes = UnitOfWork.EmploymentTypeManager.GetAllBind()
                };
                return View("Add", vm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ViewBag.Action = "Edit";
            var job = UnitOfWork.JobManager.GetById(id);
            if (job != null)
            {
                JobViewModel vm = new JobViewModel()
                {
                    Countries = UnitOfWork.CountryManager.GetAllBind(),
                    Companies = UnitOfWork.CompanyManager.GetAllBind(),
                    Job = job,
                    EmploymentTypes = UnitOfWork.EmploymentTypeManager.GetAllBind()
                };

                return View("Edit", vm);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Models.Job job, int id)
        {

            if (job != null && job.Id == id)
            {
                if (ModelState.IsValid)
                {
                    UnitOfWork.JobManager.Update(job);
                    return RedirectToAction("Index");
                }
                JobViewModel vm = new JobViewModel()
                {
                    Countries = UnitOfWork.CountryManager.GetAllBind(),
                    Companies = UnitOfWork.CompanyManager.GetAllBind(),
                    Job = job,
                    EmploymentTypes = UnitOfWork.EmploymentTypeManager.GetAllBind()
                };


                return View("Edit", vm);
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            Models.Job job = UnitOfWork.JobManager.GetById(id);
            if (job != null)
            {

                UnitOfWork.JobManager.Remove(job);

            }

            return RedirectToAction("Index");
        }


    }
}