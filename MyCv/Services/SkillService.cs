using Microsoft.EntityFrameworkCore;
using MyCv.Data;
using MyCv.Models;
using MyCv.Services.Interfaces;

namespace MyCv.Services
{
    public class SkillService : ISkillService
    {
        public readonly ApplicationDbContext _context;
        public SkillService(ApplicationDbContext context)
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
            var skillToUpdate = await _context.Skills.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (skillToUpdate != null)
            {
                _context.Entry(skillToUpdate).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
