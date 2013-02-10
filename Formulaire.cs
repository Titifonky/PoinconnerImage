using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NsSeparateurs;
using NsEditerImage;

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
