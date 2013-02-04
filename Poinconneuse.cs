using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Collections.Generic;
using DXFLibrary;
using System.IO;

namespace PoinconnerImage
{
    public struct Vecteur
    {
        public Double X;
        public Double Y;
    }

    public struct Point
    {
        public Double X;
        public Double Y;
        public void Deplacer(Vecteur Vec)
        { X = Vec.X + X; Y = Vec.Y + Y; }
    }

    public struct Rec
    {
        public Point Point;
        public float Luminosite;
    }

    public class Poinconneuse
    {
        private String _CheminFichierImage;
        private String _CheminDossierExport;
        private List<Double> _ListePoincons;
        private Double _Jeu;
        private Int32 _Lg;
        private Int32 _Ht;
        private String _TypeCarroyage;

        private Bitmap _ImageSource;
        private BitmapData _ImageSourceData;
        private Boolean _Optimiser;
        private Double _CoteMm;
        private Int32 _CotePxl;
        private Double _PixelParMm;
        private Double _MmParPixel;
        private Int32 _NbRecX;
        private Int32 _NbRecY;
        private Double _DecalX;
        private Double _DecalY;
        private List<Rec> _ListeTrous;
        ///private List<Vecteur> _ListeVecPixel;

        public Poinconneuse()
        {
        }

        public void Go(NameValueCollection Data)
        {

            _CheminFichierImage = Data["CheminFichierImage"];
            _CheminDossierExport = Data["CheminDossierExport"];

            _ListePoincons = new List<double>();
            foreach (String S in Data["ListePoincons"].Split(' '))
            {
                _ListePoincons.Add(Convert.ToDouble(S));
            }

            _Jeu = Convert.ToDouble(Data["Jeu"]);
            _Lg = Convert.ToInt32(Data["LargeurImage"]);
            _Ht = Convert.ToInt32(Data["HauteurImage"]);
            _TypeCarroyage = Data["TypeCarroyage"];

            _ImageSource = new Bitmap(_CheminFichierImage);
            _Optimiser = false;

            _ListePoincons.Sort();
            _ListePoincons.Reverse();

            _MmParPixel = (Double)_Lg / (Double)_ImageSource.Width;
            _PixelParMm = (Double)_ImageSource.Width / (Double)_Lg;
            _CoteMm = _ListePoincons[0] + _Jeu;
            _CotePxl = (Int32)(_CoteMm * _PixelParMm);
            _NbRecX = (Int32)(_Lg / _CoteMm);
            _NbRecY = (Int32)(_Ht / _CoteMm);
            _DecalX = (_Lg - (_NbRecX * _CoteMm)) * 0.5;
            _DecalY = (_Ht - (_NbRecY * _CoteMm)) * 0.5;

            _ListeTrous = new List<Rec>();


            ConvertirEnDxf();
        }

        private void ConvertirEnDxf()
        {

            if (_ImageSource.PixelFormat == PixelFormat.Format32bppArgb || _ImageSource.PixelFormat == PixelFormat.Format24bppRgb)
            {
                _Optimiser = true;
                _ImageSourceData = _ImageSource.LockBits(
                        new Rectangle(0, 0, _ImageSource.Width, _ImageSource.Height),
                        ImageLockMode.ReadOnly,
                        _ImageSource.PixelFormat
                        );
            }

            for (Int32 y = 1; y <= _NbRecY; y++)
            {
                Double pDecalY = _DecalY + (y - 0.5) * _CoteMm;
                Int32 PxlDepY = (Int32)(_PixelParMm * (_DecalY + (y - 1) * _CoteMm));

                for (Int32 x = 1; x <= _NbRecX; x++)
                {
                    Rec pRec = new Rec();
                    Point PtCentre;
                    PtCentre.X = _DecalX + (x - 0.5) * _CoteMm;
                    PtCentre.Y = pDecalY;
                    pRec.Point = PtCentre;                

                    float pLuminosite = 0;

                    for (Int32 j = 0; j <= _CotePxl; j++)
                    {
                        PxlDepY += j;
                        Int32 PxlDepX = (Int32)(_PixelParMm * (_DecalX + (x - 1) * _CoteMm));

                        for (Int32 i = 0; i <= _CotePxl; i++)
                        {
                            PxlDepX += i;
                            Color P;
                            if (_Optimiser)
                                P = GetPixel(PxlDepX, PxlDepY);
                            else
                                P = _ImageSource.GetPixel(PxlDepX, PxlDepY);

                            pLuminosite += P.GetBrightness();

                        }
                    }

                    pRec.Luminosite = pLuminosite / ((float)(_CotePxl * _CotePxl));
                    _ListeTrous.Add(pRec);
                }
            }

            if (_Optimiser)
                _ImageSource.UnlockBits(_ImageSourceData);
            
            ﻿DXFLibrary.Document DocDXF = new DXFLibrary.Document();

             DXFLibrary.Tables Table = new DXFLibrary.Tables();
             DocDXF.SetTables(Table);

             DXFLibrary.Table Claques = new DXFLibrary.Table("LAYER");
             Table.addTable(Claques);

             foreach (Rec pRect in _ListeTrous)
             {
                 Debug.WriteLine(pRect.Point.X.ToString() + " / " + pRect.Point.Y.ToString() + "   -   " + pRect.Luminosite.ToString());
                 DXFLibrary.Circle Cercle = new DXFLibrary.Circle(pRect.Point.X, pRect.Point.Y, pRect.Luminosite * 10, "Poinçonnage");
                 DocDXF.add(Cercle);
             }

             _ListeTrous.Clear();

             FileStream FichierDXF = new FileStream(_CheminDossierExport + "\\Test2.dxf", System.IO.FileMode.Create);
             DXFLibrary.Writer.Write(DocDXF, FichierDXF);
             FichierDXF.Close();

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
    }
}
