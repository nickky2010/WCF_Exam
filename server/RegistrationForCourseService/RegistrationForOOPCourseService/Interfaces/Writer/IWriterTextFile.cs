using RegistrationForOOPCourseService.Models;

namespace RegistrationForOOPCourseService.Interfaces.Writer
{
    public interface IWriterTextFile
    {
        string Write(string fileName, Student student);
    }
}
