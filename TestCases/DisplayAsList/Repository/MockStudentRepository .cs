namespace DisplayAsList.Repository
{
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
