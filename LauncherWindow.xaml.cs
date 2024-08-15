using System.Windows;
using System.Windows.Controls;
using OpenGE.Core;
using OpenGE.Launcher;  

namespace OpenGE
{
    public partial class LauncherWindow : Window
    {
        public LauncherWindow()
        {
            InitializeComponent();
        }

        private void Projects_Click(object sender, RoutedEventArgs e)
        {
            // Load the Projects view into the ContentArea
            var projectManager = new ProjectManagerControl();
            ContentArea.Children.Clear();
            ContentArea.Children.Add(projectManager);
        }

        private void SDKManager_Click(object sender, RoutedEventArgs e)
        {
            // Load the SDK Manager view into the ContentArea
            var sdkManager = new SDKManagerControl();
            ContentArea.Children.Clear();
            ContentArea.Children.Add(sdkManager);
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            // Load the Settings view into the ContentArea
            var settingsManager = new SettingsControl();
            ContentArea.Children.Clear();
            ContentArea.Children.Add(settingsManager);
        }

        private void Help_Click(object sender, RoutedEventArgs e)
        {
            // Load the Help view into the ContentArea
            var helpManager = new HelpControl();
            ContentArea.Children.Clear();
            ContentArea.Children.Add(helpManager);
        }
        
        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Prompt the user for a project name
                string projectName = "NewProject"; // Replace this with a prompt/dialogue to get input from the user

                // Create the project
                string projectPath = ProjectManager.CreateProject(projectName);

                MessageBox.Show($"Project '{projectName}' created at {projectPath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create project: {ex.Message}");
            }
        }

    }
}