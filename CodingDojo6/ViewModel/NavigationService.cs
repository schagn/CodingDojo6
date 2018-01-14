using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;

namespace CodingDojo6.ViewModel
{
    public class NavigationService
    {
        private string lastviewId = "";
        private string currentviewId = null;

        public ViewModelBase GoBack()
        {
            if (lastviewId != "")
            {
                return SimpleFactory(lastviewId);
            }
            {
                return SimpleFactory(currentviewId);
            }
        }

        private ViewModelBase SimpleFactory(string view)
        {
            lastviewId = currentviewId;

            switch (view)
            {
                case "Overview":
                    currentviewId = view;
                    return SimpleIoc.Default.GetInstance<OverviewVM>();

                case "MyToys":
                    currentviewId = view;
                    return SimpleIoc.Default.GetInstance<ToysVM>();

                default:
                    return SimpleFactory(currentviewId);
            }
        }

        public ViewModelBase NavigateTo(string view)
        {
            return SimpleFactory(view);
        }
    }
}
