using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Team
    {
        public int TeamId { get; set; }
        public String Name { get; set; }
        public ICollection<MemberTeam> MemberTeams { get; set; }
    }
}
