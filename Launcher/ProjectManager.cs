using System;
using System.IO;

namespace OpenGE.Launcher
{
    public static class ProjectManager
    {
        public static string CreateProject(string projectName)
        {
            // Define the base path in AppData\Local\OpenGE\
            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string projectPath = Path.Combine(appDataPath, "OpenGE", projectName);

            // Check if project already exists
            if (Directory.Exists(projectPath))
            {
                throw new InvalidOperationException("A project with this name already exists.");
            }

            // Create the project directory and subdirectories
            Directory.CreateDirectory(projectPath);
            Directory.CreateDirectory(Path.Combine(projectPath, "Scenes"));
            Directory.CreateDirectory(Path.Combine(projectPath, "Assets"));
            Directory.CreateDirectory(Path.Combine(projectPath, "Scripts"));

            return projectPath;
        }
    }
}