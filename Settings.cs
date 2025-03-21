using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace cstmpricebot.filemanager
{
    internal class Settings
    {
        internal static async Task InitializeJson()
        {
            if (!System.IO.File.Exists("settings.json"))
            {
                await System.IO.File.WriteAllTextAsync("settings.json", "{}");
            }
        }
        internal static async Task<SettingsData> LoadJson()
        {
            string json = await File.ReadAllTextAsync("settings.json");
            SettingsData? settings = JsonConvert.DeserializeObject<SettingsData>(json);
            if (settings == null)
            {
                MessageBox.Show("An error occurred while loading settings", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(1);
            }
            return settings;
        }
        internal static async Task SaveApiKey(string key)
        {
            SettingsData settings = await LoadJson();
            settings.ApiKey = key;
            await System.IO.File.WriteAllTextAsync("settings.json", JsonConvert.SerializeObject(settings, Formatting.Indented));
        }
    }
    internal class SettingsData
    {
        public string? ApiKey { get; set; }
    }
}
