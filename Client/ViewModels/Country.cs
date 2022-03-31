using SolarTaxApp.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolarTaxApp.Client.ViewModels
{
    public class Country
    {
        public string Stateid { get; set; }
        public string Code { get; set; }
        public string Statename { get; set; }
        public string Flag { get; set; }

        public static implicit operator Country(StateTb state)
        {
            return new Country
            {
                Stateid = state.StateId,
                Code = state.Code,
                Statename = state.StateName,
                Flag = state.Flag                
            };
        }

        public static implicit operator StateTb(Country state)
        {
            return new StateTb
            {
                StateId = state.Stateid,
                Code = state.Code,
                StateName = state.Statename,
                Flag = state.Flag
                
            };
        }
    }
}
