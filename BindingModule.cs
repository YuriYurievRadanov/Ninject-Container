using System;
using System.Collections.Generic;
using System.Text;
using Ninject.Modules;

namespace DINinject
{
    class BindingModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEncryptor>().To<MichalengeloEncryptor>();
        }
    }
}
