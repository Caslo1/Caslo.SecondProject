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
    public partial class CharacterForm : Form
    {
        public Character Character { get; set; }
        public CharacterForm()
        {
            InitializeComponent();
        }

        public CharacterForm(Character character) : this()
        {
            Character = character;
            textBox1.Text = character.Name;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var c = Character ?? new Character();
            c.Name = textBox1.Text;
            Close();
        }
    }
}
