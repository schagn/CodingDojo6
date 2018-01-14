using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using MessageBar.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CodingDojo6.ViewModel
{
    public class OverviewVM : ViewModelBase
    {
        public ObservableCollection<ItemVM> Items { get; set; }

        //public ObservableCollection<ItemVM> ShoppingCart { get; set; }

        private ItemVM selectedItem;

        public ItemVM SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; RaisePropertyChanged(); }
        }

        private RelayCommand<ItemVM> buyBtnClick;

        public RelayCommand<ItemVM> BuyBtnClick
        {
            get { return buyBtnClick; }
            set { buyBtnClick = value; RaisePropertyChanged(); }
        }

        private Messenger messg = SimpleIoc.Default.GetInstance<Messenger>();

        public OverviewVM()
        {
            Items = new ObservableCollection<ItemVM>();
            //ShoppingCart = new ObservableCollection<ItemVM>();

            BuyBtnClick = new RelayCommand<ItemVM>(
                (p) =>
                {
                    messg.Send<PropertyChangedMessage<ItemVM>>(new PropertyChangedMessage<ItemVM>(null, p, "AddNew"), "Write");

                    messg.Send<PropertyChangedMessage<Message>>(new PropertyChangedMessage<Message>(null, new Message("New Entry Added", MessageState.Info), ""), "@Message");

                }, (p) => { return true; });

            GenerateDemoData();
        }


        private void GenerateDemoData()
        {
            Items.Add(new ItemVM("MY Lego", new BitmapImage(new Uri("../Images/lego1.jpg", UriKind.Relative)), "-"));
            Items.Add(new ItemVM("MY Playmobil", new BitmapImage(new Uri("../Images/playmobil1.jpg", UriKind.Relative)), "-"));
            Items[Items.Count - 1].AddItem(
                new ItemVM("Playmobil 2", new BitmapImage(new Uri("../Images/playmobil2.jpg", UriKind.Relative)), "5+"));
            Items[Items.Count - 1].AddItem(
                new ItemVM("Playmobil 3", new BitmapImage(new Uri("../Images/playmobil3.jpg", UriKind.Relative)), "10+"));
            Items[Items.Count - 1].AddItem(
               new ItemVM("Playmobil 2", new BitmapImage(new Uri("../Images/playmobil2.jpg", UriKind.Relative)), "5+"));
            Items[Items.Count - 1].AddItem(
                new ItemVM("Playmobil 3", new BitmapImage(new Uri("../Images/playmobil3.jpg", UriKind.Relative)), "10+"));
            Items[Items.Count - 1].AddItem(
               new ItemVM("Playmobil 2", new BitmapImage(new Uri("../Images/playmobil2.jpg", UriKind.Relative)), "5+"));
            Items[Items.Count - 1].AddItem(
                new ItemVM("Playmobil 3", new BitmapImage(new Uri("../Images/playmobil3.jpg", UriKind.Relative)), "10+"));
            Items[Items.Count - 1].AddItem(
               new ItemVM("Playmobil 2", new BitmapImage(new Uri("../Images/playmobil2.jpg", UriKind.Relative)), "5+"));
            Items[Items.Count - 1].AddItem(
                new ItemVM("Playmobil 3", new BitmapImage(new Uri("../Images/playmobil3.jpg", UriKind.Relative)), "10+"));
            Items[Items.Count - 1].AddItem(
               new ItemVM("Playmobil 2", new BitmapImage(new Uri("../Images/playmobil2.jpg", UriKind.Relative)), "5+"));
            Items[Items.Count - 1].AddItem(
                new ItemVM("Playmobil 3", new BitmapImage(new Uri("../Images/playmobil3.jpg", UriKind.Relative)), "10+"));
        }
    }
}
