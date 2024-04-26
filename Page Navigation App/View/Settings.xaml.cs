using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using ModInstaller.Model;

namespace ModInstaller.View
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : UserControl
    {
        public Settings()
        {
            InitializeComponent();
            
            FolderPathTextBox.Text = Convert.ToString(JsonConvert.DeserializeObject(File.ReadAllText("..\\..\\..\\JSON\\pathGTA.json")));
        }
        private void SelectFolder_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string selectedPath = dialog.SelectedPath;
                string json = JsonConvert.SerializeObject(selectedPath, Formatting.Indented);
                File.WriteAllText("..\\..\\..\\JSON\\pathGTA.json", json);
                FolderPathTextBox.Text = selectedPath;
            }
        }

        private void ClearPath_Click(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("..\\..\\..\\JSON\\pathGTA.json", "");
            FolderPathTextBox?.Clear();
        }
    }
}
