using System;
using System.ComponentModel.DataAnnotations;

namespace TagHelpersMvc.Models
{
	public class Contact
	{
		[Required]
		[Display(Name = "Contact Name")]
		[DataType(DataType.Text)]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Date Of Birth")]
		[DataType(DataType.Date)]
		public DateTime DateOfBirth { get; set; }

		[Required]
		[Display(Name = "Phone Number")]
		[DataType(DataType.PhoneNumber)]
		public string PhoneNumber { get; set; }
		
		public string Id { get; set; }
	}
}