using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyManagement.Services.Models.FamilyManagement
{
    public class ToDoListModel : BaseModel
    {
        public int OwnerId { get; set; }
    }
}
