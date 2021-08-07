using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using JobPortalApi.BuisnessLogic.Interfaces;
using JobPortalApi.DataAccess;
using JobPortalApi.ViewModel;

namespace JobPortalApi.BuisnessLogic.Implementation
{
    public class CountryConcrete:ICountry
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        private IEnumerable<CountryViewModel> countryList = new List<CountryViewModel>();
        public IEnumerable<CountryViewModel> GetCountry()
        {
            try
            {
                countryList = unitOfWork.CountryRepository.GetEger().Select(a => new CountryViewModel
                {
                    CountryId = a.CountryId,
                    CountryName = a.CountryName
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            return countryList;
        }

    }

}
