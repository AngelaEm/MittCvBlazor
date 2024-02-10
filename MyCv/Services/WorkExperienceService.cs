using Microsoft.EntityFrameworkCore;
using MyCv.Data;
using MyCv.Models;
using MyCv.Services.Interfaces;

namespace MyCv.Services
{
    public class WorkExperienceService : IWorkExperienceService
    {
        public readonly ApplicationDbContext _context;

        public WorkExperienceService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(WorkExperienceModel entity)
        {
            _context.WorkExperience.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var workExperienceToDelete = await _context.WorkExperience.FindAsync(id);
            if (workExperienceToDelete != null)
            {
                _context.WorkExperience.Remove(workExperienceToDelete);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<WorkExperienceModel>> GetAllAsync()
        {
            return await _context.WorkExperience.ToListAsync();
        }

        public async Task<WorkExperienceModel> GetByIdAsync(Guid id)
        {
            return await _context.WorkExperience.FindAsync(id);
        }

        public async Task UpdateAsync(WorkExperienceModel entity)
        {
            var workExperienceToUpdate = _context.WorkExperience.FirstOrDefault(x => x.Id == entity.Id);
            if (workExperienceToUpdate != null)
            {
                _context.Entry(workExperienceToUpdate).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
