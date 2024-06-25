using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageProviderUnitTest
{
    /// <summary>
    /// Die Messageklasse - <T> ist IPostClient
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class MessageEventArgs<T>
    {
        public T Sender { get; set; }
        public IEnumerable<string> Reciever { get; set; }
        public string Message { get; set; }
        public enum MessageType
        {
            Package = 0,
            Message = 1,
            Other = 2
        }

        public MessageType MType { get; set; }

        /// <summary>
        /// Para0 = Das Senderobjekt
        /// Para1 = Ein IEnumerableObjekt<string> mit den Empfängern (exakt selber Name mit welchem die Senderobjekte registriert wurden
        /// Para2 = Die Nachricht als String
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="reciever"></param>
        /// <param name="message"></param>
        public MessageEventArgs(T sender, IEnumerable<string> reciever, string message)
        {
            Sender = sender;
            Reciever = reciever;
            Message = message;
        }
        public MessageEventArgs(T sender, IEnumerable<string> reciever, string message, MessageType messageType)
        {
            Sender = sender;
            Reciever = reciever;
            Message = message;
            MType = messageType;
        }
        
    }
}
