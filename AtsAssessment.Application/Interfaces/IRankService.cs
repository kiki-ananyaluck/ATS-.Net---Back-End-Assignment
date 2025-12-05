using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtsAssessment.Domain.DTOs;

namespace AtsAssessment.Application.Interfaces
{
    public interface IRankService
    {
        IEnumerable<string> ProcessRank(RankRequest request);
    }
}
