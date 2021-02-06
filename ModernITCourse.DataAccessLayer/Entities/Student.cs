using System;

namespace ModernITCourse.DataAccessLayer.Entities
{
    public class Student : UniversityRelatedPerson
    {
        public int STIPEND { get; set; }
        public int KURS { get; set; }
        public DateTime BIRTHDAY { get; set; }
    }
}
