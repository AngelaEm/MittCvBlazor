using Common.Interfaces;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using MyCvApi.Data;

namespace MyCvApi.Repositories
{
    public class ProjectRepository : IProjectService
    {
        private readonly ApiDbContext _context;

        public ProjectRepository(ApiDbContext context)
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
            var entity = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
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
