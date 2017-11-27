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
    public class CityWebTask : IDisposable
    {
        private readonly CityTask _CityTask;

        public CityWebTask()
        {
            _CityTask = new CityTask();
        }

        public bool AddCity(CityViewModel model)
        {
            var city = Mapper.Map<CityViewModel, City>(model);
            return _CityTask.AddCity(city);
        }

        public bool UpdateCity(CityViewModel model)
        {
            var city = Mapper.Map<CityViewModel, City>(model);
            return _CityTask.UpdateCity(city);
        }

        public List<CityViewModel> GetCityList()
        {
            try
            {
                var city = Mapper.Map<List<City>, List<CityViewModel>>(_CityTask.GetCityList());
                return city;
            }
            catch (Exception)
            {
                return new List<CityViewModel>();
            }
        }

        public CityViewModel GetCity(long Id)
        {
            var city = Mapper.Map<City, CityViewModel>(_CityTask.GetCity(Id));
            return city;
        }

        public bool DeleteCity(long Id)
        {
            return _CityTask.DeleteCity(Id);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
