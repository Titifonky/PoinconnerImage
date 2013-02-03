using System;
using System.Collections.Specialized;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Collections.Generic;

namespace PoinconnerImage
{
    public class Poinconneuse
    {
        private String pCheminFichierImage;
        private String pCheminDossierExport;
        private List<Double> pListePoincons;
        private Int32 pLg;
        private Int32 pHt;
        private String TypeCarroyage;
        private Bitmap pImageSource;
        private BitmapData pImageSourceData;
        private Boolean pOptimiser;

        public Poinconneuse()
        {
        }

        public void Go(NameValueCollection Data)
        {
            try
            {
                pCheminFichierImage = Data["CheminFichierImage"];
                pCheminDossierExport = Data["CheminDossierExport"];
                
                pListePoincons = new List<double>();
                foreach (String S in Data["ListePoincons"].Split(' '))
                {
                    pListePoincons.Add(Convert.ToDouble(S));
                }
                pListePoincons.Sort();

                Debug.WriteLine(pListePoincons[0]);

                pLg = Convert.ToInt32(Data["LargeurImage"]);
                pHt = Convert.ToInt32(Data["HauteurImage"]);
                TypeCarroyage = Data["TypeCarroyage"];

                pImageSource = new Bitmap(pCheminFichierImage);
                pOptimiser = false;

                ConvertirEnDxf();
            }
            catch
            {
                Debug.WriteLine("Erreur");
            }
        }

        private void ConvertirEnDxf()
        {

            if (pImageSource.PixelFormat == PixelFormat.Format32bppArgb || pImageSource.PixelFormat == PixelFormat.Format24bppRgb)
            {
                pOptimiser = true;
                pImageSourceData = pImageSource.LockBits(
                        new Rectangle(0, 0, pImageSource.Width, pImageSource.Height),
                        ImageLockMode.ReadOnly,
                        pImageSource.PixelFormat
                        );
            }





            if (pOptimiser) pImageSource.UnlockBits(pImageSourceData);
        }

        private unsafe Color GetPixel(int x, int y)
        {
            byte* bp = (byte*)pImageSourceData.Scan0;
            switch (pImageSourceData.PixelFormat)
            {
                case PixelFormat.Format32bppArgb:
                    bp += (x * 4) + (y * pImageSourceData.Stride);
                    return Color.FromArgb(*(bp + 3), *(bp + 2), *(bp + 1), *bp);
                case PixelFormat.Format24bppRgb:
                    bp += (x * 3) + (y * pImageSourceData.Stride);
                    return Color.FromArgb(*(bp + 2), *(bp + 1), *bp);
            }
            return Color.Empty;
        }
    }
}
