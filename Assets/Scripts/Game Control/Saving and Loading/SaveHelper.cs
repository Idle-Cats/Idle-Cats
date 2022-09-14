using System.IO;
using System.Xml.Serialization;

public static class SaveHelper
{
    public static string Serialise<T>(this T toSerialise) {
        //turns a t into a string in order to save it
        XmlSerializer xml = new XmlSerializer(typeof(T));

        StringWriter writer = new StringWriter();

        xml.Serialize(writer, toSerialise);

        return writer.ToString();
    }

    public static T Deserialise<T>(this string toDeserialise) {
        //turns an xml string into a T in order to load a save
        XmlSerializer xml = new XmlSerializer(typeof(T));

        StringReader reader = new StringReader(toDeserialise);

        return (T)xml.Deserialize(reader);
    }
}
