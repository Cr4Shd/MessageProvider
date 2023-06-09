using System;
using System.Diagnostics;

namespace MessageProviderUnitTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<IPostClient> clients = new List<IPostClient>
            {
                new TestSender("Sender1"),
                new TestSender("Sender2"),
                new TestSender("Sender3"),
                new TestSender("Sender4"),
                new TestSender("Sender5"),
                new TestSender("Sender6"),
                new TestSender("Sender7"),

            };
            PostCenter<IPostClient>.AddMultipleToReg(clients);

            List<string> senderList = new List<string>
            {
                "Sender1",
                "Sender4",
                "Sender6"
            };

            TestSender tes = new TestSender("DerSender");
            tes.SendMessageToCenter(new MessageEventArgs<IPostClient>(tes, senderList, "Hallöchen!"));
            tes.SendPackageToCenter(new PackageEventArgs<IPostClient>(tes, senderList, new TestSender("Senfgas")));

            //PostCenter<IPostClient>.SendMultiMessage(new MessageEventArgs<IPostClient>(tes, senderList, "Hallöchen!"));
            // HIer noch das Senden ausprobieren
        }
            
            
    }
}

/* TODO :
 * Multiple Empfänger - Nachricht erhalten - Listen abarbeiten*/