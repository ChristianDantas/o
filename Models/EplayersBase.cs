using System.Collections.Generic;
using System.IO;

namespace eplayers_back.Models
{
    public abstract class EplayersBase
    {
        public void CreateFolderAndFile(string path)
        {
            string folder = path.Split("/")[0];
             string file     = path.Split("/")[1];

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }




        public List<string> ReadAllLinesCSV(string path){

            List<string> linhas= new List<string>();
            using (StreamReader ok= new StreamReader(path) )
            {
                string linha;
                while((linha= ok.ReadLine())!=null)
                {
                    linhas.Add(linha);
                }
            }
            return linhas;
        }

        public void RewriteCSV(string path,List<string> linhas){
using (StreamWriter ouput= new StreamWriter(path))
{
    foreach (var item in linhas)
    {
        ouput.Write(item + '\n');
    }
}
        }
    }
}