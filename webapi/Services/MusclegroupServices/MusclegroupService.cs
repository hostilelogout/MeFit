using Microsoft.EntityFrameworkCore;
using webapi.DatabaseContext;
using webapi.Exceptions;
using webapi.Models;

namespace webapi.Services.MusclegroupServices
{
    public class MusclegroupService : IMusclegroupService
    {

        private readonly MeFitContext _context;

        public MusclegroupService(MeFitContext context)
        {
            _context = context;
        }
        public async Task<Musclegroup> Create(Musclegroup entity)
        {
            _context.Musclegroups.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteById(int id)
        {
            var musclegroup = await _context.Musclegroups.FindAsync(id);

            if (musclegroup == null)
            {
                throw new EntityNotFoundException(id, nameof(Musclegroup));
            }
            _context.Musclegroups.Remove(musclegroup);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Musclegroup>> GetAll()
        {
            return await _context.Musclegroups.Include(x => x.Exercises).ToListAsync();
        }

        public async Task<Musclegroup> GetById(int id)
        {
            var musclegroup = await _context.Musclegroups.Include(x => x.Exercises).FirstOrDefaultAsync(x => x.Id == id);

            if (musclegroup == null)
            {
                throw new EntityNotFoundException(id, nameof(musclegroup));
            }
            return musclegroup;
        }

        public async Task<Musclegroup> Update(Musclegroup entity)
        {
            var foundMusclegroup = await _context.Musclegroups.AnyAsync(x => x.Id == entity.Id);
            if (!foundMusclegroup)
            {
                throw new EntityNotFoundException(entity.Id, nameof(Musclegroup));
            }
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
