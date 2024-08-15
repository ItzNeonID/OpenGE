using System.Windows;

namespace OpenGE
{
    public partial class AddSDK : Window
    {
        public AddSDK()
        {
            InitializeComponent();
        }

        private void Install_Click(object sender, RoutedEventArgs e)
        {
            // Handle SDK installation logic here
            MessageBox.Show("SDK installed successfully.");
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}