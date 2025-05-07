using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
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
using ProgramModulesDevelopmentKursovik.Pages;
using ProgramModulesDevelopmentKursovik.ViewModel;
using ZXing;
using System.Drawing;
using System.Windows.Controls.Primitives;
using ProgramModulesDevelopmentKursovik.ApplicationData;

namespace ProgramModulesDevelopmentKursovik.Pages.Menu
{
    /// <summary>
    /// Interaction logic for MenuAdmin.xaml
    /// </summary>
    public partial class MenuAdmin : Page
    {
        public MenuAdmin()
        {
            InitializeComponent();

            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Width = 120,
                    Height = 120
                }
            };
            var result = writer.Write(@"https://dneklyudov.ru/");
            var bitmap = new BitmapImage();
            using (var memoryStream = new MemoryStream())
            {
                result.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                memoryStream.Position = 0;
                bitmap.BeginInit();
                bitmap.StreamSource = memoryStream;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                bitmap.Freeze();
            }
            imgQr.Source = bitmap;

            ButtonMenu_Click(btnRequests, null);
        }


        private void ButtonMenu_Click(object sender, RoutedEventArgs e)
        {
            MenuHelper.SetStyleOfActiveMenuButton(sender);
            if ((sender as Button).Content.ToString() == "Заявки на ремонт")
            {
                ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Main = new Pages.Content.ContentRequests(1);
            }
            else if ((sender as Button).Content.ToString() == "Единицы измерения")
            {
                ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Main = new Pages.Content.Spravochnik("EdIzm");
            }
            else if ((sender as Button).Content.ToString() == "Страны")
            {
                ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Main = new Pages.Content.Spravochnik("Countries");
            }
            else if ((sender as Button).Content.ToString() == "Производители")
            {
                ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Main = new Pages.Content.Spravochnik("Producers");
            }
            else if ((sender as Button).Content.ToString() == "Поставщики")
            {
                ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Main = new Pages.Content.Spravochnik("Suppliers");
            }
            else if ((sender as Button).Content.ToString() == "Роли")
            {
                ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Main = new Pages.Content.Spravochnik("Roles");
            }
            else if ((sender as Button).Content.ToString() == "Статусы платежей")
            {
                ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Main = new Pages.Content.Spravochnik("PaymentStates");
            }
            else if ((sender as Button).Content.ToString() == "Статусы заказов")
            {
                ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Main = new Pages.Content.Spravochnik("DoneStates");
            }
            else
            {
                ((Application.Current.MainWindow as MainWindow).DataContext as LoggedUserVM).Main = new Pages.Content.Empty();
            }
        }
    }
}