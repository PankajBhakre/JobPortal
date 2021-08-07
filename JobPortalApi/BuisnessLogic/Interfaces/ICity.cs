using JobPortalApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalApi.BuisnessLogic.Interfaces
{
   public interface ICity
    {
        IEnumerable<City> GetCity(int StateId);
    }
}
