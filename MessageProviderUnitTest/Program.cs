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

            RecieverRegister<IPostClient>.SendTheMessage(new MessageEventArgs<IPostClient>(testSender1, "Sender2", "Das Ist der String!"));
        }
    }
}