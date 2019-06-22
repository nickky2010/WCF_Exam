using RegistrationForOOPCourseService;
using System;
using System.ServiceModel;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(RegistrationOOPCourseService));
            host.Open();
            Console.WriteLine("Press any key...");
            Console.ReadKey();
            host.Close();
        }
    }
}
