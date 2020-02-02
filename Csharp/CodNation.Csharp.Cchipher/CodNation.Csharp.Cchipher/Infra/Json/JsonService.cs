using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CodNation.Csharp.Cchipher.Infra
{
    public class JsonService : IinfraJson
    {
        public T Deserializar<T>(string json) => JsonConvert.DeserializeObject<T>(json);

        public string Serializar<T>(T objeto) => JsonConvert.SerializeObject(objeto);
    }
}
