using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCRegistration.DBProvider;
namespace MVCRegistration.Task
{
    public class CountryTask : IDisposable
    {
        private readonly MVCRegistrationEntities Context;

        public CountryTask()
        {
            Context = new MVCRegistrationEntities();
        }

        public bool AddCountry(Country country)
        {
            bool IsAdd = false;
            try
            {
                Context.Countries.Add(country);
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

        public bool UpdateCountry(Country country)
        {
            bool IsUpdate = false;
            try
            {
                var _country = Context.Countries.Where(x => x.CountryId== country.CountryId).FirstOrDefault();
                _country.CountryId= country.CountryId;
                _country.CountryName= country.CountryName;

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

        public List<Country> GetCountryList()
        {
            return Context.Countries.ToList();
        }

        public Country GetCountry(long Id)
        {
            return Context.Countries.Where(x => x.CountryId == Id).FirstOrDefault();
        }

        public bool DeleteCountry(long Id)
        {
            bool IsDelete = false;
            try
            {
                var country = Context.Countries.Where(x => x.CountryId== Id).FirstOrDefault();
                Context.Countries.Remove(country);
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
