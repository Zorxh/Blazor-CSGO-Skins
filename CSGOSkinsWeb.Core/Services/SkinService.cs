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
    public interface ISkinService
    {
        Task<Skin> GetSkinByIdStringAsync(string idString);

        Task CreateSkinAsync(Skin skin);
        Task UpdateSkinAsync(Skin skin);
        Task DeleteSkinAsync(Skin skin);

        Task<List<Skin>> GetSkinsAsync();
    }
    
    public class SkinService : ISkinService
    {
        private SkinDbContext _context;

        public SkinService(SkinDbContext context)
        {
            _context = context;
        }

        public async Task<Skin> GetSkinByIdStringAsync(string idString)
        {
            return await _context.Skin
                .Include(x => x.RarityNavigation)
                .Include(x => x.WeaponNavigation)
                .Include(x => x.WeapcaseNavigation)
                .Include(x => x.WeapcollNavigation)
                .FirstOrDefaultAsync(x => x.Idstring == idString);
        }

        [Authorize(Roles = "Admin")]
        public Task CreateSkinAsync(Skin skin)
        {
            _context.Skin.Add(skin);
            return _context.SaveChangesAsync();
        }

        [Authorize(Roles = "Admin")]
        public async Task UpdateSkinAsync(Skin skin)
        {
            _context.Skin.Update(skin);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        [Authorize(Roles = "Admin")]
        public async Task DeleteSkinAsync(Skin skin)
        {
            _context.Skin.Remove(skin);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<List<Skin>> GetSkinsAsync()
        {
            return await _context.Skin
                .Include(x => x.RarityNavigation)
                .Include(x => x.WeaponNavigation)
                .Include(x => x.WeapcaseNavigation)
                .Include(x => x.WeapcollNavigation)
                .ToListAsync()
                .ConfigureAwait(false);
        }
    }
}
