using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NsPlages;
using NsEditerImage;
using System.Diagnostics;
using NsReseau;

namespace PoinconnerImage
{
    public partial class Formulaire : Form
    {
        private Bitmap pImage;
        private Poinconneuse Poinconner = new Poinconneuse();
        private NameValueCollection Data = new NameValueCollection();
        private Plages _SepLuminosite;
        private Plages _SepRouge;
        private Plages _SepVert;
        private Plages _SepBleu;
        private EditerImage _Editeur;
        private Boolean _VisualiserPoincons = false;

        public Formulaire()
        {
            InitializeComponent();
        }

        private void Formulaire_Load(object sender, EventArgs e)
        {
            TypeCarroyage.SetSelected(0, true);
            Lancer.Enabled = false;
            Jeu.Text = "2";
            _SepLuminosite = new Plages(BoxLuminosite, 1);
            _SepRouge = new Plages(BoxRouge, 255);
            _SepVert = new Plages(BoxVert, 255);
            _SepBleu = new Plages(BoxBleu, 255);
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
                _SepRouge.Intitules(pListe);
                _SepVert.Supprimer();
                _SepVert.Intitules(pListe);
                _SepBleu.Supprimer();
                _SepBleu.Intitules(pListe);
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

            _SepLuminosite.Intitules(pListePoincons);

        }

        private void VisualiserPoincons_Click(object sender, EventArgs e)
        {
            VignetteImage.Refresh();

            Size DimTole = new Size(Convert.ToInt32(LargeurImage.Text), Convert.ToInt32(HauteurImage.Text));
            int pDecalX = (int)Math.Truncate((VignetteImage.Width - _Editeur.Image.Size.Width) * 0.5);
            int pDecalY = (int)Math.Truncate((VignetteImage.Height - _Editeur.Image.Size.Height) * 0.5);

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

            Double MmParPx = DimTole.Width / Convert.ToDouble(_Editeur.Image.Size.Width);
            Double PxParMm = 1.0 / MmParPx;

            Graphics pGraph = VignetteImage.CreateGraphics();

            foreach (Poincon pPc in _Editeur.ListePoincons(_SepLuminosite.ListePlages(), Convert.ToDouble(Jeu.Text), DimTole, TypeReseau))
            {
                int pX = (int)Math.Truncate(pDecalX + pPc.Point.X * PxParMm - pPc.Diametre * 0.5 * PxParMm);
                int pY = (int)Math.Truncate(pDecalY + pPc.Point.Y * PxParMm - pPc.Diametre * 0.5 * PxParMm);
                pGraph.FillEllipse(Brushes.Black, pX, pY, (int)Math.Truncate(pPc.Diametre * PxParMm), (int)Math.Truncate(pPc.Diametre * PxParMm));
            }

            pGraph.Dispose();

            _VisualiserPoincons = true;

        }
        private void VisualiserNoirEtBlanc_Click(object sender, EventArgs e)
        {
            Bitmap pBitmap = new Bitmap(_Editeur.Image);
            EditerImage pEditeur = new EditerImage((Image)pBitmap);

            List<Plage> pListePlages = _SepLuminosite.ListePlages();



            //Color C = _Editeur.GetPixel((int)Math.Truncate(PtTmp.X * PxParMm), (int)Math.Truncate(PtTmp.Y * PxParMm));
        }


        private void Reinitialiser_Click(object sender, EventArgs e)
        {
            VignetteImage.Refresh();
            _VisualiserPoincons = false;
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

        private void AfficherVignette_CheckedChanged(object sender, EventArgs e)
        {
            GestionAffichageVignette();
        }

        private void MasquerVignette_CheckedChanged(object sender, EventArgs e)
        {
            GestionAffichageVignette();
        }

        private void GestionAffichageVignette()
        {
            if (AfficherVignette.Checked == true)
            {
                VignetteImage.Image = _Editeur.Image;
            }
            else
            {
                VignetteImage.Image = null;
            }

            if (_VisualiserPoincons)
                VisualiserPoincons_Click(null, null);
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
