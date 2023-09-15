using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DisplayAsList21AugGivenExample.Models
{
	public interface IStudentRepository
	{
		Students GetStudentById(int Id);
		IEnumerable<Students> GetAllStudents();
	}
	public class Students
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
	}
	public class MockStudentRepository : IStudentRepository
	{
		private List<Students> _studentList;

		public MockStudentRepository()
		{
			_studentList = new List<Students>()
		{
			new Students() { Id = 1, Name = "Mary", Address = "HR" },
			new Students() { Id = 2, Name = "John", Address = "IT" },
			new Students() { Id = 3, Name = "Sam", Address = "IT" },
		};
		}
		public IEnumerable<Students> GetAllStudents()
		{
			return _studentList;
		}

		public Students GetStudentById(int Id)
		{
			return this._studentList.FirstOrDefault(e => e.Id == Id);
		}
	}
}
