using System.Collections.Generic;

namespace InfiniteSquare_InWink_GraphQl.Services
{
    public interface IClassroomService
    {
        bool AddStudent(Student student);

        IEnumerable<Student> GetAllStudents();
    }
}
