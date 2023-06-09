using System;

namespace MessageProviderUnitTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            TestSender testSender1 = new TestSender("Sender1");
            TestSender testSender2 = new TestSender("Sender2");
            RecieverRegister<IPostClient>.AddToReg(testSender1);
            RecieverRegister<IPostClient>.AddToReg(testSender2);
            string[] senders = new string[2];
            senders[0] = "Sender1";
            senders[1] = "Sender2";

            RecieverRegister<IPostClient>.SendMultiMessage(new MessageEventArgs<IPostClient>(testSender1, senders, "Das Ist der String!"));
        }
    }
}