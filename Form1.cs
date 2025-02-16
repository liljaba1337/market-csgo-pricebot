using System.Windows.Forms;
using cstmpricebot.filemanager;

namespace cstmpricebot
{
    public partial class Form1 : Form
    {
        private Api api;
        private Dictionary<long, Item> botitems = new();
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            //SettingsData settings;
            //Api api = new("");
            await Settings.InitializeJson();
            await Items.InitializeJson();
            SettingsData settings = await Settings.LoadJson();
            api = new(settings.ApiKey);

            bool valid = false;
            /*
            do
            {
                settings = await Settings.LoadJson();
                if (settings.ApiKey == null)
                {
                    ApiKeyPrompt prompt = new();
                    prompt.ShowDialog();
                    continue;
                }
                api = new(settings.ApiKey);
                Console.WriteLine("testing api key = "+settings.ApiKey);
                valid = await api.test();
                Console.WriteLine("valid = " + valid);
                if (!valid)
                {
                    ApiKeyPrompt prompt = new();
                    prompt.ShowDialog();
                }
            } while (settings.ApiKey == null || !valid);*/
            label1.Text = "получение предметов на продаже";

            List<ApiItem> items = await api.GetItemsOnSale();
            List<Item> parsedbotitems = await Items.LoadJson();
            List<long> presentedids = parsedbotitems.Select(i => i.Id).ToList();
            foreach (ApiItem item in items)
            {
                if (presentedids.Contains(item.Id)) continue;
                Panel panel = CreateApiItemPanel(item);
                flowLayoutPanel1.Controls.Add(panel);
            }
            foreach (Item item in parsedbotitems)
            {
                Panel panel = CreateBotItemPanel(item);
                flowLayoutPanel2.Controls.Add(panel);
            }
            label1.Visible = false;
            button1.Visible = true;
        }
        private void AddItem(object? sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                if (clickedButton.Parent is Panel parentPanel)
                {
                    Label? nameLabel = parentPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "name");
                    Label? priceLabel = parentPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "price");
                    Label? idLabel = parentPanel.Controls.OfType<Label>().FirstOrDefault(l => l.Name == "id");
                    ApiItem item = new()
                    {
                        Id = long.Parse(idLabel?.Text),
                        Name = nameLabel?.Text,
                        Price = decimal.Parse(priceLabel?.Text.Replace("$", ""))
                    };
                    AdditionPrompt prompt = new(item, parentPanel, this);
                    
                    prompt.ShowDialog();
                }
            }
        }
        private void EditItem(object? sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                Item item = botitems[long.Parse(clickedButton.Name)];
                AdditionPrompt prompt = new(item, this);
                prompt.ShowDialog();
            }
        }
        private async void RemoveItem(object? sender, EventArgs e)
        {
            if (sender is Button clickedButton)
            {
                Item item = botitems[long.Parse(clickedButton.Name)];
                flowLayoutPanel2.Controls.Remove(item.Panel);
                flowLayoutPanel1.Controls.Add(CreateApiItemPanel(new ApiItem { Id = item.Id, Name = item.Name, Price = item.BasePrice }));
                botitems.Remove(item.Id);
                await Items.RemoveItem(item);
            }
        }
        private Panel CreateApiItemPanel(ApiItem item)
        {
            Size textSize = TextRenderer.MeasureText(item.Name, SystemFonts.DefaultFont);
            Panel panel = new Panel
            {
                Size = new Size(30 + textSize.Width, 80),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.LightGray,
                Margin = new Padding(10)
            };

            Label nameLabel = new Label { Name = "name", Text = item.Name, AutoSize = true, Location = new Point(5, 5) };
            Label priceLabel = new Label { Name = "price", Text = $"${item.Price}", AutoSize = true, Location = new Point(5, 25) };
            Label idLabel = new Label { Name = "id", Text = item.Id.ToString(), Visible = false };
            Button addButton = new Button { Text = "Добавить", Location = new Point(5, 45) };
            addButton.Click += AddItem;

            panel.Controls.Add(nameLabel);
            panel.Controls.Add(priceLabel);
            panel.Controls.Add(idLabel);
            panel.Controls.Add(addButton);

            return panel;
        }
        internal Panel CreateBotItemPanel(Item item)
        {
            Size textSize = TextRenderer.MeasureText(item.Name, SystemFonts.DefaultFont);
            Panel panel = new Panel
            {
                Name = item.Id.ToString(),
                Size = new Size(30 + textSize.Width, 100),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.LightGray,
                Margin = new Padding(10)
            };

            Label nameLabel = new Label { Name = "name", Text = item.Name, AutoSize = true, Location = new Point(5, 5) };
            Label priceLabel = new Label { Name = "price", Text = $"${item.BasePrice}       (${item.MinPrice} - ${item.MaxPrice})",
                AutoSize = true, Location = new Point(5, 25) };
            Label idLabel = new Label { Name = "id", Text = item.Id.ToString(), Visible = false };
            Button editButton = new Button { Name = item.Id.ToString(), Text = "Изменить", Location = new Point(5, 45) };
            Button removeButton = new Button { Name = item.Id.ToString(), Text = "Удалить", Location = new Point(5, 70) };

            editButton.Click += EditItem;
            removeButton.Click += RemoveItem;
            panel.Controls.Add(nameLabel);
            panel.Controls.Add(priceLabel);
            panel.Controls.Add(idLabel);
            panel.Controls.Add(editButton);
            panel.Controls.Add(removeButton);
            item.Panel = panel;
            botitems[item.Id] = item;
            return panel;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            List<ApiItem> items = await api.GetItemsOnSale();
            List<filemanager.Item> botitems = await Items.LoadJson();
            List<long> presentedids = botitems.Select(i => i.Id).ToList();
            foreach (ApiItem item in items)
            {
                if (presentedids.Contains(item.Id)) continue;
                Panel panel = CreateApiItemPanel(item);
                flowLayoutPanel1.Controls.Add(panel);
            }
        }
    }
}
