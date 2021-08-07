using JobPortalApi.BuisnessLogic.Interfaces;
using JobPortalApi.DataAccess;
using JobPortalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortalApi.BuisnessLogic.Implementation
{
    public class CityConcrete : ICity
    {
        private UnitOfWork unitofwork = new UnitOfWork();
        public IEnumerable<City> CityList = new List<City>();

        public IEnumerable<City> GetCity(int StateId)
        {
            try
            {
                CityList = unitofwork.CityRepository.GetEger().Where(a => a.StateId==StateId).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return CityList;
        }


    }
}