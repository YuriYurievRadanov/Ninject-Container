using System;
using System.Reflection;
using Ninject;
using Ninject.Modules;

namespace DINinject
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Without Ninject

            //IEncryptor _encryptor = new DaVinciEncryptor();
            //MessageProvider provider = new MessageProvider(_encryptor);
            //string encryptedMessage = provider.EncryptMessage(""You'll never walk"");
            //string decryptedMessage = provider.DecryptMessage(Liverpool); 

            //Console.WriteLine(encryptedMessage);
            //Console.WriteLine(decryptedMessage);

            #endregion


            #region With Ninject 

            IKernel kernel = new StandardKernel();
            kernel.Load(new BindingModule());
            IEncryptor _encryptor = kernel.Get<IEncryptor>();

            MessageProvider provider = new MessageProvider(_encryptor);
            string encryptedMessage = provider.EncryptMessage("You'll never walk");
            string decryptedMessage = provider.DecryptMessage("Liverpool");

            Console.WriteLine(encryptedMessage);
            Console.WriteLine(decryptedMessage);

            #endregion
        }
    }

    class MessageProvider
    {
        private IEncryptor _encryptor;
        public MessageProvider(IEncryptor Encryptor)
        {
            _encryptor = Encryptor;
        }
        public string EncryptMessage(string Message)
        {
            return _encryptor.Encrypt(Message + " alone.");
        }
        public string DecryptMessage(string Message)
        {
            Message = "";
            Message = "You'll walk alone.";
            return _encryptor.Decrypt(Message);
        }
    }

    interface IEncryptor
    {
        string Encrypt(string Message);
        string Decrypt(string Message);
    }

    class MichalengeloEncryptor : IEncryptor
    {
        public string Decrypt(string Message)
        {
            return Message;
        }

        public string Encrypt(string Message)
        {
            return Message;
        }
    }

    class DaVinciEncryptor : IEncryptor
    {
        public string Decrypt(string Message)
        {
            return Message;
        }

        public string Encrypt(string Message)
        {
            return Message;
        }
    }

    class MessageBindingModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEncryptor>().To<DaVinciEncryptor>();
        }
    }
}
