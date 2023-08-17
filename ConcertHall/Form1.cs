namespace ConcertHall
{
    public partial class Form1 : Form
    {
        private Seat[] seats = new Seat[25];
        public Form1()
        {
            InitializeComponent();
            InitializeSeats();
        }

        private void InitializeSeats()
        {
      
            for (int seatNum = 0; seatNum < 25; seatNum++)
            {
                seats[seatNum] = new Seat { IsReserved = false };
            }
     

            // initialize the seats
            int seatNumber = 25;
            foreach (Control control in panelSeats.Controls)
            {
                control.Text = seatNumber.ToString();
                control.BackColor = Color.Green;
                seatNumber--;
            }
        }


        private void UpdateSeatDisplay()
        {
            
          
            // Update the UI to reflect the seat reservation status
            for (int seatNum = 0; seatNum < 25; seatNum++)
            {
                Seat seat = seats[seatNum];
                int reversePosition = 24 - (seatNum);
                Control control = panelSeats.Controls[reversePosition];
                control.BackColor = seat.IsReserved ? Color.Red : Color.Green;
            }
            
        
        }

        private void ReserveSeat(int seatNum, string customerName)
        {
            Seat seat = seats[seatNum - 1];
            seat.IsReserved = true;
            seat.CustomerName = customerName;
            UpdateSeatDisplay();
        }

        private void buttonReserve_Click(object sender, EventArgs e)
        {
            int selectedSeat = Convert.ToInt32(numericSeat.Value);
            string customerName = txtCustomerName.Text.Trim();

            if (selectedSeat < 1 || selectedSeat > 25)
            {
                MessageBox.Show("Invalid row or seat number.");
                return;
            }            
            
            if (customerName.Equals(""))
            {
                MessageBox.Show("Invalid Customer Name");
                return;
            }

            if (seats[selectedSeat - 1].IsReserved)
            {
                MessageBox.Show("Seat is already reserved.");
                return;
            }

            ReserveSeat(selectedSeat, customerName);
        }


        private void buttonRemove_Click(object sender, EventArgs e)
        {
            string customerName = txtCustomerName.Text.Trim();

                for (int seatNum = 0; seatNum < 25; seatNum++)
                {
                    Seat seat = seats[seatNum];
                    if (seat.IsReserved && seat.CustomerName.Equals(customerName, StringComparison.OrdinalIgnoreCase))
                    {
                        seat.IsReserved = false;
                        seat.CustomerName = "";
                        UpdateSeatDisplay();
                        return;
                    }
                }

            MessageBox.Show("Customer not found.");
        }
    }
}