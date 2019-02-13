using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetGram.Models.Interfaces
{
    public interface IGram
    {
        //Delete
        Task DeleteAsync(int id);
        //Find
        Task<Gram> FindGram(int id);
        //GetAll
        Task<List<Gram>> GetGram();
        //Save
        Task SaveAsync(Gram gram);
    }
}
