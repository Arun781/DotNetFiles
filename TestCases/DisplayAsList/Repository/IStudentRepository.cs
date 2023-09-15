namespace DisplayAsList.Repository
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
		// public string Email { get; set; }
		public string Address { get; set; }
	}
}

	