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

namespace Reiskosten
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            float baseFlight = float.Parse(baseFlightTextBox.Text);
            float numberOfPersons = float.Parse(numberOfPersonsTextBox.Text);
            float numberOfDays = float.Parse(numberOfDaysTextBox.Text);
            float basePrice = float.Parse(basePriceTextBox.Text);
            float total = (baseFlight * numberOfPersons) + (numberOfDays * basePrice);
            double reduction = double.Parse(reductionPercentageTextBox.Text) * 0.01;
            string flightClass = flightClassTextBox.Text;
            float classMultiplier;
            float hotelPrice = basePrice;
            switch (flightClass)
            {
                case "1":
                    classMultiplier = 1.3f;
                    break;
                case "3":
                    classMultiplier = 0.8f;
                        break;
                default:
                    classMultiplier = 1f;
                        break;
            }

            if(numberOfPersons == 2)
            {
                hotelPrice = basePrice * numberOfPersons;
            }

            if (numberOfPersons == 3)
            {
                hotelPrice = basePrice * 2;
                hotelPrice += basePrice * 0.5f;
            }

            if (numberOfPersons >= 4)
            {
                hotelPrice = basePrice * 2;
                hotelPrice += basePrice * 0.5f;
                for (int i = 4; i <= numberOfPersons; i++)
                {
                    hotelPrice += basePrice * 0.3f;

                }
            }

            StringBuilder result = new StringBuilder();
            result.AppendLine($"Reiskost voor de eerste vlucht naar {destinationTextBox.Text}");
            result.AppendLine();
            result.AppendLine($"Totale vluchtprijs: {baseFlight * numberOfPersons * classMultiplier} Euro");
            result.AppendLine($"Totale verblijfprijs: {numberOfDays * hotelPrice} Euro");
            result.AppendLine($"Totale reisprijs: {total} Euro");
            result.AppendLine($"Korting: {total * reduction} Euro");
            result.AppendLine();
            result.AppendLine($"Te betalen: {total - (total * reduction)} Euro");
            resultTextBox.Text = result.ToString();
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            baseFlightTextBox.Clear();
            flightClassTextBox.Clear();
            reductionPercentageTextBox.Clear();
            destinationTextBox.Clear();
            basePriceTextBox.Clear();
            numberOfDaysTextBox.Clear();
            numberOfPersonsTextBox.Clear();
            resultTextBox.Clear();
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void flightClassTextBox_MouseEnter(object sender, MouseEventArgs e)
        {
            buisnessTextBox.Visibility = Visibility.Visible;
        }

        private void flightClassTextBox_MouseLeave(object sender, MouseEventArgs e)
        {
            buisnessTextBox.Visibility = Visibility.Collapsed;
        }
    }
}