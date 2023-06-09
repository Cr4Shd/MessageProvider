using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageProviderUnitTest
{
    /// <summary>
    /// Die Message
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MessageEventArgs<T>
    {
        public T Sender { get; set; }
        public string[] Reciever { get; set; }
        public string Message { get; set; }

        public MessageEventArgs(T sender, string[] reciever, string message)
        {
            Sender = sender;
            Reciever = reciever;
            Message = message;
        }
    }
}
