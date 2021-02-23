using ModernITCourse.Services.DomainTransferObjects;
using ModernITCourse.Services.Enums;

namespace ModernITCourse.Services
{
    public interface IExecutionService
    {
        public ExecutionDto GetStage(bool isStart);
    }
}
