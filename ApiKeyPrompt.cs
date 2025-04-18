﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using cstmpricebot.filemanager;

namespace cstmpricebot
{
    public partial class ApiKeyPrompt : Form
    {
        public ApiKeyPrompt()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://market.csgo.com/en/api/content/start#apigen") { UseShellExecute = true });
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            Api api = new(apikeytb.Text);
            if (await api.test())
            {
                await Settings.SaveApiKey(apikeytb.Text);
                Close();
            }
            else
            {
                MessageBox.Show("Invalid key", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            button2.Enabled = true;
        }
    }
}
