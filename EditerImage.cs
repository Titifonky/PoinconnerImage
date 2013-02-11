using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace NsEditerImage
{
    [Flags]
    public enum Canal_e
    {
        Rouge = 1,
        Vert = 2,
        Bleu = 4,
        Teinte = 8,
        Saturation = 16,
        Luminosite = 32
    }

    public class EditerImage
    {
        Image _Source = null;
        Bitmap _Bmp = null;
        BitmapData _BmpData = null;
        Boolean _Optimiser = false;
        Boolean _Verrouiller = false;

        public Image Image { get { return _Source; } }
        public Bitmap Bitmap { get { return _Bmp; } }
        public int Depth { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public bool Optimiser { get { return _Optimiser; } }

        private int[] _HistRouge;
        private int[] _HistVert;
        private int[] _HistBleu;
        private int[] _HistTeinte;
        private int[] _HistSaturation;
        private int[] _HistLuminosite;

        public EditerImage(Image Source)
        {
            Init(Source);
        }

        private void Init(Image Source)
        {
            Liberer();

            _Source = Source;
            _Bmp = _Source as Bitmap;

            // Get width and height of bitmap
            Width = _Bmp.Width;
            Height = _Bmp.Height;

            // get source bitmap pixel format size
            Depth = System.Drawing.Bitmap.GetPixelFormatSize(_Bmp.PixelFormat);

            // Check if bpp (Bits Per Pixel) is 8, 24, or 32
            if (Depth == 8 || Depth == 24 || Depth == 32)
            {
                _Optimiser = true;
            }
            else
                _Optimiser = false;

            _HistRouge = null;
            _HistVert = null;
            _HistBleu = null;
            _HistTeinte = null;
            _HistSaturation = null;
            _HistLuminosite = null;
        }

        ~EditerImage()
        {
            Liberer();
        }

        /// <summary>
        /// Lock bitmap data
        /// </summary>
        public void Verrouiller()
        {
            try
            {

                if (_Optimiser && (_Verrouiller == false))
                {
                    // Lock bitmap and return bitmap data
                    _BmpData = _Bmp.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite,
                                                 _Bmp.PixelFormat);

                    _Verrouiller = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Unlock bitmap data
        /// </summary>
        public void Liberer()
        {
            try
            {
                if (_Optimiser && (_Verrouiller == true))
                {
                    // Unlock bitmap data
                    _Bmp.UnlockBits(_BmpData);
                    _Verrouiller = false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get the color of the specified pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        /// 

        public unsafe Color GetPixel(int x, int y)
        {
            if (!_Optimiser || (_Verrouiller == false))
            {
                return _Bmp.GetPixel(x, y);
            }

            byte* pBp = (byte*)_BmpData.Scan0;

            switch (Depth)
            {
                case 32:
                    pBp += (x * 4) + (y * _BmpData.Stride);
                    return Color.FromArgb(*(pBp + 3), *(pBp + 2), *(pBp + 1), *pBp);
                case 24:
                    pBp += (x * 3) + (y * _BmpData.Stride);
                    return Color.FromArgb(*(pBp + 2), *(pBp + 1), *pBp);
                case 8:
                    pBp += x + (y * _BmpData.Stride);
                    return Color.FromArgb(*pBp, *pBp, *pBp);
            }

            return Color.Empty;
        }

        /// <summary>
        /// Set the color of the specified pixel
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public unsafe void SetPixel(int x, int y, Color color)
        {
            if (!_Optimiser || (_Verrouiller == false))
            {
                _Bmp.SetPixel(x, y, color);
                return;
            }

            byte* pBp = (byte*)_BmpData.Scan0;

            switch (Depth)
            {
                case 32:
                    pBp += (x * 4) + (y * _BmpData.Stride);
                    *(pBp + 3) = color.A;
                    *(pBp + 2) = color.R;
                    *(pBp + 1) = color.G;
                    *pBp = color.B;
                    break;
                case 24:
                    pBp += (x * 3) + (y * _BmpData.Stride);
                    *(pBp + 2) = color.R;
                    *(pBp + 1) = color.G;
                    *pBp = color.B;
                    break;
                case 8:
                    pBp += x + (y * _BmpData.Stride);
                    *pBp = color.B;
                    break;
            }
        }

        public void Redimensionner(Size Dim)
        {
            Liberer();

            int sourceWidth = _Source.Width;
            int sourceHeight = _Source.Height;

            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Dim.Width / (float)sourceWidth);
            nPercentH = ((float)Dim.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;

            g.DrawImage(_Source, 0, 0, destWidth, destHeight);
            g.Dispose();

            Init(b as Image);
        }

        public Bitmap Histogramme(Size Dim, Canal_e Canal)
        {

            int[] pHistogramme = new int[byte.MaxValue + 1];

            if (Canal.HasFlag(Canal_e.Rouge))
            {
                if (_HistRouge == null)
                    _HistRouge = HistogrammeDuCanal(Canal_e.Rouge);

                Add(ref pHistogramme, _HistRouge);
            }

            if (Canal.HasFlag(Canal_e.Vert))
            {
                if (_HistVert == null)
                    _HistVert = HistogrammeDuCanal(Canal_e.Vert);

                Add(ref pHistogramme, _HistVert);
            }

            if (Canal.HasFlag(Canal_e.Bleu))
            {
                if (_HistBleu == null)
                    _HistBleu = HistogrammeDuCanal(Canal_e.Bleu);

                Add(ref pHistogramme, _HistBleu);
            }

            if (Canal.HasFlag(Canal_e.Teinte))
            {
                if (_HistTeinte == null)
                    _HistTeinte = HistogrammeDuCanal(Canal_e.Teinte);

                Add(ref pHistogramme, _HistTeinte);
            }

            if (Canal.HasFlag(Canal_e.Saturation))
            {
                if (_HistSaturation == null)
                    _HistSaturation = HistogrammeDuCanal(Canal_e.Saturation);

                Add(ref pHistogramme, _HistSaturation);
            }

            if (Canal.HasFlag(Canal_e.Luminosite))
            {
                if (_HistLuminosite == null)
                    _HistLuminosite = HistogrammeDuCanal(Canal_e.Luminosite);

                Add(ref pHistogramme, _HistLuminosite);
            }

            int pMax = 1;
            for (int i = 0; i < pHistogramme.Length; i++)
            {
                if (pHistogramme[i] > pMax)
                    pMax = pHistogramme[i];
            }

            int pBoxWidth = Dim.Width;
            int pBoxHeight = Dim.Height;
            float byteMaxValue = byte.MaxValue;

            Point[] Points = new Point[pHistogramme.Length + 1];
            Points[0].X = 0;
            Points[0].Y = pBoxHeight;

            for (int i = 0; i < pHistogramme.Length; i++)
            {
                Points[i + 1].X = Convert.ToInt32((i * (pBoxWidth - 2) / (byteMaxValue + 1)) + 1);
                Points[i + 1].Y = Convert.ToInt32((pBoxHeight - 1) - ((Convert.ToDouble(pHistogramme[i]) * (pBoxHeight - 5)) / pMax));
            }

            Points[pHistogramme.Length].X = pBoxWidth - 1;
            Points[pHistogramme.Length].Y = pBoxHeight;


            Bitmap Image_Histogram = new Bitmap(pBoxWidth, pBoxHeight);
            Graphics Graphic_Histogram = Graphics.FromImage(Image_Histogram);
            Pen Pen = new Pen(Color.Black);
            Pen.Brush = new SolidBrush(Color.Black);
            Graphic_Histogram.FillPolygon(Pen.Brush, Points);

            return Image_Histogram;
        }

        private void Add(ref int[] x, int[] y)
        {
            for (int i = 0; i < x.Length; i++)
            {
                x[i] += y[i];
            }
        }

        private int[] HistogrammeDuCanal(Canal_e Canal)
        {
            Verrouiller();

            int[] pixels_map = new int[Width * Height];
            Double byteMaxValue = byte.MaxValue;

            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Color P = GetPixel(j, i);

                    Double Val = 0;

                    switch (Canal)
                    {
                        case Canal_e.Rouge:
                            Val = P.R;
                            break;
                        case Canal_e.Vert:
                            Val = P.G;
                            break;
                        case Canal_e.Bleu:
                            Val = P.B;
                            break;
                        case Canal_e.Teinte:
                            Val = (P.GetHue() * byteMaxValue) / 360;
                            break;
                        case Canal_e.Saturation:
                            Val = P.GetSaturation() * byteMaxValue;
                            break;
                        case Canal_e.Luminosite:
                            Val = P.GetBrightness() * byteMaxValue;
                            break;
                        default:
                            Val = 0;
                            break;
                    }
                    pixels_map[j + Width * i] = Convert.ToInt32(Math.Round(byteMaxValue - Val, 0));
                }
            }

            int pLg = pixels_map.Length;
            int[] pHistogram = new int[Byte.MaxValue + 1];

            for (int i = 0; i < pLg; i++)
            {
                int pPixel = pixels_map[i];
                pHistogram[pPixel]++;
            }

            Liberer();

            return pHistogram;
        }

    }
}
