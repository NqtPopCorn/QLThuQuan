using QLThuQuan.Data;
using QLThuQuan.Data.Services;
using Microsoft.EntityFrameworkCore;
using QLThuQuan.Data.Models;
public class ViolationService : IViolationService
{
    private readonly AppDbContext _context;

    public ViolationService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Violation>> GetUserViolationsAsync(int userId)
    {
        return await _context.Violations
            .Include(v => v.Rule)
            .Where(v => v.user_id == userId)
            .OrderByDescending(v => v.violated_at)
            .ToListAsync();
    }
}