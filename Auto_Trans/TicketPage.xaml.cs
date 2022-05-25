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
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class TicketPage : Page
    {
        public TicketPage()
        {
            InitializeComponent();
            ///DGridTicket.ItemsSource = AutoBaseEntities.GetContext().Tickets.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage((sender as Button).DataContext as Ticket));
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage(null));
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var TicketForRemoving = DGridTicket.SelectedItems.Cast<Ticket>().ToList();
            if(MessageBox.Show($"Вы точно хотите удалить слудущее {TicketForRemoving.Count()} элементов?","внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    AutoBaseEntities.GetContext().Tickets.RemoveRange(TicketForRemoving);
                    AutoBaseEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridTicket.ItemsSource = AutoBaseEntities.GetContext().Tickets.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                AutoBaseEntities.GetContext().ChangeTracker.Entries().ToList();
                DGridTicket.ItemsSource = AutoBaseEntities.GetContext().Tickets.ToList();


            }
        }
    }
}
