using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using MVCRegistration.DBProvider;

namespace MVCRegistration.Models
{
   public class StateViewModel
    {
        public StateViewModel()
        {
            lstCountry = new List<SelectListItem>();
        }

        public int StateId { get; set; }
        public string StateName { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public List<SelectListItem> lstCountry { get; set; }


    }
}
