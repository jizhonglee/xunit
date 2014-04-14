using System;
#if !K10
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Xunit.Abstractions;
#endif

namespace Xunit.Sdk
{
#if !K10
    /// <summary>
    /// Serializes and de-serializes <see cref="ITestCase"/> instances using <see cref="BinaryFormatter"/>,
    /// <see cref="Convert.ToBase64String(byte[])"/>, and <see cref="Convert.FromBase64String"/>.
    /// </summary>
    public static class SerializationHelper
    {
        static readonly BinaryFormatter BinaryFormatter = new BinaryFormatter();

        /// <inheritdoc/>
        public static T Deserialize<T>(string serializedValue)
        {
            using (var stream = new MemoryStream(Convert.FromBase64String(serializedValue)))
                return (T)BinaryFormatter.Deserialize(stream);
        }

        /// <inheritdoc/>
        public static string Serialize(object value)
        {
            using (var stream = new MemoryStream())
            {
                BinaryFormatter.Serialize(stream, value);
                return Convert.ToBase64String(stream.GetBuffer());
            }
        }
    }
#else
    public static class SerializationHelper
    {
        public static T Deserialize<T>(string serializedValue)
        {
            throw new NotImplementedException();
        }

        public static string Serialize(object value)
        {
            throw new NotImplementedException();
        }
    }
#endif
}