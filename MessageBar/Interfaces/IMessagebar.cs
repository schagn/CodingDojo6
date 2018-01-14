using GalaSoft.MvvmLight.Messaging;
using MessageBar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBar.Interfaces
{
     public interface IMessagebar
    {
        void RegisterOnMessenger(Messenger messg, string token);

        void SetTime(int time);

        void ShowInfo(Message msg);

    }
}
