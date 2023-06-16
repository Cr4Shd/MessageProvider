using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageProviderUnitTest
{
    class TestSender : IPostClient
    {
        public event IPostClient.OnMessageRecievedEventHandler OnMessageRecieved;
        public event IPostClient.OnPackageRecievedEventHandler OnPackageRecieved;
        public string IPostName { get; set; }

        public TestSender(string name)
        {
            IPostName = name;
            OnMessageRecieved += GetMessageInfo;
            OnPackageRecieved += GetPackageInfo;
        }
        public void GetMessageInfo(MessageEventArgs<IPostClient> e)
        {
            Console.WriteLine(e.Message);
        }

        public void MessageRecieved(MessageEventArgs<IPostClient> e)
        {
            switch (e.MType)
            {
                case MessageEventArgs<IPostClient>.MessageType.Message:
                    OnMessageRecieved?.Invoke(e);
                    break;

                case MessageEventArgs<IPostClient>.MessageType.Package:
                    OnPackageRecieved?.Invoke(e);
                    break;

                default:
                    break;
            }


        }

        public void SendMessageToCenter(MessageEventArgs<IPostClient> e)
        {
            PostCenter<IPostClient>.SendMultiMessage(e);
        }

        public void PackageRecieved(MessageEventArgs<IPostClient> e)
        {
            OnPackageRecieved?.Invoke(e);
        }



        public void SendPackageToCenter(MessageEventArgs<IPostClient> e)
        {
            PostCenter<IPostClient>.SendMultiPackage(e);
        }

        public void GetPackageInfo(MessageEventArgs<IPostClient> e)
        {
            Console.WriteLine(e.Sender.IPostName);
        }
    }
}
