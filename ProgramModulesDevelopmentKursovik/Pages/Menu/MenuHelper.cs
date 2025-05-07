using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace ProgramModulesDevelopmentKursovik.Pages.Menu
{
    public static class MenuHelper
    {
        public static void SetStyleOfActiveMenuButton(object sender)
        {
            var brushActive = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#efefef"));
            Button clickedButton = sender as Button;
            var parent = clickedButton.Parent;
            for (int x = 0; x < VisualTreeHelper.GetChildrenCount(parent); x++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, x);
                var control = child as Control;
                if (control is Button)
                {
                    (control as Button).Background = brushActive;
                }
            }
            clickedButton.Background = Brushes.LightGray;
        }
    }
}
