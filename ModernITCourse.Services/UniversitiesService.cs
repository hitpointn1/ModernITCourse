using Microsoft.EntityFrameworkCore;
using ModernITCourse.DataAccessLayer;
using ModernITCourse.Services.DomainTransferObjects;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ModernITCourse.Services
{
    public class UniversitiesService : ServiceBase, IUniversitiesService
    {
        private static Random _rand = new Random();
        private readonly IUpdatesService updatesService;

        public UniversitiesService(CourseContext context, IUpdatesService updatesService) : base(context)
        {
            this.updatesService = updatesService;
        }

        public UniversityDto[] GetUniversitiesAboveRating(int rating)
        {
            return Context.Universities
                .AsNoTracking()
                .Where(u => u.RATING > rating)
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

        public UniversityDto[] GetUniversitiesWithStudentsOverCount(int count)
        {
            return Context.Universities
                .AsNoTracking()
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

        public async Task UpdateUniversities()
        {
            var universities = Context.Universities
                .Where(u => !u.UNIV_NAME.Equals("ВГУ"))
                .ToArray();

            foreach (var uni in universities)
                uni.RATING = _rand.Next(200, 700);

            await Context.SaveChangesAsync();
            await updatesService.MarkAsUpdated(nameof(Context.Universities));
        }

    }
}
