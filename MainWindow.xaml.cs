using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;
using System.Windows.Interop;
using OpenGE.Core;
using OpenGE.Engine;
using OpenGE.Launcher;

namespace OpenGE
{
    public partial class MainWindow : Window
    {
        private Scene currentScene;
        private HwndSource hwndSource;
        private string currentProjectPath;
        private ContentManagerWindow contentManager;



        public MainWindow()
        {
            InitializeComponent();
            SetUpRendering();
        }

        private void SetUpRendering()
        {
            var hwndSourceParams = new HwndSourceParameters("RenderCanvas", (int)RenderCanvas.ActualWidth, (int)RenderCanvas.ActualHeight)
            {
                ParentWindow = new WindowInteropHelper(this).Handle,
                WindowStyle = 0
            };

            hwndSource = new HwndSource(hwndSourceParams);
            hwndSource.AddHook(WndProc);

            UpdateRenderingSize((int)RenderCanvas.ActualWidth, (int)RenderCanvas.ActualHeight);
        }

        private void NewScene_Click(object sender, RoutedEventArgs e)
        {
            currentScene = new Scene("New Scene");
            MessageBox.Show($"Scene '{currentScene.Name}' created.");
        }

        private void OpenScene_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Open Scene clicked.");
        }

        private void SaveScene_Click(object sender, RoutedEventArgs e)
        {
            if (currentScene != null)
            {
                currentScene.Save("path/to/scene/file.json");
                MessageBox.Show($"Scene '{currentScene.Name}' saved.");
            }
            else
            {
                MessageBox.Show("No scene to save.");
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Undo clicked.");
        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Redo clicked.");
        }

        private void ToggleGrid_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Toggle Grid clicked.");
        }

        private void ImportAsset_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Import Asset clicked.");
        }

        private void BuildSettings_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Build Settings clicked.");
        }

        private void Layout1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Layout 1 clicked.");
        }

        private void Layout2_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Layout 2 clicked.");
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateRenderingSize((int)RenderCanvas.ActualWidth, (int)RenderCanvas.ActualHeight);
        }

        private void UpdateRenderingSize(int width, int height)
        {
            // Your rendering logic to handle the new width and height
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            return IntPtr.Zero;
        }
        
        private void OpenContentManager_Click(object sender, RoutedEventArgs e)
        {
            ContentManagerWindow contentManager = new ContentManagerWindow();
            contentManager.Show();
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            AboutOpenGEWindow aboutWindow = new AboutOpenGEWindow();
            aboutWindow.Show();
        }
        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Prompt the user for a project name
                string projectName = "NewProject"; // Replace this with a prompt/dialogue to get input from the user

                // Create the project
                string projectPath = ProjectManager.CreateProject(projectName);

                // Open the Content Manager and load the project directory
                ContentManagerWindow contentManager = new ContentManagerWindow();
                contentManager.LoadProjectDirectory(projectPath);
                contentManager.Show();

                MessageBox.Show($"Project '{projectName}' created at {projectPath}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to create project: {ex.Message}");
            }
        }
        private void RefreshContent_Click(object sender, RoutedEventArgs e)
        {
            // Assuming you have a field or property storing the current project path
            contentManager.LoadProjectDirectory(currentProjectPath);
        }
    }
}
