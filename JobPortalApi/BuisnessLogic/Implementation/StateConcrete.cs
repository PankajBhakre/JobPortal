using JobPortalApi.BuisnessLogic.Interfaces;
using JobPortalApi.DataAccess;
using JobPortalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobPortalApi.BuisnessLogic.Implementation
{
    public class StateConcrete : IState
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private IEnumerable<State> stateList = new List<State>();
        
        public IEnumerable<State> GetState(int countryId)
        {
            try
            {
                stateList =unitOfWork.StateRepository.GetEger().Where(a => a.CountryId ==countryId).ToList();
            }
            catch(Exception)
            {
                throw;
            }
            return stateList;
        }
       

    }
}