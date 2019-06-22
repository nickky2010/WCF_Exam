using RegistrationForOOPCourseService.Interfaces.Writer;
using System.IO;

namespace RegistrationForOOPCourseService.Models.Writer
{
    public class WriterTextFile : IWriterTextFile
    {
        public string Write(string fileName, Student student)
        {
            string message = null;
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, append: true))
                {
                    writer.WriteLine(student.Surname + ";" + student.GradeByBasicsOfAlgorithms);
                }
            }
            catch
            {
                message = "error";
            }
            return message;
        }
    }
}
