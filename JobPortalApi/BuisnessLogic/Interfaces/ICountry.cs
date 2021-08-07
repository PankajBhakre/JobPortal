using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JobPortalApi.ViewModel;

namespace JobPortalApi.BuisnessLogic.Interfaces
{
   public interface ICountry
    {
        IEnumerable<CountryViewModel> GetCountry();

    }
}
