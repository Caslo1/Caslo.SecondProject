using CrmBL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class PlayerForm : Form
    {
        public Player Player { get; set; }
        public PlayerForm()
        {
            InitializeComponent();
        }

        public PlayerForm(Player player) : this()
        {
            Player = player;
            textBox1.Text = player.Name;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var p = Player ?? new Player();
            p.Name = textBox1.Text;
            Close();
        }
    }
}
