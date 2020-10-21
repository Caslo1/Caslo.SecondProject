using CrmBL.Model;
using System;
using System.Windows.Forms;

namespace CrmUI
{
    public partial class Login : Form
    {
        public Player Player { get; set; }

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Player = new Player
            {
                Name = textBox1.Text
            };
            DialogResult = DialogResult.OK;
        }
    }
}
