using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AtsAssessment.Domain.Auth;

namespace AtsAssessment.Application.Interfaces
{
    public interface IAuthService
    {
        JwtResult GenerateToken(JwtRequest request);
    }
}
