using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

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
                    pNbH = Convert.ToInt32(Dimensions.Width / Diametre);
                    pNbV = Convert.ToInt32(Dimensions.Height / Diametre);
                    pDecalH = ((Dimensions.Width - (pNbH * Diametre)) * 0.5) + (Diametre * 0.5);
                    pDecalV = ((Dimensions.Height - (pNbV * Diametre)) * 0.5) + (Diametre * 0.5);

                    for (int y = 0; y < pNbH; y++) for (int x = 0; x < pNbV; x++)
                        {
                            Point pPt;
                            pPt.X = pDecalH + (x * pDimH);
                            pPt.Y = pDecalV + (y * pDimV);
                            pListePoints.Add(pPt);
                        }

                    break;

                case TypeReseau_e.Hexagonal:
                    pDimV = (Diametre / Math.Cos(Math.PI / 12.0));
                    pNbH = Convert.ToInt32(Dimensions.Width / Diametre);
                    pNbV = Convert.ToInt32(Dimensions.Height / pDimV);
                    pDecalH = ((Dimensions.Width - (pNbH * Diametre)) * 0.5) + (Diametre * 0.5);
                    pDecalV = ((Dimensions.Height - (pNbV * pDimV)) * 0.5) + (pDimV * 0.5);
                    Vecteur pVecteur;
                    pVecteur.X = (pDimH * 0.5);
                    pVecteur.Y = (pDimV * 3.0 / 4.0);

                    for (int y = 0; y < pNbV; y++) for (int x = 0; x < pNbH; x++)
                        {
                            Point pPt;
                            pPt.X = pDecalH + (x * pDimH);
                            pPt.Y = pDecalV + (y * pDimV);
                            pListePoints.Add(pPt);
                            if (x < (pNbH - 1))
                            {
                                Point pPtI = pPt;
                                pPtI.Deplacer(pVecteur);
                                pListePoints.Add(pPtI);
                            }
                            
                        }

                    break;
            }

            return pListePoints;
        }

    }
}
