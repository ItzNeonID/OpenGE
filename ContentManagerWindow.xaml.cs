using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace OpenGE
{
    public partial class ContentManagerWindow : Window
    {
        public ContentManagerWindow()
        {
            InitializeComponent();
        }

        // Method to load the directory structure into the TreeView
        public void LoadProjectDirectory(string projectPath)
        {
            // Clear the current items
            FileTreeView.Items.Clear();

            // Load the root directory
            TreeViewItem rootItem = new TreeViewItem()
            {
                Header = new DirectoryInfo(projectPath).Name,
                Tag = projectPath
            };
            FileTreeView.Items.Add(rootItem);

            // Recursively load directories and files
            LoadDirectory(rootItem, projectPath);
        }

        // Recursive method to load directories and files
        private void LoadDirectory(TreeViewItem item, string path)
        {
            // Load directories
            foreach (var directory in Directory.GetDirectories(path))
            {
                TreeViewItem dirItem = new TreeViewItem()
                {
                    Header = new DirectoryInfo(directory).Name,
                    Tag = directory
                };
                item.Items.Add(dirItem);

                // Recursively load subdirectories
                LoadDirectory(dirItem, directory);
            }

            // Load files
            foreach (var file in Directory.GetFiles(path))
            {
                TreeViewItem fileItem = new TreeViewItem()
                {
                    Header = Path.GetFileName(file),
                    Tag = file
                };
                item.Items.Add(fileItem);
            }
        }
    }
}