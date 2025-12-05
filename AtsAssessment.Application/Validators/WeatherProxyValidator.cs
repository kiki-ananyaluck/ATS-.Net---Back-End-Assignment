using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AtsAssessment.Domain.DTOs;

namespace AtsAssessment.Application.Validators
{
    public static class WeatherProxyValidator
    {
        public static (bool IsValid, string Error) Validate(WeatherProxyRequest request)
        {
            if (request == null)
                return (false, "Request body is required.");

            if (string.IsNullOrWhiteSpace(request.Url))
                return (false, "URL must not be empty.");

            if (!Uri.IsWellFormedUriString(request.Url, UriKind.Absolute))
                return (false, "URL is not a valid absolute URL.");

            return (true, "");
        }
    }
}
