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
    public partial class ItemForm : Form
    {
        public Item Item { get; set; }
        public ItemForm()
        {
            InitializeComponent();
        }

        public ItemForm(Item item) : this()
        {
            Item = item;
            textBox1.Text = Item.Name;
            numericUpDown1.Value = Item.DropChance;
            numericUpDown2.Value = Item.Count;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var p = Item ?? new Item();
            p.Name = textBox1.Text;
            p.DropChance = numericUpDown1.Value;
            p.Count = Convert.ToInt32(numericUpDown2.Value);
            Close();
        }

        private void ItemForm_Load(object sender, EventArgs e)
        {

        }
    }
}
