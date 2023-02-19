using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;
using Formatting = Newtonsoft.Json.Formatting;


namespace Zoo
{
    public class Json<T> : ISerializeDeserialize<T> where T : Dictionary<string, Animals> // Сериализация и десериализация JSON формата
    {
        public void SerializeDictionary(Dictionary<string, Animals> dictionary, string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    writer.Write(JsonConvert.SerializeObject(dictionary, Formatting.Indented));
                    writer.Close();
                }
            }
            catch
            {
                throw new FileNotFoundException();
            }
        }

        public Dictionary<string, Animals> DeserializeDictionary(string filename)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    string dictionary = reader.ReadToEnd();
                    reader.Close();
                    return JsonConvert.DeserializeObject<Dictionary<string, Animals>>(dictionary);
                }
            }
            catch
            {
                throw new FileNotFoundException();
            }
        }
    }

    public class Xml<T> : ISerializeDeserialize<T> where T : Dictionary<string, Animals>
    {
        public void SerializeDictionary(Dictionary<string, Animals> dictionary, string filename)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filename))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Dictionary<string, Animals>));
                    serializer.Serialize(writer, dictionary);
                    writer.Close();
                }
            }
            catch
            {
                throw new FileNotFoundException();
            }
        }

        public Dictionary<string, Animals> DeserializeDictionary(string filename)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filename))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Dictionary<string, Animals>));
                    Dictionary<string, Animals> dictionary = serializer.Deserialize(reader) as Dictionary<string, Animals>;
                    reader.Close();
                    return dictionary;
                }
            }
            catch
            {
                throw new FileNotFoundException();
            }
        }
    }
}