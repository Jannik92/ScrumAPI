using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Member
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberId { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Password { get; set; }      
        public ICollection<MemberTeam> MemberTeams { get; set; }
        public ICollection<Item> AssignedItems { get; set; }
    }
}
