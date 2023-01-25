using Korsun.ClassFolder;
using Korsun.DataFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Korsun.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(LoginTB.Text))
            {
                MBClass.ErrorMB("Введите логин");
                LoginTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordPB.Password))
            {
                MBClass.ErrorMB("Введите пароль");
                PasswordPB.Focus();
            }
            else
            {
                try
                {
                    var user = DBEntities.GetContext()
                        .User
                        .FirstOrDefault(u => u.Login == LoginTB.Text);
                    if (user == null)
                    {
                        MBClass.ErrorMB("Такого пользователя " +
                            "не существует");
                        LoginTB.Focus();
                        return;
                    }
                    if (user.Password != PasswordPB.Password)
                    {
                        MBClass.ErrorMB("Пароль неверный");
                        PasswordPB.Focus();
                        return;
                    }
                    else
                    {
                        switch (user.IdRole)
                        {
                            case 1:
                                new MainWindow().ShowDialog();
                                this.Close();
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
            }
        }

            private void ExitBtn_Click(object sender, RoutedEventArgs e)
            {
                MBClass.ExitMB();
            }

            private void RegBtn_Click(object sender, RoutedEventArgs e)
            {
            new RegistrationWindow().ShowDialog();
            }
        
    }
}
