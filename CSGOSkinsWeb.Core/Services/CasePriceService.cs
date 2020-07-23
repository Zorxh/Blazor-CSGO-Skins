using System;
using CSGOSkinsWeb.Database;
using CSGOSkinsWeb.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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
        string RetrieveCasePrice(string caseName);
        string RetrieveCaseVolume(string caseName);
        string ConvertToHashKey(string caseName);
    }
    
    public class CasePriceService : ICasePriceService
    {
        private SkinDbContext _context;

        private string jsonUrl = string.Empty;

        public CasePriceService(SkinDbContext context)
        {
            _context = context;
        }

        public string RetrieveCasePrice(string caseName)
        {
            return CaseJSON("price", caseName);
        }

        public string RetrieveCaseVolume(string caseName)
        {
            return CaseJSON("volume", caseName);
        }

        private string CaseJSON(string value, string caseName)
        {
            string caseHash = ConvertToHashKey(caseName);

            if(jsonUrl.IsNullOrEmpty())
                jsonUrl = $"https://steamcommunity.com/market/priceoverview/?country=US&currency=1&appid=730&market_hash_name={caseHash}".GetJsonFromUrl();

            if(value == "price")
                return jsonUrl.FromJson<CaseValuesFromSteam>().lowest_price;
            else if(value == "volume")
                return jsonUrl.FromJson<CaseValuesFromSteam>().volume.ToString();

            return "Value couldn't be obtained";
        }

        public string ConvertToHashKey(string caseName)
        {
            string caseHash = caseName.Replace(":", "%3A").Replace(" ", "%20");

            return caseHash;
        }
    }

    public class CaseValuesFromSteam
    {
        public string lowest_price { get; set; }
        public long volume { get; set; }
    }
}
