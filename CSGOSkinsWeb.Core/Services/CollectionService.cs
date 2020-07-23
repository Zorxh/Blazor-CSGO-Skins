using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CSGOSkinsWeb.Database;
using CSGOSkinsWeb.Database.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.AspNetCore.Authorization;

namespace CSGOSkinsWeb.Core.Services
{
    public interface ICollectionService
    {
        Task<WeaponCollection> GetCollectionByIdStringAsync(string idString);

        Task CreateCollectionAsync(WeaponCollection weaponCollection);
        Task UpdateCollectionAsync(WeaponCollection weaponCollection);
        Task DeleteCollectionAsync(WeaponCollection weaponCollection);

        Task<List<WeaponCollection>> GetCollectionsAsync();
    }
    
    public class CollectionService : ICollectionService
    {
        private SkinDbContext _context;

        public CollectionService(SkinDbContext context)
        {
            _context = context;
        }

        public async Task<WeaponCollection> GetCollectionByIdStringAsync(string idString)
        {
            return await _context.WeaponCollection.FirstOrDefaultAsync(x => x.Idstring == idString);
        }

        [Authorize(Roles = "Admin")]
        public async Task CreateCollectionAsync(WeaponCollection weaponCollection)
        {
            await _context.WeaponCollection.AddAsync(weaponCollection).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        [Authorize(Roles = "Admin")]
        public async Task UpdateCollectionAsync(WeaponCollection weaponCollection)
        {
            _context.WeaponCollection.Update(weaponCollection);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        [Authorize(Roles = "Admin")]
        public async Task DeleteCollectionAsync(WeaponCollection weaponCollection)
        {
            _context.WeaponCollection.Remove(weaponCollection);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<List<WeaponCollection>> GetCollectionsAsync()
        {
            return await _context.WeaponCollection.ToListAsync().ConfigureAwait(false);
        }
    }
}
