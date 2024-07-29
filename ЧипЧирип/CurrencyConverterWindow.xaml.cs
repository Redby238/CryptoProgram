using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace CryptoDesktop
{
   
    public partial class CurrencyConverterWindow : Window
    {
        private List<CryptoData> cryptoDataList;

        public CurrencyConverterWindow(List<CryptoData> cryptoDataList)
        {
            InitializeComponent();
            this.cryptoDataList = cryptoDataList;

            FromCurrencyComboBox.ItemsSource = cryptoDataList;
            FromCurrencyComboBox.DisplayMemberPath = "name";
            ToCurrencyComboBox.ItemsSource = cryptoDataList;
            ToCurrencyComboBox.DisplayMemberPath = "name";
        }

        private void ConvertButton_Click(object sender, RoutedEventArgs e)
        {
            if (FromCurrencyComboBox.SelectedItem != null && ToCurrencyComboBox.SelectedItem != null && !string.IsNullOrEmpty(AmountTextBox.Text))
            {
                CryptoData fromCurrency = (CryptoData)FromCurrencyComboBox.SelectedItem;
                CryptoData toCurrency = (CryptoData)ToCurrencyComboBox.SelectedItem;
                string amountText = AmountTextBox.Text;
                string fromCurrencyPriceText = fromCurrency.priceUsd;
                string toCurrencyPriceText = toCurrency.priceUsd;

                double amount;
                double fromCurrencyPrice;
                double toCurrencyPrice;

                if (double.TryParse(amountText, NumberStyles.Any, CultureInfo.InvariantCulture, out amount) &&
                    double.TryParse(fromCurrencyPriceText, NumberStyles.Any, CultureInfo.InvariantCulture, out fromCurrencyPrice) &&
                    double.TryParse(toCurrencyPriceText, NumberStyles.Any, CultureInfo.InvariantCulture, out toCurrencyPrice))
                {
                   
                    double result = amount * toCurrencyPrice / fromCurrencyPrice;

                    ResultTextBox.Text = $"{amount} {fromCurrency.symbol} = {result} {toCurrency.symbol}";
                }
                else
                {
                    
                    ResultTextBox.Text = "Error: unable to parse input";
                }
            }
        }
    }
}
