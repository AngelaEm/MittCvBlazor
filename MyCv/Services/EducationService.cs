using Microsoft.EntityFrameworkCore;
using MyCv.Data;
using MyCv.Models;
using MyCv.Services.Interfaces;

namespace MyCv.Services
{
    public class EducationService : IEducationService
    {
        private readonly ApplicationDbContext _context;

        public EducationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EducationModel>> GetAllAsync()
        {
            return await _context.Educations.ToListAsync();
        }

        public async Task AddAsync(EducationModel entity)
        {
            _context.Educations.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Educations.FindAsync(id);
            if (entity != null)
            {
                _context.Educations.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<EducationModel> GetByIdAsync(Guid id)
        {
            return await _context.Educations.FindAsync(id);
        }

        public async Task UpdateAsync(EducationModel entity)
        {
            var existingEntity = await _context.Educations.FindAsync(entity.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
