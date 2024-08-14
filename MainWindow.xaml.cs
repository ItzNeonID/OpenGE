using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;
using System.Windows.Controls;
using System.Windows.Interop;
using OpenGE.Core;

namespace OpenGE
{
    public partial class MainWindow : Window
    {
        private Scene currentScene;
        private HwndSource hwndSource;

        public MainWindow()
        {
            InitializeComponent();
            currentScene = new Scene("Untitled");
            SetUpRendering();
        }

        private void SetUpRendering()
        {
            // Set up rendering context if needed
            UpdateRenderingSize((int)RenderViewport.ActualWidth, (int)RenderViewport.ActualHeight);
        }

        private void NewScene_Click(object sender, RoutedEventArgs e)
        {
            currentScene = new Scene("New Scene");
            MessageBox.Show($"Scene '{currentScene.Name}' created.");
            RenderScene();
        }

        private void OpenScene_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Scene Files (*.json)|*.json",
                Title = "Open Scene"
            };

            if (dialog.ShowDialog() == true)
            {
                currentScene.Load(dialog.FileName);
                MessageBox.Show($"Scene '{currentScene.Name}' opened.");
                RenderScene();
            }
        }

        private void SaveScene_Click(object sender, RoutedEventArgs e)
        {
            if (currentScene != null)
            {
                var dialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "Scene Files (*.json)|*.json",
                    Title = "Save Scene"
                };

                if (dialog.ShowDialog() == true)
                {
                    currentScene.Save(dialog.FileName);
                    MessageBox.Show($"Scene '{currentScene.Name}' saved.");
                }
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

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                // Example action for W key
            }
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            // Handle mouse movement
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // Update rendering size when the window is resized
            UpdateRenderingSize((int)RenderViewport.ActualWidth, (int)RenderViewport.ActualHeight);
        }

        private void UpdateRenderingSize(int width, int height)
        {
            // Update viewport size if needed
        }

        private void RenderScene()
        {
            if (currentScene != null)
            {
                currentScene.Render(RenderViewport);
            }
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            // Handle Windows messages if needed
            return IntPtr.Zero;
        }
    }
}
