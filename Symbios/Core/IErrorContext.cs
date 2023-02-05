using System;

namespace Symbios.Core {

    public interface IErrorContext {

        Exception GetException();

        void Redirect(string url);

        void Transfer(string url);

        void ClearError();

        string GetRequestedUrl();

    }

}