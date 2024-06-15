using FamilyManagement.Data.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FamilyManagement.Models.Enums;

namespace FamilyManagement.Models.Entities
{
    public class RefreshToken
    {
        [Key]
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime CreatedOn { get; set; }
        public RefreshTokenStatus Status { get; set; }

        public int CreatedBy { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        public virtual User User { get; set; }
    }
}
