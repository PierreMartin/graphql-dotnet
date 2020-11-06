using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfiniteSquare_InWink_GraphQl.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// TODO remove this file, not GraphQL
namespace InfiniteSquare_InWink_GraphQl.Controllers
{
    [ApiController]
    [Route("api/Classroom/Student")]
    public class ClassRoomController : ControllerBase
    {
        private IClassroomService _classroomService; 

        public ClassRoomController(IClassroomService classroomService)
        {
            _classroomService = classroomService;
        }

        [HttpPost]
        public ActionResult<bool> AddStudent(Student student)
        {
            if(_classroomService == null)
            {
                return NotFound();
            }

            var result = _classroomService.AddStudent(student);

            return result;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            if(_classroomService == null)
            {
                return NotFound();
            }

            var result = _classroomService.GetAllStudents().ToList();
            return result;
        }

    }
}
