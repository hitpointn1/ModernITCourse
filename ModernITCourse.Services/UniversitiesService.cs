using ModernITCourse.DataAccessLayer;
using ModernITCourse.Services.DomainTransferObjects;
using System.Linq;

namespace ModernITCourse.Services
{
    public class UniversitiesService : ServiceBase, IUniversitiesService
    {
        public UniversitiesService(CourseContext context) : base(context)
        {
        }

        public UniversityDto[] GetUniversitiesAboveRating(int rating)
        {
            return Context.Universities
                .Where(u => u.RATING > rating)
                .Select(u => new UniversityDto()
                {
                    ID = u.UNIV_ID,
                    City = u.CITY,
                    Name = u.UNIV_NAME,
                    Rating = u.RATING
                })
                .ToArray();
        }

        public UniversityDto[] GetUniversitiesWithStudentsOverCount(int count)
        {
            return Context.Universities
                .Where(u => u.Students.Count > count)
                .Select(u => new UniversityDto()
                {
                    ID = u.UNIV_ID,
                    City = u.CITY,
                    Name = u.UNIV_NAME,
                    Rating = u.RATING
                })
                .OrderByDescending(r => r.Rating)
                .ToArray();
        }
    }
}
