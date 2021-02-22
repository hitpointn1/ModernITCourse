using System;

namespace ModernITCourse.DataAccessLayer.Entities
{
    public class UpdateInfo
    {
        public int ID { get; set; }
        public bool IsFinished { get; set; }
        public DateTime TimeStamp { get; set; }
        public string TableName { get; set; }
    }
}
