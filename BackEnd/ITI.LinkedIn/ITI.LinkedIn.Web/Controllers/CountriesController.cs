using ITI.MVC.Layers.Core;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITI.MVC.Layers.Controllers
{
    public class CountriesController : Controller
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

            var countries = UnitOfWork.CountryManager.GetAllBind();

            return View("Index", countries);
        }
        [HttpGet]
        public ActionResult Add()
        {
           
            return View("Add");
        }
        [HttpPost]
        public ActionResult Add(Models.Country country)
        {
            if (ModelState.IsValid)
            {
                UnitOfWork.CountryManager.Add(country);
                return RedirectToAction("Index");
            }
            else
            {

                return View("Add", country);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ViewBag.Action = "Edit";
            var country = UnitOfWork.CountryManager.GetById(id);
            if (country != null)
            {
               
                return View("Edit", country);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Models.Country country, int id)
        {

            if (country != null && country.Id == id)
            {
                if (ModelState.IsValid)
                {
                    UnitOfWork.CountryManager.Update(country);
                    return RedirectToAction("Index");
                }
                
                return View("EmployeeForm", country);
            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            Models.Country country = UnitOfWork.CountryManager.GetById(id);
            if (country != null)
            {

                UnitOfWork.CountryManager.Remove(country);
                
            }

            return RedirectToAction("Index");
        }


    }
}