using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DTOs;
using Core.Models;

namespace Infrastructure.Repositories
{
    public interface IMovementsRepository
    {
        Task<IEnumerable<MovementsDTO>?> GetMovementsAsync( DateTime? startDate, DateTime? endDate, string? category,int page, int pageSize);
        Task<MovementsSummaryDTO?> GetSummaryAsync( DateTime? startDate, DateTime? endDate, string? category);
    }
}
