using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CodNation.Csharp.Cchipher.Infra.File
{
    public class FileMananger
    {
        public void Save(string path, string content)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                
                    writer.Write(content);
                    writer.Flush();
                    writer.Close();
                
                }

                fs.Close();
            }
        }
    }
}
