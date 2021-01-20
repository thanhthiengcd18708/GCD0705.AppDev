using System.ComponentModel.DataAnnotations;

namespace GCD0705.AppDev.Models
{
	public class TaskUser
	{
		public int Id { get; set; }
		[Required]
		public string ApplicationUserId { get; set; }
		public ApplicationUser User { get; set; }
		[Required]
		public int TaskId { get; set; }
		public Task Task { get; set; }
	}
}