namespace PoinconnerImage
{
    partial class Formulaire
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Formulaire));
            this.OuvrirFichierImage = new System.Windows.Forms.OpenFileDialog();
            this.CheminImage = new System.Windows.Forms.TextBox();
            this.ChercherImage = new System.Windows.Forms.Button();
            this.CheminDossier = new System.Windows.Forms.TextBox();
            this.ChercherDXF = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.OuvrirDossierExport = new System.Windows.Forms.FolderBrowserDialog();
            this.Lancer = new System.Windows.Forms.Button();
            this.VignetteImage = new System.Windows.Forms.PictureBox();
            this.VignettePoincons = new System.Windows.Forms.PictureBox();
            this.ControleVignette = new System.Windows.Forms.GroupBox();
            this.MasquerVignette = new System.Windows.Forms.RadioButton();
            this.AfficherVignette = new System.Windows.Forms.RadioButton();
            this.Onglets = new System.Windows.Forms.TabControl();
            this.Fichier = new System.Windows.Forms.TabPage();
            this.label16 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.LargeurImage = new System.Windows.Forms.TextBox();
            this.HauteurImage = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.Poincons = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.BoxLuminosite = new System.Windows.Forms.PictureBox();
            this.Blanc = new System.Windows.Forms.PictureBox();
            this.Noir = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ValiderPoincon = new System.Windows.Forms.Button();
            this.ListePoincons = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TypeCarroyage = new System.Windows.Forms.ListBox();
            this.VisualiserPoincons = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Jeu = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LienWikipedia = new System.Windows.Forms.LinkLabel();
            this.label20 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Bleu = new System.Windows.Forms.TextBox();
            this.Rouge = new System.Windows.Forms.TextBox();
            this.Vert = new System.Windows.Forms.TextBox();
            this.Somme = new System.Windows.Forms.Label();
            this.ConvertirNoirEtBlanc = new System.Windows.Forms.Button();
            this.RestaurerCouleur = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.NbPoincons = new System.Windows.Forms.Label();
            this.Valeurs = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.VignetteImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.VignettePoincons)).BeginInit();
            this.ControleVignette.SuspendLayout();
            this.Onglets.SuspendLayout();
            this.Fichier.SuspendLayout();
            this.Poincons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoxLuminosite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blanc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Noir)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OuvrirFichierImage
            // 
            this.OuvrirFichierImage.Filter = "Fichier image (*.jpg, *.png, *.gif, *.tif, *.bmp)|*.jpg;*.gif;*.png;*.tif;*.tiff;" +
    "*.jpeg;*.bmp|Tout les fichiers (*.*)|*.*";
            // 
            // CheminImage
            // 
            this.CheminImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheminImage.Location = new System.Drawing.Point(12, 27);
            this.CheminImage.Margin = new System.Windows.Forms.Padding(4);
            this.CheminImage.Name = "CheminImage";
            this.CheminImage.Size = new System.Drawing.Size(810, 22);
            this.CheminImage.TabIndex = 2;
            this.CheminImage.TextChanged += new System.EventHandler(this.CheminImage_TextChanged);
            // 
            // ChercherImage
            // 
            this.ChercherImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChercherImage.Location = new System.Drawing.Point(12, 62);
            this.ChercherImage.Margin = new System.Windows.Forms.Padding(4);
            this.ChercherImage.Name = "ChercherImage";
            this.ChercherImage.Size = new System.Drawing.Size(100, 28);
            this.ChercherImage.TabIndex = 3;
            this.ChercherImage.Text = "Parcourir";
            this.ChercherImage.UseVisualStyleBackColor = true;
            this.ChercherImage.Click += new System.EventHandler(this.ChercherImage_Click);
            // 
            // CheminDossier
            // 
            this.CheminDossier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheminDossier.Location = new System.Drawing.Point(12, 298);
            this.CheminDossier.Margin = new System.Windows.Forms.Padding(4);
            this.CheminDossier.Name = "CheminDossier";
            this.CheminDossier.Size = new System.Drawing.Size(810, 22);
            this.CheminDossier.TabIndex = 5;
            this.CheminDossier.TextChanged += new System.EventHandler(this.CheminDossier_TextChanged);
            // 
            // ChercherDXF
            // 
            this.ChercherDXF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChercherDXF.Location = new System.Drawing.Point(12, 332);
            this.ChercherDXF.Margin = new System.Windows.Forms.Padding(4);
            this.ChercherDXF.Name = "ChercherDXF";
            this.ChercherDXF.Size = new System.Drawing.Size(100, 28);
            this.ChercherDXF.TabIndex = 6;
            this.ChercherDXF.Text = "Parcourir";
            this.ChercherDXF.UseVisualStyleBackColor = true;
            this.ChercherDXF.Click += new System.EventHandler(this.ChercherDXF_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 4);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(270, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "1. Sélectionnez l\'image à poinçonner :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 274);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(254, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "3. Sélectionnez le dossier d\'export :";
            // 
            // Lancer
            // 
            this.Lancer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lancer.Location = new System.Drawing.Point(16, 862);
            this.Lancer.Margin = new System.Windows.Forms.Padding(4);
            this.Lancer.Name = "Lancer";
            this.Lancer.Size = new System.Drawing.Size(349, 53);
            this.Lancer.TabIndex = 13;
            this.Lancer.Text = "6. Convertir en DXF";
            this.Lancer.UseVisualStyleBackColor = true;
            this.Lancer.Click += new System.EventHandler(this.Lancer_Click);
            // 
            // VignetteImage
            // 
            this.VignetteImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VignetteImage.Location = new System.Drawing.Point(16, 15);
            this.VignetteImage.Margin = new System.Windows.Forms.Padding(4);
            this.VignetteImage.Name = "VignetteImage";
            this.VignetteImage.Size = new System.Drawing.Size(649, 747);
            this.VignetteImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.VignetteImage.TabIndex = 37;
            this.VignetteImage.TabStop = false;
            // 
            // VignettePoincons
            // 
            this.VignettePoincons.BackColor = System.Drawing.Color.Transparent;
            this.VignettePoincons.Location = new System.Drawing.Point(16, 15);
            this.VignettePoincons.Margin = new System.Windows.Forms.Padding(4);
            this.VignettePoincons.Name = "VignettePoincons";
            this.VignettePoincons.Size = new System.Drawing.Size(649, 747);
            this.VignettePoincons.TabIndex = 39;
            this.VignettePoincons.TabStop = false;
            // 
            // ControleVignette
            // 
            this.ControleVignette.Controls.Add(this.MasquerVignette);
            this.ControleVignette.Controls.Add(this.AfficherVignette);
            this.ControleVignette.Location = new System.Drawing.Point(16, 770);
            this.ControleVignette.Margin = new System.Windows.Forms.Padding(4);
            this.ControleVignette.Name = "ControleVignette";
            this.ControleVignette.Padding = new System.Windows.Forms.Padding(4);
            this.ControleVignette.Size = new System.Drawing.Size(285, 81);
            this.ControleVignette.TabIndex = 38;
            this.ControleVignette.TabStop = false;
            this.ControleVignette.Text = "Vignette";
            // 
            // MasquerVignette
            // 
            this.MasquerVignette.AutoSize = true;
            this.MasquerVignette.Location = new System.Drawing.Point(44, 53);
            this.MasquerVignette.Margin = new System.Windows.Forms.Padding(4);
            this.MasquerVignette.Name = "MasquerVignette";
            this.MasquerVignette.Size = new System.Drawing.Size(101, 17);
            this.MasquerVignette.TabIndex = 1;
            this.MasquerVignette.Text = "Masquer l\'image";
            this.MasquerVignette.UseVisualStyleBackColor = true;
            this.MasquerVignette.CheckedChanged += new System.EventHandler(this.MasquerVignette_CheckedChanged);
            // 
            // AfficherVignette
            // 
            this.AfficherVignette.AutoSize = true;
            this.AfficherVignette.Checked = true;
            this.AfficherVignette.Location = new System.Drawing.Point(44, 23);
            this.AfficherVignette.Margin = new System.Windows.Forms.Padding(4);
            this.AfficherVignette.Name = "AfficherVignette";
            this.AfficherVignette.Size = new System.Drawing.Size(96, 17);
            this.AfficherVignette.TabIndex = 0;
            this.AfficherVignette.TabStop = true;
            this.AfficherVignette.Text = "Afficher l\'image";
            this.AfficherVignette.UseVisualStyleBackColor = true;
            this.AfficherVignette.CheckedChanged += new System.EventHandler(this.AfficherVignette_CheckedChanged);
            // 
            // Onglets
            // 
            this.Onglets.Controls.Add(this.Fichier);
            this.Onglets.Controls.Add(this.Poincons);
            this.Onglets.Controls.Add(this.tabPage1);
            this.Onglets.Location = new System.Drawing.Point(673, 15);
            this.Onglets.Margin = new System.Windows.Forms.Padding(4);
            this.Onglets.Name = "Onglets";
            this.Onglets.SelectedIndex = 0;
            this.Onglets.Size = new System.Drawing.Size(838, 900);
            this.Onglets.TabIndex = 40;
            // 
            // Fichier
            // 
            this.Fichier.Controls.Add(this.label16);
            this.Fichier.Controls.Add(this.label9);
            this.Fichier.Controls.Add(this.label6);
            this.Fichier.Controls.Add(this.LargeurImage);
            this.Fichier.Controls.Add(this.HauteurImage);
            this.Fichier.Controls.Add(this.label1);
            this.Fichier.Controls.Add(this.label10);
            this.Fichier.Controls.Add(this.ChercherDXF);
            this.Fichier.Controls.Add(this.CheminImage);
            this.Fichier.Controls.Add(this.CheminDossier);
            this.Fichier.Controls.Add(this.ChercherImage);
            this.Fichier.Controls.Add(this.label4);
            this.Fichier.Controls.Add(this.label3);
            this.Fichier.Location = new System.Drawing.Point(4, 25);
            this.Fichier.Margin = new System.Windows.Forms.Padding(4);
            this.Fichier.Name = "Fichier";
            this.Fichier.Padding = new System.Windows.Forms.Padding(4);
            this.Fichier.Size = new System.Drawing.Size(830, 871);
            this.Fichier.TabIndex = 0;
            this.Fichier.Text = "Fichiers";
            this.Fichier.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(8, 140);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(294, 16);
            this.label16.TabIndex = 31;
            this.label16.Text = "2. Dimensions finales de la pièce en mm :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(241, 179);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "mm";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 176);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "Largeur :";
            // 
            // LargeurImage
            // 
            this.LargeurImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LargeurImage.Location = new System.Drawing.Point(76, 173);
            this.LargeurImage.Margin = new System.Windows.Forms.Padding(4);
            this.LargeurImage.Name = "LargeurImage";
            this.LargeurImage.Size = new System.Drawing.Size(156, 22);
            this.LargeurImage.TabIndex = 26;
            this.LargeurImage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.LargeurImage.TextChanged += new System.EventHandler(this.LargeurImage_TextChanged);
            // 
            // HauteurImage
            // 
            this.HauteurImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HauteurImage.Location = new System.Drawing.Point(77, 207);
            this.HauteurImage.Margin = new System.Windows.Forms.Padding(4);
            this.HauteurImage.Name = "HauteurImage";
            this.HauteurImage.Size = new System.Drawing.Size(156, 22);
            this.HauteurImage.TabIndex = 28;
            this.HauteurImage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.HauteurImage.TextChanged += new System.EventHandler(this.HauteurImage_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 210);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Hauteur :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(243, 213);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "mm";
            // 
            // Poincons
            // 
            this.Poincons.Controls.Add(this.label19);
            this.Poincons.Controls.Add(this.Valeurs);
            this.Poincons.Controls.Add(this.button1);
            this.Poincons.Controls.Add(this.label15);
            this.Poincons.Controls.Add(this.label11);
            this.Poincons.Controls.Add(this.BoxLuminosite);
            this.Poincons.Controls.Add(this.Blanc);
            this.Poincons.Controls.Add(this.Noir);
            this.Poincons.Controls.Add(this.label2);
            this.Poincons.Controls.Add(this.ValiderPoincon);
            this.Poincons.Controls.Add(this.ListePoincons);
            this.Poincons.Controls.Add(this.label5);
            this.Poincons.Controls.Add(this.TypeCarroyage);
            this.Poincons.Controls.Add(this.VisualiserPoincons);
            this.Poincons.Controls.Add(this.label8);
            this.Poincons.Controls.Add(this.label7);
            this.Poincons.Controls.Add(this.Jeu);
            this.Poincons.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Poincons.Location = new System.Drawing.Point(4, 25);
            this.Poincons.Margin = new System.Windows.Forms.Padding(4);
            this.Poincons.Name = "Poincons";
            this.Poincons.Padding = new System.Windows.Forms.Padding(4);
            this.Poincons.Size = new System.Drawing.Size(830, 871);
            this.Poincons.TabIndex = 1;
            this.Poincons.Text = "Poinçons";
            this.Poincons.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(424, 794);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(193, 32);
            this.button1.TabIndex = 56;
            this.button1.Text = "Masquer les poinçons";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.MasquerPoincons_Click);
            // 
            // label15
            // 
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(8, 4);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(809, 224);
            this.label15.TabIndex = 45;
            this.label15.Text = resources.GetString("label15.Text");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(8, 441);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(237, 16);
            this.label11.TabIndex = 44;
            this.label11.Text = "4. Histogramme de la luminosité :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BoxLuminosite
            // 
            this.BoxLuminosite.BackColor = System.Drawing.Color.White;
            this.BoxLuminosite.Location = new System.Drawing.Point(12, 500);
            this.BoxLuminosite.Margin = new System.Windows.Forms.Padding(4);
            this.BoxLuminosite.Name = "BoxLuminosite";
            this.BoxLuminosite.Size = new System.Drawing.Size(813, 204);
            this.BoxLuminosite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BoxLuminosite.TabIndex = 41;
            this.BoxLuminosite.TabStop = false;
            this.BoxLuminosite.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BoxLuminosite_MouseDown);
            this.BoxLuminosite.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BoxLuminosite_MouseMove);
            this.BoxLuminosite.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BoxLuminosite_MouseUp);
            // 
            // Blanc
            // 
            this.Blanc.BackColor = System.Drawing.Color.White;
            this.Blanc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Blanc.Location = new System.Drawing.Point(11, 470);
            this.Blanc.Margin = new System.Windows.Forms.Padding(4);
            this.Blanc.Name = "Blanc";
            this.Blanc.Size = new System.Drawing.Size(23, 22);
            this.Blanc.TabIndex = 42;
            this.Blanc.TabStop = false;
            // 
            // Noir
            // 
            this.Noir.BackColor = System.Drawing.Color.Black;
            this.Noir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Noir.Location = new System.Drawing.Point(801, 470);
            this.Noir.Margin = new System.Windows.Forms.Padding(4);
            this.Noir.Name = "Noir";
            this.Noir.Size = new System.Drawing.Size(23, 22);
            this.Noir.TabIndex = 43;
            this.Noir.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 334);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(232, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "2. Jeu mini entre deux poinçons :";
            // 
            // ValiderPoincon
            // 
            this.ValiderPoincon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValiderPoincon.Location = new System.Drawing.Point(658, 286);
            this.ValiderPoincon.Margin = new System.Windows.Forms.Padding(4);
            this.ValiderPoincon.Name = "ValiderPoincon";
            this.ValiderPoincon.Size = new System.Drawing.Size(44, 28);
            this.ValiderPoincon.TabIndex = 26;
            this.ValiderPoincon.Text = "Ok";
            this.ValiderPoincon.UseVisualStyleBackColor = true;
            this.ValiderPoincon.Click += new System.EventHandler(this.ValiderPoincon_Click);
            // 
            // ListePoincons
            // 
            this.ListePoincons.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListePoincons.Location = new System.Drawing.Point(13, 289);
            this.ListePoincons.Margin = new System.Windows.Forms.Padding(4);
            this.ListePoincons.Name = "ListePoincons";
            this.ListePoincons.Size = new System.Drawing.Size(637, 22);
            this.ListePoincons.TabIndex = 12;
            this.ListePoincons.TextChanged += new System.EventHandler(this.ListePoincons_TextChanged);
            this.ListePoincons.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ListePoincons_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 265);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(192, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "1. Diamètres de poinçons :";
            // 
            // TypeCarroyage
            // 
            this.TypeCarroyage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeCarroyage.FormattingEnabled = true;
            this.TypeCarroyage.ItemHeight = 16;
            this.TypeCarroyage.Items.AddRange(new object[] {
            "Carré",
            "Hexagonal"});
            this.TypeCarroyage.Location = new System.Drawing.Point(160, 379);
            this.TypeCarroyage.Margin = new System.Windows.Forms.Padding(4);
            this.TypeCarroyage.Name = "TypeCarroyage";
            this.TypeCarroyage.Size = new System.Drawing.Size(159, 36);
            this.TypeCarroyage.TabIndex = 17;
            this.TypeCarroyage.SelectedIndexChanged += new System.EventHandler(this.TypeCarroyage_SelectedIndexChanged);
            // 
            // VisualiserPoincons
            // 
            this.VisualiserPoincons.AutoSize = true;
            this.VisualiserPoincons.Location = new System.Drawing.Point(13, 794);
            this.VisualiserPoincons.Margin = new System.Windows.Forms.Padding(4);
            this.VisualiserPoincons.Name = "VisualiserPoincons";
            this.VisualiserPoincons.Size = new System.Drawing.Size(391, 32);
            this.VisualiserPoincons.TabIndex = 27;
            this.VisualiserPoincons.Text = "5. Visualiser les poinçons dans l\'aperçu";
            this.VisualiserPoincons.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.VisualiserPoincons.UseVisualStyleBackColor = true;
            this.VisualiserPoincons.Click += new System.EventHandler(this.VisualiserPoincons_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(325, 336);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "mm";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 390);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "3. Type de réseau :";
            // 
            // Jeu
            // 
            this.Jeu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Jeu.Location = new System.Drawing.Point(249, 331);
            this.Jeu.Margin = new System.Windows.Forms.Padding(4);
            this.Jeu.Name = "Jeu";
            this.Jeu.Size = new System.Drawing.Size(68, 22);
            this.Jeu.TabIndex = 21;
            this.Jeu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Jeu.TextChanged += new System.EventHandler(this.Jeu_TextChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.ConvertirNoirEtBlanc);
            this.tabPage1.Controls.Add(this.RestaurerCouleur);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(830, 871);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Noir et blanc";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LienWikipedia);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.Bleu);
            this.groupBox1.Controls.Add(this.Rouge);
            this.groupBox1.Controls.Add(this.Vert);
            this.groupBox1.Controls.Add(this.Somme);
            this.groupBox1.Location = new System.Drawing.Point(4, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(664, 214);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Facteur de conversion";
            // 
            // LienWikipedia
            // 
            this.LienWikipedia.AutoSize = true;
            this.LienWikipedia.Location = new System.Drawing.Point(271, 102);
            this.LienWikipedia.Name = "LienWikipedia";
            this.LienWikipedia.Size = new System.Drawing.Size(230, 16);
            this.LienWikipedia.TabIndex = 57;
            this.LienWikipedia.TabStop = true;
            this.LienWikipedia.Text = "http://en.wikipedia.org/wiki/Grayscale";
            this.LienWikipedia.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LienWikipedia_LinkClicked);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(7, 22);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(438, 96);
            this.label20.TabIndex = 56;
            this.label20.Text = resources.GetString("label20.Text");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 160);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 16);
            this.label12.TabIndex = 51;
            this.label12.Text = "Rouge";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(147, 160);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 16);
            this.label13.TabIndex = 52;
            this.label13.Text = "Vert";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(432, 160);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(61, 16);
            this.label17.TabIndex = 55;
            this.label17.Text = "Somme :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(279, 160);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 16);
            this.label14.TabIndex = 53;
            this.label14.Text = "Bleu";
            // 
            // Bleu
            // 
            this.Bleu.Location = new System.Drawing.Point(320, 157);
            this.Bleu.Name = "Bleu";
            this.Bleu.Size = new System.Drawing.Size(68, 22);
            this.Bleu.TabIndex = 50;
            this.Bleu.TextChanged += new System.EventHandler(this.Bleu_TextChanged);
            // 
            // Rouge
            // 
            this.Rouge.Location = new System.Drawing.Point(62, 157);
            this.Rouge.Name = "Rouge";
            this.Rouge.Size = new System.Drawing.Size(68, 22);
            this.Rouge.TabIndex = 48;
            this.Rouge.TextChanged += new System.EventHandler(this.Rouge_TextChanged);
            // 
            // Vert
            // 
            this.Vert.Location = new System.Drawing.Point(185, 157);
            this.Vert.Name = "Vert";
            this.Vert.Size = new System.Drawing.Size(68, 22);
            this.Vert.TabIndex = 49;
            this.Vert.TextChanged += new System.EventHandler(this.Vert_TextChanged);
            // 
            // Somme
            // 
            this.Somme.AutoSize = true;
            this.Somme.Location = new System.Drawing.Point(498, 160);
            this.Somme.Name = "Somme";
            this.Somme.Size = new System.Drawing.Size(15, 16);
            this.Somme.TabIndex = 54;
            this.Somme.Text = "1";
            // 
            // ConvertirNoirEtBlanc
            // 
            this.ConvertirNoirEtBlanc.AutoSize = true;
            this.ConvertirNoirEtBlanc.Location = new System.Drawing.Point(4, 23);
            this.ConvertirNoirEtBlanc.Margin = new System.Windows.Forms.Padding(4);
            this.ConvertirNoirEtBlanc.Name = "ConvertirNoirEtBlanc";
            this.ConvertirNoirEtBlanc.Size = new System.Drawing.Size(120, 26);
            this.ConvertirNoirEtBlanc.TabIndex = 46;
            this.ConvertirNoirEtBlanc.Text = "Convertir en N&&B";
            this.ConvertirNoirEtBlanc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ConvertirNoirEtBlanc.UseVisualStyleBackColor = true;
            this.ConvertirNoirEtBlanc.Click += new System.EventHandler(this.NoirEtBlanc_Click);
            // 
            // RestaurerCouleur
            // 
            this.RestaurerCouleur.AutoSize = true;
            this.RestaurerCouleur.Location = new System.Drawing.Point(166, 23);
            this.RestaurerCouleur.Margin = new System.Windows.Forms.Padding(4);
            this.RestaurerCouleur.Name = "RestaurerCouleur";
            this.RestaurerCouleur.Size = new System.Drawing.Size(152, 26);
            this.RestaurerCouleur.TabIndex = 47;
            this.RestaurerCouleur.Text = "Restaurer les couleurs";
            this.RestaurerCouleur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RestaurerCouleur.UseVisualStyleBackColor = true;
            this.RestaurerCouleur.Click += new System.EventHandler(this.RestaurerCouleur_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(380, 806);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(136, 20);
            this.label18.TabIndex = 41;
            this.label18.Text = "Nb de perçage :";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NbPoincons
            // 
            this.NbPoincons.AutoSize = true;
            this.NbPoincons.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NbPoincons.Location = new System.Drawing.Point(522, 806);
            this.NbPoincons.Name = "NbPoincons";
            this.NbPoincons.Size = new System.Drawing.Size(19, 20);
            this.NbPoincons.TabIndex = 42;
            this.NbPoincons.Text = "0";
            this.NbPoincons.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Valeurs
            // 
            this.Valeurs.Location = new System.Drawing.Point(125, 711);
            this.Valeurs.Name = "Valeurs";
            this.Valeurs.ReadOnly = true;
            this.Valeurs.Size = new System.Drawing.Size(392, 22);
            this.Valeurs.TabIndex = 57;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(10, 714);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(110, 16);
            this.label19.TabIndex = 58;
            this.label19.Text = "Valeurs limite :";
            // 
            // Formulaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1524, 928);
            this.Controls.Add(this.NbPoincons);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.VignetteImage);
            this.Controls.Add(this.VignettePoincons);
            this.Controls.Add(this.Lancer);
            this.Controls.Add(this.Onglets);
            this.Controls.Add(this.ControleVignette);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Formulaire";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Poinçonner une image";
            this.Load += new System.EventHandler(this.Formulaire_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VignetteImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.VignettePoincons)).EndInit();
            this.ControleVignette.ResumeLayout(false);
            this.ControleVignette.PerformLayout();
            this.Onglets.ResumeLayout(false);
            this.Fichier.ResumeLayout(false);
            this.Fichier.PerformLayout();
            this.Poincons.ResumeLayout(false);
            this.Poincons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoxLuminosite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Blanc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Noir)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog OuvrirFichierImage;
        private System.Windows.Forms.TextBox CheminImage;
        private System.Windows.Forms.Button ChercherImage;
        private System.Windows.Forms.TextBox CheminDossier;
        private System.Windows.Forms.Button ChercherDXF;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FolderBrowserDialog OuvrirDossierExport;
        private System.Windows.Forms.Button Lancer;
        private System.Windows.Forms.PictureBox VignetteImage;
        private System.Windows.Forms.GroupBox ControleVignette;
        private System.Windows.Forms.RadioButton MasquerVignette;
        private System.Windows.Forms.RadioButton AfficherVignette;
        private System.Windows.Forms.PictureBox VignettePoincons;
        private System.Windows.Forms.TabControl Onglets;
        private System.Windows.Forms.TabPage Fichier;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox LargeurImage;
        private System.Windows.Forms.TextBox HauteurImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TabPage Poincons;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox BoxLuminosite;
        private System.Windows.Forms.PictureBox Blanc;
        private System.Windows.Forms.PictureBox Noir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ValiderPoincon;
        private System.Windows.Forms.TextBox ListePoincons;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox TypeCarroyage;
        private System.Windows.Forms.Button VisualiserPoincons;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Jeu;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button ConvertirNoirEtBlanc;
        private System.Windows.Forms.Button RestaurerCouleur;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox Bleu;
        private System.Windows.Forms.TextBox Vert;
        private System.Windows.Forms.TextBox Rouge;
        private System.Windows.Forms.Label Somme;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label NbPoincons;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.LinkLabel LienWikipedia;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox Valeurs;
    }
}

