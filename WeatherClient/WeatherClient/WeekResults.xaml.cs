using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WeatherClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WeekResults : Page
    {
        public WeekResults()
        {
            this.InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RetrieveOptionsPage));
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(FirstPage));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }


        public dynamic PostData(string JsonSting, string url)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("http://weatherapikunal.azurewebsites.net/api/");
                httpClient.DefaultRequestHeaders.Accept.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var message = JsonSting;
                HttpContent content = new StringContent(message, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = httpClient.PostAsync(url, content).Result;
                dynamic responseBody = response.Content.ReadAsStringAsync();
                httpClient.Dispose();
                return responseBody.Result;
            }
        }

        private void DatePicker_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {

            string data = "{ \"Type\":\"WEEK\",\"Date\":\"" + DatePicker.Date.ToString("yyyy-MM-dd") + "\"}";
            string JsonData = PostData(data, "RetrieveData");
            var Data = (JObject)JsonConvert.DeserializeObject(JsonData);
            txtTempHigh.Text = Data["HighTemp"].ToString();
            txtTempLow.Text = Data["LowTemp"].ToString();
            txtTempAvg.Text = Data["AvgTemp"].ToString();
            txtHumidHigh.Text = Data["HighHum"].ToString();
            txtHumidLow.Text = Data["LowHum"].ToString();
            txtHumidAvg.Text = Data["AvgHum"].ToString();
            txtPressHigh.Text = Data["HighPres"].ToString();
            txtPressLow.Text = Data["LowPres"].ToString();
            txtPressAvg.Text = Data["AvgPres"].ToString();
        }
    }
}