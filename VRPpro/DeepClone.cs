using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace VRPpro
{
    [Serializable]
    public class INTSergesion
    {
        public static object DeepClone(IList a)
        {
            MemoryStream ms = new MemoryStream();

            //以二进制格式进行序列化          

            BinaryFormatter bf = new BinaryFormatter();

            bf.Serialize(ms, a);

            //反序列化当前实例到一个object    

            ms.Seek(0, 0);

            object obj = bf.Deserialize(ms);

            //关闭内存流            

            ms.Close();

            return obj; 
        }
    }
}
