using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Wathet.Common
{
    public static class DoSerializable
    {

        /// <summary>
        /// 将对象序例化
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static byte[] SerializableSet(object obj)
        {
            if (obj == null) return null;
            using (MemoryStream fs = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, obj);
                formatter = null;
                return fs.ToArray();
            }
        }
        /// <summary>
        /// 将二进制数据反序例化为对象
        /// </summary>
        /// <param name="tmp"></param>
        public static object SerializableGet(byte[] tmp)
        {
            if (tmp == null) return null;
            using (MemoryStream fs = new MemoryStream(tmp))
            {
                fs.Position = 0;
                BinaryFormatter formatter = new BinaryFormatter();
                return formatter.Deserialize(fs);
            }
        }
    }
}
