using System;

namespace MessageProviderUnitTest
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            TestSender testSender1 = new TestSender("Sender1");
            TestSender testSender2 = new TestSender("Sender2");
            TestSender testSender3 = new TestSender("Sender3");
            TestSender testSender4 = new TestSender("Sender4");
            TestSender testSender5 = new TestSender("Sender5");
            TestSender testSender6 = new TestSender("Sender6");

            RecieverRegister<IPostClient>.AddToReg(testSender1);
            RecieverRegister<IPostClient>.AddToReg(testSender2);

            List<string> senders = new List<string>
            {
                "Sender1",
                "Sender2",
                "Sender3",
                "Sender4",
            };

            RecieverRegister<IPostClient>.SendMultiMessage(new MessageEventArgs<IPostClient>(testSender1, senders, "Das Ist der String!"));
        }
    }
}

/* TODO :
 * Multiple Empfänger - Nachricht erhalten - Listen abarbeiten