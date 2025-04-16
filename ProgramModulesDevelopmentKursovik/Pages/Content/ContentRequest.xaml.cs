using ProgramModulesDevelopmentKursovik.ApplicationData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

namespace ProgramModulesDevelopmentKursovik.Pages.Content
{
    /// <summary>
    /// Логика взаимодействия для Requests.xaml
    /// </summary>
    public partial class ContentRequests : Page
    {

        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;

        public ContentRequests()
        {
            InitializeComponent();
            
            var users = AppConnect.model01.Users.OrderBy(x => x.email);
            ComboFilterByUser.Items.Add("Фильтровать по пользователю");
            
            foreach (var item in users)
            {
                if (item.Roles.id == 3)
                    ComboFilterByUser.Items.Add(item.name + " " + item.patronymic + " " + item.surname + " [" + item.email + "]");
            }
            ComboFilterByUser.SelectedIndex = 0;

            listRequests.ItemsSource = RequestsList();
        }

        Requests[] RequestsList()
        {
            try
            {
                List<Requests> requests = AppConnect.model01.Requests.ToList();
                if (TextSearch != null)
                {
                    requests = requests.Where(x => x.title.ToLower().Contains(TextSearch.Text.ToLower()) || x.description.ToLower().Contains(TextSearch.Text.ToLower())).ToList();
                }

                if (ComboFilterByUser.SelectedIndex > 0)
                {
                    requests = requests.Where(x => x.userinfo == ComboFilterByUser.Items[ComboFilterByUser.SelectedIndex].ToString()).ToList(); 
                }


                return requests.ToArray();
            }
            catch
            {
                MessageBox.Show("Повторите попытку");
                return null;
            }

        }

        private void TextSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            listRequests.ItemsSource = RequestsList();
        }

        private void ComboFilterByUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listRequests.ItemsSource = RequestsList();
        }

        private void listRequestsHeader_Click(object sender, RoutedEventArgs e)
        {
            var headerClicked = e.OriginalSource as GridViewColumnHeader;
            ListSortDirection direction;

            if (headerClicked != null)
            {
                if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
                {
                    if (headerClicked != _lastHeaderClicked)
                    {
                        direction = ListSortDirection.Ascending;
                    }
                    else
                    {
                        if (_lastDirection == ListSortDirection.Ascending)
                        {
                            direction = ListSortDirection.Descending;
                        }
                        else
                        {
                            direction = ListSortDirection.Ascending;
                        }
                    }

                    var columnBinding = headerClicked.Column.DisplayMemberBinding as Binding;
                    var sortBy = columnBinding?.Path.Path ?? headerClicked.Column.Header as string;

                    Sort(sortBy, direction);

                    if (direction == ListSortDirection.Ascending)
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowUp"] as DataTemplate;
                    }
                    else
                    {
                        headerClicked.Column.HeaderTemplate =
                          Resources["HeaderTemplateArrowDown"] as DataTemplate;
                    }

                    // Remove arrow from previously sorted header
                    if (_lastHeaderClicked != null && _lastHeaderClicked != headerClicked)
                    {
                        _lastHeaderClicked.Column.HeaderTemplate = null;
                    }

                    _lastHeaderClicked = headerClicked;
                    _lastDirection = direction;
                }
            }
        }

        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(listRequests.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }
    }
}
