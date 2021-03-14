using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Учёт_аренды.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ClearFilter_Click(object sender, RoutedEventArgs e)
        {
            this.FilterBox.Text = null;
            //FilterBox_TextChanged(FilterBox, null);
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Data.JSON.JsonContext.SaveBuildingsAsync(Data.JSON.JsonContext.GenerateTestBuildings());
        }
    }
}
