using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Collections.Generic;

namespace PoinconnerImage
{
    public partial class Formulaire : Form
    {
        private Bitmap pImage;
        private Poinconneuse Poinconner = new Poinconneuse();
        private NameValueCollection Data = new NameValueCollection();
        private Separateurs _Sep;
        private Histogramme _Histogramme;

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

                VignetteImage.Image = EditionImage.RedimensionnerImage(pImage, VignetteImage.Size);

                _Histogramme = new Histogramme(BoxHistogram, VignetteImage.Image);

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
            List<String> pListeDiams = new List<String>();
            foreach (String S in ListePoincons.Text.Split(' '))
            {
                if (!String.IsNullOrEmpty(S))
                    pListeDiams.Add(S);
            }

            List<Texte> pListeTexte = _Sep.ListeTextes;

            for (int i = 0; i < Math.Min(pListeDiams.Count, pListeTexte.Count); i++)
            {
                pListeTexte[i].Nom = pListeDiams[i];
            }

            if (pListeDiams.Count > pListeTexte.Count)
            {
                Separateur SepG;

                int Div;

                if (pListeTexte.Count == 0)
                    SepG = _Sep.AjouterSeparateur(0, 2);
                else
                    SepG = pListeTexte[pListeTexte.Count - 1].Droite;

                if ((BoxHistogram.Width - SepG.X) < 10)
                {
                    Separateur SepTmp = pListeTexte[pListeTexte.Count - 1].Gauche;
                    Div = (BoxHistogram.Width - 5 - SepTmp.X) / (1 + pListeDiams.Count - pListeTexte.Count);
                    SepG.X = SepTmp.X + Div;
                }
                else
                    Div = (BoxHistogram.Width - 5 - SepG.X) / (pListeDiams.Count - pListeTexte.Count);

                for (int i = pListeTexte.Count; i < pListeDiams.Count; i++)
                {
                    Separateur SepD = _Sep.AjouterSeparateur(SepG.No + 1, SepG.X + Div);
                    _Sep.AjouterTexte(pListeDiams[i], SepG, SepD);
                    SepG = SepD;
                }
            }
            else if (pListeDiams.Count < pListeTexte.Count)
            {
                if (pListeDiams.Count == 0)
                    _Sep.Supprimer();
                else
                    for (int i = (pListeTexte.Count - 1); i >= pListeDiams.Count; i--)
                    {
                        Texte Txt = pListeTexte[i];
                        _Sep.SupprimerSeparateur(Txt.Droite);
                        _Sep.SupprimerTexte(Txt);
                    }
            }

        }

        private void VisualiserZones_Click(object sender, EventArgs e)
        {

            if (_Sep.ListeTextes.Count > 0)
            {
            }

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
