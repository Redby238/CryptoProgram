using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace CryptoCurrency
{
    // почему-то выдаёт 8 ошибок но программа запускаеться и работает,проверялась дебаггером(возможно у меня забагался вижуал студио)
    // ошибки фальш т.к все неймы есть в XAML и он подсоединен (<Window x:Class="CryptoDesktop.MainWindow")
    public partial class CryptoCurrencies : Window
    {
        private List<CryptoData> cryptoDataList;

        public CryptoCurrencies()
        {
            InitializeComponent();
            LoadCryptoData();
        }

        private async void LoadCryptoData()
        {
            try
            {
                string jsonData = await GetJsonDataAsync("https://api.coincap.io/v2/assets?limit=100");
                if (!string.IsNullOrEmpty(jsonData))
                {
                    try
                    {
                        MessageBox.Show("Подождите прогрузку!(5-10с)");
                        var rootObject = JsonConvert.DeserializeObject<RootObject>(jsonData);
                        cryptoDataList = rootObject.data;

                        foreach (var crypto in cryptoDataList)
                        {
                            string marketJsonData = await GetJsonDataAsync($"https://api.coincap.io/v2/assets/{crypto.id}/markets");
                            if (!string.IsNullOrEmpty(marketJsonData))
                            {
                                var marketRootObject = JsonConvert.DeserializeObject<MarketRootObject>(marketJsonData);
                                crypto.markets = marketRootObject.data;
                            }
                        }

                        //if (cryptoDataList.Count > 0)
                        //{
                        //    MessageBox.Show($"Loaded {cryptoDataList.Count} items");
                        //}
                        CryptoListView.ItemsSource = cryptoDataList;
                        MarketsListView.ItemsSource = cryptoDataList;
                    }
                    catch (JsonException ex)
                    {
                        MessageBox.Show("Error: Unable to deserialize JSON data. " + ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Error: Unable to load data");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Error: Unable to connect to the API. " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: An unexpected error occurred. " + ex.Message);
            }
           


        }

        private async Task<string> GetJsonDataAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    MessageBox.Show("Error: " + response.StatusCode);
                }
            }

            return null;
        }

        //private void SwitchTheme(string themeName)
        //{
        //    var themeStyle = (Style)Resources[themeName];
        //    foreach (var control in LayoutRoot.Children)
        //    {
        //        if (control is FrameworkElement frameworkElement)
        //        {
        //            frameworkElement.Style = themeStyle;
        //        }
        //    }
        //} нерабочий метод крашит(слишком много времени потратил,к сожалению сдался)

        //private void Button_Click(object sender, RoutedEventArgs e)
        ////{
        ////    SwitchTheme("DarkTheme");
        ////}



        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchText = SearchTextBox.Text.Trim();
            if (string.IsNullOrEmpty(searchText))
            {
                CryptoListView.ItemsSource = cryptoDataList;
                MarketsListView.ItemsSource = cryptoDataList;
            }
            else
            {
                var filteredData = cryptoDataList.Where(x => x.name.Contains(searchText, StringComparison.OrdinalIgnoreCase));
                CryptoListView.ItemsSource = filteredData;
                MarketsListView.ItemsSource = filteredData;
            }
        }

    }



    public class RootObject
    {
        public List<CryptoData> data { get; set; }
    }

    public class CryptoData
    {
        public string id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
        public string rank { get; set; }
        public string priceUsd { get; set; }
        public List<MarketData> markets { get; set; }
    }

    public class MarketData
    {
        public string exchangeId { get; set; }
    }

    public class MarketRootObject
    {
        public List<MarketData> data { get; set; }
    }
}
