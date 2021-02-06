using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModernITCourse.DataAccessLayer.Entities
{
    public class SubjectLecturer
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey(nameof(Subject))]
        public int SUBJ_ID { get; set; }
        public Subject Subject { get; set; }

        [ForeignKey(nameof(Lecturer))]
        public int LECTURER_ID { get; set; }
        public Lecturer Lecturer { get; set; }
    }
}
