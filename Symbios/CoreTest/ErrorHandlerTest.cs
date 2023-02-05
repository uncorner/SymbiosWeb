using System;
using System.Web;
using NMock2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Symbios.Core
{
    
    /// <summary>
    ///This is a test class for ErrorHandlerTest and is intended
    ///to contain all ErrorHandlerTest Unit Tests
    ///</summary>
    [TestClass]
    public class ErrorHandlerTest {
        private Mockery mocks;
        private IErrorContext errorContext;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        #region Additional test attributes

        [TestInitialize]
        public void TestInitialize() {
            mocks = new Mockery();
            errorContext = (IErrorContext)mocks.NewMock(typeof(IErrorContext));
        }

        #endregion

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CantPassNullContext() {
            ErrorHandler.Handle(null);
        }

        [TestMethod]
        public void NullExceptionIsNoHandled() {
            Expect.Once.On(errorContext).Method("GetException")
                .Will(Return.Value(null));
            ErrorHandler.Handle(errorContext);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void ResourceNotFoundError() {
            var httpException = new HttpException(404, "Resource not found");
            Expect.AtLeastOnce.On(errorContext)
                .Method("GetException").Will(Return.Value(httpException));
            Expect.Once.On(errorContext)
                .Method("ClearError").WithNoArguments();
            Expect.AtLeastOnce.On(errorContext)
                .Method("GetRequestedUrl").WithNoArguments().Will(Return.Value("/wrong-page.htm"));
            Expect.Once.On(errorContext)
                .Method("Transfer").With(ErrorHandler.NOT_FOUND_URL);
            ErrorHandler.Handle(errorContext);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [TestMethod]
        public void UnhandledError() {
            AssertUnhandledError(new Exception("Unhandled"));
        }

        [TestMethod]
        public void UnhandledHttpError() {
            AssertUnhandledError(new HttpException(500, "Http unhandled"));
        }

        [TestMethod]
        public void ParameterNotFoundError() {
            var unhandledEx = new HttpUnhandledException("Http unhandled",
                new ParameterNotFoundException("SomeParam"));
            Expect.AtLeastOnce.On(errorContext)
                .Method("GetException").Will(Return.Value(unhandledEx));
            Expect.Once.On(errorContext)
                .Method("ClearError").WithNoArguments();
            Expect.Once.On(errorContext)
                .Method("Redirect").With(ErrorHandler.ROOT_URL);
            ErrorHandler.Handle(errorContext);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void AssertUnhandledError(Exception exception) {
            Expect.AtLeastOnce.On(errorContext)
                .Method("GetException").Will(Return.Value(exception));
            Expect.Once.On(errorContext)
                .Method("ClearError").WithNoArguments();
            Expect.Once.On(errorContext)
                .Method("Redirect").With(ErrorHandler.TROUBLE_URL);
            ErrorHandler.Handle(errorContext);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

    }
}
