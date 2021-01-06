using System;

namespace GCD0705.AppDev.Models
{
	public class Task
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime DueDate { get; set; }

		public Task(int id, string name, string description, DateTime dueDate)
		{
			Id = id;
			Name = name;
			Description = description;
			DueDate = dueDate;
		}
	}
}