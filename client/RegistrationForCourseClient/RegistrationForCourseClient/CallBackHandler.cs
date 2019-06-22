using System.Collections.Generic;
using System.Linq;
using System.Windows;
using RegistrationForCourseClient.RegistrationServiceReference;

namespace RegistrationForCourseClient
{
    public class CallBackHandler : IRegistrationForOOPCourseContractCallback
    {
        public void SetIdClient(int id)
        {
            ((MainWindow)Application.Current.MainWindow).IdClient = id;
        }

        public void ShowErrorMessage(string message)
        {
            MessageBox.Show(message);
            ((MainWindow)Application.Current.MainWindow).Error = true;
        }

        public void ShowStudentsWithGreaterAverageBall(List<Student> students)
        {
            ((MainWindow)Application.Current.MainWindow).listViewStudents.Items.Clear();
            students.OrderByDescending(s => s.GradeByBasicsOfAlgorithms).ToList()
                .ForEach(s=>((MainWindow)Application.Current.MainWindow).listViewStudents.Items.Add(s));
        }
    }
}
