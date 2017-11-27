using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MVCRegistration.Task;
using MVCRegistration.Models;
using MVCRegistration.DBProvider;

namespace MVCRegistration.WebTask
{
    public class CountryWebTask : IDisposable
    {
        private readonly CountryTask _CountryTask;

        public CountryWebTask()
        {
            _CountryTask = new CountryTask();
        }

        public bool AddCountry(CountryViewModel model)
        {
            var country = Mapper.Map<CountryViewModel, Country>(model);
            return _CountryTask.AddCountry(country);
        }

        public bool UpdateCountry(CountryViewModel model)
        {
            var country = Mapper.Map<CountryViewModel, Country>(model);
            return _CountryTask.UpdateCountry(country);
        }

        public List<CountryViewModel> GetCountryList()
        {
            try
            {
                var country = Mapper.Map<List<Country>, List<CountryViewModel>>(_CountryTask.GetCountryList());
                return country;
            }
            catch (Exception)
            {
                return new List<CountryViewModel>();
            }
        }

        public CountryViewModel GetCountry(long Id)
        {
            var country = Mapper.Map<Country, CountryViewModel>(_CountryTask.GetCountry(Id));
            return country;
        }

        public bool DeleteCountry(long Id)
        {
            return _CountryTask.DeleteCountry(Id);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
