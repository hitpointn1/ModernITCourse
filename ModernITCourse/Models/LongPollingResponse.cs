using ModernITCourse.Services.DomainTransferObjects;
using System;

namespace ModernITCourse.Models
{
    public class LongPollingResponse
    {
        public bool IsFinished { get; set; }
        public DateTime TimeStamp { get; set; }
        public UniversityDto[] Universities { get; set; }
    }
}
