using ProgramModulesDevelopmentKursovik.ApplicationData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
using System.Text.Json;
using System.IO;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Paragraph = iTextSharp.text.Paragraph;
using ProgramModulesDevelopmentKursovik.ViewModel;


namespace ProgramModulesDevelopmentKursovik.Pages.Content
{
    /// <summary>
    /// Логика взаимодействия для Requests.xaml
    /// </summary>
    public partial class ContentRequests : Page
    {

        GridViewColumnHeader _lastHeaderClicked = null;
        ListSortDirection _lastDirection = ListSortDirection.Ascending;

        public ContentRequests(int clientRoleId)
        {
            InitializeComponent();
            
            var users = AppConnect.model01.Users.OrderBy(x => x.email);
            ComboFilterByUser.Items.Add("Фильтровать по пользователю");

            if (clientRoleId == 3)
            {
                // Почему тут не работает?
                var lu = ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM);
                foreach (var item in users)
                {
                    if (item.id == lu.Id)
                    {
                        ComboFilterByUser.Items.Add(item.userinfo);
                        break;
                    }
                }
                ComboFilterByUser.SelectedIndex = 1;
                ComboFilterByUser.Visibility = Visibility.Hidden;
            }
            else
            {
                foreach (var item in users)
                {
                    if (item.Roles.id == 3)
                        ComboFilterByUser.Items.Add(item.userinfo);
                }
                ComboFilterByUser.SelectedIndex = 0;
            }

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


        private void BtnChangeInTable_Click(object sender, RoutedEventArgs e)
        {
            object datacontext = (sender as Button).DataContext as Requests;
            int id = ((sender as Button).DataContext as Requests).id;
            string header = "Заявки на ремонт. Изменение заявки [id=" + id + "]";
            NavigationService.Navigate(new Pages.Content.AddEditSpravochnikPage(datacontext, "Requests", header));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string header = "Заявки на ремонт. Создание заявки";
            NavigationService.Navigate(new Pages.Content.AddEditSpravochnikPage(null, "Requests", header));
        }

        private void BtnRemoveInTable_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Вы точно хотите удалить заявку?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Requests datacontext = (sender as Button).DataContext as Requests;
                    AppConnect.model01.Requests.Remove(datacontext);
                    AppConnect.model01.SaveChanges();
                    listRequests.ItemsSource = RequestsList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }

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
                        direction = ListSortDirection.Ascending;
                    else
                    {
                        if (_lastDirection == ListSortDirection.Ascending)
                            direction = ListSortDirection.Descending;
                        else
                            direction = ListSortDirection.Ascending;
                    }

                    var columnBinding = headerClicked.Column.DisplayMemberBinding as Binding;
                    var sortBy = columnBinding?.Path.Path ?? headerClicked.Column.Header as string;

                    Sort(sortBy, direction);

                    if (direction == ListSortDirection.Ascending)
                        headerClicked.Column.HeaderTemplate = Resources["HeaderTemplateArrowUp"] as DataTemplate;
                    else
                        headerClicked.Column.HeaderTemplate = Resources["HeaderTemplateArrowDown"] as DataTemplate;

                    if (_lastHeaderClicked != null && _lastHeaderClicked != headerClicked)
                        _lastHeaderClicked.Column.HeaderTemplate = null;

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

        private void btnToPDF_Click(object sender, RoutedEventArgs e)
        {

            Document doc = new Document();

            try
            {
                PdfWriter.GetInstance(doc, new FileStream("Requests.pdf", FileMode.Create));

                doc.Open();
                BaseFont bf = BaseFont.CreateFont("arial.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

                Font font = new Font(bf, 12);
                Font titleFont = new Font(bf, 25, 3, BaseColor.RED);

                Paragraph p = new Paragraph("Список заявок", titleFont);
                p.Alignment = Element.ALIGN_CENTER;
                doc.Add(p);

                foreach (var item in AppConnect.model01.Requests.ToList())
                {
                    if (item is Requests data)
                    {
                        //String imgURI = "../../Images/cook.jpg";
                        //if (!(String.IsNullOrEmpty(item.Image) || String.IsNullOrWhiteSpace(item.Image))) imgURI = "../../Images/" + item.Image;

                        //document.Add(new Image(ImageDataFactory.Create(imgURI))
                        //    .ScaleAbsolute(100, 100));

                        doc.Add(new Paragraph("Название: " + data.title, font));
                        doc.Add(new Paragraph("Описание: " + data.description, font));
                        doc.Add(new Paragraph("Дата начала работ: " + data.datefrom.ToString(), font));
                        doc.Add(new Paragraph("Дата окончания работ: " + data.dateto.ToString(), font));
                        doc.Add(new Paragraph("Пользователь: " + data.Users.userinfo, font));
                        doc.Add(new Paragraph("Статус заявки: " + data.DoneStates.title, font));
                        doc.Add(new Paragraph("Статус оплаты: " + data.PaymentStates.title, font));

                    }
                }
                MessageBox.Show("PDF-документ успешно создан.", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("При создании PDF-документа произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                doc.Close();
            }
        }
    }
}