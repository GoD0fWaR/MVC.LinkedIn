using ITI.MVC.Layers.Core;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITI.MVC.Layers.Controllers
{
    public class CompaniesController : Controller
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
            var companies = UnitOfWork.OwinCompanyManager.GetAllBind();

            return View("Index", companies);
        }
        [HttpGet]
        public ActionResult Add()
        {

            return View("Add");
        }
        [HttpPost]
        public ActionResult Add(Models.Company company)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.CompanyManager.Add(company);
                return RedirectToAction("Index");
            }
            else
            {

                return View("Add", company);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ViewBag.Action = "Edit";
            var company = UnitOfWork.CompanyManager.GetById(id);
            if (company != null)
            {

                return View("Edit", company);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Models.Company company, int id)
        {

            if (company != null && company.Id == id)
            {
                if (ModelState.IsValid)
                {
                    UnitOfWork.CompanyManager.Update(company);
                    return RedirectToAction("Index");
                }

                return View("Edit", company);
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            Models.Company company = UnitOfWork.CompanyManager.GetById(id);
            if (company != null)
            {

                UnitOfWork.CompanyManager.Remove(company);

            }

            return RedirectToAction("Index");
        }


    }
}