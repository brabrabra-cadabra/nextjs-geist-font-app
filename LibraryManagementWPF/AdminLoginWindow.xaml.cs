using System.Windows;

namespace LibraryManagementWPF
{
    public partial class AdminLoginWindow : Window
    {
        public AdminLoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            bool isValid = DataAccess.ValidateAdmin(username, password);
            if (isValid)
            {
                AdminWindow adminWindow = new AdminWindow();
                adminWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid credentials.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
