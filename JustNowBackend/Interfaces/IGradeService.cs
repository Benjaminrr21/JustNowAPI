using JustNowBackend.Data.Models;

namespace JustNowBackend.Interfaces
{
    public interface IGradeService
    {
        Task AddGrade(UserRestaurantGrades grade);
        Task <List<UserRestaurantGrades>> GetAllGrades();
    }
}
