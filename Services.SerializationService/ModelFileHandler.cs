using De.HsFlensburg.ClientApp078.Business.Model.BusinessObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.ClientApp078.Services.SerializationService
{
    public class ModelFileHandler
    {
        public Administration ReadModelFromFile(string path)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream streamLoad = new FileStream(
                path,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read);
            Administration loadedCollection = (Administration)formatter.Deserialize(streamLoad);
            streamLoad.Close();

            return loadedCollection;
        }

        public void WriteModelToFile(string path, Administration model)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(
                path,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None);
            formatter.Serialize(stream, model);
            stream.Close();
        }
    }
}
