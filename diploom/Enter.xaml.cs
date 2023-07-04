using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace diploom
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Enter : Window
    {
        public Enter()
        {
            InitializeComponent();
        }
        private void Clear()
        {
            text_login.ToolTip = "";
            text_login.Background = Brushes.Transparent;
            text_password.ToolTip = "";
            text_password.Background = Brushes.Transparent;
        }

        private void reg_Click_1(object sender, RoutedEventArgs e)
        {
            regin form1 = new regin();
            form1.Show();
            Close();

        }
        private void enter_Click(object sender, RoutedEventArgs e)
        {
            var login = text_login.Text.Trim();
            var password = text_password.Password.Trim();

            if (login.Length < 5)
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
            else
            {
                Clear();
                User autUser = null;
                using (AppContect contect = new AppContect()) {
                    autUser = contect.Users.Where(b => b.Login ==login && b.Password == password )
                        .FirstOrDefault();
                } 
                if ( autUser != null )
                {
                    MessageBox.Show("отлично");
                    library library = new library();
                    library.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("вы ввели что-то некорректно");
                }
            }


        }
    }
}