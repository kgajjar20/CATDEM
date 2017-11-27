using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCRegistration.WebTask;
using MVCRegistration.Models;

namespace MVCRegistration.Controllers
{
    public class CityController : Controller
    {
        private readonly StateWebTask _StateWebTask;
        private readonly CityWebTask _CityWebTask;


        public CityController()
        {
            _StateWebTask = new StateWebTask();
            _CityWebTask = new CityWebTask();
        }

        // GET: Cource
        public ActionResult Index()
        {
            var CityList = _CityWebTask.GetCityList();
            return View(CityList);
        }

        public List<SelectListItem> GetStateList()
        {
            List<SelectListItem> lstStateList = new List<SelectListItem>();
            var data = _StateWebTask.GetStateList();
            lstStateList = data.Select(x => new SelectListItem
            {
                Text = x.StateName,
                Value = x.StateId.ToString(),
            }).ToList();

            return lstStateList;
        }

        public ActionResult AddCity()
        {
            try
            {
                CityViewModel model = new CityViewModel();
                model.lstState = GetStateList();

                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult AddCity(CityViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _CityWebTask.AddCity(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    model.lstState = GetStateList();
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                model.lstState = GetStateList();
                return View(model);
            }
        }

        public ActionResult Edit(long Id)
        {
            try
            {
                if (Id > 0)
                {
                    var model = _CityWebTask.GetCity(Id);
                    model.lstState = GetStateList();
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
        public ActionResult Edit(CityViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _CityWebTask.UpdateCity(model);
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
            _CityWebTask.DeleteCity(Id);
            return RedirectToAction("Index");
        }

    }
}