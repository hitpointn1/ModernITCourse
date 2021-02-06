using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModernITCourse.DataAccessLayer.Entities
{
    public class ExamMarks
    {
        [Key]
        public int EXAM_ID { get; set; }
        public int MARK { get; set; }
        public DateTime EXAM_DATE { get; set; }

        [ForeignKey(nameof(Student))]
        public int STUDENT_ID { get; set; }
        public Student Student { get; set; }

        [ForeignKey(nameof(Subject))]
        public int SUBJ_ID { get; set; }
        public Subject Subject { get; set; }
    }
}
