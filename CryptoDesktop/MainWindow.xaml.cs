using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;

namespace CryptoDesktop
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadCryptoData();
        }

        private async void LoadCryptoData()
        {
            try
            {
                string jsonData = await GetJsonDataAsync("https://api.coincap.io/v2/assets?limit=30");
                if (!string.IsNullOrEmpty(jsonData))
                {
                    try
                    {
                        
                        var rootObject = JsonConvert.DeserializeObject<RootObject>(jsonData);

                       
                        List<CryptoData> cryptoDataList = rootObject.data;

                        
                        cryptoDataList = cryptoDataList.GetRange(0, Math.Min(10, cryptoDataList.Count));

                        
                        if (cryptoDataList.Count > 0)
                        {
                            MessageBox.Show($"Loaded {cryptoDataList.Count} items");
                        }

                        
                        CryptoListView.ItemsSource = cryptoDataList;
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
   
    }
}