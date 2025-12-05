using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtsAssessment.Application.Interfaces;
using AtsAssessment.Domain.DTOs;
using System.Text.RegularExpressions;

namespace AtsAssessment.Application.Services
{
    public class RankService : IRankService
    {
        public IEnumerable<string> ProcessRank(RankRequest request)
        {
            // 1) เตรียม input → trim space และตัดค่า null/ว่างออก
            var items = request.p1
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();

            if (!items.Any())
                return Enumerable.Empty<string>();

            // 2) หาเฉพาะค่าที่ซ้ำกันเท่านั้น
            var duplicates = items
                .GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            // 3) ไม่มี duplicate → คืน empty list
            if (!duplicates.Any())
                return Enumerable.Empty<string>();

            // 4) การ sort:
            //    - ตัวอักษร มาก่อน ตัวเลข
            //    - A-Z ก่อน
            //    - 0-9 ต่อจากตัวอักษร
            var sorted = duplicates
                .OrderBy(x => IsDigit(x) ? 1 : 0)  // ตัวเลขไปอยู่กลุ่มหลัง
                .ThenBy(x => x, StringComparer.OrdinalIgnoreCase)
                .ToList();

            return sorted;
        }

        private bool IsDigit(string value)
        {
            return Regex.IsMatch(value, @"^\d+$");
        }
    }
}
