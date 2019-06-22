using System.ServiceModel;

namespace RegistrationForOOPCourseService.Interfaces
{
    [ServiceContract(CallbackContract = typeof(ICallBackClient))]
    public interface IRegistrationForOOPCourseContract
    {
        [OperationContract(IsOneWay = true)]
        void Join();
        [OperationContract(IsOneWay = true)]
        void Leave(int id);
        [OperationContract(IsOneWay = true)]
        void Registration(int id, string surname, int gradeByBasicsOfAlgorithms);
        [OperationContract]
        bool IsStudentEnrolled(int id, string surname);
    }
}
