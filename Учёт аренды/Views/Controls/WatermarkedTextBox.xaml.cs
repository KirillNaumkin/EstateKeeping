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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Учёт_аренды.Views.Controls
{
    /// <summary>
    /// Логика взаимодействия для WatermarkedTextBox.xaml
    /// </summary>
    public partial class WatermarkedTextBox : UserControl
    {
        public string Watermark
        {
            get { return (string)GetValue(WatermarkProperty); }
            set { SetValue(WatermarkProperty, value); }
        }

        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.Register("Watermark", typeof(string), typeof(WatermarkedTextBox), new PropertyMetadata("Подсказка о назначении поля"));


        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(WatermarkedTextBox), new PropertyMetadata(null));


        public TextWrapping Wrapping
        {
            get { return (TextWrapping)GetValue(WrappingProperty); }
            set { SetValue(WrappingProperty, value); }
        }

        public static readonly DependencyProperty WrappingProperty =
            DependencyProperty.Register("Wrapping", typeof(TextWrapping), typeof(WatermarkedTextBox), new PropertyMetadata(TextWrapping.NoWrap));
        

        public WatermarkedTextBox()
        {
            InitializeComponent();
        }
    }
}
