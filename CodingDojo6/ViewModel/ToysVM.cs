using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CodingDojo6.ViewModel
{
    public class ToysVM : ViewModelBase
    {

        private Messenger messg = SimpleIoc.Default.GetInstance<Messenger>();

        public ObservableCollection<ItemVM> Toys { get; set; }

        public ToysVM()
        {
            Toys = new ObservableCollection<ItemVM>();
            messg.Register<PropertyChangedMessage<ItemVM>>(this, "Write", Update);
        }

        private void Update(PropertyChangedMessage<ItemVM> obj)
        {
            Toys.Add(obj.NewValue);
        }
    }
}
