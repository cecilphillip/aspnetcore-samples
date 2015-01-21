using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Linq;
using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;
using WebApiShimMvc.Models;
using System.Net;

namespace WebApiShimMvc.Controllers.Controllers
{
    public class ContactController : ApiController
    {
        [HttpGet]
        public IActionResult Retrieve(string id)
        {
            //id gets bound from the query string e.g ?id=1
            var contact = new Contact()
            {
                Id = id,
                Name = "John Smith",
                DateOfBirth = DateTime.Parse("10-12-1985"),
                Address = "Miami, Fl",
                PhoneNumber = "305-555-5555"
            };

            return Ok(contact);
        }

        [HttpGet]
        public IActionResult RetrieveError(int id)
        {
            //Error gets bubbled up to ErrorPage middleware
            throw new Exception("Boom!");
        }

        [HttpPost]
        public IActionResult ConflictStatus()
        {
            return StatusCode(HttpStatusCode.Conflict);
        }

        [HttpPost]
        public IActionResult Create(Contact contact)
        {
            // contact gets bound from the the bound
            return Created(Url.Action(), contact);
        }

        [HttpGet]
        public IActionResult Echo()
        {
            var uri = Request.RequestUri;
            var headers = Request.Headers.Select(h => new { h.Key, h.Value });
            var method = Request.Method.Method;

            return Content(HttpStatusCode.OK, new {
                Uri = uri,
                Headers = headers,
                Method = method
            });
        }
    }
}
