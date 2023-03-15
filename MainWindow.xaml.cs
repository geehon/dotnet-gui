using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
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
                using (var client = new HttpClient())
                {
                    var response = await client.GetAsync("https://www.formytest.top/api/v1/vpsInfo");
                    var content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(content);
                    lstNames.Text = (content);
                }
            }
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("All will be cleared!");
            lstNames.Text = ("");
        }
    }

}
