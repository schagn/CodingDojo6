using GalaSoft.MvvmLight;
using MessageBar.Model;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System;
using MessageBar.Interfaces;
using GalaSoft.MvvmLight.Messaging;

namespace MessageBar.ViewModel
{
    public class MessageBarVm : ViewModelBase, IMessagebar
    {
        private Messenger messenger = null;

        private string message;

        private BitmapImage image;

        private DispatcherTimer timer;

        private int DisplayTime = 2;

        private Visibility visible;

        public string Message
        {
            get => message;
            set { message = value; RaisePropertyChanged(); }
        }

        public BitmapImage Image
        {
            get => image;
            set { image = value; RaisePropertyChanged(); }
        }

        public Visibility Visible
        {
            get => visible;
            set { visible = value; RaisePropertyChanged(); }
        }

        public MessageBarVm()
        {
            timer = new DispatcherTimer();
            timer.Interval = new System.TimeSpan(0, 0, DisplayTime);
            timer.Tick += timer_Tick;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Message = "";
            Image = null;
            timer.Stop();
            Visible = Visibility.Hidden;
        }


        public void SetTime(int time)
        {
            DisplayTime = time;
        }

        public void ShowInfo(Message msg)
        {
            Visible = Visibility.Visible;
            switch(msg.State)
            {
                case MessageState.Warning:
                    Image = new BitmapImage(new Uri("Images/State_Warning.png", UriKind.Relative));
                    break;
                case MessageState.Error:
                    Image = new BitmapImage(new Uri("Images/State_Error.png", UriKind.Relative));
                    break;
                case MessageState.Info:
                    Image = new BitmapImage(new Uri("Images/State_Info.png", UriKind.Relative));
                    break;
                case MessageState.Ok:
                    Image = new BitmapImage(new Uri("Images/State_Ok.png", UriKind.Relative));
                    break;
                default:
                    break;
            }
            Message = msg.Text;
            RaisePropertyChanged("Message");
            RaisePropertyChanged("Visible");
            timer.Start();
        }

        public void RegisterOnMessenger(Messenger mess, string token)
        {
            this.messenger= mess;
            messenger.Register<PropertyChangedMessage<Message>>(this, token, ShowContent);
        }

        public void ShowContent(PropertyChangedMessage<Message> obj)
        {
            ShowInfo(obj.NewValue);
        }

        
    }
}