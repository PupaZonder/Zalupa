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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Sputnic1._1
{
    

    public partial class BeginSeseion : Window
    {

        DispatcherTimer _timer;
        TimeSpan _time; 

        public BeginSeseion()
        {
            

            Timer();

            InitializeComponent();
    
            var currentPack = Frolov_DiplomEntities.GetContext().Packe.ToList();

            currentPack.Insert(0, new Packe
            {

                Name = "Нет"

            });

            ComboPack.ItemsSource = currentPack;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();  
            
        }

        private void txtBoxClient_TextChanged(object sender, TextChangedEventArgs e)
        {

            string boxClient = txtBoxClient.Text.Trim();


            if (boxClient.Length > 0) {

                Clients clients = null;
                using (Frolov_DiplomEntities db = new Frolov_DiplomEntities())
                {
                    clients = db.Clients.Where(p => p.Login == boxClient).FirstOrDefault();
                }

                if (clients != null)
                {
                    txtBoxClient.Background = new SolidColorBrush(Colors.Aqua);
                    txtBoxClient.ToolTip = "Client selected";
                }

                else
                {
                    txtBoxClient.Background = new SolidColorBrush(Colors.DarkSlateGray);
                    txtBoxClient.ToolTip = "No client";
                }
            }
            else
            {
                txtBoxClient.Background = new SolidColorBrush(Colors.White);
                txtBoxClient.ToolTip = null;
            }

        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            ComboAge.Items.Add("Adult");
            ComboAge.Items.Add("Child's - 5%");

        }

        private void Timer()
        {
            _time = TimeSpan.FromSeconds(10);
            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                txtTime.Text = _time.ToString("c");
                if (_time == TimeSpan.Zero) _timer.Stop();
                _time = _time.Add(TimeSpan.FromSeconds(-1));


            }, Application.Current.Dispatcher);
            
            _timer.Start();
        }

    }
}
