using System;
using System.Diagnostics.CodeAnalysis;
#if !K10
using System.Runtime.Serialization;
#endif

namespace Xunit.Sdk
{
#if !K10
    [Serializable]
    public partial class TestClassException : Exception
    {
        /// <inheritdoc/>
        protected TestClassException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
    }
#endif

    /// <summary>
    /// Represents an exception that happened during the process of a test class. This typically
    /// means there were problems identifying the correct test class constructor, or problems
    /// creating the fixture data for the test class.
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors")]
    public partial class TestClassException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestClassException"/> class.
        /// </summary>
        /// <param name="message">The exception message.</param>
        public TestClassException(string message)
            : base(message) { }
    }
}
