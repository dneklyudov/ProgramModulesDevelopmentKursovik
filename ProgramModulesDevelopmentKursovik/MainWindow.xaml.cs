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

namespace ProgramModulesDevelopmentKursovik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new LoggedUserVM();

            AppConnect.model01 = new CompFirmEntities();
            AppFrame.frameMain = FrmMain;
            AppFrame.frameMenu = FrmMenu;

            FrmMain.Navigate(new Pages.Auth());
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {

            (this.DataContext as LoggedUserVM).Menu = null;

            FrmMain.Navigate(new Pages.Auth());

            (this.DataContext as LoggedUserVM).Fio = "";
            (this.DataContext as LoggedUserVM).Role = "";

        }
    }
}
