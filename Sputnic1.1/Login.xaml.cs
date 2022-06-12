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

namespace Sputnic1._1
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void TxtBox1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TxtBox1.Text == "here your login")
            {
                TxtBox1.Clear();
            }
        }

        private void TxtBox2_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (TxtBox2.Text == "give me your your password")
            {
                TxtBox2.Clear();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPanel());
        }

    }
}
