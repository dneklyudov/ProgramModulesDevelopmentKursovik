using ProgramModulesDevelopmentKursovik.ApplicationData;
using ProgramModulesDevelopmentKursovik.ViewModel;
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
using ProgramModulesDevelopmentKursovik.Pages.Menu;
using ProgramModulesDevelopmentKursovik.Pages.Content;

namespace ProgramModulesDevelopmentKursovik.Pages
{
    /// <summary>
    /// Interaction logic for Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void ButtonGo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbEmail.Text == "a") tbEmail.Text = "admin@mail.ru";
                if (tbEmail.Text == "m") tbEmail.Text = "manager@mail.ru";
                if (tbEmail.Text == "c") tbEmail.Text = "client@mail.ru";

                var userObj = AppConnect.model01.Users.FirstOrDefault(x => x.email == tbEmail.Text && x.password == pbPassword.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Такой пользователь не найден", "Ошибка авторизации", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    switch(userObj.role_id)
                    {
                        case 1:
                            // MessageBox.Show("Здравствуйте, " + userObj.name + " " + userObj.patronymic + "! Вы успешно авторизовались как администратор.", "Успешная авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                            ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Fio = userObj.name + " " + userObj.patronymic + " " + userObj.surname;
                            ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Role = "Администратор";
                            ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Menu = new Pages.Menu.MenuAdmin();
                            ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Main = new Pages.Content.Empty();
                            break;
                        case 2:
                            // MessageBox.Show("Здравствуйте, " + userObj.name + " " + userObj.patronymic + "! Вы успешно авторизовались как менеджер.", "Успешная авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                            ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Fio = userObj.name + " " + userObj.patronymic + " " + userObj.surname;
                            ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Role = "Менеджер";
                            ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Menu = new Pages.Menu.MenuManager();
                            ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Main = new Pages.Content.Empty();
                            break;
                        case 3:
                            // MessageBox.Show("Здравствуйте, " + userObj.name + " " + userObj.patronymic + "! Вы успешно авторизовались как заказчик.", "Успешная авторизация", MessageBoxButton.OK, MessageBoxImage.Information);
                            ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Fio = userObj.name + " " + userObj.patronymic + " " + userObj.surname;
                            ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Role = "Заказчик";
                            ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Menu = new Pages.Menu.MenuClient();
                            ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Main = new Pages.Content.Empty();
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка " + Ex.Message.ToString(), "Критическая ошибка приложения", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.Reg());
        }
    }
}
