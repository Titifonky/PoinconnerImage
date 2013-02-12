using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NsSeparateurs;
using NsEditerImage;
using System.Diagnostics;

namespace PoinconnerImage
{
    public partial class Formulaire : Form
    {
        private Bitmap pImage;
        private Poinconneuse Poinconner = new Poinconneuse();
        private NameValueCollection Data = new NameValueCollection();
        private Separateurs _SepLuminosite;
        private Separateurs _SepRouge;
        private Separateurs _SepVert;
        private Separateurs _SepBleu;
        private EditerImage _Editeur;

        public Formulaire()
        {
            InitializeComponent();
        }

        private void Formulaire_Load(object sender, EventArgs e)
        {
            TypeCarroyage.SetSelected(0, true);
            Lancer.Enabled = false;
            Jeu.Text = "2";
            _SepLuminosite = new Separateurs(BoxLuminosite, 1);
            _SepRouge = new Separateurs(BoxRouge, 255);
            _SepVert = new Separateurs(BoxVert, 255);
            _SepBleu = new Separateurs(BoxBleu, 255);
        }

        private void Formulaire_FormClosing(object sender, FormClosingEventArgs e)
        {
            pImage = null;
            Poinconner = null;
            Data = null;
            this.Dispose(true);
        }

        private void ChercherImage_Click(object sender, EventArgs e)
        {
            if (OuvrirFichierImage.ShowDialog() == DialogResult.OK)
            {
                CheminImage.Text = OuvrirFichierImage.FileName;
            }
        }

        private void CheminImage_TextChanged(object sender, EventArgs e)
        {
            if (File.Exists(CheminImage.Text))
            {
                pImage = new Bitmap(CheminImage.Text);

                _Editeur = new EditerImage(pImage);

                if ((pImage.Width > VignetteImage.Width) || (pImage.Height > VignetteImage.Height))
                    _Editeur.Redimensionner(VignetteImage.Size);

                VignetteImage.Image = _Editeur.Image;

                Size pSize = BoxLuminosite.Size;
                pSize.Width -= 20;

                _SepLuminosite.LgHistogramme = pSize.Width;
                _SepRouge.LgHistogramme = pSize.Width;
                _SepVert.LgHistogramme = pSize.Width;
                _SepBleu.LgHistogramme = pSize.Width;

                BoxLuminosite.Image = (Image)_Editeur.Histogramme(pSize, Canal_e.Luminosite);
                BoxRouge.Image = (Image)_Editeur.Histogramme(pSize, Canal_e.Rouge);
                BoxVert.Image = (Image)_Editeur.Histogramme(pSize, Canal_e.Vert);
                BoxBleu.Image = (Image)_Editeur.Histogramme(pSize, Canal_e.Bleu);

                List<string> pListe = new List<string>();
                pListe.Add(" ");

                _SepLuminosite.Supprimer();
                _SepRouge.Supprimer();
                _SepRouge.Diametres(pListe);
                _SepVert.Supprimer();
                _SepVert.Diametres(pListe);
                _SepBleu.Supprimer();
                _SepBleu.Diametres(pListe);
            }

            Valider();
        }

        private void ChercherDXF_Click(object sender, EventArgs e)
        {
            if (OuvrirDossierExport.ShowDialog() == DialogResult.OK)
            {
                CheminDossier.Text = OuvrirDossierExport.SelectedPath;
            }
        }

        private void CheminDossier_TextChanged(object sender, EventArgs e)
        {

            if (!Directory.Exists(CheminDossier.Text))
            {
                CheminDossier.Text = "";
            }

            Valider();
        }

        private void ListePoincons_TextChanged(object sender, EventArgs e)
        {
            if (!ContientQueDesChiffres(ListePoincons.Text))
                ListePoincons.Text = "";

            Valider();
        }


        private void ValiderPoincon_Click(object sender, EventArgs e)
        {
            List<String> pListePoincons = new List<String>();
            foreach (String S in ListePoincons.Text.Split(' '))
            {
                if (!String.IsNullOrEmpty(S))
                    pListePoincons.Add(S);
            }

            _SepLuminosite.Diametres(pListePoincons);

        }

        private void VisualiserZones_Click(object sender, EventArgs e)
        {
            VignetteImage.Refresh();

            Double DiamMax = 0;
            foreach (String S in ListePoincons.Text.Split(' '))
            {
                if (!String.IsNullOrEmpty(S))
                {
                    if (Convert.ToDouble(S) > DiamMax)
                        DiamMax = Convert.ToDouble(S);
                }

            }

            DiamMax += Convert.ToDouble(Jeu.Text);

            int pLgImage = Convert.ToInt32(LargeurImage.Text);
            int pHtImage = Convert.ToInt32(HauteurImage.Text);
            int pLgBmp = VignetteImage.Image.Size.Width;
            int pHtBmp = VignetteImage.Image.Size.Height;
            int pDecalX = (int)Math.Truncate((VignetteImage.Width - pLgBmp) * 0.5);
            int pDecalY = (int)Math.Truncate((VignetteImage.Height - pHtBmp) * 0.5);

            TypeReseau_e TypeReseau = TypeReseau_e.Carre;

            switch ((String)TypeCarroyage.SelectedItem)
            {
                case "Carré":
                    TypeReseau = TypeReseau_e.Carre;
                    break;
                case "Hexagonal":
                    TypeReseau = TypeReseau_e.Hexagonal;
                    break;
            }

            Double MmParPx = pLgImage / Convert.ToDouble(pLgBmp);
            Double PxParMm = Convert.ToDouble(pLgBmp) / pLgImage;

            Size pDimTole = new System.Drawing.Size(pLgImage, pHtImage);
            List<Point> pListePointsReseau = Reseau.ListePointsReseau(pDimTole, DiamMax, TypeReseau);
            List<Vecteur> pListePointsMatrice = Reseau.ListVecteursMatrice(DiamMax, MmParPx, TypeReseau);
            List<Poincon> pListePoincons = _SepLuminosite.Poincons();

            Graphics pGraph = VignetteImage.CreateGraphics();

            _Editeur.Verrouiller();

            foreach (Point Pt in pListePointsReseau)
            {
                float Val = 0;

                foreach (Vecteur V in pListePointsMatrice)
                {
                    Point PtTmp = Pt;
                    PtTmp.Deplacer(V);
                    Color C = _Editeur.GetPixel((int)Math.Truncate(PtTmp.X * PxParMm), (int)Math.Truncate(PtTmp.Y * PxParMm));
                    Val += C.GetBrightness();
                }

                Val /= pListePointsMatrice.Count;

                Double Diam = 0;

                foreach (Poincon Pc in pListePoincons)
                {
                    if ((Val > Pc.Min) && (Val <= Pc.Max))
                    {
                        Diam = Pc.Diametre;
                        break;
                    }
                }

                int pX = (int)Math.Truncate(pDecalX + Pt.X * PxParMm - Diam * 0.5 * PxParMm);
                int pY = (int)Math.Truncate(pDecalY + Pt.Y * PxParMm - Diam * 0.5 * PxParMm);

                pGraph.FillEllipse(Brushes.Black, pX, pY, (int)Math.Truncate(Diam * PxParMm), (int)Math.Truncate(Diam * PxParMm));
            }

            _Editeur.Liberer();

            pGraph.Dispose();

        }
        private void VisualiserNoirEtBlanc_Click(object sender, EventArgs e)
        {
            EditerImage pEditeur = new EditerImage(_Editeur.Image);



            //Color C = _Editeur.GetPixel((int)Math.Truncate(PtTmp.X * PxParMm), (int)Math.Truncate(PtTmp.Y * PxParMm));
        }


        private void Reinitialiser_Click(object sender, EventArgs e)
        {
            VignetteImage.Refresh();
        }

        private void Jeu_TextChanged(object sender, EventArgs e)
        {
            Double Nb;
            if (!Double.TryParse(Jeu.Text, out Nb))
            {
                Jeu.Text = "";
            }

            Valider();
        }

        private void LargeurImage_TextChanged(object sender, EventArgs e)
        {
            if (LargeurImage.Focused)
            {
                Int32 Nb;
                if (Int32.TryParse(LargeurImage.Text, out Nb) && (pImage != null))
                {
                    HauteurImage.Text = Convert.ToString((int)(Nb * pImage.Height / pImage.Width));
                }
                else
                    LargeurImage.Text = "";
            }

            Valider();
        }

        private void HauteurImage_TextChanged(object sender, EventArgs e)
        {
            if (HauteurImage.Focused)
            {
                Int32 Nb;
                if (Int32.TryParse(HauteurImage.Text, out Nb) && (pImage != null))
                {
                    LargeurImage.Text = Convert.ToString((int)(Nb * pImage.Width / pImage.Height));
                }
                else
                    HauteurImage.Text = "";
            }

            Valider();
        }

        private void TypeCarroyage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Valider();
        }

        private void Valider()
        {
            Boolean T = true;

            if (
                String.IsNullOrEmpty(CheminImage.Text) ||
                String.IsNullOrEmpty(CheminDossier.Text) ||
                String.IsNullOrEmpty(ListePoincons.Text) ||
                String.IsNullOrEmpty(Jeu.Text) ||
                String.IsNullOrEmpty(LargeurImage.Text) ||
                String.IsNullOrEmpty(HauteurImage.Text)
                )
                T = false;

            Lancer.Enabled = T;
        }

        private void Lancer_Click(object sender, EventArgs e)
        {
            Lancer.Enabled = false;
            Data.Clear();
            Data.Add("CheminFichierImage", CheminImage.Text);
            Data.Add("CheminDossierExport", CheminDossier.Text);
            Data.Add("Jeu", Jeu.Text);
            Data.Add("ListePoincons", ListePoincons.Text);
            Data.Add("LargeurImage", LargeurImage.Text);
            Data.Add("HauteurImage", HauteurImage.Text);
            Data.Add("TypeCarroyage", (String)TypeCarroyage.SelectedItem);

            Poinconner.Go(Data);

            Lancer.Enabled = true;
        }



        private bool ContientQueDesChiffres(string S)
        {
            bool Test = true;
            foreach (char C in S)
            {
                if ((char.IsDigit(C) == false) && (C != '.') && (C != ',') && (C != ' '))
                {
                    Test = false;
                }
            }

            return Test;
        }

        

    }
}
