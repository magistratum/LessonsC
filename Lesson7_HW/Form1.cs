using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson7_HW
{
    public partial class Form1 : Form
    {
        int _width = 1000;
        int _height = 895;
        int _sizeofside = 15;
        int score;
        int shiftX;
        int shiftY;
        PictureBox _fruit;
        PictureBox[] snake = new PictureBox[400];
        Label labelScore;
        Label lablFruX;
        Label lablFruY;
        int fruX;
        int fruY;

        public Form1()
        {
            InitializeComponent();
            this.Width = _width;
            this.Height = _height;
            shiftX = 1;
            shiftY = 0;
            lablFruX = new Label();
            lablFruX.Text = "FruX = ";
            lablFruX.Location = new Point(910, 50);
            this.Controls.Add(lablFruX);
            lablFruY = new Label();
            lablFruY.Text = "FruY = ";
            lablFruY.Location = new Point(910, 80);
            this.Controls.Add(lablFruY);
            labelScore = new Label();
            labelScore.Text = "Score: ";
            labelScore.Location = new Point(910, 20);
            this.Controls.Add(labelScore);
            snake[0] = new PictureBox();
            snake[0].BackColor = Color.Red;
            snake[0].Size = new Size(_sizeofside, _sizeofside);
            snake[0].Location = new Point(150, 150);
            this.Controls.Add(snake[0]);
            _fruit = new PictureBox();
            _fruit.BackColor = Color.Green;
            _fruit.Size = new Size(_sizeofside, _sizeofside);
            _GenerateMap();
            _GenerateFruit();
            timer.Tick += new EventHandler(_update);
            timer.Interval = 200;
            timer.Start();
            this.KeyDown += new KeyEventHandler(Keys);

        }
        void _GenerateMap()
        {
            for (int i = 0; i < _height / _sizeofside; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(0, _sizeofside * i);
                pic.Size = new Size(_width - 100, 1);
                this.Controls.Add(pic);
            }
            for (int i = 0; i < (_width - 100 + _sizeofside) / _sizeofside; i++)
            {
                PictureBox pic = new PictureBox();
                pic.BackColor = Color.Black;
                pic.Location = new Point(_sizeofside * i, 0);
                pic.Size = new Size(1, _height);
                this.Controls.Add(pic);
            }
        }
        void _GenerateFruit()
        {
            Random ran = new Random();
            fruX = ran.Next(0, _width - _sizeofside - 100);
            fruY = ran.Next(0, _height - _sizeofside);
            int tmp = fruX % _sizeofside;
            fruX -= tmp;
            tmp = fruY % _sizeofside;
            fruY -= tmp;
            lablFruX.Text = $"FruX = {fruX}";
            lablFruY.Text = $"FruY = {fruY}";
            _fruit.Location = new Point(fruX, fruY);
            this.Controls.Add(_fruit);
        }
        void _movesnake()
        {
            for (int i = score; i >= 1; i--)
                snake[i].Location = snake[i - 1].Location;
            snake[0].Location = new Point(snake[0].Location.X + shiftX * _sizeofside, snake[0].Location.Y + shiftY * _sizeofside);
        }
        void _update(Object myobject, EventArgs eventArgs)
        {
            _eatsels();
            _movesnake();
            _eatFruit();
            _chekBorder();
        }
        void _eatsels()
        {
            for(int i = 1; i < score; i++)
            {
                if (snake[0].Location == snake[i].Location)
                {
                    for( int j = i; j < score; j++ )
                    {
                        this.Controls.Remove(snake[j]);
                    }
                    score = score - (score - i + 1);
                }
            }
        }
        void _chekBorder()
        {
            if (snake[0].Location.X < 0 || snake[0].Location.X > _width - _sizeofside - 100)
            {
                timer.Stop();
                if (MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK) == DialogResult.OK)
                    this.Close();
            }
            if (snake[0].Location.Y < 0 || snake[0].Location.Y > _height - _sizeofside)
            {
                timer.Stop();
                if (MessageBox.Show("Game Over", "Game Over", MessageBoxButtons.OK) == DialogResult.OK)
                    this.Close();
            }
        }
        void _eatFruit()
        {
            if (snake[0].Location.X == fruX && snake[0].Location.Y == fruY)
            {
                labelScore.Text = $"Score: {++score}";
                snake[score] = new PictureBox();
                snake[score].Location = new Point(snake[score - 1].Location.X + _sizeofside * shiftX, snake[score - 1].Location.Y - _sizeofside * shiftY);
                snake[score].BackColor = Color.Red;
                snake[score].Size = new Size(_sizeofside, _sizeofside);
                this.Controls.Add(snake[score]);
                _GenerateFruit();
            }
        }
        void Keys(object sender, KeyEventArgs eventArgs)
        {
            switch(eventArgs.KeyCode.ToString())
            {
                case "Right":
                    shiftX = 1;
                    shiftY = 0;
                    break;
                case "Left":
                    shiftX = -1;
                    shiftY = 0;
                    break;
                case "Up":
                    shiftY = -1;
                    shiftX = 0;
                    break;
                case "Down":
                    shiftY = 1;
                    shiftX = 0;
                    break;
            }
        }
    }
}
