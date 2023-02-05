using System;
using System.IO;
using Ninject.Modules;
using Symbios.Core.Logging;

namespace Symbios.Core.Orm {

    public class StorageModule : NinjectModule {

        public override void Load() {
            Bind<Type>().ToConstant(typeof(DbStorage));
            Bind<TextWriter>().To<Log4NetWriter>();
            Bind<IDataStorage>().To<DbStorage>();
        }

    }
}