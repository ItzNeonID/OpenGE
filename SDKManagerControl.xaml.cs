using System.Windows;
using System.Windows.Controls;

namespace OpenGE
{
    public partial class SDKManagerControl : UserControl
    {
        public SDKManagerControl()
        {
            InitializeComponent();
            CheckInstalledComponents();
        }

        private async void CheckInstalledComponents()
        {
            StatusTextBlock.Text = "Checking installed components...";
            bool dotnetInstalled = IsComponentInstalled("dotnet-runtime");
            bool directXInstalled = IsComponentInstalled("directx");
            bool vcRedistInstalled = IsComponentInstalled("vc_redist");

            // Update the UI based on installed components
            InstalledSDKList.Items.Clear();
            if (dotnetInstalled) InstalledSDKList.Items.Add("Microsoft .NET Runtime");
            if (directXInstalled) InstalledSDKList.Items.Add("DirectX");
            if (vcRedistInstalled) InstalledSDKList.Items.Add("Visual C++ Redistributable");

            StatusTextBlock.Text = "Components check complete.";
        }

        private bool IsComponentInstalled(string componentName)
        {
            // Implement actual check for each component
            // This example uses dummy logic; replace with real checks
            switch (componentName)
            {
                case "dotnet-runtime":
                    return IsDotNetRuntimeInstalled();
                case "directx":
                    return IsDirectXInstalled();
                case "vc_redist":
                    return IsVCRedistInstalled();
                default:
                    return false;
            }
        }

        private bool IsDotNetRuntimeInstalled()
        {
            // Check if .NET runtime is installed (example logic)
            return IsFileExists(@"C:\Program Files\dotnet\dotnet.exe");
        }

        private bool IsDirectXInstalled()
        {
            // Check if DirectX is installed (example logic)
            return IsFileExists(@"C:\Windows\System32\d3dx9_43.dll");
        }

        private bool IsVCRedistInstalled()
        {
            // Check if Visual C++ Redistributable is installed (example logic)
            return IsFileExists(@"C:\Program Files (x86)\Common Files\Microsoft Shared\VC\vc_redist.x64.exe");
        }

        private bool IsFileExists(string path)
        {
            return System.IO.File.Exists(path);
        }

        private async void InstallDotNet_Click(object sender, RoutedEventArgs e)
        {
            await InstallComponentAsync("dotnet-runtime-installer.exe", "https://example.com/dotnet-runtime-installer.exe");
        }

        private async void InstallDirectX_Click(object sender, RoutedEventArgs e)
        {
            await InstallComponentAsync("directx-installer.exe", "https://example.com/directx-installer.exe");
        }

        private async void InstallVCRedist_Click(object sender, RoutedEventArgs e)
        {
            await InstallComponentAsync("vc_redist_x64.exe", "https://example.com/vc_redist_x64.exe");
        }

        private async Task InstallComponentAsync(string fileName, string downloadUrl)
        {
            StatusTextBlock.Text = "Downloading...";
            DownloadProgressBar.Visibility = Visibility.Visible;
            DownloadProgressBar.IsIndeterminate = true;

            string tempFilePath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), fileName);

            try
            {
                using (var client = new System.Net.WebClient())
                {
                    client.DownloadProgressChanged += (s, e) =>
                    {
                        DownloadProgressBar.Value = e.ProgressPercentage;
                    };
                    await client.DownloadFileTaskAsync(downloadUrl, tempFilePath);
                }

                StatusTextBlock.Text = "Installing...";
                DownloadProgressBar.IsIndeterminate = false;
                DownloadProgressBar.Value = 100;

                var process = new System.Diagnostics.Process
                {
                    StartInfo = new System.Diagnostics.ProcessStartInfo
                    {
                        FileName = tempFilePath,
                        Arguments = "/quiet",
                        UseShellExecute = true
                    }
                };
                process.Start();
                process.WaitForExit();

                StatusTextBlock.Text = "Installation completed.";
            }
            catch (Exception ex)
            {
                StatusTextBlock.Text = $"Error: {ex.Message}";
            }
            finally
            {
                DownloadProgressBar.Visibility = Visibility.Collapsed;
                System.IO.File.Delete(tempFilePath);
            }
        }

        // Event handlers for button clicks
        private void AddSDK_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic to add a new SDK
            AddSDK sdkAdd = new AddSDK();
            sdkAdd.Show();
        }

        private void RemoveSDK_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic to remove selected SDK
            if (InstalledSDKList.SelectedItem != null)
            {
                InstalledSDKList.Items.Remove(InstalledSDKList.SelectedItem);
                MessageBox.Show("SDK removed.");
            }
            else
            {
                MessageBox.Show("No SDK selected to remove.");
            }
        }
    }
}
