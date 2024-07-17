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
            decimal ticketPrice = GetTicketPrice();
            decimal discount = GetDiscount();
            string discountDetails = $"Base Discount: {discount * 100}%";

            if (!string.IsNullOrEmpty(CouponTextBox.Text))
            {
                decimal couponDiscount = GetCouponDiscount(CouponTextBox.Text);
                if (couponDiscount >= 0)
                {
                    discount += couponDiscount;
                    discountDetails += $", Coupon Discount: {couponDiscount * 100}%";
                }
                else
                {
                    MessageBox.Show("Invalid coupon code.", "Coupon Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
        
            if (int.TryParse(TicketTextBox.Text, out int numberOfTickets))
            {
                if (numberOfTickets > 0)
                {
                    decimal totalCost = numberOfTickets * ticketPrice * (1 - discount);
                    TotalTextBlock.Text = $"Total Cost: ${totalCost:F2} ({discountDetails})";
                }
                else
                {
                    MessageBox.Show("Number of tickets must be greater than zero.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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

        private decimal GetCouponDiscount(string coupon)
        {
            switch (coupon.ToUpper())
            {
                case "DISCOUNT10": return 0.10m;
                case "DISCOUNT15": return 0.15m;
                case "DISCOUNT20": return 0.20m;
                default: return -1;
            }
        }
    }
}
