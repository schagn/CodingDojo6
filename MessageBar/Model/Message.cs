using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageBar.Model
{
    public class Message
    {

        public string Text { get; set; }

        public MessageState State { get; set; }

        public Message(string msg, MessageState state)
        {
            Text = msg;
            State = state;
        }
    }
}
