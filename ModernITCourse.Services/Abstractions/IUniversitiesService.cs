using ModernITCourse.Services.DomainTransferObjects;

namespace ModernITCourse.Services
{
    public interface IUniversitiesService
    {
        UniversityDto[] GetUniversitiesAboveRating(int rating);
        UniversityDto[] GetUniversitiesWithStudentsOverCount(int count);
    }
}
