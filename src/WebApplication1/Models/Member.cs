using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public String Name { get; set; }
        public ICollection<MemberTeam> MemberTeams { get; set; }
        public ICollection<Item> AssignedItems { get; set; }
    }
}
