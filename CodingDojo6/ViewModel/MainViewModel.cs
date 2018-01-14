using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace CodingDojo6.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private NavigationService navService = SimpleIoc.Default.GetInstance<NavigationService>();

        private ViewModelBase currentDetailView;
       
        public ViewModelBase CurrentDetailView
        {
            get => currentDetailView;
            set { currentDetailView = value; RaisePropertyChanged(); }
        }

        public RelayCommand SwitchToMyToysView { get; set; }

        public RelayCommand SwitchToOverviewView { get; set; }

        public MainViewModel()
        {

            SwitchToMyToysView = new RelayCommand(
                () => { CurrentDetailView = navService.NavigateTo("MyToys"); });

            SwitchToOverviewView = new RelayCommand(
                () => { CurrentDetailView = navService.NavigateTo("Overview"); });

            //Default View

            CurrentDetailView = navService.NavigateTo("Overview");

            (App.Current.Resources["Locator"] as ViewModelLocator).MessageBar.RegisterOnMessenger(SimpleIoc.Default.GetInstance<Messenger>(), "@Message");
            //after that messages sent via messanger at @Message are displayed in the bar
        }


    }
}
