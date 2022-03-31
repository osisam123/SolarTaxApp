using SolarTaxApp.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Server.Data
{
    public interface IStateData
    {
        List<StateTb> GetState();
        StateTb GetState(string id);
        StateTb AddState(StateTb state);
        StateTb EditState(StateTb state);
        void DeleteState(StateTb state);
    }
}
