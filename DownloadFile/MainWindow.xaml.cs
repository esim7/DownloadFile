using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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

namespace DownloadFile
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Uri Address { get; set; }
        public bool isDownloaded = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void downloadFile_Click(object sender, RoutedEventArgs e)
        {
            var url = textBoxUrl.Text;
            Address = new Uri(url);
            var thread = new Thread(Download);
            thread.Start();
            progressBar.IsIndeterminate = true;
        }
        private void Download()
        {
            var dialog = new SaveFileDialog();
            if (dialog.ShowDialog() == true)
            {
                var thread = Thread.CurrentThread;
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(Address, dialog.FileName);
                }
                isDownloaded = true;
            }
            if (isDownloaded)
            {
                MessageBox.Show("Файл загружен!");
            }
        }
    }
}
