using RegistrationForOOPCourseService.Interfaces;
using RegistrationForOOPCourseService.Interfaces.Reader;
using RegistrationForOOPCourseService.Interfaces.Writer;
using RegistrationForOOPCourseService.Models;
using RegistrationForOOPCourseService.Models.Reader;
using RegistrationForOOPCourseService.Models.Writer;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace RegistrationForOOPCourseService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class RegistrationOOPCourseService : IRegistrationForOOPCourseContract
    {
        static int currentId = 0;
        static List<ConnectedUser> connectedUsers = new List<ConnectedUser>();
        static List<Student> students;
        static IReader Reader = new Reader();
        static IWriter Writer = new Writer();

        public void Join()
        {
            ICallBackClient callBackClient = OperationContext.Current.GetCallbackChannel<ICallBackClient>();
            ConnectedUser connectedUser = new ConnectedUser
            {
                Id = ++currentId,
                CallBack = callBackClient
            };
            connectedUsers.Add(connectedUser);
            callBackClient.SetIdClient(connectedUser.Id);
        }

        public void Registration(int id, string surname, int gradeByBasicsOfAlgorithms)
        {
            ConnectedUser connectedUser = connectedUsers.FirstOrDefault(u=>u.Id==id);
            if (connectedUser != null)
            {
                connectedUser.Student = new Student { Surname = surname, GradeByBasicsOfAlgorithms = gradeByBasicsOfAlgorithms };
                AddInformationToTextFile(connectedUser);
                students = Reader.ReaderTextFile.Read("../../../Students_Information.txt");
                foreach (ConnectedUser u in connectedUsers)
                {
                    if (u.Student != null)
                    {
                        List<Student> goodStudents = students.Where(s => s.GradeByBasicsOfAlgorithms > u.Student.GradeByBasicsOfAlgorithms).ToList();
                        if(goodStudents!=null)
                            u.CallBack.ShowStudentsWithGreaterAverageBall(goodStudents);
                    }
                }
            }
        }
        
        private void AddInformationToTextFile(ConnectedUser connectedUser)
        {
            if(Writer.WriterTextFile.Write("../../../Students_Information.txt", connectedUser.Student) !=null)
            {
                connectedUser.CallBack.ShowErrorMessage("Could not write into file");
            }
        }
        public bool IsStudentEnrolled(int id, string surname)
        {
            ConnectedUser connectedUser = connectedUsers.FirstOrDefault(u => u.Id == id);
            if (connectedUser != null)
            {
                List<Student> students = Reader.ReaderTextFile.Read("../../../Students_Information.txt");
                if (students != null)
                {
                    if (students.Count==0 || students.FirstOrDefault(s => s.Surname == surname) == null)
                        return false;
                    else
                        return true;
                }
                else
                {
                    connectedUser.CallBack.ShowErrorMessage("Could not read from file");
                    return false;
                }
            }
            return false;
        }

        public void Leave(int id)
        {
            ConnectedUser connectedUser = connectedUsers.FirstOrDefault(u => u.Id == id);
            if (connectedUser != null)
                connectedUsers.Remove(connectedUser);
        }
    }
}
