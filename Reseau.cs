using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Diagnostics;
using NsEditerImage;

namespace NsReseau
{
    public enum TypeReseau_e
    {
        Carre,
        Hexagonal
    }

    public static class Reseau
    {
        public static List<MathPoint> ListePointsReseau(Size Dimensions, Double Diametre, TypeReseau_e TypeReseau)
        {
            List<MathPoint> pListePoints = new List<MathPoint>();
            int pNbH;
            int pNbV;
            Double pDimH = Diametre;
            Double pDimV = Diametre;
            Double pDecalH;
            Double pDecalV;

            switch (TypeReseau)
            {
                case TypeReseau_e.Carre:
                    pNbH = (int)Math.Truncate((Dimensions.Width - pDimH) / pDimH);
                    pNbV = (int)Math.Truncate((Dimensions.Height - pDimV) / pDimV);
                    pDecalH = (Dimensions.Width - (pNbH * pDimH)) * 0.5;
                    pDecalV = (Dimensions.Height - (pNbV * pDimV)) * 0.5;

                    for (int y = 0; y <= pNbV; y++) for (int x = 0; x <= pNbH; x++)
                        {
                            MathPoint pPt;
                            pPt.X = pDecalH + (x * pDimH);
                            pPt.Y = pDecalV + (y * pDimV);
                            pListePoints.Add(pPt);
                        }

                    break;

                case TypeReseau_e.Hexagonal:
                    pDimV = (Diametre / Math.Cos(Math.PI / 12.0));
                    Double pDistV = pDimV * 3.0 / 4.0;
                    pNbH = (int)Math.Truncate((Dimensions.Width - pDimH) / pDimH);
                    pNbV = (int)Math.Truncate((Dimensions.Height - pDimV) / pDistV);
                    pDecalH = (Dimensions.Width - (pNbH * pDimH)) * 0.5;
                    pDecalV = (Dimensions.Height - (pNbV * pDistV)) * 0.5;

                    for (int y = 0; y <= pNbV; y++) for (int x = 0; x <= pNbH; x++)
                        {
                            MathPoint pPt = new MathPoint();
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

        public static List<MathVecteur> ListVecteursMatrice(Double Diametre, Double Pas, TypeReseau_e TypeReseau)
        {
            List<MathPoint> pListePoints = new List<MathPoint>();

            int pNbH;
            int pNbV;
            Double pDimH = Diametre;
            Double pDimV = Diametre;
            Double pDecalH;
            Double pDecalV;

            pNbH = (int)Math.Truncate(pDimH / Pas);
            pNbV = (int)Math.Truncate(pDimV / Pas);
            pDecalH = (pDimH - (pNbH * Pas)) * 0.5;
            pDecalV = (pDimV - (pNbV * Pas)) * 0.5;

            MathPoint PtCentre = new MathPoint(pDimH * 0.5, pDimV * 0.5);

            switch (TypeReseau)
            {
                case TypeReseau_e.Carre:
                    for (int y = 0; y <= pNbV; y++) for (int x = 0; x <= pNbH; x++)
                        {
                            MathPoint pPt;
                            pPt.X = pDecalH + (x * Pas);
                            pPt.Y = pDecalV + (y * Pas);
                            pListePoints.Add(pPt);
                        }
                    break;

                case TypeReseau_e.Hexagonal:
                    Double pCoteV = (pDimV / Math.Cos(Math.PI / 12.0));
                    MathPoint Pt1 = new MathPoint(0.0, pCoteV / 4.0);
                    MathPoint Pt2 = new MathPoint(pDimH * 0.5, 0.0);
                    MathPoint Pt3 = new MathPoint(pDimH, pCoteV / 4.0);
                    MathPoint Pt4 = new MathPoint(pDimH, pCoteV * 3.0 / 4.0);
                    MathPoint Pt5 = new MathPoint(pDimH * 0.5, pCoteV);
                    MathPoint Pt6 = new MathPoint(0.0, pCoteV * 3.0 / 4.0);
                    PtCentre.Y = pCoteV * 0.5;

                    for (int y = 0; y <= pNbV; y++) for (int x = 0; x <= pNbH; x++)
                        {
                            MathPoint pPt;
                            pPt.X = pDecalH + (x * Pas);
                            pPt.Y = pDecalV + (y * Pas);

                            Boolean T = true;
                            MathPoint PtTest = pPt;

                            T = T & SensHoraire(Pt1, Pt2, PtTest);
                            T = T & SensHoraire(Pt2, Pt3, PtTest);
                            T = T & SensHoraire(Pt4, Pt5, PtTest);
                            T = T & SensHoraire(Pt5, Pt6, PtTest);

                            if (T)
                                pListePoints.Add(pPt);
                        }
                    break;
            }

            List<MathVecteur> pListeVecteurs = new List<MathVecteur>();

            foreach (MathPoint Pt in pListePoints)
            {
                MathVecteur pV = new MathVecteur(PtCentre, Pt);
                pListeVecteurs.Add(pV);
            }

            return pListeVecteurs;
        }

        private static void Rotation90(MathPoint Centre, ref MathPoint Pt)
        {
            Pt.X -= Centre.X;
            Pt.Y -= Centre.Y;
            Double X = Pt.X;
            Double Y = Pt.Y;
            Pt.X = (-1 * Y) + Centre.X;
            Pt.Y = X + Centre.Y;
        }

        private static void Symetrique(MathPoint Centre, ref MathPoint Pt, Boolean Verticale = true)
        {
            if (Verticale)
                Pt.X = Centre.X + (Centre.X - Pt.X);
            else
                Pt.Y = Centre.Y + (Centre.Y - Pt.Y);
        }

        private static Boolean SensHoraire(MathPoint Dep, MathPoint Arr, MathPoint Pt)
        {
            Boolean T = false;

            Double A = (Arr.X - Dep.X) * (Pt.Y - Dep.Y);
            Double B = (Arr.Y - Dep.Y) * (Pt.X - Dep.X);

            if (A > B)
                T = true;

            return T;
        }

    }
}
