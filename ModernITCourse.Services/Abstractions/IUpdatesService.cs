using ModernITCourse.Services.DomainTransferObjects;
using System;
using System.Threading.Tasks;

namespace ModernITCourse.Services
{
    public interface IUpdatesService
    {
        public Task<UpdateDto> GetUniversitiesListUpdate(DateTime? currentTimeStamp);
        public Task MarkAsUpdated(string tableName);
    }
}
