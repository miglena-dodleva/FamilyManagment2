using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyManagement.Data.Entities
{
    public class UserToFamily
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public int FamilyId { get; set; }

        [ForeignKey(nameof(FamilyId))]
        public virtual Family Family { get; set; }
    }
}
