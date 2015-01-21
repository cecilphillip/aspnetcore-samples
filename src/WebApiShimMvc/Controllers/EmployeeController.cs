using Microsoft.AspNet.Mvc;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using WebApiShimMvc.Models;
using System.Linq;
using System;

namespace WebApiShimMvc.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Retrieve(string id)
        {

            var response = Request.CreateResponse(HttpStatusCode.OK, new Employee
            {
                Id = id,
                Name = "Jane Smith",
                Department = "Research and Development",
                Location = "Fort Lauderdale, Fl",
                Salary = 100000
            });

            response.Headers.Add("X-Custom", "Custom Value");
            return response;
        }

        [HttpPost]
        public HttpResponseMessage Create(Employee contact)
        {
            contact.Id = Guid.NewGuid().ToString();
            return Request.CreateResponse(HttpStatusCode.Created, contact);
        }

        [HttpGet]
        public HttpResponseMessage Echo()
        {
            var uri = Request.RequestUri;
            var headers = Request.Headers.Select(h => new { h.Key, h.Value });
            var method = Request.Method.Method;

            var response = Request.CreateResponse(HttpStatusCode.OK, new
            {
                Uri = uri,
                Headers = headers,
                Method = method
            });

            return response;
        }
    }
}