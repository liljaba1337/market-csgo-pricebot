using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cstmpricebot.filemanager;

namespace cstmpricebot
{
    public partial class AdditionPrompt : Form
    {
        private ApiItem? item;
        private Item? botitem;
        private Panel panel;
        private Form1 form;
        public AdditionPrompt(ApiItem item, Panel panel, Form1 form)
        {
            InitializeComponent();
            this.item = item;
            this.panel = panel;
            this.form = form;
        }
        public AdditionPrompt(Item item, Form1 form)
        {
            InitializeComponent();
            botitem = item;
            panel = item.Panel;
            this.form = form;
        }

        private void AdditionPrompt_Load(object sender, EventArgs e)
        {
            if (botitem != null)
            {
                namelbl.Text = botitem.Name;
                pricelbl.Text = $"${botitem.BasePrice}";
                minpricetb.Text = botitem.MinPrice.ToString();
                maxpricetb.Text = botitem.MaxPrice.ToString();
                return;
            }
            namelbl.Text = item.Name;
            pricelbl.Text = $"${item.Price}";
            minpricetb.Text = item.Price.ToString();
            maxpricetb.Text = item.Price.ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (botitem != null) minpricetb.Text = (botitem.BasePrice + (botitem.BasePrice / 100 * trackBar1.Value)).ToString();
            else minpricetb.Text = (item.Price + (item.Price / 100 * trackBar1.Value)).ToString();
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (botitem != null) maxpricetb.Text = (botitem.BasePrice + (botitem.BasePrice / 100 * trackBar2.Value)).ToString();
            else maxpricetb.Text = (item.Price + (item.Price / 100 * trackBar2.Value)).ToString();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (botitem != null)
            {
                botitem.MinPrice = decimal.Parse(minpricetb.Text);
                botitem.MaxPrice = decimal.Parse(maxpricetb.Text);
                await Items.SaveItem(botitem);

                form.UpdateBotItemPanel(botitem);

                Close();
                return;
            }
            Item newItem = new Item
            {
                Id = item.Id,
                Name = item.Name,
                BasePrice = item.Price,
                MinPrice = decimal.Parse(minpricetb.Text),
                MaxPrice = decimal.Parse(maxpricetb.Text)
            };
            await Items.SaveItem(newItem);
            Panel newpanel = form.CreateBotItemPanel(newItem);
            form.flowLayoutPanel1.Controls.Remove(panel);
            form.flowLayoutPanel2.Controls.Add(newpanel);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If your currency on market.csgo.com is set to anything other than USD, " +
                "prices will be displayed in your selected currency, even if a dollar sign appears " +
                "next to them. This does not affect the software—just set your min and max prices in your currency.",
                "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
