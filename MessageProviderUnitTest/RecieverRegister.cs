using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace MessageProviderUnitTest
{
    static class RecieverRegister<T>
    {

        public static Dictionary<string, IPostClient> Register { get; set; } = new Dictionary<string, IPostClient>();
        

        /// <summary>
        /// Methode, um ein Objekt in die Empfängerliste einzutragen. Dieses Objekt muss das IPostClient Interface einbinden
        /// </summary>
        /// <param name="t"></param>
        public static void AddToReg(T t)
        {
            if (t != null && t is IPostClient)
            {
                var tt = t as IPostClient;
                Register.Add(tt.IPostName, tt);
            }
            else
            {
                Console.WriteLine("Objekt kann nicht hinzugefügt werden!");
            }
        }
        
        /// <summary>
        /// Verarbeitet alle Keys des Registerdictionarys zu einer Liste und gibt diese zurück. 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> GetRegList()
        {
            var x =
                from item in Register
                where item.Value.IPostName != String.Empty
                select item.Value.IPostName;

            return x.ToList();

        }
        /// <summary>
        /// Die Sendermethode - Hierbei wird aus den MessageEventArgs der Empfängername verwendet, um in der Klasseninternen Empfängerliste den Empfänger herauszusuchen.
        /// Sendet dann MessageEventArgs an das entsprechende Senderobjekt
        /// </summary>
        /// <param name="e"></param>
        public static bool SendTheMessage(MessageEventArgs<IPostClient> e)
        {
            var y = GetRegList();
            foreach ( var item in y )
            {
                if (item.Equals(e.Reciever))
                {
                    IPostClient temp;
                    Register.TryGetValue(e.Reciever, out temp);
                    temp.IncomingMessageObject(e);
                    return true;
                }
            }
            return false;
        }
    }
}
