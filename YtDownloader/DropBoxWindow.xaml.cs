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
using System.Windows.Shapes;

namespace YtDownloader
{
    /// <summary>
    /// Logique d'interaction pour DropBoxWindow.xaml
    /// </summary>
    public partial class DropBoxWindow : Window
    {
        public MainWindow MainWindow { get; set; }
        public DropBoxWindow(MainWindow mainWindow)
        {
            MainWindow = mainWindow;
            InitializeComponent();
        }

        private void DropBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void DropBox_MouseEnter(object sender, MouseEventArgs e)
        {
            DropBox.Opacity = 1;
        }

        private void DropBox_MouseLeave(object sender, MouseEventArgs e)
        {
            DropBox.Opacity = 0.5;
        }

        private async void DropBox_PreviewDropAsync(object sender, DragEventArgs e)
        {
            string url = (string) e.Data.GetData(DataFormats.Text);
            await MainWindow.Download(url, Settings.SettingsData.StartDropBoxDll);
        }

        private void DropBox_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
            e.Handled = true;
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            Window window = (Window)sender;
            window.Topmost = true;
        }
    }
}
