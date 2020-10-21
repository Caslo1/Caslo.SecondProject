using CrmBL.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class Catalog<T> : Form
        where T : class
    {
        CrmContext db;
        DbSet<T> set;

        public Catalog(DbSet<T> set, CrmContext db)
        {
            InitializeComponent();
            this.db = db;
            this.set = set;
            set.Load();
            dataGridView1.DataSource = set.Local.ToBindingList();
        }

        private void Catalog_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (typeof(T) == typeof(Item))
            {

            }
            else if (typeof(T) == typeof(Player))
            {

            }
            else if (typeof(T) == typeof(Character))
            {

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var id = dataGridView1.SelectedRows[0].Cells[0].Value;

            if (typeof(T) == typeof(Item))
            {
                var item = set.Find(id) as Item;
                if (item != null)
                {
                    var form = new ItemForm(item);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        item = form.Item;
                        db.SaveChanges();
                        dataGridView1.Update();
                    }
                }
            }
            else if (typeof(T) == typeof(Player))
            {
                var player = set.Find(id) as Player;
                if (player != null)
                {
                    var form = new PlayerForm(player);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        player = form.Player;
                        db.SaveChanges();
                        dataGridView1.Update();
                    }
                }
            }
            else if (typeof(T) == typeof(Character))
            {
                var character = set.Find(id) as Character;
                if (character != null)
                {
                    var form = new CharacterForm(character);

                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        character = form.Character;
                        db.SaveChanges();
                        dataGridView1.Update();
                    }
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
