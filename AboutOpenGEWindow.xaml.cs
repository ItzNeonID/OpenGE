using System.Windows;
using System.Diagnostics;   

namespace OpenGE;

public partial class AboutOpenGEWindow : Window
{
    public AboutOpenGEWindow()
    {
        InitializeComponent();
    }

    private void Quit_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
    
    private void VisitGitHub_Click(object sender, RoutedEventArgs e)
    {
        // Replace with your GitHub URL
        Process.Start(new ProcessStartInfo("https://github.com/ItzNeonID/OpenGE/tree/master")
        {
            UseShellExecute = true
        });
    }
    
    private void ReportBug_Click(object sender, RoutedEventArgs e)
    {
        // Replace with your GitHub URL
        Process.Start(new ProcessStartInfo("https://github.com/ItzNeonID/OpenGE/issues")
        {
            UseShellExecute = true
        });
    }
}