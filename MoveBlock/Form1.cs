using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveBlock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        const int N = 4;// 按钮的行数、列数
        Button[,] buttons = new Button[N, N];
        DateTime timeNow = new DateTime();
        TimeSpan timeCount = new TimeSpan();

        void GenerateAllButtons()
        {
            int x0 = 30, y0 = 10, w = 45, d = 50;
            for (int r = 0; r < N; r++)
                for (int c = 0; c < N; c++)
                {
                    int num = r * N + c;
                    Button btn = new Button();
                    btn.Text = (num + 1).ToString();
                    btn.Top = y0 + r * d;
                    btn.Left = x0 + c * d;
                    btn.Width = w;
                    btn.Height = w;
                    btn.Visible = true;
                    btn.Tag = r * N + c;
                    btn.Font = new Font("华文细黑", 15);
                    btn.Click += new EventHandler(Btn_Click);

                    buttons[r, c] = btn;
                    this.Controls.Add(btn);
                }
            buttons[N - 1, N - 1].Visible = false;
        }

        // 查找隐藏按钮
        Button FindHiddenButton()
        {
            for (int r = 0; r < N; r++)
                for (int c = 0; c < N; c++)
                {
                    if (!buttons[r, c].Visible)
                    {
                        return buttons[r, c];
                    }
                }
            return null;
        }

        bool IsNeightbor(Button btnA, Button btnB)
        {
            int a = (int)btnA.Tag;  // 按钮a的位置
            int b = (int)btnB.Tag;  // 按钮b的位置
            int r1 = a / N;  // 按钮a的行
            int c1 = a % N;  //按钮a的列
            int r2 = b / N;  // 按钮b的行
            int c2 = b % N;  //按钮b的列

            if (r1 == r2 && (c1 == c2 - 1 || c1 == c2 + 1)  // 行号相邻
                || c1 == c2 && (r1 == r2 + 1 || r1 == r2 - 1))  // 列号相邻
                return true;
            else
                return false;
        }

        // 检查是否完成
        bool ResultIsOk()
        {
            for (int r = 0; r < N; r++)
                for (int c = 0; c < N; c++)
                {
                    if (buttons[r, c].Text != (r * N + c + 1).ToString())
                        return false;
                }
            return true;
        }


        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;  //当前点中的按钮
            Button blank = FindHiddenButton();  //空白按钮

            //判断周围是不是有空白块，如果有，交换
            if (IsNeightbor(btn, blank))
            {
                Swap(btn, blank);
                blank.Focus();
            }

            if (ResultIsOk())
            {
                this.timer1.Stop();
                MessageBox.Show("Success!");
            }
        }

        void Swap(Button btna, Button btnb)
        {
            string t = btna.Text;
            btna.Text = btnb.Text;
            btnb.Text = t;

            bool v = btna.Visible;
            btna.Visible = btnb.Visible;
            btnb.Visible = v;
        }

        void Shuffle()
        {
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)  //次数越是多，交换越是乱
            {
                int a = rnd.Next(N);
                int b = rnd.Next(N);
                int c = rnd.Next(N);
                int d = rnd.Next(N);
                Swap(buttons[a, b], buttons[c, d]);
            }

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            Shuffle();  // 打乱顺序
            this.timer1.Start();
            timeNow = DateTime.Now;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GenerateAllButtons();  // 产生所有按钮
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeCount = DateTime.Now - timeNow;
            label1.Text = string.Format("{0:00}:{1:00}:{2:00}", timeCount.Hours, timeCount.Minutes, timeCount.Seconds);
        }
    }

}
