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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {

        
        private Clients _currentClient = new Clients();
        public AddEditPage(Clients selectedClients)
        {
            InitializeComponent();

            
            


            if (selectedClients != null)
                _currentClient = selectedClients;


            DataContext = _currentClient;

        }

        private void btbSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            

            if (string.IsNullOrWhiteSpace(_currentClient.Name))
                errors.AppendLine("Field is empty: Name");

            if (string.IsNullOrWhiteSpace(_currentClient.LastName))
                errors.AppendLine("Field is empty: LastName");

            if (string.IsNullOrWhiteSpace(_currentClient.Patronymic))
                errors.AppendLine("Field is empty: Name");

            if (string.IsNullOrWhiteSpace(_currentClient.Patronymic))
                errors.AppendLine("Field is empty: Name");

            if (string.IsNullOrWhiteSpace(_currentClient.Number_Telephone))
                errors.AppendLine("Field is empty: Number Telephone");

            if (string.IsNullOrWhiteSpace(_currentClient.Login))
                errors.AppendLine("Field is empty: Login");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString(), "Warning",MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (_currentClient.Number == 0)
                Frolov_DiplomEntities.GetContext().Clients.Add(_currentClient);

            try
            {
                Frolov_DiplomEntities.GetContext().SaveChanges();
                MessageBox.Show("Data saved", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
