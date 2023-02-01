using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.Media;

namespace Fight_til_the_End
{
    public partial class Main : Form
    {
        static int[,] map =
        {
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,1,0,1,1,1,1,0,1,1,1,1,1,1,0,0,1,1,0,0},
            {0,1,0,1,1,1,0,0,1,1,1,1,1,1,1,1,1,1,0,0},
            {0,1,1,1,1,1,0,1,1,1,0,0,0,1,2,0,1,1,0,0},
            {0,1,0,1,1,2,0,1,0,2,1,1,0,0,1,0,1,1,0,0},
            {0,0,1,0,1,1,1,1,0,1,1,0,1,1,1,1,1,0,1,0},
            {0,1,1,1,0,0,1,1,0,0,1,0,1,1,1,1,1,0,1,0},
            {0,1,2,1,1,0,0,1,0,1,0,0,1,1,1,1,1,1,1,0},
            {0,0,1,1,1,1,1,2,1,1,1,1,1,1,1,0,1,1,2,0},
            {0,0,0,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0},
            {0,1,1,1,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,0},
            {0,0,1,1,1,1,1,0,0,1,1,0,1,0,1,1,0,1,1,0},
            {0,0,1,1,0,1,1,0,1,0,2,0,1,0,0,1,0,1,1,0},
            {0,0,1,1,1,1,1,0,1,0,1,0,1,1,0,1,1,1,1,0},
            {0,1,1,0,1,1,1,1,1,1,1,0,1,1,0,0,1,2,1,0},
            {0,1,1,0,0,2,0,1,0,0,1,1,1,1,1,0,1,1,1,0},
            {0,0,2,1,0,0,1,1,0,1,1,1,0,2,1,0,1,1,1,0},
            {0,1,1,0,1,1,1,0,2,0,1,1,1,0,1,1,1,0,0,0},
            {0,1,1,1,1,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
        }; // 0:obstacle, 1:path, 2:barrel //props are hidden under the barrel
        int gameMode, min=3, sec=0, bombX, bombY;
        int bulletSpeed = 32, spiderBulletY, spiderBulletX, greenBulletY, greenBulletX, spiderBulletNum=1, greenBulletNum=1, spiderFiredAmount=1, greenFiredAmount=1;
        int sx1=0, sy1=0, x1=0, y1=0;//player spiderman
        int sx2=0, sy2=0, x2=0, y2=0;//player green_gobin
        WindowsMediaPlayer bgm = new WindowsMediaPlayer();
        SoundPlayer gunSound = new SoundPlayer("gun sound.wav");
        SoundPlayer propSound = new SoundPlayer("buttonSound.wav");
        SoundPlayer crackBox = new SoundPlayer("woodCrack.wav");

        private void Main_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left && !game_timer.Enabled)
            {
                gameStart();
            }
        }

        SoundPlayer hit = new SoundPlayer("hit.wav");
        public Main()
        {
            InitializeComponent();
            this.SetBounds(0, 0, 660, 680);
        }


        private void Main_Load(object sender, EventArgs e)
        {
            bgm.URL = "bgm.mp3";
            bgm.settings.playCount = 10;
            bgm.settings.volume = 20;
            bgm.controls.play();
            Menu menu = new Menu();
            menu.ShowDialog();
            gameMode = menu.getGameMode();
            gameStart();
        }

        private void gameStart()
        {
            if (gameMode == 1) {
                game_timer.Start();
                gameResult.Dock = DockStyle.Bottom;
                gameResult.Hide();
                min = 3; sec = 0;
                spiderBulletNum = 1; greenBulletNum = 1; spiderFiredAmount = 1; greenFiredAmount = 1;
                gameStatus.Text = "目前戰況: 沒有人擁有寶箱";
                money_box.Location = new Point(10 * 32, 9 * 32);
                money_box.Show();
                spiderman.Location = new Point(17 * 32, 2 * 32);
                green_gobin.Location = new Point(1 * 32, 17 * 32);
                x1 = 17; y1 = 2;
                x2 = 1; y2 = 17;
                return;
            }
            else
                Application.Exit();
        }


        private void game_timer_Tick(object sender, EventArgs e)
        {
            timerCountDown();
            foreach(Control x in this.Controls){
                if(x is PictureBox && x.Tag == "spiderBullet")
                {
                    spiderBulletY = (x.Top+30) / 32;
                    spiderBulletX = (x.Left+10) / 32;
                    //check.Text += "\n" + spiderBulletY;
                    if(map[spiderBulletY, spiderBulletX] == 0 || x.Top <= 0) {
                        spiderFiredAmount = 1;
                        x.Dispose();
                        continue;
                    }
                    if(map[spiderBulletY, spiderBulletX] == 2)
                    {
                        crackBox.Play();
                        detectProp(spiderman, x);
                        spiderFiredAmount = 1;
                        continue;
                    }
                    if (x.Bounds.IntersectsWith(green_gobin.Bounds))
                    {
                        hit.Play();
                        x.Dispose();
                        spiderFiredAmount = 1;
                        green_gobin.Location = new Point(1 * 32, 17 * 32);
                        x2 = 1; y2 = 17;
                        updateMoneyBox(x);
                    }
                    x.Top += bulletSpeed;
                }
            }
            foreach(Control x in this.Controls) { 
                if(x is PictureBox && x.Tag == "greenBullet") {
                    greenBulletY = x.Top / 32;
                    greenBulletX = (x.Left+10) / 32;
                    //check.Text += "\n" + greenBulletY.ToString();
                    if (map[greenBulletY, greenBulletX] == 0 || x.Top <= 0)
                    {
                        greenFiredAmount = 1;
                        x.Dispose();
                        continue;
                    }
                    if (map[greenBulletY, greenBulletX] == 2) {
                        crackBox.Play();
                        detectProp(green_gobin, x);
                        greenFiredAmount = 1;
                        continue;
                    }
                    if (x.Bounds.IntersectsWith(spiderman.Bounds))
                    {
                        hit.Play();
                        x.Dispose();
                        greenFiredAmount = 1;
                        spiderman.Location = new Point(17 * 32, 2 * 32);
                        x1 = 17; y1 = 2;
                        updateMoneyBox(x);
                    }
                    x.Top -= bulletSpeed;
                }
            }
            // collide with props and get props
            foreach(Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "bomb_prop")
                {
                    if (x.Bounds.IntersectsWith(spiderman.Bounds))
                    {
                        propSound.Play();
                        spiderBulletNum++;
                        x.Dispose();
                    }
                    if (x.Bounds.IntersectsWith(green_gobin.Bounds))
                    {
                        propSound.Play();
                        greenBulletNum++;
                        x.Dispose();
                    }
                }
                if(x is PictureBox && x.Tag == "energy_prop")
                {
                    if (x.Bounds.IntersectsWith(spiderman.Bounds) || x.Bounds.IntersectsWith(green_gobin.Bounds))
                    {
                        propSound.Play();
                        sec += 10;
                        if(sec > 60)
                        {
                            min++;
                            sec = sec % 60;
                        }
                        x.Dispose();
                    }
                }
            }
            updateMoneyBox();
        }
      
        private void updateMoneyBox()
        {
            if (spiderman.Bounds.IntersectsWith(money_box.Bounds))
            {
                propSound.Play();
                gameStatus.Text = "目前戰況: 蜘蛛人擁有寶箱";
                money_box.Tag = "spiderHadIt";
                money_box.Location = new Point(-10, -10);
                money_box.Hide();
            }

            else if (green_gobin.Bounds.IntersectsWith(money_box.Bounds))
            {
                propSound.Play();
                gameStatus.Text = "目前戰況: 綠惡魔擁有寶箱";
                money_box.Tag = "greenHadIt";
                money_box.Location = new Point(-10, -10);
                money_box.Hide();
            }
        }
        private void updateMoneyBox(Control bullet)
        {
            if(bullet.Tag == "spiderBullet" && money_box.Tag == "greenHadIt")
            {
                money_box.Location = new Point(10*32, 9*32);
                gameStatus.Text = "目前戰況: 沒有人擁有寶箱";
                money_box.Tag = "";
                money_box.Show();
            }
            if(bullet.Tag == "greenBullet" && money_box.Tag == "spiderHadIt")
            {
                money_box.Location = new Point(10 * 32, 9 * 32);
                gameStatus.Text = "目前戰況: 沒有人擁有寶箱";
                money_box.Tag = "";
                money_box.Show();
            }
        }
        void timerCountDown()
        {
            sec--;
            if (sec <= 0)
            {
                if (min <= 0)
                {
                    timer_display.Text = "時間到";
                    game_timer.Stop();
                    checkGameResult();
                    return;
                }
                timer_display.Text = "時間: " + min.ToString() + " 分 ";
                sec = 60;
                min--;
            }
            else if (min <= 0)
            {
                timer_display.Text = "時間: " + sec + " 秒";
            }
            else
            {
                timer_display.Text = "時間: " + min + " 分 " + sec + " 秒";
            }
        }

        private void checkGameResult()
        {
            if (money_box.Tag == "spiderHadIt")
            {
                gameResult.Text = "蜘蛛人成功搶到寶物!";
            }
            else if (money_box.Tag == "greenHadIt")
            {
                gameResult.Text = "綠惡魔成功搶到寶物!";
            }
            else 
            {
                gameResult.Text = "沒有人搶到寶物";
            }
            gameResult.Text += "\n點擊視窗再玩一次";
            gameResult.Show();
        }
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            // enter game and exit game 
            if (e.KeyCode == Keys.Escape) { Application.Exit(); }

            // player1 and player2 moving 
            sx1 = x1; sy1 = y1;
            sx2 = x2; sy2 = y2;
            if (e.KeyCode == Keys.S) { y1 = goDown(sx1, sy1, x1, y1); }
            if (e.KeyCode == Keys.W) { y1 = goUp(sx1, sy1, x1, y1); }
            if (e.KeyCode == Keys.D) { x1 = goRight(sx1, sy1, x1, y1); }
            if (e.KeyCode == Keys.A) { x1 = goLeft(sx1, sy1, x1, y1); }
            if (e.KeyCode == Keys.Space) { shotBullet(spiderman,x1, y1); }

            if (e.KeyCode == Keys.Down) { y2 = goDown(sx2, sy2, x2, y2); }
            if (e.KeyCode == Keys.Up) { y2 = goUp(sx2, sy2, x2, y2); }
            if (e.KeyCode == Keys.Right) { x2 = goRight(sx2, sy2, x2, y2); }
            if (e.KeyCode == Keys.Left) { x2 = goLeft(sx2, sy2, x2, y2); }
            if (e.KeyCode == Keys.Enter) { shotBullet(green_gobin,x2, y2); }

            spiderman.Left = 32 * x1;
            spiderman.Top = 32 * y1;
            green_gobin.Left = 32 * x2;
            green_gobin.Top = 32 * y2;
        }

        public void shotBullet(PictureBox player, int x, int y) {
            //check.Text += "test";
            bombX = x*32; bombY = y*32;
            PictureBox bullet = new PictureBox();
            bullet.Image = Fight_til_the_End.Properties.Resources.bullet;
            bullet.SendToBack();
            bullet.Size = new Size(10, 20);
            bullet.SizeMode = PictureBoxSizeMode.StretchImage;
            bullet.BackColor = Color.Transparent;
            if (player.Name == "green_gobin" && greenFiredAmount <= greenBulletNum) {
                gunSound.Play();
                greenFiredAmount++;
                bullet.Location = new Point(bombX + 10, bombY - 30);
                bullet.Tag = "greenBullet";
                this.Controls.Add(bullet);
            }
            if(player.Name == "spiderman" && spiderFiredAmount <= spiderBulletNum) {
                gunSound.Play();
                spiderFiredAmount++;
                bullet.Location = new Point(bombX + 10, bombY + 30);
                bullet.Tag = "spiderBullet";
                this.Controls.Add(bullet);
            }
           
        }

        private void detectProp(PictureBox player, Control bullet)
        {
            foreach(Control barrels in this.Controls)
            {
                if(barrels.Bounds.IntersectsWith(bullet.Bounds) && barrels.Tag == "barrel")
                {
                    barrels.Dispose();
                    bullet.Dispose();
                    //check.Text += "\n" + "Top: " + barrels.Top / 32 + "Left: " + barrels.Left / 32;
                    if(player.Name == "spiderman")
                        map[(barrels.Top) / 32, barrels.Left / 32] = 1;
                    else
                        map[barrels.Top / 32, barrels.Left / 32] = 1;
                }
            }
        }

        public int goLeft(int sx, int sy, int x, int y)//往左
        {
            x--;
            if (map[y, x] == 0 || map[y, x] == 2)
            {
                x = sx;
            }
            return x;
        }
        public int goRight(int sx, int sy, int x, int y)//往右
        {
            x++;
            if (map[y, x] == 0 || map[y, x] == 2)
            {
                x = sx;
            }
            return x;
        }
        public int goUp(int sx, int sy, int x, int y)//往上
        {
            y--;
            if (map[y, x] == 0 || map[y, x] == 2)
            {
                y = sy;
            }
            return y;
        }
        public int goDown(int sx, int sy, int x, int y)//往下
        {
            y++;
            if (map[y, x] == 0 || map[y, x] == 2)
            {
                y = sy;
            }
            return y;
        }
    }
}
