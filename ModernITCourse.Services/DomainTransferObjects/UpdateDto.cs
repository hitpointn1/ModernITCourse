using System;

namespace ModernITCourse.Services.DomainTransferObjects
{
    public class UpdateDto
    {
        public bool IsFinished { get; set; }
        public DateTime TimeStamp { get; set; }
        public bool NeedUpdate { get; set; }
    }
}
