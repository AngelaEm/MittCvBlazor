using Common.Interfaces;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using MyCvApi.Data;

namespace MyCvApi.Services
{
    public class SkillDataService : ISkillService
    {
        public readonly ApiDbContext _context;
        public SkillDataService(ApiDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(SkillModel entity)
        {
            _context.Skills.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var skillToDelete = await _context.Skills.FindAsync(id);
            if (skillToDelete != null)
            {
                _context.Skills.Remove(skillToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<SkillModel>> GetAllAsync()
        {
            return await _context.Skills.ToListAsync();
        }

        public async Task<SkillModel> GetByIdAsync(Guid id)
        {
            return await _context.Skills.FindAsync(id);
        }

        public async Task UpdateAsync(SkillModel entity)
        {
            var skillToUpdate = await _context.Skills.FindAsync(entity.Id);
            if (skillToUpdate != null)
            {
                _context.Entry(skillToUpdate).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
