using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Mvc;
using MobelBindingMvc.Models;

namespace MobelBindingMvc.Controllers
{    
    public class FriendController : Controller
    {
        [HttpPost]
        public IActionResult Name([FromForm]string name) {
            return new HttpStatusCodeResult(200);
        }

        [HttpPost]
        public IActionResult Create([FromBody]Friend model)
        {            
            return new HttpStatusCodeResult(201);
        }

        [HttpPost]
        public IActionResult Bunch([FromBody]List<Friend> model)
        {
            return new HttpStatusCodeResult(201);
        }
    }
}