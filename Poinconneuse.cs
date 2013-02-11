using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using DXFLibrary;

namespace PoinconnerImage
{
    public struct Vecteur
    {
        public Vecteur(Double X, Double Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public Vecteur(Point Pt1, Point Pt2)
        {
            this.X = Pt2.X - Pt1.X;
            this.Y = Pt2.Y - Pt1.Y;
        }
        public Double X;
        public Double Y;
        public void Deplacer(Vecteur Vec)
        { X += Vec.X; Y += Vec.Y; }
    }

    public struct Point
    {
        public Point(Double X, Double Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public Double X;
        public Double Y;
        public void Deplacer(Vecteur Vec)
        { X += Vec.X; Y += Vec.Y; }
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
        private Double _CoteHMm;
        private Int32 _CoteHPxl;
        private Double _CoteVMm;
        private Int32 _CoteVPxl;
        private Double _PixelParMm;
        private Double _MmParPixel;
        private Int32 _NbRecX;
        private Int32 _NbRecY;
        private Double _DecalX;
        private Double _DecalY;
        private List<Rec> _ListeTrous;
        private List<Vecteur> _ListeVecPixel;

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


            Int32 p = _ImageSource.Height;
            _MmParPixel = (Double)_Lg / (Double)_ImageSource.Width;
            _PixelParMm = (Double)_ImageSource.Width / (Double)_Lg;
            _CoteHMm = _ListePoincons[0] + _Jeu;
            _CoteHPxl = (Int32)(_CoteHMm * _PixelParMm);
            _CoteVMm = _CoteHMm;
            _CoteVPxl = _CoteHPxl;
            _NbRecX = (Int32)(_Lg / _CoteHMm);
            _NbRecY = (Int32)(_Ht / _CoteHMm);
            _DecalX = (_Lg - (_NbRecX * _CoteHMm)) * 0.5;
            _DecalY = (_Ht - (_NbRecY * _CoteHMm)) * 0.5;

            _ListeTrous = new List<Rec>();
            _ListeVecPixel = new List<Vecteur>();

            // On rempli la liste des pixels pour chaque trou
            Vecteur Decalage;
            Decalage.X = -0.5 * _CoteHMm;
            Decalage.Y = -0.5 * _CoteHMm;

            if (_TypeCarroyage == "Hexagonal")
            {
                _CoteVMm = (_CoteHMm * 0.5) / Math.Tan(Math.PI / 6);
                _CoteVPxl = (Int32)(_CoteVMm * _PixelParMm);
            }

            

            for (Int32 y = 0; y <= _CoteVPxl + 1; y++) for (Int32 x = 0; x <= _CoteHPxl + 1; x++)
                {
                    Vecteur Vec = new Vecteur();
                    Vec.X = x * _MmParPixel; Vec.Y = y * _MmParPixel;
                    Vec.Deplacer(Decalage);
                    if (_TypeCarroyage == "Carré")
                    {
                        _ListeVecPixel.Add(Vec);
                    }
                    else if (_TypeCarroyage == "Hexagonal")
                    {

                    }
                    
                }

            


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

            for (Int32 y = 0; y < _NbRecY; y++)
            {

                Double pDecalY = _DecalY + ((y + 0.5) * _CoteHMm);

                for (Int32 x = 0; x < _NbRecX; x++)
                {

                    Rec pRec = new Rec();
                    Point PtCentre;
                    PtCentre.X = _DecalX + ((x + 0.5) * _CoteHMm);
                    PtCentre.Y = pDecalY;
                    pRec.Point = PtCentre;

                    float pLuminosite = 0;

                    foreach (Vecteur Vec in _ListeVecPixel)
                    {
                        Point PtPixel;
                        PtPixel = PtCentre;
                        PtPixel.Deplacer(Vec);

                        Color P;
                        if (_Optimiser)
                            P = GetPixel((int)Math.Round(PtPixel.X * _PixelParMm, 0), (int)Math.Round(PtPixel.Y * _PixelParMm, 0));
                        else
                            P = _ImageSource.GetPixel((int)Math.Round(PtPixel.X * _PixelParMm, 0), (int)Math.Round(PtPixel.Y * _PixelParMm, 0));

                        pLuminosite += P.GetBrightness();
                    }

                    pRec.Luminosite = pLuminosite / ((float)(_CoteHPxl * _CoteHPxl));
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
                 DXFLibrary.Circle Cercle = new DXFLibrary.Circle(pRect.Point.X, pRect.Point.Y * -1, pRect.Luminosite * _ListePoincons[0], "Poinçonnage");
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
