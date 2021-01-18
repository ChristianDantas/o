using System.Collections.Generic;
using eplayers_back.Models;

namespace eplayers_back.Interfaces
{
    public interface IEquipe
    {
        void Create(Equipe e);
        List<Equipe> ReadAll();
        void Update(Equipe e);
        void Delete(int Id);
    }
}