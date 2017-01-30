using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class MemberTeam
    {
        //Team
        public int TeamId { get; set; }
        public Team Team { get; set; }

        //Member
        public int MemberId { get; set; }
        public Member Member { get; set; }


    }
}
