using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCRegistration.DBProvider;

namespace MVCRegistration.Task
{
   public class EmployeeTask :IDisposable
    {
        private readonly MVCRegistrationEntities Context;

        public EmployeeTask()
        {
            Context = new MVCRegistrationEntities();
        }

        public bool AddEmployee(Employee employee)
        {
            bool IsAdd = false;
            try
            {
                Context.Employees.Add(employee);
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

        public bool UpdateEmployee(Employee employee)
        {
            bool IsUpdate = false;
            try
            {
                var _employee = Context.Employees.Where(x => x.Id == employee.Id).FirstOrDefault();
                _employee.Id= employee.Id;
                _employee.Name= employee.Name;
                _employee.Address= employee.Address;
                _employee.Email = employee.Email;
                _employee.BirthDate = employee.BirthDate;
                _employee.CountryId = employee.CountryId;
                _employee.StateId = employee.StateId;
                _employee.CityId = employee.CityId;
                _employee.Gender = employee.Gender;
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

        public List<Employee> GetEmployeeList()
        {
            return Context.Employees.ToList();
        }

        public Employee GetEmployee(long Id)
        {
            return Context.Employees.Where(x => x.Id == Id).FirstOrDefault();
        }

        public bool DeleteEmployee(long Id)
        {
            bool IsDelete = false;
            try
            {
                var employee = Context.Employees.Where(x => x.Id == Id).FirstOrDefault();
                Context.Employees.Remove(employee);
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
