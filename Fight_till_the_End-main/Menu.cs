using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fight_til_the_End
{
    public partial class Menu : Form
    {
        int gameMode = 0;
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            btn_start.Select(); // change focus to btn_start (for Keys.Enter to trigger)
            lbl_intro.Hide();
            lbl_how.Hide();
            btn_how.Location = new Point(206, 327);
            btn_how.Location = new Point(206, 466);
        }

        private void btn_how_Click(object sender, EventArgs e)
        {
            spiderman.Hide();
            btn_how.Hide();
            lbl_intro.Show();
            lbl_how.Show();
            btn_start.Location = new Point(206, 466);
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            gameMode = 1;
            this.Close();
        }

        public int getGameMode()
        {
            return gameMode;
        }

        private void Menu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) { btn_start.Select(); gameMode = 1; }
            if(e.KeyCode == Keys.Escape) { Application.Exit(); }
        }
    }
}
