using System;

namespace Cards
{
    public partial class Form1 : Form
    {
        Graphics g;
        Random rnd;
        ImageBox imageBox;
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            
            Bitmap im = new Bitmap(new MemoryStream(Properties.Resources.cards1));
            imageBox = new ImageBox(im, rows: 5, cols: 11);
            imageBox.DeleteLastCards(3);
            //pictureBox1.Image = imageBox[0];
            rnd = new Random();
            //DrawRandCards(20);

            this.KeyDown += Form1_KeyDown;

        }



        private void Form1_KeyDown(object? sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    DrawRandCards(5);
                    break;
                case Keys.F2:
                    DrawVeerCards(7);
                    break;
                case Keys.F3:
                    DrawRotateCards(7);
                    break;
            }
        }

       
        private void DrawVeerCards(int count = 10)
        {
            g.Clear(SystemColors.Control);

            float centerX = rnd.Next(imageBox.Card_width , pictureBox1.Width - imageBox.Card_width );
            float bottomY = rnd.Next(imageBox.Card_height, pictureBox1.Height - imageBox.Card_height); 

            
            float initialAngle = rnd.Next(-180, 180); 
            float angleStep = 15f; 

            for (int i = 0; i < count; i++)
            {
                var card_index = rnd.Next(imageBox.Count);
                float angle = initialAngle + angleStep * i;

               
                float offsetX = (float)(Math.Cos(angle * Math.PI / 180) * (imageBox.Card_width / 2));
                float offsetY = (float)(Math.Sin(angle * Math.PI / 180) * (imageBox.Card_height / 2));

                
                g.TranslateTransform(centerX + offsetX, bottomY - (imageBox.Card_height / 2));
                g.RotateTransform(angle);

                
                g.DrawImage(imageBox[card_index], -imageBox.Card_width / 2, -imageBox.Card_height, imageBox.Card_width, imageBox.Card_height);
                g.ResetTransform();
            }
            pictureBox1.Invalidate();
        }

        private void DrawRotateCards(int count)
        {
            g.Clear(SystemColors.Control);
            int x_start = imageBox.Card_width + rnd.Next(Screen.PrimaryScreen.Bounds.Width - 3 * imageBox.Card_width);
            int y_start = imageBox.Card_height + rnd.Next(Screen.PrimaryScreen.Bounds.Height - 3 * imageBox.Card_height);
            int randomValue = rnd.Next(0, 2) * 2 - 1;
           
            for (int i = 0; i < count; i++) 
            {
                
                var card_index = rnd.Next(imageBox.Count);
                int x = x_start + i * 30; 
                int y = y_start;



                g.TranslateTransform(x, y);
                g.RotateTransform(-1*(i - count / 2) * 5 * randomValue); 
                g.DrawImage(imageBox[card_index], 0, 0, imageBox.Card_width, imageBox.Card_height);
                g.ResetTransform();
            }
            pictureBox1.Invalidate();
        }


        public void DrawRandCards(int count)
        {
            g.Clear(SystemColors.Control);
            for (int i = 0; i < count; i++)
            {
                var card_index = rnd.Next(imageBox.Count);
                g.DrawImage(
                    imageBox[rnd.Next(imageBox.Count)],
                    rnd.Next(this.ClientSize.Width - imageBox[card_index].Width),
                    rnd.Next(this.ClientSize.Height - imageBox[card_index].Height));
            }
            pictureBox1.Invalidate();
        }
    }
}
