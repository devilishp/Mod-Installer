using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModInstaller.Model
{
    public class PageModel
    {
        public int CustomerCount { get; set; }
        public string ProductStatus { get; set; }
        public DateOnly OrderDate { get; set; }
        public decimal TransactionValue { get; set; }
        public TimeOnly ShipmentDelivery { get; set; }
        public bool LocationStatus { get; set; }


    }
    public class SettingsModel
    {
        public static string LoadFolderPath()
        {
            string json = File.ReadAllText("..\\..\\..\\JSON\\pathGTA.json");
            return JsonConvert.DeserializeObject<string>(json);
        }

        public static string SelectFolder()
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                string selectedPath = dialog.SelectedPath;
                string json = JsonConvert.SerializeObject(selectedPath, Formatting.Indented);
                File.WriteAllText("..\\..\\..\\JSON\\pathGTA.json", json);
                return selectedPath;
            }
            return string.Empty;
        }

        public static string ClearPath()
        {
            File.WriteAllText("..\\..\\..\\JSON\\pathGTA.json", "");
            return string.Empty;
        }
    }

}
