using System;
using System.Windows;
using System.Net.Http;

namespace dotnet.gui
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
        private async void ButtonAddName_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                lstNames.Text = (txtName.Text);
                txtName.Clear();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                using var client = new HttpClient();
                try {
                    var response = await client.GetAsync("https://www.formytest.top/api/v1/vpsInfo");
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                    lstNames.Text = (content);
                }
                catch (HttpRequestException ex) {

                    lstNames.Text = "网络出错！";
                }
                
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("All will be cleared!");
            lstNames.Text = "";
        }
    }

}
