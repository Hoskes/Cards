
namespace Cards
{
    internal class ImageBox
    {
        private Bitmap[] images;

        public int Rows { get; }
        public int Cols { get; }
        public int Count { get; }
        public int Card_width { get; private set; }
        public int Card_height { get; private set; }

        public ImageBox(Bitmap image, int rows, int cols)
        {
            Count = rows * cols;
            Rows = rows;
            Cols = cols;
            LoadImage(image);
        }
        public ImageBox(Bitmap image, int rows, int cols, int count)
        {
            Rows = rows;
            Cols = cols;
            Count = count;
            LoadImage(image);
        }
        public Bitmap this[int index] { get { return images[index]; } }
        private void LoadImage(Bitmap image)
        {
            Card_width = image.Width / Cols;
            Card_height = image.Height / Rows;
            var n = 0;
            images = new Bitmap[Count];
            for (var r = 0; r < Rows; r++)
            {
                for (var c = 0; c < Cols; c++,n++)
                {
                    images[n] = new Bitmap(Card_width, Card_height);
                    var g = Graphics.FromImage(images[n]);
                    g.DrawImage(image,0,0, new Rectangle(c * Card_width, r * Card_height, Card_width, Card_height), GraphicsUnit.Pixel);
                    g.Dispose();
                }
            }
        }

    }
}