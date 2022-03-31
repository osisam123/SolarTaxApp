using SolarTaxApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Server.Data
{
    public class SqlStateData : IStateData
    {
        SolarTaxationDBContext _context;
        public SqlStateData(SolarTaxationDBContext context)
        {
            _context = context;
        }
        public StateTb AddState(StateTb state)
        {
            state.StateId = Guid.NewGuid().ToString();
            _context.StateTbs.Add(state);
            _context.SaveChanges();
            return state;
        }

        public void DeleteState(StateTb state)
        {
            _context.StateTbs.Remove(state);
            _context.SaveChanges();
        }

        public StateTb EditState(StateTb state)
        {
            var existingState = _context.StateTbs.Find(state.StateId);
            if (existingState != null)
            {
                existingState.Code = state.Code;
                existingState.StateName = state.StateName;
                existingState.Flag = state.Flag;
                _context.StateTbs.Update(existingState);
                _context.SaveChanges();
            }
            return state;
        }

        public List<StateTb> GetState()
        {
            return _context.StateTbs.ToList();
        }

        public StateTb GetState(string id)
        {
            var state = _context.StateTbs.Find(id);
            return state;
        }
    }
}
