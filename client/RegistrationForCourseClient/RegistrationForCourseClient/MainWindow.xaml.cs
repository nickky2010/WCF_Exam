using System;
using System.ServiceModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using RegistrationForCourseClient.RegistrationServiceReference;


namespace RegistrationForCourseClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        InstanceContext instanceContext = new InstanceContext(new CallBackHandler());
        RegistrationForOOPCourseContractClient proxy;
        int selectGrade = 0;
        public int IdClient { get; set; }
        public bool Error { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            proxy = new RegistrationForOOPCourseContractClient(instanceContext);
            FillToComboBoxField();

        }
        private void FillToComboBoxField()
        {
            for (int i = 1; i < 11; i++)
            {
                comboBoxGrade.Items.Add($"{i}");
            }
            comboBoxGrade.SelectedIndex = 9;
        }

        private void TextBoxSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (textBoxSurname.Text == "")
            {
                buttonShowStatus.IsEnabled = false;
                buttonRegistration.IsEnabled = false;
            }
            else
            {
                buttonShowStatus.IsEnabled = true;
                buttonRegistration.IsEnabled = true;
            }
        }

        private void ComboBoxGrade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int.TryParse((sender as ComboBox).SelectedItem as string, out selectGrade);
        }

        private async void ButtonRegistration_Click(object sender, RoutedEventArgs e)
        {
            await proxy.RegistrationAsync(IdClient, textBoxSurname.Text, selectGrade);
            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(() =>
            {
                ButtonShowStatus_Click(new object(), new RoutedEventArgs());
            }));
        }

        private async void ButtonShowStatus_Click(object sender, RoutedEventArgs e)
        {
            bool registration = await proxy.IsStudentEnrolledAsync(IdClient, textBoxSurname.Text);
            if (!Error)
            {
                if (registration)
                    labelRegistrationStatusName.Content = "Registered";
                else 
                    labelRegistrationStatusName.Content = "Unregistered";
            }
            else
                Error = false;
        }

        private async void ButtonConnectToServer_Click(object sender, RoutedEventArgs e)
        {
            await proxy.JoinAsync();
            this.Dispatcher.Invoke(DispatcherPriority.Background, new Action(() =>
            {
                SetButtonsIsEnabledStatus(true);
            }));
        }

        private void SetButtonsIsEnabledStatus(bool flag)
        {
            comboBoxGrade.IsEnabled = flag;
            textBoxSurname.IsEnabled = flag;
            buttonConnectToServer.IsEnabled = !flag;
        }

        private async void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            await proxy.LeaveAsync(IdClient);
        }
    }
}
