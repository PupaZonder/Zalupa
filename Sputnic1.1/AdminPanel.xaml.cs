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
using System.Data.SqlClient;
using System.Data;

namespace Sputnic1._1
{
    /// <summary>
    /// Логика взаимодействия для AdminPanel.xaml
    /// </summary>
    public partial class AdminPanel : Page
    {
        public static BeginSeseion beginSeseion;
        

        public AdminPanel()
        {
            InitializeComponent();

            
            

            var currentStandart_PC = Frolov_DiplomEntities.GetContext().Standart_PC.ToList();
            myList.ItemsSource = currentStandart_PC;

            var currentVip_PC = Frolov_DiplomEntities.GetContext().VIp_PC.ToList();
            myList2.ItemsSource = currentVip_PC;

            var currentPro_PC = Frolov_DiplomEntities.GetContext().Pro_PC.ToList();
            myList3.ItemsSource = currentPro_PC;

            var currentClient = Frolov_DiplomEntities.GetContext().Clients.ToList();
            myList1.ItemsSource = currentClient;

            var currentBar = Frolov_DiplomEntities.GetContext().Bar.ToList();
            myList4.ItemsSource = currentBar;

            
        }

        private void BeginClient_Click(object sender, RoutedEventArgs e)
        {
            if (beginSeseion == null)
            {
                beginSeseion = new BeginSeseion();
                beginSeseion.Show();
            }
            else
                beginSeseion.Activate();
        }

        private void btbAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditPage(null));
        }

        private void btbEdit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditPage((sender as Button).DataContext as Clients));
        }

        private void btbDelete_Click(object sender, RoutedEventArgs e)
        {
            var clientDelet = myList1.SelectedItems.Cast<Clients>().ToList();
            if (MessageBox.Show($"Вo you really want to remove the following {clientDelet.Count()} clients?","Warning",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Frolov_DiplomEntities.GetContext().Clients.RemoveRange(clientDelet);
                    Frolov_DiplomEntities.GetContext().SaveChanges();
                    MessageBox.Show("Data deleted", "Message");
                    var currentClient = Frolov_DiplomEntities.GetContext().Clients.ToList();
                    myList1.ItemsSource = currentClient;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void btbEnrich_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new enrichPage((sender as Button).DataContext as Clients));
        }

     

        

        private void menuRefresh_Click(object sender, RoutedEventArgs e)
        {
            var currentClient = Frolov_DiplomEntities.GetContext().Clients.ToList();
            myList1.ItemsSource = currentClient;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            var currentAcceptBar = myListBuyBar.Items;
            myListLogs.ItemsSource = currentAcceptBar;

        }

        private void btbBuy_Click(object sender, RoutedEventArgs e)
        {
            var currentBar = myList4.SelectedItems.Cast<Bar>().ToList();
            try
            {

                myListBuyBar.Items.Add(currentBar);

                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btbCancel_Click(object sender, RoutedEventArgs e)
        {
            myListBuyBar.Items.Clear();
        }

        
    }
}
