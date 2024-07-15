using System;
using System.Windows;

namespace CinemaTicketApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeTicketTypes();
        }

        private void CalculateTotal_Click(object sender, RoutedEventArgs e)
        {
            decimal ticketPrice = 10.00m;
        
            if (int.TryParse(TicketTextBox.Text, out int numberOfTickets))
            {
                decimal totalCost = numberOfTickets * ticketPrice;
                TotalTextBlock.Text = $"Total Cost: ${totalCost:F2}";
            }
            else
            {
                MessageBox.Show("Please enter a valid number of tickets.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void InitializeTicketTypes()
        {
            TicketTypeComboBox.Items.Add("Regular - $10.00");
            TicketTypeComboBox.Items.Add("VIP - $20.00");
            TicketTypeComboBox.Items.Add("Student - $7.00");
            TicketTypeComboBox.SelectedIndex = 0;
        }

        private decimal GetTicketPrice()
        {
            switch (TicketTypeComboBox.SelectedIndex)
            {
                case 0: return 10.00m;
                case 1: return 20.00m;
                case 2: return 7.00m;
                default: return 10.00m;
            }
        }

        private decimal GetDiscount()
        {
            return 0.10m;
        }
    }
}
