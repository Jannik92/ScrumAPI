using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/member")]
    public class MemberController : Controller
    {
        private MemberService Ms = new MemberService();
        
        [HttpPost]
        [Route("register")]
        public String Register([FromHeader]string Username, [FromHeader]string Password)
        {            
            if(Ms.Register(Username, Password))
            {
                return "200";
            }
            else
            {
                return "500";
            }            
        }

        [HttpPost]
        [Route("login")]
        public String Login([FromHeader]string Username, [FromHeader]string Password)
        {
            if (Ms.Login(Username, Password))
            {
                return "200";
            }
            else
            {
                return "500";
            }
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        
    }
}
