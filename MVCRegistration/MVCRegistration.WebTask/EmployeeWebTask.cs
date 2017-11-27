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
    public class EmployeeWebTask : IDisposable
    {
        private readonly EmployeeTask _EmployeeTask;

        public EmployeeWebTask()
        {
            _EmployeeTask= new EmployeeTask();
        }

        public bool AddEmployee(EmployeeViewModel model)
        {
            var employee = Mapper.Map<EmployeeViewModel, Employee>(model);
            return _EmployeeTask.AddEmployee(employee);
        }

        public bool UpdateEmployee(EmployeeViewModel model)
        {
            var employee = Mapper.Map<EmployeeViewModel, Employee>(model);
            return _EmployeeTask.UpdateEmployee(employee);
        }

        public List<EmployeeViewModel> GetEmployeeList()
        {
            try
            {
                var employee = Mapper.Map<List<Employee>, List<EmployeeViewModel>>(_EmployeeTask.GetEmployeeList());
                return employee;
            }
            catch (Exception)
            {
                return new List<EmployeeViewModel>();
            }
        }

        public EmployeeViewModel GetEmployee(long Id)
        {
            var city = Mapper.Map<Employee, EmployeeViewModel>(_EmployeeTask.GetEmployee(Id));
            return city;
        }

        public bool DeleteEmployee(long Id)
        {
            return _EmployeeTask.DeleteEmployee(Id);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
