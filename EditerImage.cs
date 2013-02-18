using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using NsPlages;
using NsReseau;

namespace NsEditerImage
{
    [Flags]
    public enum Canal_e
    {
        Rouge = 1,
        Vert = 2,
        Bleu = 4,
        Alpha = 8,
        Teinte = 16,
        Saturation = 32,
        Luminosite = 64
    }

    public struct Poincon
    {
        public Double Diametre;
        public MathPoint Point;
    }

    public struct MathVecteur
    {
        public MathVecteur(Double X, Double Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public MathVecteur(MathPoint Pt1, MathPoint Pt2)
        {
            this.X = Pt2.X - Pt1.X;
            this.Y = Pt2.Y - Pt1.Y;
        }
        public Double X;
        public Double Y;
        public void Deplacer(MathVecteur Vec)
        { X += Vec.X; Y += Vec.Y; }
    }

    public struct MathPoint
    {
        public MathPoint(Double X, Double Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public Double X;
        public Double Y;
        public void Deplacer(MathVecteur Vec)
        { X += Vec.X; Y += Vec.Y; }
    }

    public class EditerImage
    {
        private Image _Source = null;
        private Image _Image = null;
        private Bitmap _Bmp = null;
        private BitmapData _BmpData = null;
        private Boolean _Optimiser = false;
        private Boolean _Verrouiller = false;
        int _PlageCouleur = 255;

        private int[] _HistRouge = null;
        private int[] _HistVert = null;
        private int[] _HistBleu = null;
        private int[] _HistAlpha = null;
        private int[] _HistTeinte = null;
        private int[] _HistSaturation = null;
        private int[] _HistLuminosite = null;

        public Image Original { get { return _Source; } }
        public Image Image { get { return _Image; } }
        public int Depth { get; private set; }
        public int Width { get; private set; }
        public int Height { get; private set; }
        public bool Optimiser { get { return _Optimiser; } }
        public int PlageCouleur { get { return _PlageCouleur; } }

        public EditerImage(String Chemin)
        {
            _Source = Image.FromFile(Chemin);

            _Image = (Image)_Source.Clone();

            Init();
        }

        ~EditerImage()
        {
            Liberer();
        }

        private void Init()
        {

            // Get width and height of bitmap
            Width = _Image.Width;
            Height = _Image.Height;

            // get source bitmap pixel format size
            Depth = System.Drawing.Bitmap.GetPixelFormatSize(_Image.PixelFormat);

            // Check if bpp (Bits Per Pixel) is 8, 24, or 32
            if (Depth == 8 || Depth == 24 || Depth == 32)
            {
                _Optimiser = true;
            }
            else
                _Optimiser = false;

            ReinitialiserHistogrammes();
        }

        /// <summary>
        /// Lock bitmap data
        /// </summary>
        public void Verrouiller()
        {
            try
            {
                _Bmp = (Bitmap)_Image;

                if (_Optimiser && (_Verrouiller == false))
                {
                    // Lock bitmap and return bitmap data
                    _BmpData = _Bmp.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite,
                                                 _Image.PixelFormat);

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
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;

            nPercentW = ((float)Dim.Width / (float)Width);
            nPercentH = ((float)Dim.Height / (float)Height);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            int destWidth = (int)(Width * nPercent);
            int destHeight = (int)(Height * nPercent);

            Bitmap pBmp = new Bitmap(destWidth, destHeight);
            Graphics pGraphic = Graphics.FromImage((Image)pBmp);
            pGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

            pGraphic.DrawImage(_Source, 0, 0, destWidth, destHeight);
            pGraphic.Dispose();

            _Source = (Image)pBmp;
            _Image = (Image)_Source.Clone();

            ReinitialiserHistogrammes();

            Init();
        }

        public int[] Histogramme(Canal_e Canal)
        {

            int[] pHistogramme = new int[_PlageCouleur + 1];

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

            if (Canal.HasFlag(Canal_e.Alpha))
            {
                if (_HistAlpha == null)
                    _HistAlpha = HistogrammeDuCanal(Canal_e.Alpha);

                Add(ref pHistogramme, _HistAlpha);
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

            return pHistogramme;
        }

        public void NoirEtBlanc(float R = 0.2126f, float V = 0.7152f, float B = 0.0722f)
        {
            // Create a Graphics
            Graphics pGraphic = Graphics.FromImage(_Image);
            // Create a ColorMatrix
            ColorMatrix MatriceCouleur = new ColorMatrix(
                new float[][]
                {
                    new float[] {R, R, R, 0, 0},
                    new float[] {V, V, V, 0, 0},
                    new float[] {B, B, B, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                }
            );

            // Create ImageAttributes
            ImageAttributes Attributs = new ImageAttributes();
            // Set color matrix
            Attributs.SetColorMatrix(MatriceCouleur,
            ColorMatrixFlag.Default,
            ColorAdjustType.Default);
            // Draw Image with image attributes
            pGraphic.DrawImage(_Source, new Rectangle(0, 0, _Image.Width, _Image.Height), 0, 0, _Image.Width, _Image.Height, GraphicsUnit.Pixel, Attributs);
            // Dispose
            pGraphic.Dispose();

            Init();

        }

        public List<Poincon> ListePoincons(List<Plage> ListePlages, Double Jeu, Size DimFinale, TypeReseau_e TypeReseau)
        {
            List<Poincon> pListePoincons = new List<Poincon>();

            Double DiamMax = 0;
            foreach (Plage P in ListePlages)
            {
                if (P.Intitule > DiamMax)
                    DiamMax = P.Intitule;
            }

            DiamMax += Jeu;

            Double MmParPx = (Double)DimFinale.Width / (Double)_Image.Size.Width;
            Double PxParMm = 1.0 / MmParPx;

            List<MathPoint> pListePointsReseau = Reseau.ListePointsReseau(DimFinale, DiamMax, TypeReseau);
            List<MathVecteur> pListePointsMatrice = Reseau.ListVecteursMatrice(DiamMax, MmParPx, TypeReseau);

            Verrouiller();

            foreach (MathPoint Pt in pListePointsReseau)
            {
                float Val = 0;

                foreach (MathVecteur V in pListePointsMatrice)
                {
                    MathPoint PtTmp = Pt;
                    PtTmp.Deplacer(V);
                    Color C = GetPixel((int)Math.Truncate(PtTmp.X * PxParMm), (int)Math.Truncate(PtTmp.Y * PxParMm));
                    Val += C.GetBrightness() * _PlageCouleur;
                }

                Val /= pListePointsMatrice.Count;

                Poincon pPc = new Poincon();
                pPc.Point = Pt;

                foreach (Plage Pc in ListePlages)
                {
                    if ((Val >= Pc.Min) && (Val <= Pc.Max))
                    {
                        pPc.Diametre = Pc.Intitule;
                        pListePoincons.Add(pPc);
                        break;
                    }
                }
            }

            Liberer();

            return pListePoincons;
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

            int[] pixels_map = new int[Width * Height];

            Verrouiller();

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Color P = GetPixel(x, y);

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
                        case Canal_e.Alpha:
                            Val = P.A;
                            break;
                        case Canal_e.Teinte:
                            Val = (P.GetHue() * _PlageCouleur) / 360;
                            break;
                        case Canal_e.Saturation:
                            Val = P.GetSaturation() * _PlageCouleur;
                            break;
                        case Canal_e.Luminosite:
                            Val = P.GetBrightness() * _PlageCouleur;
                            break;
                        default:
                            Val = 0;
                            break;
                    }
                    pixels_map[x + Width * y] = Convert.ToInt32(Val);
                }
            }

            Liberer();

            int pLg = pixels_map.Length;
            int[] pHistogram = new int[_PlageCouleur + 1];

            for (int i = 0; i < pLg; i++)
            {
                int pPixel = pixels_map[i];
                pHistogram[pPixel]++;
            }

            return pHistogram;
        }

        private void ReinitialiserHistogrammes()
        {
            _HistRouge = null;
            _HistVert = null;
            _HistBleu = null;
            _HistAlpha = null;
            _HistTeinte = null;
            _HistSaturation = null;
            _HistLuminosite = null;
        }

        public void ReinitialiserImage()
        {
            _Image = (Image)_Source.Clone();
            Init();
        }

    }
}
