using System.Collections.Generic;

namespace IdeaManager.Models
{
    public interface IIdeaRepository
    {
        Idea Add(Idea model);
        List<Idea> GetAll();
    }
}
