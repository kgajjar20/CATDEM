using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCRegistration.WebTask;
using MVCRegistration.Models;

namespace MVCRegistration.Controllers
{
    public class CountryController : Controller
    {

        private readonly CountryWebTask _countryWebTask;

        public CountryController()
        {
            _countryWebTask = new CountryWebTask();
        }

        // GET: Cource
        public ActionResult Index()
        {
            var countryList = _countryWebTask.GetCountryList();
            return View(countryList);
        }
        public JsonResult GetCountryList()
        {
            List<CountryViewModel> lstModel = new List<CountryViewModel>();
            var data = _countryWebTask.GetCountryList();

            lstModel = data.Select(x => new CountryViewModel
            {
                CountryId = x.CountryId,
                CountryName = x.CountryName,
            }).ToList();
            return Json(lstModel, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddCountry()
        {
            try
            {
                CountryViewModel model = new CountryViewModel();
                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult AddCountry(CountryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _countryWebTask.AddCountry(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Edit(long Id)
        {
            try
            {
                if (Id > 0)
                {
                    var model = _countryWebTask.GetCountry(Id);
                    return View(model);
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(CountryViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _countryWebTask.UpdateCountry(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public ActionResult Delete(int Id)
        {
            _countryWebTask.DeleteCountry(Id);
            return RedirectToAction("Index");
        }

    }
}