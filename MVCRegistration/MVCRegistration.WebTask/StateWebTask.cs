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
    public class StateWebTask : IDisposable
    {
        private readonly StateTask _StateTask;

        public StateWebTask()
        {
            _StateTask = new StateTask();
        }

        public bool AddState(StateViewModel model)
        {
            var state = Mapper.Map<StateViewModel, State>(model);
            return _StateTask.AddState(state);
        }

        public bool UpdateState(StateViewModel model)
        {
            var state = Mapper.Map<StateViewModel, State>(model);
            return _StateTask.UpdateState(state);
        }

        public List<StateViewModel> GetStateList()
        {
            try
            {
                var state = Mapper.Map<List<State>, List<StateViewModel>>(_StateTask.GetStateList());
                return state;
            }
            catch (Exception)
            {
                return new List<StateViewModel>();
            }
        }

        public StateViewModel GetState(long Id)
        {
            var state = Mapper.Map<State, StateViewModel>(_StateTask.GetState(Id));
            return state;
        }

        public bool DeleteState(long Id)
        {
            return _StateTask.DeleteState(Id);
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
