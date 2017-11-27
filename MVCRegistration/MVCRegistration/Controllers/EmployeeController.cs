using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCRegistration.WebTask;
using MVCRegistration.Models;
using PagedList;


namespace MVCRegistration.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly CountryWebTask _CountryWebTask;
        private readonly StateWebTask _StateWebTask;
        private readonly CityWebTask _CityWebTask;
        private readonly EmployeeWebTask _EmployeeWebTask;


        public EmployeeController()
        {
            _CountryWebTask = new CountryWebTask();
            _StateWebTask = new StateWebTask();
            _CityWebTask = new CityWebTask();
            _EmployeeWebTask = new EmployeeWebTask();
        }

        // GET: Cource
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.EmailSortParm = String.IsNullOrEmpty(sortOrder) ? "email_desc" : "";
            ViewBag.CountrySortParm = String.IsNullOrEmpty(sortOrder) ? "country_desc" : "";
            ViewBag.StateSortParm = String.IsNullOrEmpty(sortOrder) ? "state_desc" : "";
            ViewBag.CitySortParm = String.IsNullOrEmpty(sortOrder) ? "city_desc" : "";
            ViewBag.BirthdateSortParm = String.IsNullOrEmpty(sortOrder) ? "birthdate_desc" : "Date";
            ViewBag.GenderSortParm = String.IsNullOrEmpty(sortOrder) ? "gender_desc" : "";


            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;



            var EmployeeList = _EmployeeWebTask.GetEmployeeList();

            if (!String.IsNullOrEmpty(searchString))
            {
                EmployeeList = EmployeeList.Where(s => s.Name.Contains(searchString)
                                       || s.Address.Contains(searchString)
                                       || s.Gender.Contains(searchString)).ToList();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    EmployeeList = EmployeeList.OrderByDescending(s => s.Name).ToList();
                    break;
                case "Date":
                    EmployeeList = EmployeeList.OrderBy(s => s.BirthDate).ToList();
                    break;
                case "birthdate_desc":
                    EmployeeList = EmployeeList.OrderByDescending(s => s.BirthDate).ToList();
                    break;
                case "email_desc":
                    EmployeeList = EmployeeList.OrderByDescending(s => s.Email).ToList();
                    break;
                case "country_desc":
                    EmployeeList = EmployeeList.OrderByDescending(s => s.CountryId).ToList();
                    break;
                case "state_desc":
                    EmployeeList = EmployeeList.OrderByDescending(s => s.StateId).ToList();
                    break;
                case "city_desc":
                    EmployeeList = EmployeeList.OrderByDescending(s => s.CityId).ToList();
                    break;
                case "gender_desc":
                    EmployeeList = EmployeeList.OrderByDescending(s => s.Gender).ToList();
                    break;

                default:
                    EmployeeList = EmployeeList.OrderBy(s => s.Name).ToList();
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(EmployeeList.ToPagedList(pageNumber, pageSize));
        }

        public List<SelectListItem> GetCountryList()
        {
            List<SelectListItem> lstCountryList = new List<SelectListItem>();
            var data = _CountryWebTask.GetCountryList();
            lstCountryList = data.Select(x => new SelectListItem
            {
                Text = x.CountryName,
                Value = x.CountryId.ToString(),
            }).ToList();

            return lstCountryList;
        }


        public ActionResult GetStateListByCountryId(int countryId)
        {
            var data = _StateWebTask.GetStateListByCountryId(countryId);
            var result = (from s in data
                          select new
                          {
                              StateId=s.StateId,
                              StateName = s.StateName
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCityListByStateId(int stateId)
        {
            var data = _CityWebTask.GetCityListByStateId(stateId);
            var result = (from s in data
                          select new
                          {
                              CityId =s.CityId,
                              CityName = s.CityName
                          }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        public ActionResult AddEmployee()
        {
            try
            {
                EmployeeViewModel model = new EmployeeViewModel();
                model.lstCountry= GetCountryList();

                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult AddEmployee(EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _EmployeeWebTask.AddEmployee(model);
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
                model.lstCountry= GetCountryList();
                return View(model);
            }
        }

        public ActionResult Edit(long Id)
        {
            try
            {
                if (Id > 0)
                {
                    var model = _EmployeeWebTask.GetEmployee(Id);
                    model.lstCountry= GetCountryList();
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
        public ActionResult Edit(EmployeeViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _EmployeeWebTask.UpdateEmployee(model);
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
            _EmployeeWebTask.DeleteEmployee(Id);
            return RedirectToAction("Index");
        }

    }
}