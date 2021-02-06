using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ModernITCourse.DataAccessLayer.Entities
{
    public class University
    {
        [Key]
        public int UNIV_ID { get; set; }
        [StringLength(50)]
        public string UNIV_NAME { get; set; }
        [StringLength(50)]
        public string CITY { get; set; }
        public int RATING { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
