using System.Collections.Generic;
using System.IO;
using eplayers_back.Interfaces;

namespace eplayers_back.Models
{
    public class Equipe : EplayersBase , IEquipe
    {
        public int IdEquipe { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }
        private const string PATH ="Database/Equipe.csv";
        public Equipe()
        {
            CreateFolderAndFile(PATH);
        }
        public string Prepare(Equipe e)
        {
            return $"{e.IdEquipe}; {e.Nome}; {e.Imagem}";
        }

        public void Create(Equipe e)
        {
            string[] linhas={Prepare(e)};
            File.AppendAllLines(PATH, linhas);
        }

        public void Delete(int Id)
        {
             List<string> linhas=ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x=>x.Split(";")[0]== Id.ToString());
            
            RewriteCSV(PATH, linhas);
        }

          public List<Equipe> ReadAll()
        {
            List<Equipe> equipes = new List<Equipe>();
            string[] linhas = File.ReadAllLines(PATH);

            foreach (var item in linhas)
            {
                string[] linha = item.Split(";");

                Equipe equipe = new Equipe();
                equipe.IdEquipe = int.Parse(linha[0]);
                equipe.Nome = linha[1];
                equipe.Imagem = linha[2];

                equipes.Add(equipe);
            }

            return equipes;
        }

        public void Update(Equipe e)
        {
            List<string> linhas=ReadAllLinesCSV(PATH);
            linhas.RemoveAll(x=>x.Split(";")[0]== e.IdEquipe.ToString());
            linhas.Add(Prepare(e));
            RewriteCSV(PATH, linhas);
        }
    }
}