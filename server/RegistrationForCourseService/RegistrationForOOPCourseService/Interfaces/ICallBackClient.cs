using RegistrationForOOPCourseService.Models;
using System.Collections.Generic;
using System.ServiceModel;

namespace RegistrationForOOPCourseService.Interfaces
{
    public interface ICallBackClient
    {
        [OperationContract(IsOneWay = true)]
        void ShowStudentsWithGreaterAverageBall(List<Student> students);
        [OperationContract(IsOneWay = true)]
        void ShowErrorMessage(string message);
        [OperationContract(IsOneWay = true)]
        void SetIdClient(int id);
    }
}
