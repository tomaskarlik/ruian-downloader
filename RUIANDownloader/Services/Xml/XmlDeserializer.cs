using System.Text;
using System.Xml.Serialization;

namespace RUIANDownloader.Services.Xml
{
    public static class XmlDeserializer
    {

        public static T? Deserialize<T>(string file, Encoding? encoding = null) where T : class
        {
            var serializer = new XmlSerializer(typeof(T));
            T? rootObject = null;

            using (TextReader reader = new StreamReader(file, encoding ?? Encoding.UTF8))
            {
                rootObject = (T?)serializer.Deserialize(reader);
                reader.Close();
            }

            return rootObject;
        }

    }

}
