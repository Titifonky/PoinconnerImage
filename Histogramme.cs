using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Diagnostics;

using SD = System.Drawing;

namespace PoinconnerImage
{

    public class Histogramme
    {
        private PictureBox _Box;
        private Bitmap _ImageSource;
        private BitmapData _ImageSourceData;
        private Boolean _Optimiser;

        public Histogramme(PictureBox Box, Image Image)
        {
            _Box = Box;
            _ImageSource = (Bitmap)Image;

            if (_ImageSource.PixelFormat == PixelFormat.Format32bppArgb || _ImageSource.PixelFormat == PixelFormat.Format24bppRgb)
            {
                _Optimiser = true;
                _ImageSourceData = _ImageSource.LockBits(
                        new Rectangle(0, 0, _ImageSource.Width, _ImageSource.Height),
                        ImageLockMode.ReadOnly,
                        _ImageSource.PixelFormat
                        );
            }

            int[] pixel_map = GetPixelMap(_ImageSource);
            Box.Image = CreateHistogram(pixel_map);

            if (_Optimiser)
                _ImageSource.UnlockBits(_ImageSourceData);
        }

        private int[] GetPixelMap(Bitmap ImageSource)
        {
            int size = ImageSource.Width * ImageSource.Height;
            int picture_width = ImageSource.Width;
            int picture_height = ImageSource.Height;
            int[] pixels_map = new int[size];

            for (int i = 0; i < picture_height; i++)
            {
                for (int j = 0; j < picture_width; j++)
                {
                    Color P;
                    if (_Optimiser)
                        P = GetPixel(j, i);
                    else
                        P = _ImageSource.GetPixel(j, i);

                    pixels_map[j + picture_width * i] = (int)(Math.Round(P.GetBrightness() * Byte.MaxValue, 0));
                }
            }

            return pixels_map;
        }

        private unsafe Color GetPixel(int x, int y)
        {
            byte* bp = (byte*)_ImageSourceData.Scan0;
            switch (_ImageSourceData.PixelFormat)
            {
                case PixelFormat.Format32bppArgb:
                    bp += (x * 4) + (y * _ImageSourceData.Stride);
                    return Color.FromArgb(*(bp + 3), *(bp + 2), *(bp + 1), *bp);
                case PixelFormat.Format24bppRgb:
                    bp += (x * 3) + (y * _ImageSourceData.Stride);
                    return Color.FromArgb(*(bp + 2), *(bp + 1), *bp);
            }
            return Color.Empty;
        }

        private Bitmap CreateHistogram(int[] ListePixel)
        {
            int Size = ListePixel.Length;
            int[] Histogram = new int[Byte.MaxValue + 1];
            int Max = 0;

            for (int i = 0; i < Size; i++)
            {
                int Pixel = ListePixel[i];
                Histogram[Pixel]++;
                if (Histogram[Pixel] > Max)
                {
                    Max = Histogram[Pixel];
                }
            }


            SD.Point[] Points = new SD.Point[Byte.MaxValue + 3];
            Points[0].X = 0;
            Points[0].Y = _Box.Height;

            for (int i = 0; i < Byte.MaxValue + 1; i++)
            {
                Points[i + 1].X = i * _Box.Width / (Byte.MaxValue + 1);
                Points[i + 1].Y = Convert.ToInt32(_Box.Height - ((Convert.ToDouble(Histogram[i]) * (_Box.Height - 5)) / Max));
            }

            Points[Byte.MaxValue + 2].X = Byte.MaxValue;
            Points[Byte.MaxValue + 2].Y = _Box.Height;


            Bitmap Image_Histogram = new Bitmap(_Box.Width, _Box.Height);
            Graphics Graphic_Histogram = Graphics.FromImage(Image_Histogram);
            Pen Pen = new Pen(Color.Black);
            Pen.Brush = new SolidBrush(Color.Black);
            Graphic_Histogram.FillPolygon(Pen.Brush, Points);

            return Image_Histogram;
        }
    }
}
