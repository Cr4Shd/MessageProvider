using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MessageProviderUnitTest
{
    /// <summary>
    /// Stellt die Methoden zum Versenden von Nachrichten - 
    /// </summary>
    interface IPostClient
    {
        
        public delegate void OnMessageRecievedEventHandler(MessageEventArgs<IPostClient> e);
        public delegate void OnPackageRecievedEventHandler(PackageEventArgs<IPostClient> e);
        /// <summary>
        /// Dieses Event muss im Ctor des Objektes via " += " mit der Methode "GetMessageInfo" verlinkt werden - sonst werden Nachrichten nicht verarbeitet
        /// </summary>
        public event OnMessageRecievedEventHandler OnMessageRecieved;
        /// <summary>
        /// Dieses Event muss im Ctor des Objektes via += mit der Methode "GetPackageInfo" verlinkt werden - sonst werden Nachrichten nicht verarbeitet
        /// </summary>
        public event OnPackageRecievedEventHandler OnPackageRecieved;

        /// <summary>
        /// Dieser String wird im Empfängerregister (Dictionary) als Key verwendet = Ist der Empfängername
        /// </summary>
        string IPostName { get; set; }

        /// <summary>
        /// Diese Methode verarbeitet die ankommenden Daten aus der MessageEventArgs Klasse 
        /// </summary>
        /// <param name="x"></param>
        public void GetMessageInfo(MessageEventArgs<IPostClient> e);

        /// <summary>
        /// Diese Methode raised das Event welches die ankommenden Nachricht verwaltet
        /// </summary>
        /// <param name="x"></param>
        public void MessageRecieved(MessageEventArgs<IPostClient> e);

        /// <summary>
        /// Methode um direkt aus dem Objekt heraus eine Nachricht ans Postcenter zu versenden. 
        /// </summary>
        public void SendMessageToCenter(MessageEventArgs<IPostClient> e);

        /// <summary>
        /// WIP - Methode zum Empfangen von Objektpaketen - falls eigene Objekte genutzt werden müssen diese in dieser Methode behandelt werden
        /// </summary>
        /// <param name="e"></param>
        public void PackageRecieved(PackageEventArgs<IPostClient> e);
        /// <summary>
        /// WIP Methode zum versenden von Paketen
        /// </summary>
        /// <param name="e"></param>
        public void SendPackageToCenter(PackageEventArgs<IPostClient> e);

        public void GetPackageInfo(PackageEventArgs<IPostClient> e);
        
        
    }
}
