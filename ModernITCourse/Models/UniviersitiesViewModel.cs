using ModernITCourse.Services.DomainTransferObjects;
using System.Collections.Generic;

namespace ModernITCourse.Models
{
    public class UniviersitiesViewModel
    {
        public IEnumerable<UniversityDto> Universities { get; set; }
    }
}
