/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:CodingDojo6"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CodingDojo6.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using MessageBar;
using MessageBar.ViewModel;
using Microsoft.Practices.ServiceLocation;

namespace CodingDojo6.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            //Messaging System instanzieren
            SimpleIoc.Default.Register<Messenger>();
            

            SimpleIoc.Default.Register<MainViewModel>();
           
            SimpleIoc.Default.Register<OverviewVM>(true);
            SimpleIoc.Default.Register<ToysVM>(true);

            SimpleIoc.Default.Register<NavigationService>();

            SimpleIoc.Default.Register<MessageBarVm>();

            

            
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public OverviewVM Overview
        {
            get
            {
                return ServiceLocator.Current.GetInstance<OverviewVM>();
            }
        }

        public ToysVM MyToys
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ToysVM>();
            }
        }

        public MessageBarVm MessageBar
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MessageBarVm>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}