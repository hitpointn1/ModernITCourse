using System.ComponentModel.DataAnnotations;

namespace ModernITCourse.DataAccessLayer.Entities
{
    public class Subject
    {
        [Key]
        public int SUBJ_ID { get; set; }
        [StringLength(20)]
        public string SUBJ_NAME { get; set; }
        public int HOUR { get; set; }
        public int SEMESTER { get; set; }
    }
}
