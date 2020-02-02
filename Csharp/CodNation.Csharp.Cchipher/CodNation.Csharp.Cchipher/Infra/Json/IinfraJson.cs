namespace CodNation.Csharp.Cchipher.Infra
{
    interface IinfraJson
    {
        T Deserializar<T>(string json);
        string Serializar<T>(T objeto);
    }
}
