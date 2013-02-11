using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;

namespace PoinconnerImage
{
    public enum TypeReseau_e
    {
        Carre,
        Hexagonal
    }

    public static class Reseau
    {
        public static List<Point> ListePointsReseau(Size Dimensions, Double Diametre, TypeReseau_e TypeReseau)
        {
            List<Point> pListePoints = new List<Point>();
            int pNbH;
            int pNbV;
            Double pDimH = Diametre;
            Double pDimV = Diametre;
            Double pDecalH;
            Double pDecalV;

            switch (TypeReseau)
            {
                case TypeReseau_e.Carre:
                    pNbH = Convert.ToInt32((Dimensions.Width - pDimH) / pDimH);
                    pNbV = Convert.ToInt32((Dimensions.Height - pDimV) / pDimV);
                    pDecalH = (Dimensions.Width - (pNbH * Diametre)) * 0.5;
                    pDecalV = (Dimensions.Height - (pNbV * Diametre)) * 0.5;

                    for (int y = 0; y <= pNbH; y++) for (int x = 0; x <= pNbV; x++)
                        {
                            Point pPt;
                            pPt.X = pDecalH + (x * pDimH);
                            pPt.Y = pDecalV + (y * pDimV);
                            pListePoints.Add(pPt);
                        }

                    break;

                case TypeReseau_e.Hexagonal:
                    pDimV = (Diametre / Math.Cos(Math.PI / 12.0));
                    Double pDistV = pDimV * 3.0 / 4.0;
                    pNbH = Convert.ToInt32((Dimensions.Width - pDimH) / pDimH);
                    pNbV = Convert.ToInt32((Dimensions.Height - pDimV) / pDistV);
                    pDecalH = (Dimensions.Width - (pNbH * pDimH)) * 0.5;
                    pDecalV = (Dimensions.Height - (pNbV * pDistV)) * 0.5;

                    for (int y = 0; y <= pNbV; y++) for (int x = 0; x <= pNbH; x++)
                        {
                            Point pPt = new Point();
                            if ((y % 2) == 0)
                            {
                                
                                pPt.X = pDecalH + (x * pDimH);
                                pPt.Y = pDecalV + (y * pDistV);
                                pListePoints.Add(pPt);
                            }
                            else if (x < pNbH)
                            {
                                pPt.X = pDecalH + 0.5 * Diametre + (x * pDimH);
                                pPt.Y = pDecalV + (y * pDistV);
                                pListePoints.Add(pPt);
                            }
                            
                        }
                    break;
            }

            return pListePoints;
        }

        public static List<Vecteur> ListVecteursMatrice(Double Diametre, Double Pas, TypeReseau_e TypeReseau)
        {
            List<Point> pListePoints = new List<Point>();

            int pNbH;
            int pNbV;
            Double pDimH = Diametre;
            Double pDimV = Diametre;
            Double pDecalH;
            Double pDecalV;

            pNbH = Convert.ToInt32(Diametre / Pas);
            pNbV = Convert.ToInt32(Diametre / Pas);
            pDecalH = (Diametre - (pNbH * Diametre)) * 0.5;
            pDecalV = (Diametre - (pNbV * Diametre)) * 0.5;

            Point PtCentre = new Point(pDimH * 0.5, pDimV * 0.5);

            switch (TypeReseau)
            {
                case TypeReseau_e.Carre:
                    for (int y = 0; y <= pNbH; y++) for (int x = 0; x <= pNbV; x++)
                        {
                            Point pPt;
                            pPt.X = pDecalH + (x * pDimH);
                            pPt.Y = pDecalV + (y * pDimV);
                            pListePoints.Add(pPt);
                        }
                    break;
                case TypeReseau_e.Hexagonal:
                    Double pCoteV = (Diametre / Math.Cos(Math.PI / 12.0));
                    Point Pt1 = new Point(0.0, pCoteV / 4.0);
                    Point Pt2 = new Point(pDimH * 0.5, 0.0);
                    PtCentre.Y = pCoteV * 0.5;

                    for (int y = 0; y <= pNbH; y++) for (int x = 0; x <= pNbV; x++)
                        {
                            Point pPt;
                            pPt.X = pDecalH + (x * pDimH);
                            pPt.Y = pDecalV + (y * pDimV);

                            Boolean T = true;
                            Point PtTest = pPt;

                            for (int i = 0; i < 4; i++)
                            {
                                T = T & SensHoraire(Pt1, Pt2, PtTest);
                                Rotation90(PtCentre, ref PtTest);
                            }
                            if (T)
                                pListePoints.Add(pPt);
                        }
                    break;
            }

            List<Vecteur> pListeVecteurs = new List<Vecteur>();

            foreach (Point Pt in pListePoints)
            {
                Vecteur pV = new Vecteur(PtCentre, Pt);
                pListeVecteurs.Add(pV);
            }

            return pListeVecteurs;
        }

        private static void Rotation90(Point Centre, ref Point Pt)
        {
            Double X = Pt.X;
            Double Y = Pt.Y;
            Pt.X = Y;
            Pt.Y = -1 * X;
        }

        private static Boolean SensHoraire(Point Dep, Point Arr, Point Pt)
        {
            Boolean T = false;

            Double A = (Arr.X - Dep.X) * (Pt.Y - Dep.Y);
            Double B = (Arr.Y - Dep.Y) * (Pt.X - Dep.X);

            if (A < B)
                T = true;

            return T;
        }

    }
}
