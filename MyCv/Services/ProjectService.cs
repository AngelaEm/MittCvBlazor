using Microsoft.EntityFrameworkCore;
using MyCv.Data;
using MyCv.Models;
using MyCv.Services.Interfaces;

namespace MyCv.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _context;

        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProjectModel>> GetAllAsync()
        {
            return await _context.Projects.ToListAsync();
        }
        public async Task<ProjectModel> GetByIdAsync(Guid id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task AddAsync(ProjectModel entity)
        {
            _context.Projects.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Projects.FindAsync(id);
            if (entity != null)
            {
                _context.Projects.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(ProjectModel entity)
        {
            var existingProject = await _context.Projects.FirstOrDefaultAsync(x => x.Id == entity.Id);
            if (existingProject != null)
            {
                _context.Entry(existingProject).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
