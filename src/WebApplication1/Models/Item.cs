using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public int estimatedEffort { get; set; }
        public int realEffort { get; set; } 

        //Owner
        public int OwnerId { get; set; }
        public Member Owner { get; set; }

        //Sprint
        public int SprintId { get; set; }
        public Sprint Sprint { get; set; }
        
    }
}
