using System;
using System.Collections.Generic;
using System.Text;

namespace CodNation.Csharp.Cchipher.Model
{
    public class IoResponseModel
    {
        public int numero_casas { get; set; }
        public string token { get; set; }
        public string cifrado { get; set; }
        public string decifrado { get; set; }
        public string resumo_criptografico { get; set; }

    }
}
