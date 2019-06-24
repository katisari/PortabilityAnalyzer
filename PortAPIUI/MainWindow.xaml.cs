using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace PortAPIUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainViewModel();
            InitializeComponent();
            
        }

        private void About_Click(object sender, RoutedEventArgs e)

        {
            Hyperlink link = new Hyperlink();
            link.NavigateUri = new Uri("https://docs.microsoft.com/en-us/dotnet/standard/analyzers/portability-analyzer");
            ProcessStartInfo psi = new ProcessStartInfo(link.NavigateUri.ToString());
            psi.UseShellExecute = true;
            Process.Start(psi);
        }

        private void Privacy_Click(object sender, RoutedEventArgs e)

        {
            Hyperlink link = new Hyperlink();
            link.NavigateUri = new Uri("https://privacy.microsoft.com/en-us/privacystatement");
            ProcessStartInfo psi = new ProcessStartInfo(link.NavigateUri.ToString());
            psi.UseShellExecute = true;
            Process.Start(psi);
        }

        private void BStart_Click(object sender, RoutedEventArgs e)
        {
            ExportBtn.IsEnabled = true;
            API.IsEnabled = true;
            Assembly.IsEnabled = true;
        }
    }
}
