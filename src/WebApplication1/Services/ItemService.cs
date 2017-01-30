using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;

namespace WebApplication1.Services
{
    public class ItemService
    {
        DataModell access;

        public ItemService()
        {
            access = new DataModell();
        }      
    }
}
