using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using CSGOSkinsWeb.Database;
using ServiceStack;

namespace CSGOSkinsWeb.Core.Services
{
    public interface ISkinPriceService
    {
        string ConvertToHashKey(string skinName);
        Task<string> RetrieveSkinPrice(string skinName);
        Task<string> RetrieveSkinVolume(string skinName);
    }

    public class SkinPriceService : ISkinPriceService
    {
        private SkinDbContext _context;

        private string jsonUrlPrice = string.Empty;
        private string skinHash = string.Empty;
        private string oldSkinHash = string.Empty;

        public SkinPriceService(SkinDbContext context)
        {
            _context = context;
        }

        public string ConvertToHashKey(string skinName)
        {
            return skinName.Replace(":", "%3A").Replace(" ", "%20").Replace("|", "%7C").Replace("(", "%28").Replace(")", "%29");
        }

        public async Task<string> RetrieveSkinPrice(string skinName)
        {
            return await WeaponJSON("price", skinName);
        }

        public async Task<string> RetrieveSkinVolume(string skinName)
        {
            return await WeaponJSON("volume", skinName);
        }

        private async Task SetJsonVariable()
        {
            if (string.IsNullOrEmpty(jsonUrlPrice) || skinHash != oldSkinHash)
            {
                jsonUrlPrice = await $"https://steamcommunity.com/market/priceoverview/?country=US&currency=1&appid=730&market_hash_name={skinHash}".GetJsonFromUrlAsync();
                Debug.WriteLine("One call");
            }
        }

        private async Task<string> WeaponJSON(string value, string skinName)
        {
            skinHash = ConvertToHashKey(skinName);
            

            if (value == "price" || value == "volume")
            {
                await SetJsonVariable();

                if (value == "price")
                {
                    oldSkinHash = skinHash;
                    return jsonUrlPrice.FromJson<CaseValuesFromSteam>().lowest_price;
                }

                else
                {
                    oldSkinHash = skinHash;
                    return jsonUrlPrice.FromJson<CaseValuesFromSteam>().volume.ToString();
                }
                    
            }

            return "Value couldn't be obtained";
        }
    }
}
