using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DXFLibrary;
using NsEditerImage;
using NsPlages;
using NsReseau;

namespace PoinconnerImage
{
    public partial class Formulaire : Form
    {
        private Plages _SepLuminosite;
        private EditerImage _Editeur;
        private Image _ImagePoincons;
        private Boolean _NoirEtBlanc = false;

        public Formulaire()
        {
            InitializeComponent();
        }

        private void Formulaire_Load(object sender, EventArgs e)
        {
            Lancer.Enabled = false;
            Jeu.Text = "2";
            TypeCarroyage.SelectedIndex = 1;

            Rouge.Text = "0.2126";
            Vert.Text = "0.7152";
            Bleu.Text = "0.0722";

            Somme.Text = "1";

            // Pour gerer la transparence de l'aperçu des poincons, on met VignettePoincons dans VignetteImage,
            // comme ca, les poincons sont au dessus.
            VignettePoincons.Parent = VignetteImage;
            // Et on repositionne par rapport au parent
            VignettePoincons.Location = new Point(0, 0);

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
                _Editeur = new EditerImage(CheminImage.Text);

                if ((_Editeur.Image.Width > VignetteImage.Width) || (_Editeur.Image.Height > VignetteImage.Height))
                    _Editeur.Redimensionner(VignetteImage.Size);

                VignetteImage.Image = _Editeur.Image;
                VignettePoincons.Image = null;

                HauteurImage.Text = "";
                LargeurImage.Text = "";

                if (_SepLuminosite == null)
                    _SepLuminosite = new Plages(BoxLuminosite, _Editeur.PlageCouleur);
                else
                    _SepLuminosite.Supprimer();

                MettreAJourHistogramme();
            }

            ValiderDXF();
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

            ValiderDXF();
        }

        private void ListePoincons_TextChanged(object sender, EventArgs e)
        {
            if (!ContientQueDesChiffres(ListePoincons.Text))
                ListePoincons.Text = "";

            ValiderDXF();
        }

        private void ValiderPoincon_Click(object sender, EventArgs e)
        {
            List<String> pListePoincons = new List<String>();
            foreach (String S in ListePoincons.Text.Split(' '))
            {
                if (!String.IsNullOrEmpty(S))
                    pListePoincons.Add(S);
            }

            if (_SepLuminosite != null)
                _SepLuminosite.Intitules(pListePoincons);

        }

        private void VisualiserPoincons_Click(object sender, EventArgs e)
        {
            VignetteImage.Refresh();

            if (String.IsNullOrWhiteSpace(LargeurImage.Text) || String.IsNullOrWhiteSpace(HauteurImage.Text))
                return;

            Size DimTole = new Size(Convert.ToInt32(LargeurImage.Text), Convert.ToInt32(HauteurImage.Text));
            int pDecalX = (int)Math.Truncate((VignettePoincons.Width - _Editeur.Image.Size.Width) * 0.5);
            int pDecalY = (int)Math.Truncate((VignettePoincons.Height - _Editeur.Image.Size.Height) * 0.5);

            Double MmParPx = DimTole.Width / Convert.ToDouble(_Editeur.Image.Size.Width);
            Double PxParMm = 1.0 / MmParPx;

            _ImagePoincons = new Bitmap(VignettePoincons.Width, VignettePoincons.Height);
            Graphics pGraphic = Graphics.FromImage(_ImagePoincons);

            List<Poincon> pListePoincons = _Editeur.ListePoincons(_SepLuminosite.ListePlages(), Convert.ToDouble(Jeu.Text), DimTole, TypeReseau());

            foreach (Poincon pPc in pListePoincons)
            {
                int pX = (int)Math.Truncate(pDecalX + pPc.Point.X * PxParMm - pPc.Diametre * 0.5 * PxParMm);
                int pY = (int)Math.Truncate(pDecalY + pPc.Point.Y * PxParMm - pPc.Diametre * 0.5 * PxParMm);
                pGraphic.FillEllipse(Brushes.Black, pX, pY, (int)Math.Truncate(pPc.Diametre * PxParMm), (int)Math.Truncate(pPc.Diametre * PxParMm));
            }

            pGraphic.Dispose();

            VignettePoincons.Image = _ImagePoincons;

        }

        private void MasquerPoincons_Click(object sender, EventArgs e)
        {
            VignettePoincons.Image = null;
        }

        private void Jeu_TextChanged(object sender, EventArgs e)
        {
            Double Nb;
            if (!Double.TryParse(Jeu.Text, out Nb))
            {
                Jeu.Text = "0";
            }

            ValiderDXF();
        }

        private void LargeurImage_TextChanged(object sender, EventArgs e)
        {
            if (LargeurImage.Focused)
            {
                Int32 Nb;
                if (Int32.TryParse(LargeurImage.Text, out Nb) && (_Editeur != null))
                {
                    HauteurImage.Text = Convert.ToString((int)(Nb * _Editeur.Image.Height / _Editeur.Image.Width));
                }
                else
                    LargeurImage.Text = "";
            }

            ValiderDXF();
        }

        private void HauteurImage_TextChanged(object sender, EventArgs e)
        {
            if (HauteurImage.Focused)
            {
                Int32 Nb;
                if (Int32.TryParse(HauteurImage.Text, out Nb) && (_Editeur != null))
                {
                    LargeurImage.Text = Convert.ToString((int)(Nb * _Editeur.Image.Width / _Editeur.Image.Height));
                }
                else
                    HauteurImage.Text = "";
            }

            ValiderDXF();
        }

        private void TypeCarroyage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValiderDXF();
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
            if ((AfficherVignette.Checked == true) && (_Editeur != null))
            {
                VignetteImage.Image = _Editeur.Image;
            }
            else
            {
                VignetteImage.Image = null;
            }
        }

        private void Lancer_Click(object sender, EventArgs e)
        {
            EditerImage pEditeur = new EditerImage(CheminImage.Text);

            Lancer.Enabled = false;

            Size DimTole = new Size(Convert.ToInt32(LargeurImage.Text), Convert.ToInt32(HauteurImage.Text));

            pEditeur.Redimensionner(DimTole);

            if (_NoirEtBlanc)
                pEditeur.NoirEtBlanc();

            List<Poincon> pListePoincons = pEditeur.ListePoincons(_SepLuminosite.ListePlages(), Convert.ToDouble(Jeu.Text), DimTole, TypeReseau());

            Document DocumentDXF = new Document();

            Tables Tables = new Tables();
            DocumentDXF.SetTables(Tables);

            Table Calques = new Table("LAYER");
            Tables.addTable(Calques);

            foreach (Poincon pPc in pListePoincons)
            {
                Circle Cercle = new Circle(pPc.Point.X, pPc.Point.Y * -1, pPc.Diametre * 0.5, "0");
                DocumentDXF.add(Cercle);
            }


            int No = 1;

            String pCheminDeBaseFichierDXF = CheminDossier.Text + "\\" + Path.GetFileNameWithoutExtension(CheminImage.Text) + "_";
            String pCheminFichierDXF = pCheminDeBaseFichierDXF + No + ".dxf";

            while (File.Exists(pCheminFichierDXF))
            {
                No++;
                pCheminFichierDXF = pCheminDeBaseFichierDXF + No + ".dxf";
            }

            FileStream Fichier = new FileStream(pCheminFichierDXF, System.IO.FileMode.Create);
            Writer.Write(DocumentDXF, Fichier);
            Fichier.Close();

            Lancer.Enabled = true;
        }

        private void NoirEtBlanc_Click(object sender, EventArgs e)
        {
            if (_Editeur != null)
            {
                _Editeur.NoirEtBlanc(Convert.ToSingle(Rouge.Text), Convert.ToSingle(Vert.Text), Convert.ToSingle(Bleu.Text));
                VignetteImage.Refresh();
                MettreAJourHistogramme();
                _NoirEtBlanc = true;
            }
        }

        private void Rouge_TextChanged(object sender, EventArgs e)
        {
            Double Nb;

            Rouge.Text = Rouge.Text.Replace('.', ',');

            if (!Double.TryParse(Rouge.Text, out Nb))
            {
                Rouge.Text = "0";
            }

            SommeNoirEtBlanc();
        }

        private void Vert_TextChanged(object sender, EventArgs e)
        {
            Double Nb;

            Vert.Text = Vert.Text.Replace('.', ',');

            if (!Double.TryParse(Vert.Text, out Nb))
            {
                Vert.Text = "0";
            }

            SommeNoirEtBlanc();
        }

        private void Bleu_TextChanged(object sender, EventArgs e)
        {
            Double Nb;

            Bleu.Text = Bleu.Text.Replace('.', ',');

            if (!Double.TryParse(Bleu.Text, out Nb))
            {
                Bleu.Text = "0";
            }

            SommeNoirEtBlanc();
        }

        private void RestaurerCouleur_Click(object sender, EventArgs e)
        {
            if (_Editeur != null)
            {
                _Editeur.ReinitialiserImage();
                VignetteImage.Image = _Editeur.Image;
                VignetteImage.Refresh();
                MettreAJourHistogramme();
                _NoirEtBlanc = false;
            }
        }

        private Image ConvertirHistogrammeEnImage(int[] Histogramme, Size Dim)
        {
            int pMax = 1;
            for (int i = 0; i < Histogramme.Length; i++)
            {
                if (Histogramme[i] > pMax)
                    pMax = Histogramme[i];
            }

            int pBoxWidth = Dim.Width;
            int pBoxHeight = Dim.Height;

            Point[] Points = new Point[Histogramme.Length + 1];
            Points[0].X = 0;
            Points[0].Y = pBoxHeight;

            for (int i = 0; i < Histogramme.Length; i++)
            {
                Points[i + 1].X = Convert.ToInt32((i * (pBoxWidth - 2) / Histogramme.Length) + 1);
                Points[i + 1].Y = Convert.ToInt32((pBoxHeight - 1) - ((Convert.ToDouble(Histogramme[Histogramme.GetUpperBound(0) - i]) * (pBoxHeight - 5)) / pMax));
            }

            Points[Histogramme.Length].X = pBoxWidth - 1;
            Points[Histogramme.Length].Y = pBoxHeight;

            Bitmap Image_Histogram = new Bitmap(pBoxWidth, pBoxHeight);


            Graphics Graphic_Histogram = Graphics.FromImage(Image_Histogram);
            Pen Pen = new Pen(Color.Black);
            Pen.Brush = new SolidBrush(Color.Black);
            Graphic_Histogram.FillPolygon(Pen.Brush, Points);
            Graphic_Histogram.Dispose();

            return (Image)Image_Histogram;
        }

        private void MettreAJourHistogramme()
        {
            Size pSize = BoxLuminosite.Size;
            pSize.Width -= 20;
            _SepLuminosite.LgHistogramme = pSize.Width;
            Image pImage = ConvertirHistogrammeEnImage(_Editeur.Histogramme(Canal_e.Luminosite), pSize);
            BoxLuminosite.Image = ConvertirHistogrammeEnImage(_Editeur.Histogramme(Canal_e.Luminosite), pSize);
        }

        private void ValiderDXF()
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

        private TypeReseau_e TypeReseau()
        {
            TypeReseau_e pTypeReseau = TypeReseau_e.Carre;

            switch ((String)TypeCarroyage.SelectedItem)
            {
                case "Carré":
                    pTypeReseau = TypeReseau_e.Carre;
                    break;
                case "Hexagonal":
                    pTypeReseau = TypeReseau_e.Hexagonal;
                    break;
            }

            return pTypeReseau;
        }

        private void SommeNoirEtBlanc()
        {
            Double R = 0; Double V = 0; Double B = 0;

            if (!String.IsNullOrWhiteSpace(Rouge.Text))
                R = Convert.ToDouble(Rouge.Text);

            if (!String.IsNullOrWhiteSpace(Vert.Text))
                V = Convert.ToDouble(Vert.Text);

            if (!String.IsNullOrWhiteSpace(Bleu.Text))
                B = Convert.ToDouble(Bleu.Text);

            Somme.Text = Convert.ToString(R + V + B);

        }

    }
}
