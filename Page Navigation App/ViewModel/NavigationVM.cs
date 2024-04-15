using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModInstaller.Utilities;
using System.Windows.Input;

namespace ModInstaller.ViewModel
{
    class NavigationVM : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand ProductsCommand { get; set; }
        public ICommand SettingsCommand { get; set; }

        private void Home(object obj) => CurrentView = new HomeVM();
        private void Product(object obj) => CurrentView = new ProductVM();
        private void Setting(object obj) => CurrentView = new SettingVM();

        public NavigationVM()
        {
            HomeCommand = new RelayCommand(Home);
            ProductsCommand = new RelayCommand(Product);
            SettingsCommand = new RelayCommand(Setting);

            // Startup Page
            CurrentView = new HomeVM();
        }
    }
}
