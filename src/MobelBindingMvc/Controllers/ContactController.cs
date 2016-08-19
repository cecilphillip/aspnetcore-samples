using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MobelBindingMvc.Models;

namespace MobelBindingMvc.Controllers
{    
    public class FriendController : Controller
    {
        [HttpPost]
        public IActionResult Name([FromForm]string name) {
            return new StatusCodeResult(200);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Friend model)
        {            
            return new StatusCodeResult(201);
        }

        [HttpPost]
        public IActionResult Bunch([FromBody]List<Friend> model)
        {
            return new StatusCodeResult(201);
        }
    }
}