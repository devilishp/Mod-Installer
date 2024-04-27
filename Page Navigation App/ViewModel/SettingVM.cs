using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ModInstaller.Model;
using ModInstaller.Utilities;
using System.IO;
using Newtonsoft.Json;

namespace ModInstaller.ViewModel
{
    class SettingVM : ViewModelBase
    {
        public SettingsModel _settingsModel;
        private string _folderPath;

        public string FolderPath
        {
            get { return _folderPath; }
            set
            {
                if (_folderPath != value)
                {
                    _folderPath = value;
                    OnPropertyChanged(nameof(FolderPath));
                }
            }
        }

        public ICommand SelectFolderCommand { get; }
        public ICommand ClearPathCommand { get; }

        public SettingVM()
        {
            _settingsModel = new SettingsModel();
            SelectFolderCommand = new RelayCommand((object parameter) => SelectFolder());
            ClearPathCommand = new RelayCommand((object parameter) => ClearPath());
            LoadFolderPath();
        }
        private void LoadFolderPath()
        {
            FolderPath = SettingsModel.LoadFolderPath();
        }

        private void SelectFolder()
        {
            FolderPath = SettingsModel.SelectFolder();
        }

        private void ClearPath()
        {
            FolderPath = SettingsModel.ClearPath();
        }

    }
}
