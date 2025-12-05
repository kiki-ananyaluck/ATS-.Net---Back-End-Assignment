using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AtsAssessment.Domain.DTOs
{
    public class WeatherProxyResult
    {
        public string Url { get; set; }
        public string Method { get; set; }
        public object Response { get; set; }

        public WeatherProxyResult(string url, string method, object response)
        {
            Url = url;
            Method = method;
            Response = response;
        }
    }
}
