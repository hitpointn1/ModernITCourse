using ModernITCourse.DataAccessLayer;

namespace ModernITCourse.Services
{
    public abstract class ServiceBase
    {
        protected ServiceBase(CourseContext context)
        {
            Context = context;
        }

        protected CourseContext Context { get; set; }
    }
}
