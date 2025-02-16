using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace cstmpricebot
{
    public class Api
    {
        string key;
        RestClient client = new RestClient("https://market.csgo.com/api");
        public Api(string key)
        {
            this.key = key;
        }
        public async Task<bool> test()
        {
            RestRequest testreq = new RestRequest($"v2/my-inventory?key={key}");
            RestResponse response = await client.ExecuteAsync(testreq);
            if (response.Content == null) return false;
            dynamic? content = JsonConvert.DeserializeObject(response.Content);
            if (content == null) return false;
            return response.IsSuccessStatusCode && content["success"] == "True";
        }
        public async Task<List<ApiItem>> GetItemsOnSale()
        {
            RestRequest testreq = new RestRequest($"v2/items?key={key}");
            RestResponse response = await client.ExecuteAsync(testreq);
            if (response.Content == null) return new List<ApiItem>();
            dynamic? content = JsonConvert.DeserializeObject(response.Content);
            if (content == null) return new List<ApiItem>();
            List<ApiItem> items = new();
            foreach (dynamic item in content["items"])
            {
                items.Add(new ApiItem
                {
                    Id = item["item_id"],
                    Name = item["market_hash_name"],
                    Price = item["price"]
                });
            }
            return items;
        }
    }
    public class ApiItem
    {
        public required long Id;
        public required string Name;
        public required decimal Price;
    }
}
