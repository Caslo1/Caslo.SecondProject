using CrmBL.Model;
using System;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class Main : Form
    {
        CrmContext db;

        public Main()
        {
            InitializeComponent();
            db = new CrmContext();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void playerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogPlayer = new Catalog<Player>(db.Players, db);
            catalogPlayer.Show();
        }

        private void itemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogItems = new Catalog<Item>(db.Items, db);
            catalogItems.Show();
        }

        private void chatacterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogChatacter = new Catalog<Character>(db.Characters, db);
            catalogChatacter.Show();
        }

        private void lootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var catalogLoot = new Catalog<Loot>(db.Loots, db);
            catalogLoot.Show();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new PlayerForm();
            if(form.ShowDialog() == DialogResult.OK)
            {
                db.Players.Add(form.Player);
                db.SaveChanges();
            }
        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new CharacterForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Characters.Add(form.Character);
                db.SaveChanges();
            }
        }

        private void addToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var form = new ItemForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                db.Items.Add(form.Item);
                db.SaveChanges();
            }
        }

        private void itemsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
