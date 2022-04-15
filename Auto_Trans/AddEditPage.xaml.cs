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

namespace Auto_Trans
{
    /// <summary>
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private Ticket _currentTicket = new Ticket();  

        public AddEditPage(Ticket selectedTicket)
        {
            
            InitializeComponent();
            if (selectedTicket != null)
                _currentTicket = selectedTicket;
            DataContext = _currentTicket;        
            ComboSity.ItemsSource = AutoBaseEntities.GetContext().Ticketroutes.ToList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();
            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }
            if (_currentTicket.id == 0)
                AutoBaseEntities.GetContext().Tickets.Add(_currentTicket);
            
            try
            {
                AutoBaseEntities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
