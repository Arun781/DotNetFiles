
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PassingDataToViewInASP.NetCore_MVC.Models;

namespace PassingDataToViewInASP.NetCore_MVC.Models
{
    public interface IStudentRepository
    {
        Students GetStudentById(int Id);
    }
    public class Students
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
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

    public Students GetStudentById(int Id)
    {
        //throw new NotImplementedException();
        return this._studentList.FirstOrDefault(e => e.Id == Id);
    }
}
