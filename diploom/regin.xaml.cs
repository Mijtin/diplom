using System.Windows;
using System.Windows.Media;

namespace diploom
{
    /// <summary>
    /// Interaction logic for regin.xaml
    /// </summary>
    public partial class regin : Window
    {
        AppContect db;
        public regin()
        {
            InitializeComponent();
            db = new AppContect();
            //List<User> users = db.Users.ToList();
            //string str = "";
            //foreach(User user in users)
            //{
            //    str += "Login " + user.Login + " | "; 

            //    check.Text = str;
            //}
        }
        private void Clear()
        {
            text_login.ToolTip = "";
            text_login.Background = Brushes.Transparent;
            text_password.ToolTip = "";
            text_password.Background = Brushes.Transparent;
            text_password_2.ToolTip = "";
            text_password_2.Background = Brushes.Transparent;
        }
        private void refuse_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            var login = text_login.Text.Trim();
            var password = text_password.Password.Trim();
            var password_2 = text_password_2.Password.Trim();

            if(login.Length < 5)
            {
                Clear();
                text_login.ToolTip = "логин должен содержать больше 5 символов";
                text_login.Background = Brushes.DarkRed;
            }
            else if (password.Length < 5)
            {
                Clear();
                text_password.ToolTip = "пароль должен содержать больше 5 символов";
                text_password.Background = Brushes.DarkRed;
            }
            else if (password != password_2)
            {
                Clear();
                text_password.ToolTip = "пароли должны совпадать";
                text_password.Background = Brushes.DarkRed;
            }
            else
            {
                Clear();
                MessageBox.Show("отлично");
                User user = new User(login,password);
                db.Users.Add(user);
                db.SaveChanges();

                library library = new library();
                library.Show();
                Hide();
            }
        }
    }
}
