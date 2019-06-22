using RegistrationForOOPCourseService.Models;
using System.Collections.Generic;

namespace RegistrationForOOPCourseService.Interfaces.Reader
{
    public interface IReaderTextFile
    {
        List<Student> Read(string fileName);
    }
}
