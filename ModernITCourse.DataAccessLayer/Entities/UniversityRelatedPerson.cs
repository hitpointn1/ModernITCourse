using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModernITCourse.DataAccessLayer.Entities
{
    public abstract class UniversityRelatedPerson
    {
        [Key]
        public int ID { get; set; }
        [StringLength(20)]
        public string SURNAME { get; set; }
        [StringLength(20)]
        public string NAME { get; set; }
        [StringLength(50)]
        public string CITY { get; set; }

        [ForeignKey(nameof(University))]
        public int UNIV_ID { get; set; }
        public University University { get; set; }
    }
}
