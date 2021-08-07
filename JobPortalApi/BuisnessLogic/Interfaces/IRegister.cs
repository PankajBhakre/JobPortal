using JobPortalApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobPortalApi.BuisnessLogic.Interfaces
{
   public interface IRegister
    {
        bool CheckExistUser(string userName);
        string InsertReg(Register reg);
        
    }
}
