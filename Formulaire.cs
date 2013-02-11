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
        private Separateurs _Sep;
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
            _Sep = new Separateurs(BoxHistogram, 1);
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
                _Editeur.Redimensionner(VignetteImage.Size);

                VignetteImage.Image = _Editeur.Image;

                BoxHistogram.Image = (Image)_Editeur.Histogramme(BoxHistogram.Size, Canal_e.Luminosite);

                _Sep.Supprimer();
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

            _Sep.Diametres(pListePoincons);

        }

        private void VisualiserZones_Click(object sender, EventArgs e)
        {
            VignetteImage.Refresh();

            Double DiamMax = 0;
            foreach (String S in ListePoincons.Text.Split(' '))
            {
                if ((!String.IsNullOrEmpty(S)) && (Convert.ToDouble(S) > DiamMax))
                {
                    DiamMax = Convert.ToDouble(S);
                }

            }

            int pLgImage = Convert.ToInt32(LargeurImage.Text);
            int pHtImage = Convert.ToInt32(HauteurImage.Text);
            int pLgBmp = VignetteImage.Image.Size.Width;
            int pHtBmp = VignetteImage.Image.Size.Height;
            int pDecalX = Convert.ToInt32((VignetteImage.Width - pLgBmp) * 0.5);
            int pDecalY = Convert.ToInt32((VignetteImage.Height - pHtBmp) * 0.5);

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


            Size pDimTole = new System.Drawing.Size(pLgImage, pHtImage);
            List<Point> pListePointsReseau = Reseau.ListePointsReseau(pDimTole, DiamMax, TypeReseau);
            List<Vecteur> pListePointsMatrice = Reseau.ListVecteursMatrice(DiamMax, pLgImage / Convert.ToDouble(pLgBmp), TypeReseau);

            Graphics pGraph = VignetteImage.CreateGraphics();

            foreach (Point Pt in pListePointsReseau)
            {

                int pX = Convert.ToInt32(pDecalX + Pt.X * pLgBmp / pLgImage);
                int pY = Convert.ToInt32(pDecalY + Pt.Y * pHtBmp / pHtImage);

                pGraph.FillRectangle(Brushes.Black, pX, pY, 1, 1);
            }

            pGraph.Dispose();

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
