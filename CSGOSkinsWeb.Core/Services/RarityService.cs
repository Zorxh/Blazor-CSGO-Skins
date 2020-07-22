using CSGOSkinsWeb.Database;
using CSGOSkinsWeb.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSGOSkinsWeb.Core.Services
{
    public interface IWeaponService
    {
        Task<Weapon> GetWeaponByIdStringAsync(string idString);

        Task<List<Weapon>> GetWeaponsAsync();
    }
    
    public class WeaponService : IWeaponService
    {
        private SkinDbContext _context;

        public WeaponService(SkinDbContext context)
        {
            _context = context;
        }

        public async Task<Weapon> GetWeaponByIdStringAsync(string idString)
        {
            return await _context.Weapon.FirstOrDefaultAsync(x => x.Idstring == idString);
        }

        public async Task<List<Weapon>> GetWeaponsAsync()
        {
            return await _context.Weapon.ToListAsync().ConfigureAwait(false);
        }
    }
}
