using AtsAssessment.Domain.DTOs;

namespace AtsAssessment.Application.Validators
{
    public static class RankValidator
    {
        public static (bool IsValid, string Error) Validate(RankRequest request)
        {
            if (request == null)
                return (false, "Request body is required.");

            if (string.IsNullOrWhiteSpace(request.p1))
                return (false, "Parameter 'p1' must not be empty.");

            if (request.p1.Length > 99)
                return (false, "Parameter 'p1' must not exceed 99 characters.");

            return (true, "");
        }
    }
}
