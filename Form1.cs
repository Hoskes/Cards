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

            Bitmap im = new Bitmap(new MemoryStream(Properties.Resources.cards));
            imageBox = new ImageBox(im, rows: 4, cols: 13);
            //pictureBox1.Image = imageBox[0];
            rnd = new Random();
            //DrawRandCards(20);

            this.KeyDown += Form1_KeyDown;

        }

        

        private void Form1_KeyDown(object? sender, KeyEventArgs e) {
            switch (e.KeyCode)
            {
                case Keys.F1:
                    DrawRandCards(5);
                    break;
                case Keys.F2:
                    DrawVeerCards(20);
                    break;
            }
        }
        private void DrawVeerCards(int count =10)
        {
            g.Clear(SystemColors.Control);
            for (int i = 0; i < count; i++)
            {
                var card_index = rnd.Next(imageBox.Count);
                g.RotateTransform(-120 +15*(count-1));
                g.DrawImage(
                    imageBox[rnd.Next(imageBox.Count)],
                    550,
                    50);
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
