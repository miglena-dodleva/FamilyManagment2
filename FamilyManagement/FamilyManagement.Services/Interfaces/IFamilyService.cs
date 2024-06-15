using FamilyManagement.Data.Entities;
using FamilyManagement.Services.Models.FamilyManagement;
using FamilyManagement.Services.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Services.Interfaces
{
    public interface IFamilyService
    {
        List<Family> GetAllFamilies();

        Family GetFamilyById(int userId);

        Family CreateFamily(FamilyModel model);

        Family EditFamily(FamilyModel model, int userId);

        Family DeleteFamily(int userId);
    }
}
