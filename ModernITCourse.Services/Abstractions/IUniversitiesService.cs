using ModernITCourse.Services.DomainTransferObjects;
using System.Threading.Tasks;

namespace ModernITCourse.Services
{
    public interface IUniversitiesService
    {
        UniversityDto[] GetUniversitiesAboveRating(int rating);
        UniversityDto[] GetUniversitiesWithStudentsOverCount(int count);
        Task UpdateUniversities();
    }
}
