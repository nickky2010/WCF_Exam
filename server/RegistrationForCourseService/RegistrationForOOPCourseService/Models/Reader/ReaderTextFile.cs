using RegistrationForOOPCourseService.Interfaces.Reader;
using System;
using System.Collections.Generic;
using System.IO;

namespace RegistrationForOOPCourseService.Models.Reader
{
    public class ReaderTextFile : IReaderTextFile
    {
        public List<Student> Read(string fileName)
        {
            List<Student> students = new List<Student>();
            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] temp = reader.ReadLine().Split(';');
                        students.Add(new Student() { Surname = temp[0], GradeByBasicsOfAlgorithms = Int32.Parse(temp[1]) });
                    }
                }
            }
            catch
            {
                students = null;
            }
            return students;
        }
    }
}
