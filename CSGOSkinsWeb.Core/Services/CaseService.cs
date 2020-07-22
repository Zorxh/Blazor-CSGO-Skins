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
    public interface ICaseService
    {
        Task<WeaponCase> GetCaseByIdStringAsync(string idString);

        Task CreateCaseAsync(WeaponCase weaponCase);
        Task UpdateCaseAsync(WeaponCase weaponCase);
        Task DeleteCaseAsync(WeaponCase weaponCase);

        Task<List<WeaponCase>> GetCasesAsync();
    }
    
    public class CaseService : ICaseService
    {
        private SkinDbContext _context;

        public CaseService(SkinDbContext context)
        {
            _context = context;
        }

        public async Task<WeaponCase> GetCaseByIdStringAsync(string idString)
        {
            return await _context.WeaponCase.FirstOrDefaultAsync(x => x.Idstring == idString);
        }

        [Authorize(Roles = "Admin")]
        public async Task CreateCaseAsync(WeaponCase weaponCase)
        {
            await _context.WeaponCase.AddAsync(weaponCase).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        [Authorize(Roles = "Admin")]
        public async Task UpdateCaseAsync(WeaponCase weaponCase)
        {
            _context.WeaponCase.Update(weaponCase);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        [Authorize(Roles = "Admin")]
        public async Task DeleteCaseAsync(WeaponCase weaponCase)
        {
            _context.WeaponCase.Remove(weaponCase);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task<List<WeaponCase>> GetCasesAsync()
        {
            return await _context.WeaponCase.ToListAsync().ConfigureAwait(false);
        }
    }
}
