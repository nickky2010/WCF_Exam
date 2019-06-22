using RegistrationForOOPCourseService.Interfaces;

namespace RegistrationForOOPCourseService.Models
{
    internal class ConnectedUser
    {
        public int Id { get; set; }
        public ICallBackClient CallBack { get; set; }
        public Student Student { get; set; }
    }
}