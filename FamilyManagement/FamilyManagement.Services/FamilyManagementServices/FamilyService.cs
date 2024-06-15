using FamilyManagement.Data;
using FamilyManagement.Data.Entities;
using FamilyManagement.Services.Interfaces;
using FamilyManagement.Services.Models.FamilyManagement;
using FamilyManagement.Services.Models.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Services.FamilyManagementServices
{
    public class FamilyService : IFamilyService
    {
        private readonly FamilyManagementDbContext context;

        public FamilyService(FamilyManagementDbContext context)
        {
            this.context = context;
        }

        public List<Family> GetAllFamilies()
        {
            var families = context.Families
                 .ToList();

            return families;
        }

        public Family CreateFamily(FamilyModel model)
        {
            var family = new Family
            {
                Name = model.Name
            };

            context.Families.Add(family);
            context.SaveChanges();

            return family;
        }

        public Family GetFamilyById(int familyId)
        {
            var family = context.Families
                .Where(f => f.Id == familyId)
                .FirstOrDefault();

            return family;
        }

        public Family EditFamily(FamilyModel model, int familyId)
        {
            var family = GetFamilyById(familyId);

            if (family == null)
            {
                return family;
            }

            family.Name = model.Name;

            context.Families.Update(family);
            context.SaveChanges();

            return family;

        }

        public Family DeleteFamily(int familyId)
        {
            var family = GetFamilyById(familyId);

            if (family == null)
            {
                return family;
            }

            context.Families.Remove(family);
            context.SaveChanges();

            return family;
        }
    }
}
