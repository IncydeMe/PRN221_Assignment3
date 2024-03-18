using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Countdown_Timer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        private TimeSpan countdown;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            btnStop.IsEnabled = false;
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            //Check if the input is valid, note that the input is in hh:mm:ss format
            if (TimeSpan.TryParse(txtTimer.Text, out countdown))
            {
                timer = new DispatcherTimer();
                //Set the interval of the timer to 1 second
                timer.Interval = new System.TimeSpan(0, 0, 1);
                //Set the countdown to the input
                timer.Tick += Timer_Tick;
                //Start the timer
                timer.Start();
                //Disable the start button
                btnStart.IsEnabled = false;
                //Enable the stop button
                btnStop.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("Invalid input");
            } 
        }

        private void Timer_Tick(object sender, System.EventArgs e)
        {
            //Subtract 1 second from the countdown
            countdown = countdown.Subtract(new System.TimeSpan(0, 0, 1));
            //Display the countdown
            txtTimer.Text = countdown.ToString();
            //If the countdown reaches 0, stop the timer
            if (countdown.TotalSeconds <= 0)
            {
                timer.Stop();
                MessageBox.Show("Time's up!");
                btnStart.IsEnabled = true;
                btnStop.IsEnabled = false;
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            //Stop the timer
            timer.Stop();
            //Enable the start button
            btnStart.IsEnabled = true;
            //Disable the stop button
            btnStop.IsEnabled = false;
        }
    }
}