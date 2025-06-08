using System.Windows;

namespace LibraryManagementWPF
{
    public partial class StudentLoginWindow : Window
    {
        public StudentLoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string studentId = StudentIdTextBox.Text.Trim();

            if (string.IsNullOrEmpty(studentId))
            {
                MessageBox.Show("Please enter your Student ID.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            int? id = DataAccess.GetStudentIdByStudentNumber(studentId);
            if (id != null)
            {
                StudentWindow studentWindow = new StudentWindow();
                // TODO: Pass student ID to studentWindow for personalized data
                studentWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Student ID not found or not enrolled. Please contact admin.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
