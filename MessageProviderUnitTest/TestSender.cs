using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageProviderUnitTest
{
    class TestSender : IPostClient
    {
        public event IPostClient.PostClientEventHandler PostClient;

        public string IPostName { get; set; }

        public TestSender(string name)
        {
            IPostName = name;
            PostClient += GetMessageInfo;
        }
        public void GetMessageInfo(MessageEventArgs<IPostClient> e)
        {
            Console.WriteLine(e.Message);
        }

        public void IncomingMessageObject(MessageEventArgs<IPostClient> e)
        {
            PostClient?.Invoke(e);
        }

        public void SendMessageToCenter(MessageEventArgs<IPostClient> e)
        {
            PostCenter<IPostClient>.SendMultiMessage(e);
        }
    }
}
