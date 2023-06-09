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
            OnMessageRecieved?.Invoke(e);
        }

        public void SendMessageToCenter(MessageEventArgs<IPostClient> e)
        {
            PostCenter<IPostClient>.SendMultiMessage(e);
        }

        public void PackageRecieved(PackageEventArgs<IPostClient> e)
        {
            OnPackageRecieved?.Invoke(e);
        }

        

        public void SendPackageToCenter(PackageEventArgs<IPostClient> e)
        {
            PostCenter<IPostClient>.SendMultiPackage(e);
        }

        public void GetPackageInfo(PackageEventArgs<IPostClient> e)
        {
            Console.WriteLine(e.Package.GetType().ToString());
        }
    }
}
