using CSGOSkinsWeb.Database;
using CSGOSkinsWeb.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSGOSkinsWeb.Core.Services
{
    public interface IRarityService
    {
        Task<Rarity> GetRarityByIdAsync(int id);

        Task<List<Rarity>> GetRaritiesAsync();
    }
    
    public class RarityService : IRarityService
    {
        private readonly SkinDbContext _context;

        public RarityService(SkinDbContext context)
        {
            _context = context;
        }

        public async Task<Rarity> GetRarityByIdAsync(int id)
        {
            return await _context.Rarity.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Rarity>> GetRaritiesAsync()
        {
            return await _context.Rarity.ToListAsync().ConfigureAwait(false);
        }
    }
}
