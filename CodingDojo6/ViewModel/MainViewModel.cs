using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace CodingDojo6.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<ItemVM> Items { get; set; }

        public ObservableCollection<ItemVM> ShoppingCart { get; set; }

        private NavigationService navService = SimpleIoc.Default.GetInstance<NavigationService>();

        private ItemVM selectedItem;

        private RelayCommand<ItemVM> buyBtnClick;

        private ViewModelBase currentDetailView;

        public ItemVM SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; RaisePropertyChanged(); }
        }

        public RelayCommand<ItemVM> BuyBtnClick
        {
            get { return buyBtnClick; }
            set { buyBtnClick = value; RaisePropertyChanged(); }
        }

        public ViewModelBase CurrentDetailView
        {
            get => currentDetailView;
            set { currentDetailView = value; RaisePropertyChanged(); }
        }

        public RelayCommand SwitchToMyToysView { get; set; }

        public RelayCommand SwitchToOverviewView { get; set; }

        public MainViewModel()
        {
            Items = new ObservableCollection<ItemVM>();
            ShoppingCart = new ObservableCollection<ItemVM>();

            BuyBtnClick = new RelayCommand<ItemVM>(
                (p) =>
                {
                    ShoppingCart.Add(p);
                    //RaisePropertyChanged();
                }, (p) => { return true; });

            GenerateDemoData();



            SwitchToMyToysView = new RelayCommand(
                () => { CurrentDetailView = navService.NavigateTo("MyToys"); });

            SwitchToOverviewView = new RelayCommand(
                () => { CurrentDetailView = navService.NavigateTo("Overview"); });

            //Default View

            CurrentDetailView = navService.NavigateTo("Overview");
        }

        private void GenerateDemoData()
        {
            Items.Add(new ItemVM("MY Lego", new BitmapImage(new Uri("Images/lego1.jpg", UriKind.Relative)), "-"));
            Items.Add(new ItemVM("MY Playmobil", new BitmapImage(new Uri("Images/playmobil1.jpg", UriKind.Relative)), "-"));
            Items[Items.Count - 1].AddItem(
                new ItemVM("Playmobil 2", new BitmapImage(new Uri("Images/playmobil2.jpg", UriKind.Relative)), "5+"));
            Items[Items.Count - 1].AddItem(
                new ItemVM("Playmobil 3", new BitmapImage(new Uri("Images/playmobil3.jpg", UriKind.Relative)), "10+"));
            Items[Items.Count - 1].AddItem(
               new ItemVM("Playmobil 2", new BitmapImage(new Uri("Images/playmobil2.jpg", UriKind.Relative)), "5+"));
            Items[Items.Count - 1].AddItem(
                new ItemVM("Playmobil 3", new BitmapImage(new Uri("Images/playmobil3.jpg", UriKind.Relative)), "10+"));
            Items[Items.Count - 1].AddItem(
               new ItemVM("Playmobil 2", new BitmapImage(new Uri("Images/playmobil2.jpg", UriKind.Relative)), "5+"));
            Items[Items.Count - 1].AddItem(
                new ItemVM("Playmobil 3", new BitmapImage(new Uri("Images/playmobil3.jpg", UriKind.Relative)), "10+"));
            Items[Items.Count - 1].AddItem(
               new ItemVM("Playmobil 2", new BitmapImage(new Uri("Images/playmobil2.jpg", UriKind.Relative)), "5+"));
            Items[Items.Count - 1].AddItem(
                new ItemVM("Playmobil 3", new BitmapImage(new Uri("Images/playmobil3.jpg", UriKind.Relative)), "10+"));
            Items[Items.Count - 1].AddItem(
               new ItemVM("Playmobil 2", new BitmapImage(new Uri("Images/playmobil2.jpg", UriKind.Relative)), "5+"));
            Items[Items.Count - 1].AddItem(
                new ItemVM("Playmobil 3", new BitmapImage(new Uri("Images/playmobil3.jpg", UriKind.Relative)), "10+"));
        }
    }
}
