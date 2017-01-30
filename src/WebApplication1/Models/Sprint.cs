using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Sprint
    {
        public int SprintId { get; set; }
        public String Title { get; set; }

        //Team
        public int TeamId { get; set; }
        public Team Team { get; set; }
        
        //Sprint Master
        public int MasterId { get; set; }
        public Member Master { get; set; }

        //Items
        public ICollection<Item> Items { get; set; }
    }
}
