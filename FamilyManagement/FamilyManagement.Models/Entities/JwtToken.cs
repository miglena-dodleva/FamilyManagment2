using FamilyManagement.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FamilyManagement.Models.Enums;

namespace FamilyManagement.Models.Entities
{
    public class JwtToken
    {
        [Key]
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime CreatedOn { get; set; }
        public JwtTokenStatus Status { get; set; }
        
        public int CreatedBy { get; set; }

        [ForeignKey(nameof(CreatedBy))]
        public virtual User User { get; set; }
    }
}
