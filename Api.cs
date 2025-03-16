using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using cstmpricebot.filemanager;
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
            RestRequest testreq = new RestRequest($"v2/test?key={key}");
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
        public async Task<Dictionary<Item, decimal>> GetBestPrices(List<Item> items)
        {
            Dictionary<Item, decimal> bestprices = new();
            RestRequest request = new RestRequest($"v2/search-list-items-by-hash-name-all?" +
                $"{GenerateParams(key, items.Select(i => i.Name).ToList())}");
            RestResponse response = await client.ExecuteAsync(request);
            if (response.Content == null) return bestprices;
            if (!response.IsSuccessStatusCode) return bestprices;
            structs.bestprice.ApiResponse? apiResponse = JsonConvert.DeserializeObject<structs.bestprice.ApiResponse> (response.Content);
            if (apiResponse == null) return bestprices;
            if (!apiResponse.Success)
            {
                Console.WriteLine(response.Content);
                return bestprices;
            }
            foreach (Item item in items)
            {
                if (!apiResponse.Data.ContainsKey(item.Name)) continue;
                decimal lowestprice = (apiResponse.Data[item.Name][0].Price) / 1000m;
                if (apiResponse.Data[item.Name][0].Id == item.Id)
                {
                    if(apiResponse.Data[item.Name][1].Price / 1000m - apiResponse.Data[item.Name][0].Price / 1000m > 0.001m)
                    {
                        bestprices.Add(item, apiResponse.Data[item.Name][1].Price / 1000m - 0.001m);
                    } else bestprices.Add(item, -1); // -1 = already has the best price
                }
                else
                {
                    bestprices.Add(item, lowestprice);
                }
            }
            return bestprices;
        }
        public async Task<bool> SetPrice(Item item, decimal price)
        {
            RestRequest request = new RestRequest($"v2/set-price?key={key}&item_id={item.Id}&price={(int)(price * 1000)}&cur=USD");
            RestResponse response = await client.ExecuteAsync(request);
            if (response.Content == null) return false;
            if (!response.IsSuccessStatusCode) return false;
            dynamic? content = JsonConvert.DeserializeObject(response.Content);
            if (content == null) return false;
            Console.WriteLine(response.Content);
            return content["success"] == "True";
        }
        private string GenerateParams(string apiKey, List<string> names)
        {
            var query = HttpUtility.ParseQueryString("");
            query["key"] = apiKey;

            foreach (string name in names)
            {
                query.Add("list_hash_name[]", name);
            }

            return query.ToString() ?? "";
        }
    }
    public class ApiItem
    {
        public required long Id;
        public required string Name;
        public required decimal Price;
    }
}

namespace cstmpricebot.structs.bestprice
{

    public class Item
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("price")]
        public int Price { get; set; }
    }

    public class ApiResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, List<Item>> Data { get; set; }
    }
}