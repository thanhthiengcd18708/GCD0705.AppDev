using System;
using System.ComponentModel.DataAnnotations;

namespace GCD0705.AppDev.Models
{
	public class Task
	{
		[Key]
		public int Id { get; set; }

		[Required(ErrorMessage = "Name should not be Empty !!!")]
		[StringLength(255)]
		public string Name { get; set; }
		[Required(ErrorMessage = "Description should not be Empty !!!")]
		[StringLength(255)]
		public string Description { get; set; }
		[Required(ErrorMessage = "Due Date should not be Empty !!!")]
		public DateTime DueDate { get; set; }

	}
}