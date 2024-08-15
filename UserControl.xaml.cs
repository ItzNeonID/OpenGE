using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace OpenGE
{
    public partial class ProjectManagerControl : UserControl
    {
        private string projectDirectory = "Projects";

        public ProjectManagerControl()
        {
            InitializeComponent();
            LoadProjects();
        }

        private void LoadProjects()
        {
            if (Directory.Exists(projectDirectory))
            {
                var projects = Directory.GetDirectories(projectDirectory);
                ProjectList.ItemsSource = projects;
            }
        }

        private void NewProject_Click(object sender, RoutedEventArgs e)
        {
            string projectName = $"Project_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}";
            string projectPath = Path.Combine(projectDirectory, projectName);
            Directory.CreateDirectory(projectPath);
            LoadProjects();
        }

        private void OpenProject_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectList.SelectedItem != null)
            {
                string selectedProject = ProjectList.SelectedItem.ToString();
                MessageBox.Show($"Opening project: {selectedProject}");
                // Logic to open the project in OpenGE
            }
        }

        private void DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            if (ProjectList.SelectedItem != null)
            {
                string selectedProject = ProjectList.SelectedItem.ToString();
                Directory.Delete(selectedProject, true);
                LoadProjects();
            }
        }
    }
}