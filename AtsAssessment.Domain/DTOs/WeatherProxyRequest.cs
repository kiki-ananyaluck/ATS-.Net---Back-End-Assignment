using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtsAssessment.Domain.DTOs
{
    public class WeatherProxyRequest
    {
        public string Url { get; set; } = "";
        public string Method { get; set; } = "GET";
    }
}
