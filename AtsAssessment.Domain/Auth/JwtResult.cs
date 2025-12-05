using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtsAssessment.Domain.Auth
{
    public class JwtResult
    {
        public string Token { get; set; }
        public DateTime Expires { get; set; }

        public JwtResult(string token, DateTime expires)
        {
            Token = token;
            Expires = expires;
        }
    }
}
