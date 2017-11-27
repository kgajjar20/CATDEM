using MVCRegistration.DBProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MVCRegistration.Models
{
    public class CityViewModel
    {
        public CityViewModel()
        {
            lstState = new List<SelectListItem>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int StateId { get; set; }

        public List<SelectListItem> lstState { get; set; }
        public virtual State State { get; set; }

    }
}
