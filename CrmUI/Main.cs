using CrmBL.Model;
using System;
using System.Linq;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class Main : Form
    {
        CrmContext db;
        Player player;
        Dungeon dung;
        Character character;
        Bosses bosses;

        public Main()
        {
            InitializeComponent();
            db = new CrmContext();

            dung = new Dungeon(character);
            bosses = new Bosses(Name, db.Players.FirstOrDefault())
            {
                KillBoss = false
            };

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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var form = new Login();
            form.ShowDialog();
            if(form.DialogResult == DialogResult.OK)
            {
                var tempPlayer = db.Players.FirstOrDefault(p => p.Name.Equals(form.Player.Name));
                if(tempPlayer != null)
                {
                    player = tempPlayer; 
                }
                else
                {
                    db.Players.Add(form.Player);
                    db.SaveChanges();
                    player = form.Player;
                }
            }

            linkLabel1.Text = $"Здравствуйте, {player.Name}";
        }
    }
}
