using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Services.Interfaces
{
    public interface ITokenGeneratorService
    {
        List<string> GenerateToken(string claimValue);
    }
}
