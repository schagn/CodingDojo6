using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CodingDojo6.ViewModel
{
    public class ItemVM
    {
        public ItemVM(string description, BitmapImage image, string ageRec)
        {
            Description = description;
            Image = image;
            AgeRecommondation = ageRec;
        }

        public string Description { get; set; }

        public BitmapImage Image { get; set; }

        public string AgeRecommondation { get; set; }

        public ObservableCollection<ItemVM> Items { get; set; }

        public void AddItem(ItemVM item)
        {
            if (Items == null)
            {
                Items = new ObservableCollection<ItemVM>();
            }
            Items.Add(item);
        }
    }
}
