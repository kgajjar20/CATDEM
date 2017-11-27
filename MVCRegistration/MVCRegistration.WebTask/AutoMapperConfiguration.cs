using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MVCRegistration.DBProvider;
using MVCRegistration.Models;

namespace MVCRegistration.WebTask
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapping();
        }

        private static void Mapping()
        {
            Mapper.CreateMap<Country, CountryViewModel>();
            Mapper.CreateMap<CountryViewModel, Country>();

            Mapper.CreateMap<State, StateViewModel>();
            Mapper.CreateMap<StateViewModel, State>();

            Mapper.CreateMap<City, CityViewModel>();
            Mapper.CreateMap<CityViewModel, City>();

        }
    }
}
