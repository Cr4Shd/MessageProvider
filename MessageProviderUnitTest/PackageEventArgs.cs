using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageProviderUnitTest
{
    class PackageEventArgs <T>
    {
        
        public T Sender { get; set; }
        public IEnumerable<string> Reciever { get; set; }
        public object Package { get; set; }

        /// <summary>
        /// Para0 = Das Senderobjekt
        /// Para1 = Ein IEnumerableObjekt<string> mit den Empfängern (exakt selber Name mit welchem die Senderobjekte registriert wurden
        /// Para2 = Die Nachricht als String
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="reciever"></param>
        /// <param name="message"></param>
        public PackageEventArgs(T sender, IEnumerable<string> reciever, object package)
        {
            this.Sender = sender;
            this.Reciever = reciever;
            this.Package = package;
        }
    }
}

