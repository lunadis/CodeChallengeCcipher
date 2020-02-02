using CodNation.Csharp.Cchipher.Services;
using System;

namespace CodNation.Csharp.Cchipher
{
    class Program
    {
        const string TOKEN = "91498adf786e10d487ad56a7b30dc98173ebbf53";
        static void Main(string[] args)
        {
            ApiServices api = new ApiServices();
            AnswerService answer = new AnswerService();

            var dados = api.GetCipher(TOKEN);

            answer.SaveFile(dados);
            answer.DecryptFile();
            

            Console.WriteLine(dados.ToString());


        }
    }
}
