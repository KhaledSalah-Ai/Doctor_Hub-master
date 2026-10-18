using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data.Repositories.MedicalRepo
{
    public class MedicalSpecialtyRepository(ClincDbContext _dbContext) : IMedicalSpecialtyRepository
    {
        public async Task<IEnumerable<MedicalSpecialty>> GetAllAsync()
        {
            return await _dbContext.MedicalSpecialties.Include(s=>s.Advisor).ToListAsync();
        }

        public async Task<MedicalSpecialty?> GetByIdAsync(int id)
        {
            return await _dbContext.MedicalSpecialties.FindAsync(id);
        }

        public async Task AddAsync(MedicalSpecialty entity)
        {
            await _dbContext.MedicalSpecialties.AddAsync(entity);
        }

        public void Update(MedicalSpecialty entity)
        {
            _dbContext.MedicalSpecialties.Update(entity);
        }

        public void Delete(MedicalSpecialty entity)
        {
            _dbContext.MedicalSpecialties.Remove(entity);
        }
        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
