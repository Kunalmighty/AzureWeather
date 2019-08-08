using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Devices.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WeatherClient.Modal;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WeatherClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddPage : Page
    {
        public AddPage()
        {
            this.InitializeComponent();
        }

        private async void Button_ClickAdd(object sender, RoutedEventArgs e)
        {
            string DATA;
            string url;
            if (CmbTempType.SelectedIndex == 0)
            {
                DATA = "{ \"TempFra\":" + Convert.ToInt32(txtTemp.Text) + ",\"Humidity\":" + Convert.ToInt32(txtHumid.Text) + ",\"BroPres\":" + Convert.ToInt32(txtPressure.Text) + "}";
                url = "SendDataFra";
            }
            else
            {
                DATA = "{ \"TempCel\":"+ Convert.ToInt32(txtTemp.Text) + ",\"Humidity\":"+ Convert.ToInt32(txtHumid.Text) + ",\"BroPres\":"+ Convert.ToInt32(txtPressure.Text) + "}";
                url = "SendDataCel";
            }

            await RunAsync(DATA, url);
            Frame.Navigate(typeof(FirstPage));
        }

        static async Task RunAsync(string data, string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://weatherapikunal.azurewebsites.net/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                System.Net.Http.HttpContent content = new StringContent(data, UTF8Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    ShowMsg("Data Saved");
                }
                else
                {
                    ShowMsg("Something went wrong, weather not saved.");
                }
            }
        }

        public static async void ShowMsg(string msg)
        {
            var dialog = new MessageDialog(msg);
            await dialog.ShowAsync();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            CmbTempType.Items.Clear();
            CmbTempType.Items.Add("Fahrenheit");
            CmbTempType.Items.Add("Celsius");
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(FirstPage));
        }
    }
}
