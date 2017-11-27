using MVCRegistration.DBProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCRegistration.Models
{
   public class EmployeeViewModel
    {
        public EmployeeViewModel()
        {
            lstCountry = new List<SelectListItem>();
            lstState = new List<SelectListItem>();
            lstCity = new List<SelectListItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Gender { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }

        public List<SelectListItem> lstCountry { get; set; }
        public List<SelectListItem> lstState { get; set; }
        public List<SelectListItem> lstCity { get; set; }
    }
}
