using JustNowBackend.Data;
using JustNowBackend.Data.Models;
using JustNowBackend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JustNowBackend.Services
{
    public class GradeService : IGradeService
    {
        private readonly MyDBContext dBContext;
        public GradeService(MyDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        public async Task AddGrade(UserRestaurantGrades grade)
        {
            await dBContext.Grades.AddAsync(grade);
            await dBContext.SaveChangesAsync();
        }

        public async Task<List<UserRestaurantGrades>> GetAllGrades()
        {
            return await dBContext.Grades.ToListAsync();
        }
    }
}
