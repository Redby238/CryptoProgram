using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace CryptoCurrency
{
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
        public decimal priceUsd { get; set; }
        public decimal volumeUsd24Hr { get; set; } 
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