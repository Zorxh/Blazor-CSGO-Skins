using System;
using CSGOSkinsWeb.Database;
using CSGOSkinsWeb.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ServiceStack;

namespace CSGOSkinsWeb.Core.Services
{
    public interface ICasePriceService
    {
        Task<string> RetrieveCasePrice(string caseName);
        Task<string> RetrieveCaseVolume(string caseName);
        string ConvertToHashKey(string caseName);
    }
    
    public class CasePriceService : ICasePriceService
    {
        private SkinDbContext _context;

        private string jsonUrlPrice = string.Empty;
        private string caseHash = string.Empty;
        private string oldCaseHash = string.Empty;

        public CasePriceService(SkinDbContext context)
        {
            _context = context;
        }

        public async Task<string> RetrieveCasePrice(string caseName)
        {
            return await CaseJSON("price", caseName);
        }

        public async Task<string> RetrieveCaseVolume(string caseName)
        {
            return await CaseJSON("volume", caseName);
        }

        private async Task SetJsonVariable()
        {
            if (string.IsNullOrEmpty(jsonUrlPrice) || caseHash != oldCaseHash)
            {
                jsonUrlPrice = await $"https://steamcommunity.com/market/priceoverview/?country=US&currency=1&appid=730&market_hash_name={caseHash}".GetJsonFromUrlAsync();
            }
        }

        private async Task<string> CaseJSON(string value, string caseName)
        {
            caseHash = ConvertToHashKey(caseName);

            await SetJsonVariable();

            if (value == "price")
            {
                oldCaseHash = caseHash;
                return jsonUrlPrice.FromJson<CaseValuesFromSteam>().lowest_price;
            }
            else if (value == "volume")
            {
                oldCaseHash = caseHash;
                return jsonUrlPrice.FromJson<CaseValuesFromSteam>().volume.ToString();
            }

            return "Value couldn't be obtained";
        }

        public string ConvertToHashKey(string caseName)
        {
            return caseName.Replace(":", "%3A").Replace(" ", "%20");
        }
    }
}
