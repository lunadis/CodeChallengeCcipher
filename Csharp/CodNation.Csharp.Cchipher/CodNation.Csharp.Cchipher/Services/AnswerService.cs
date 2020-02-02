﻿using CodNation.Csharp.Cchipher.Infra;
using CodNation.Csharp.Cchipher.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodNation.Csharp.Cchipher.Services
{
    public class AnswerService
    {
        internal void SaveFile(IoResponseModel dados)
        {
            JsonService jsonService = new JsonService();

            var recordDate = jsonService.Serializar(dados);

            var path = Environment.CurrentDirectory + "\\ansewer.json";

            using (StreamWriter writer = File.CreateText(path))
            {
                writer.Write(recordDate);
                writer.Close();
            }
        }

        internal void DecryptFile()
        {
            JsonService jsonService = new JsonService();

            var path = Environment.CurrentDirectory + "\\ansewer.json";

            using (StreamReader reader = File.OpenText(path))
            {
                string dados = reader.ReadToEnd();

                var FileData = jsonService.Deserializar<IoResponseModel>(dados);

                FileData.decifrado = DecryptCesar(FileData.cifrado);
            }

        }

        private string DecryptCesar(string cifrado)
        {
            string decryptData = "";
            var latter = cifrado.ToCharArray();
            var asc = Encoding.ASCII.GetBytes(latter);
            var bytes = new List<Byte>();


            for (var i = 0; i<cifrado.Length; i++)
            {
                if(asc[i].Equals(32) || asc[i].Equals(46))
                {
                    bytes.Add(Convert.ToByte(asc[i]));
                }
                else
                {
                    var newLatter = ((asc[i] - 97 + (26 - 4)) % 26) + 97;
                    bytes.Add(Convert.ToByte(newLatter));
                }
            }
            decryptData = Encoding.ASCII.GetString(bytes.ToArray());
            return decryptData;
        }
    }
}
