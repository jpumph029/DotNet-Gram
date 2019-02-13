using Microsoft.EntityFrameworkCore;
using NetGram.Data;
using NetGram.Models;
using NetGram.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetGram.Services
{
    public class GramManager : IGram
    {
        private readonly GramDbcontext _context;

        public GramManager(GramDbcontext context)
        {
            _context = context;
        }

        /// <summary>
        /// Delete the gram that is passed into its paramater
        /// </summary>
        /// <param name="id">GramID</param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            Gram gram = await _context.Gram.FindAsync(id);
            if (gram != null)
            {
                _context.Remove(gram);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Finds a gram from an ID
        /// </summary>
        /// <param name="id">GramID</param>
        /// <returns></returns>
        public async Task<Gram> FindGram(int id)
        {
            Gram gram = await _context.Gram.FirstOrDefaultAsync(r => r.ID == id);
            return gram;
        }


        /// <summary>
        /// Returns all Grams
        /// </summary>
        /// <returns></returns>
        public async Task<List<Gram>> GetGram()
        {
            return await _context.Gram.ToListAsync();
        }


        /// <summary>
        /// Save/Create
        /// </summary>
        /// <param name="gram"></param>
        /// <returns></returns>
        public async Task SaveAsync(Gram gram)
        {
            //checks to see if we need to create a gram
            if (await _context.Gram.FirstOrDefaultAsync(m => m.ID == gram.ID) == null)
            {
                _context.Gram.Add(gram);
            }
            else
            {
                //Updated DB with new Gram
                _context.Gram.Update(gram);
            }
            //Saves to DB
            await _context.SaveChangesAsync();
        }
    }
}
