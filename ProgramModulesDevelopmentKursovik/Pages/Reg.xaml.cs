using ProgramModulesDevelopmentKursovik.ApplicationData;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Data.Entity.Infrastructure.Design.Executor;
using System.Xml.Linq;
// Для валидации email
using System.ComponentModel.DataAnnotations;

namespace ProgramModulesDevelopmentKursovik.Pages
{
    /// <summary>
    /// Interaction logic for Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        public Reg()
        {
            InitializeComponent();
        }


    private bool IsValidEmail(string source)
    {
        return new EmailAddressAttribute().IsValid(source);
    }

    private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (AppConnect.model01.Users.Count(x => x.email == tbEmail.Text) > 0)
            {
                MessageBox.Show("Пользователь с таким адресом электронной почты уже существует", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            if (
                String.IsNullOrEmpty(tbSurname.Text) || String.IsNullOrWhiteSpace(tbSurname.Text) ||
                String.IsNullOrEmpty(tbName.Text) || String.IsNullOrWhiteSpace(tbName.Text) ||
                String.IsNullOrEmpty(tbPatronymic.Text) || String.IsNullOrWhiteSpace(tbPatronymic.Text) ||
                String.IsNullOrEmpty(tbPhone.Text) || String.IsNullOrWhiteSpace(tbPhone.Text) ||
                String.IsNullOrEmpty(tbEmail.Text) || String.IsNullOrWhiteSpace(tbEmail.Text) ||
                String.IsNullOrEmpty(pbPassword.Password) || String.IsNullOrWhiteSpace(pbPassword.Password)
            )
            {
                MessageBox.Show("Не заполнены все поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            else if (!IsValidEmail(tbEmail.Text))
            {
                MessageBox.Show("Некорректный адрес электронной почты", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            try
            {
                Users userObj = new Users()
                {
                    surname = tbSurname.Text,
                    name = tbName.Text,
                    patronymic = tbPatronymic.Text,
                    phone = tbPhone.Text,
                    email = tbEmail.Text,
                    password = pbPassword.Password,
                    role_id = 3
                };
                AppConnect.model01.Users.Add(userObj);
                AppConnect.model01.SaveChanges();
                MessageBox.Show("Регистрация успешно завершена", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                ApplicationData.AppFrame.frameMain.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении данных: " + ex.ToString(), "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            ApplicationData.AppFrame.frameMain.GoBack();
        }

        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (pbPassword.Password != pbPassword1.Password)
            {
                btnRegister.IsEnabled = false;
                pbPassword1.Background = Brushes.LightCoral;
                pbPassword1.BorderBrush = Brushes.Red;
            }
            else
            {
                btnRegister.IsEnabled = true;
                pbPassword1.Background = Brushes.LightGreen;
                pbPassword1.BorderBrush = Brushes.Green;
            }
        }

    }
}
