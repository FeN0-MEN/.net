using System.Collections.Generic;

namespace Zoo
{
    public interface ISerializeDeserialize<T> where T : Dictionary<string, Animals>
    {
        void SerializeDictionary(Dictionary<string, Animals> dictionary, string filename);
        Dictionary<string, Animals> DeserializeDictionary(string filename);
    }
}