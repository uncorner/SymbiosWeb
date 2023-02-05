using System;

namespace Symbios.Core {

    public class ParameterNotFoundException : Exception {

        public ParameterNotFoundException(string paramName) :
            base(string.Format("The page parameter '{0}' is not found.", paramName)) {
        }

    }

}
