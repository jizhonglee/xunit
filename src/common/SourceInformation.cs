using Xunit.Abstractions;
#if !K10
using System;
using System.Runtime.Serialization;
#endif

#if XUNIT_CORE_DLL
namespace Xunit.Sdk
#else
namespace Xunit
#endif
{
#if !K10
    /// <summary>
    /// Default implementation of <see cref="ISourceInformation"/>.
    /// </summary>
    [Serializable]
    public partial class SourceInformation : ISerializable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SourceInformation"/> class.
        /// </summary>
        public SourceInformation() { }

        /// <summary/>
        protected SourceInformation(SerializationInfo info, StreamingContext context)
        {
            FileName = info.GetString("FileName");
            LineNumber = (int?)info.GetValue("LineNumber", typeof(int?));
        }

        /// <inheritdoc/>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("FileName", FileName);
            info.AddValue("LineNumber", LineNumber, typeof(int?));
        }
    }
#endif

    public partial class SourceInformation : LongLivedMarshalByRefObject, ISourceInformation
    {
        /// <inheritdoc/>
        public string FileName { get; set; }

        /// <inheritdoc/>
        public int? LineNumber { get; set; }
    }
}