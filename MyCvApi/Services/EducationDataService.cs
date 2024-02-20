using Common.Interfaces;
using Common.Models;
using Microsoft.EntityFrameworkCore;
using MyCvApi.Data;

namespace MyCvApi.Services
{
    public class EducationDataService : IEducationService
    {
        private readonly ApiDbContext _context;

        public EducationDataService(ApiDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EducationModel>> GetAllAsync()
        {
	        try
	        {
		        return await _context.Educations.ToListAsync();
			}
	        catch (Exception e)
	        {
		        Console.WriteLine(e.Message);
		        return new List<EducationModel>();

	        }
            
        }

        public async Task AddAsync(EducationModel entity)
        {
            _context.Educations.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.Educations.FirstOrDefaultAsync(x => x.Id == id);
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
