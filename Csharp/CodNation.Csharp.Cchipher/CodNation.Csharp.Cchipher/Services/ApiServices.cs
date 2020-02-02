using CodNation.Csharp.Cchipher.Infra;
using CodNation.Csharp.Cchipher.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace CodNation.Csharp.Cchipher.Services
{
    public class ApiServices
    {
        const string BASEURL = "https://api.codenation.dev/v1/challenge/dev-ps/";

        public IoResponseModel GetCipher(string token)
        {
            IoResponseModel oRes = new IoResponseModel();
            var url = BASEURL + $"generate-data?token={token}";
            var req = WebRequest.CreateHttp(url);
            req.Method = WebRequestMethods.Http.Get;
            req.UserAgent = "Chipher DEMO";
            var jsonService = new JsonService();


            using(var resp = req.GetResponse())
            {
                var dados = resp.GetResponseStream();
                
                StreamReader reader = new StreamReader(dados);
                
                var json = reader.ReadToEnd();

                oRes = jsonService.Deserializar<IoResponseModel>(json);

            }
            
            return oRes;

        }
        
        public bool PostDechiper(string path)
        {
            var url = BASEURL; /*+ $"generate-data?token={token}";*/
            var req = WebRequest.CreateHttp(url);
            req.Method = WebRequestMethods.Http.Get;
            req.UserAgent = "Chipher DEMO";
            var jsonService = new JsonService();

            return false;
        }




    }
}
