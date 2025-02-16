using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace cstmpricebot.filemanager
{
    public class Item
    {
        public required long Id { get; set; }
        public required string Name { get; set; }
        public required decimal BasePrice { get; set; }
        public required decimal MinPrice { get; set; }
        public required decimal MaxPrice { get; set; }
        [JsonIgnore]
        public Panel? Panel { get; set; }
    }
    internal class Items
    {
        internal static async Task InitializeJson()
        {
            if (!System.IO.File.Exists("items.json"))
            {
                await System.IO.File.WriteAllTextAsync("items.json", "[]");
            }
        }
        internal static async Task<List<Item>> LoadJson()
        {
            string json = await System.IO.File.ReadAllTextAsync("items.json");
            List<Item>? items = JsonConvert.DeserializeObject<List<Item>>(json);
            if (items == null)
            {
                MessageBox.Show("Ошибка загрузки предметов", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            return items;
        }
        internal static async Task SaveItem(Item item)
        {
            List<Item> items = await LoadJson();
            Item? odItem = items.FirstOrDefault(x => x.Id == item.Id);
            if (odItem != null) items.Remove(odItem);
            items.Add(item);
            await System.IO.File.WriteAllTextAsync("items.json", JsonConvert.SerializeObject(items, Formatting.Indented));
        }
        internal static async Task RemoveItem(Item item)
        {
            List<Item> items = await LoadJson();
            Item? odItem = items.FirstOrDefault(x => x.Id == item.Id);
            if (odItem != null) items.Remove(odItem);
            await System.IO.File.WriteAllTextAsync("items.json", JsonConvert.SerializeObject(items, Formatting.Indented));
        }
    }
}
