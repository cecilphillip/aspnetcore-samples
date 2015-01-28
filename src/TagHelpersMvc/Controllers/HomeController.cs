using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using TagHelpersMvc.Models;
using System;

namespace TagHelpersMvc.Controllers
{
    public class HomeController : Controller
    {
        private static List<Contact> DataList { get; set; }
        static HomeController()
        {
            DataList = new List<Contact> {
                new Contact { Id="A-101", Name = "Cecil", PhoneNumber = "555-000-5555" },
                new Contact { Id="A-102", Name = "Dave", PhoneNumber = "555-111-5555" },
                new Contact { Id="A-103", Name = "Richie", PhoneNumber = "555-222-5555" },
                new Contact { Id="A-104", Name = "Janier", PhoneNumber = "555-333-5555" },
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index([Bind("Name", "DateOfBirth", "PhoneNumber")] Contact model)
        {
            model.Id =  "A-" + (new Random()).Next(105, 140);
            DataList.Add(model);
            return View();
        }

        public IActionResult List()
        {
            ViewBag.Message = "Your application description page.";

            return View(DataList);
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}