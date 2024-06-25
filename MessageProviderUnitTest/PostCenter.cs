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
    #region OldPostOffice
    static class PostCenter<T> 
    {

        public static Dictionary<string, IPostClient> Register { get; set; } = new Dictionary<string, IPostClient>();
        

        /// <summary>
        /// Methode, um ein IPostClientobjekt in die Empfängerliste einzufügen
        /// </summary>
        /// <param name="t"></param>
        public static void AddSingleToReg(T t)
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
        /// Methode, um eine Liste von IPostClient Objekten in das Register einzufügen 
        /// </summary>
        /// <param name="t"></param>
        public static void AddMultipleToReg(IEnumerable<IPostClient> t)
        {
            foreach (var item in t)
            {
                if (item != null && item is IPostClient)
                {
                    var xItem = item as IPostClient;
                    Register.Add(xItem.IPostName, xItem);
                }
                else
                {
                    Console.WriteLine("Objekt kann nicht hinzugefügt werden!");
                }
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


        public static bool SendMultiMessage(MessageEventArgs<IPostClient> e)
        {
            var y = GetRegList();
            List<string> tempList = new List<string>();

            foreach (var itemInRegister in y)
            {
                foreach (var itemRecieverInMessage in e.Reciever)
                {
                    if (itemRecieverInMessage.Equals(itemInRegister))
                    {
                        tempList.Add(itemInRegister);
                    }
                }
            }

            foreach (var item in tempList)
            {
                IPostClient temp;
                Register.TryGetValue(item, out temp);
                temp.MessageRecieved(e);
                
            }
            return true;
                

        }
        public static bool SendMultiPackage(MessageEventArgs<IPostClient> e)
        {
            var y = GetRegList();
            List<string> tempList = new List<string>();

            foreach (var itemInRegister in y)
            {
                foreach (var itemRecieverInMessage in e.Reciever)
                {
                    if (itemRecieverInMessage.Equals(itemInRegister))
                    {
                        tempList.Add(itemInRegister);
                    }
                }
            }

            foreach (var item in tempList)
            {
                IPostClient temp;
                Register.TryGetValue(item, out temp);
                temp.MessageRecieved(e);

            }
            return true;
        }
    }
#endregion
    interface IPostOffice <T>
    {
        public static Dictionary<string, IPostClient> Register { get; set; } = new Dictionary<string, IPostClient>();

        //public static Dictionary<string, IPostClient> Register { get; set; } = new Dictionary<string, IPostClient>();


        /// <summary>
        /// Methode, um ein IPostClientobjekt in die Empfängerliste einzufügen
        /// </summary>
        /// <param name="t"></param>
        public static void AddSingleToReg(T t)
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
        /// Methode, um eine Liste von IPostClient Objekten in das Register einzufügen 
        /// </summary>
        /// <param name="t"></param>
        public static void AddMultipleToReg(IEnumerable<IPostClient> t)
        {
            foreach (var item in t)
            {
                if (item != null && item is IPostClient)
                {
                    var xItem = item as IPostClient;
                    Register.Add(xItem.IPostName, xItem);
                }
                else
                {
                    Console.WriteLine("Objekt kann nicht hinzugefügt werden!");
                }
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


        public static bool SendMultiMessage(MessageEventArgs<IPostClient> e)
        {
            var y = GetRegList();
            List<string> tempList = new List<string>();

            foreach (var itemInRegister in y)
            {
                foreach (var itemRecieverInMessage in e.Reciever)
                {
                    if (itemRecieverInMessage.Equals(itemInRegister))
                    {
                        tempList.Add(itemInRegister);
                    }
                }
            }

            foreach (var item in tempList)
            {
                IPostClient temp;
                Register.TryGetValue(item, out temp);
                temp.MessageRecieved(e);

            }
            return true;


        }
        public static bool SendMultiPackage(MessageEventArgs<IPostClient> e)
        {
            var y = GetRegList();
            List<string> tempList = new List<string>();

            foreach (var itemInRegister in y)
            {
                foreach (var itemRecieverInMessage in e.Reciever)
                {
                    if (itemRecieverInMessage.Equals(itemInRegister))
                    {
                        tempList.Add(itemInRegister);
                    }
                }
            }

            foreach (var item in tempList)
            {
                IPostClient temp;
                Register.TryGetValue(item, out temp);
                temp.MessageRecieved(e);

            }
            return true;
        }
    }
}
