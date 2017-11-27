using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCRegistration.DBProvider;

namespace MVCRegistration.Task
{
    public class CityTask : IDisposable
    {

        private readonly MVCRegistrationEntities Context;

        public CityTask()
        {
            Context = new MVCRegistrationEntities();
        }

        public bool AddCity(City city)
        {
            bool IsAdd = false;
            try
            {
                Context.Cities.Add(city);
                Context.SaveChanges();
                IsAdd = true;
            }
            catch (Exception ex)
            {
                IsAdd = false;
                throw (ex);
            }
            return IsAdd;
        }

        public bool UpdateCity(City city)
        {
            bool IsUpdate = false;
            try
            {
                var _city = Context.Cities.Where(x => x.CityId== city.CityId).FirstOrDefault();
                _city.StateId = city.StateId;
                _city.CityId = city.CityId;
                _city.CityName= city.CityName;

                Context.SaveChanges();
                IsUpdate = true;
            }
            catch (Exception ex)
            {
                IsUpdate = false;
                throw (ex);
            }
            return IsUpdate;
        }

        public List<City> GetCityList()
        {
            return Context.Cities.ToList();
        }

        public List<City> GetCityListByStateId(int stateId)
        {
            return Context.Cities.Where(x=>x.StateId ==stateId).ToList();
        }

        

        public City GetCity(long Id)
        {
            return Context.Cities.Where(x => x.CityId == Id).FirstOrDefault();
        }

        public bool DeleteCity(long Id)
        {
            bool IsDelete = false;
            try
            {
                var city = Context.Cities.Where(x => x.CityId == Id).FirstOrDefault();
                Context.Cities.Remove(city);
                Context.SaveChanges();
                IsDelete = true;
            }
            catch (Exception ex)
            {
                IsDelete = false;
                throw (ex);
            }
            return IsDelete;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
