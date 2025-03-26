using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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
using ProgramModulesDevelopmentKursovik.ApplicationData;

namespace ProgramModulesDevelopmentKursovik.Pages.Content
{
    /// <summary>
    /// Логика взаимодействия для Requests.xaml
    /// </summary>
    public partial class ContentRequests : Page
    {
        public ContentRequests()
        {
            InitializeComponent();
            listRequests.ItemsSource = RequestsList();
        }

        Requests[] RequestsList()
        {
            try
            {
                List<Requests> requests = AppConnect.model01.Requests.ToList();
                return requests.ToArray();
            }
            catch
            {
                MessageBox.Show("Повторите попытку");
                return null;
            }

        }


    }
}
