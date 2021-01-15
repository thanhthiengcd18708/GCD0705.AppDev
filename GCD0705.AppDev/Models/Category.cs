using System.ComponentModel.DataAnnotations;

namespace GCD0705.AppDev.Models
{
	public class Category
	{
		public int Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
	}
}