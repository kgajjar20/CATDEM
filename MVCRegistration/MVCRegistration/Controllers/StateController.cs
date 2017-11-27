using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCRegistration.WebTask;
using MVCRegistration.Models;

namespace MVCRegistration.Controllers
{
    public class StateController : Controller
    {

        private readonly CountryWebTask _countryWebTask;
        private readonly StateWebTask _stateWebTask;


        public StateController()
        {
            _countryWebTask = new CountryWebTask();
            _stateWebTask = new StateWebTask();
        }

        // GET: Cource
        public ActionResult Index()
        {
            var stateList = _stateWebTask.GetStateList();
            return View(stateList);
        }

        public List<SelectListItem> GetCountryList()
        {
            List<SelectListItem> lstCountryList = new List<SelectListItem>();
            var data = _countryWebTask.GetCountryList();
            lstCountryList = data.Select(x => new SelectListItem
            {
                Text = x.CountryName,
                Value = x.CountryId.ToString(),
            }).ToList();

            return lstCountryList;
        }

        public ActionResult AddState()
        {
            try
            {
                StateViewModel model = new StateViewModel();
                model.lstCountry = GetCountryList();

                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult AddState(StateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _stateWebTask.AddState(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    model.lstCountry = GetCountryList();
                    return View(model);
                }
            }
            catch (Exception ex)
            {
                model.lstCountry = GetCountryList();
                return View(model);
            }
        }

        public ActionResult Edit(long Id)
        {
            try
            {
                if (Id > 0)
                {
                    var model = _stateWebTask.GetState(Id);
                    model.lstCountry = GetCountryList();
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
        public ActionResult Edit(StateViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _stateWebTask.UpdateState(model);
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
            _stateWebTask.DeleteState(Id);
            return RedirectToAction("Index");
        }

    }
}