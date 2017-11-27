using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCRegistration.DBProvider;


namespace MVCRegistration.Task
{
    public class StateTask : IDisposable
    {
        private readonly MVCRegistrationEntities Context;

        public StateTask()
        {
            Context = new MVCRegistrationEntities();
        }

        public bool AddState(State state)
        {
            bool IsAdd = false;
            try
            {
                Context.States.Add(state);
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

        public bool UpdateState(State state)
        {
            bool IsUpdate = false;
            try
            {
                var _state = Context.States.Where(x => x.StateId== state.StateId).FirstOrDefault();
                _state.StateId= state.StateId;
                _state.StateName= state.StateName;
                _state.CountryId = state.CountryId;

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

        public List<State> GetStateList()
        {
            return Context.States.ToList();
        }

        public State GetState(long Id)
        {
            return Context.States.Where(x => x.StateId== Id).FirstOrDefault();
        }

        public bool DeleteState(long Id)
        {
            bool IsDelete = false;
            try
            {
                var state = Context.States.Where(x => x.StateId== Id).FirstOrDefault();
                Context.States.Remove(state);
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
