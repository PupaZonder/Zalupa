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
    /// Логика взаимодействия для enrichPage.xaml
    /// </summary>
    public partial class enrichPage : Page
    {
        private Clients _currentClient;

        public enrichPage(Clients selectedClient)
        {
            InitializeComponent();

            if (selectedClient != null)
                _currentClient = selectedClient;

            DataContext = _currentClient;

            

        }


        private void btbSave_Click(object sender, RoutedEventArgs e)
        {
            Frolov_DiplomEntities.GetContext().Clients.SqlQuery("UPDATE Clients SET Balance = Balance + '"+txtNewBalance+"'");
            NavigationService.GoBack();
        }
    }
}
