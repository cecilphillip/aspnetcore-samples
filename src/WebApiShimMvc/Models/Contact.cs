using System;

namespace WebApiShimMvc.Models
{
    public class Contact
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Id { get; set; }
    }

    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public DateTime HiredDate { get; set; }
        public decimal Salary { get; set; }
        public string Location { get; set; }
    }

}