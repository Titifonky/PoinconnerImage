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
            this.OuvrirFichierImage = new System.Windows.Forms.OpenFileDialog();
            this.CheminImage = new System.Windows.Forms.TextBox();
            this.ChercherImage = new System.Windows.Forms.Button();
            this.CheminDossier = new System.Windows.Forms.TextBox();
            this.ChercherDXF = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.OuvrirDossierExport = new System.Windows.Forms.FolderBrowserDialog();
            this.label5 = new System.Windows.Forms.Label();
            this.ListePoincons = new System.Windows.Forms.TextBox();
            this.Lancer = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.LargeurImage = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TypeCarroyage = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.HauteurImage = new System.Windows.Forms.TextBox();
            this.Jeu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ValiderPoincon = new System.Windows.Forms.Button();
            this.VisualiserPoincons = new System.Windows.Forms.Button();
            this.Reinitialiser = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.BoxLuminosite = new System.Windows.Forms.PictureBox();
            this.Fichiers = new System.Windows.Forms.GroupBox();
            this.Couleur = new System.Windows.Forms.GroupBox();
            this.AppliquerBleu = new System.Windows.Forms.Button();
            this.AppliquerVert = new System.Windows.Forms.Button();
            this.AppliquerRouge = new System.Windows.Forms.Button();
            this.AppliquerLuminosite = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.BoxBleu = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.BoxVert = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.BoxRouge = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.VignetteImage = new System.Windows.Forms.PictureBox();
            this.ControleVignette = new System.Windows.Forms.GroupBox();
            this.MasquerVignette = new System.Windows.Forms.RadioButton();
            this.AfficherVignette = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxLuminosite)).BeginInit();
            this.Fichiers.SuspendLayout();
            this.Couleur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoxBleu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxVert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxRouge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VignetteImage)).BeginInit();
            this.ControleVignette.SuspendLayout();
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
            this.CheminImage.Location = new System.Drawing.Point(6, 45);
            this.CheminImage.Name = "CheminImage";
            this.CheminImage.Size = new System.Drawing.Size(555, 22);
            this.CheminImage.TabIndex = 2;
            this.CheminImage.TextChanged += new System.EventHandler(this.CheminImage_TextChanged);
            // 
            // ChercherImage
            // 
            this.ChercherImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChercherImage.Location = new System.Drawing.Point(6, 71);
            this.ChercherImage.Name = "ChercherImage";
            this.ChercherImage.Size = new System.Drawing.Size(75, 23);
            this.ChercherImage.TabIndex = 3;
            this.ChercherImage.Text = "Parcourir";
            this.ChercherImage.UseVisualStyleBackColor = true;
            this.ChercherImage.Click += new System.EventHandler(this.ChercherImage_Click);
            // 
            // CheminDossier
            // 
            this.CheminDossier.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheminDossier.Location = new System.Drawing.Point(6, 131);
            this.CheminDossier.Name = "CheminDossier";
            this.CheminDossier.Size = new System.Drawing.Size(555, 22);
            this.CheminDossier.TabIndex = 5;
            this.CheminDossier.TextChanged += new System.EventHandler(this.CheminDossier_TextChanged);
            // 
            // ChercherDXF
            // 
            this.ChercherDXF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChercherDXF.Location = new System.Drawing.Point(6, 157);
            this.ChercherDXF.Name = "ChercherDXF";
            this.ChercherDXF.Size = new System.Drawing.Size(75, 23);
            this.ChercherDXF.TabIndex = 6;
            this.ChercherDXF.Text = "Parcourir";
            this.ChercherDXF.UseVisualStyleBackColor = true;
            this.ChercherDXF.Click += new System.EventHandler(this.ChercherDXF_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(254, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sélectionnez l\'image à poinçonner :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(238, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Sélectionnez le dossier d\'export :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(340, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Diamètres de poinçons séparés par un espace :";
            // 
            // ListePoincons
            // 
            this.ListePoincons.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListePoincons.Location = new System.Drawing.Point(10, 44);
            this.ListePoincons.Name = "ListePoincons";
            this.ListePoincons.Size = new System.Drawing.Size(337, 22);
            this.ListePoincons.TabIndex = 12;
            this.ListePoincons.TextChanged += new System.EventHandler(this.ListePoincons_TextChanged);
            // 
            // Lancer
            // 
            this.Lancer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lancer.Location = new System.Drawing.Point(1290, 519);
            this.Lancer.Name = "Lancer";
            this.Lancer.Size = new System.Drawing.Size(262, 43);
            this.Lancer.TabIndex = 13;
            this.Lancer.Text = "Convertir en DXF";
            this.Lancer.UseVisualStyleBackColor = true;
            this.Lancer.Click += new System.EventHandler(this.Lancer_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(146, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Largeur de l\'image :";
            // 
            // LargeurImage
            // 
            this.LargeurImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LargeurImage.Location = new System.Drawing.Point(161, 101);
            this.LargeurImage.Name = "LargeurImage";
            this.LargeurImage.Size = new System.Drawing.Size(118, 22);
            this.LargeurImage.TabIndex = 15;
            this.LargeurImage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.LargeurImage.TextChanged += new System.EventHandler(this.LargeurImage_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(7, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Type de réseau :";
            // 
            // TypeCarroyage
            // 
            this.TypeCarroyage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeCarroyage.FormattingEnabled = true;
            this.TypeCarroyage.ItemHeight = 16;
            this.TypeCarroyage.Items.AddRange(new object[] {
            "Carré",
            "Hexagonal"});
            this.TypeCarroyage.Location = new System.Drawing.Point(139, 157);
            this.TypeCarroyage.Name = "TypeCarroyage";
            this.TypeCarroyage.Size = new System.Drawing.Size(120, 36);
            this.TypeCarroyage.TabIndex = 17;
            this.TypeCarroyage.SelectedIndexChanged += new System.EventHandler(this.TypeCarroyage_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Hauteur de l\'image :";
            // 
            // HauteurImage
            // 
            this.HauteurImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HauteurImage.Location = new System.Drawing.Point(161, 129);
            this.HauteurImage.Name = "HauteurImage";
            this.HauteurImage.Size = new System.Drawing.Size(118, 22);
            this.HauteurImage.TabIndex = 19;
            this.HauteurImage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.HauteurImage.TextChanged += new System.EventHandler(this.HauteurImage_TextChanged);
            // 
            // Jeu
            // 
            this.Jeu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Jeu.Location = new System.Drawing.Point(227, 72);
            this.Jeu.Name = "Jeu";
            this.Jeu.Size = new System.Drawing.Size(52, 22);
            this.Jeu.TabIndex = 21;
            this.Jeu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Jeu.TextChanged += new System.EventHandler(this.Jeu_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(216, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Jeu mini entre deux poinçons :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(285, 77);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "mm";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(285, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "mm";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(285, 134);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "mm";
            // 
            // ValiderPoincon
            // 
            this.ValiderPoincon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ValiderPoincon.Location = new System.Drawing.Point(353, 41);
            this.ValiderPoincon.Name = "ValiderPoincon";
            this.ValiderPoincon.Size = new System.Drawing.Size(33, 23);
            this.ValiderPoincon.TabIndex = 26;
            this.ValiderPoincon.Text = "Ok";
            this.ValiderPoincon.UseVisualStyleBackColor = true;
            this.ValiderPoincon.Click += new System.EventHandler(this.ValiderPoincon_Click);
            // 
            // VisualiserPoincons
            // 
            this.VisualiserPoincons.Location = new System.Drawing.Point(1320, 446);
            this.VisualiserPoincons.Name = "VisualiserPoincons";
            this.VisualiserPoincons.Size = new System.Drawing.Size(193, 23);
            this.VisualiserPoincons.TabIndex = 27;
            this.VisualiserPoincons.Text = "Visualiser les poinçons dans l\'aperçu";
            this.VisualiserPoincons.UseVisualStyleBackColor = true;
            this.VisualiserPoincons.Click += new System.EventHandler(this.VisualiserPoincons_Click);
            // 
            // Reinitialiser
            // 
            this.Reinitialiser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reinitialiser.Location = new System.Drawing.Point(209, 831);
            this.Reinitialiser.Name = "Reinitialiser";
            this.Reinitialiser.Size = new System.Drawing.Size(151, 30);
            this.Reinitialiser.TabIndex = 28;
            this.Reinitialiser.Text = "Reinitialiser";
            this.Reinitialiser.UseVisualStyleBackColor = true;
            this.Reinitialiser.Click += new System.EventHandler(this.Reinitialiser_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(6, 189);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 18);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(563, 189);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(18, 18);
            this.pictureBox2.TabIndex = 30;
            this.pictureBox2.TabStop = false;
            // 
            // BoxLuminosite
            // 
            this.BoxLuminosite.BackColor = System.Drawing.Color.White;
            this.BoxLuminosite.Location = new System.Drawing.Point(6, 17);
            this.BoxLuminosite.Name = "BoxLuminosite";
            this.BoxLuminosite.Size = new System.Drawing.Size(575, 166);
            this.BoxLuminosite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BoxLuminosite.TabIndex = 25;
            this.BoxLuminosite.TabStop = false;
            // 
            // Fichiers
            // 
            this.Fichiers.BackColor = System.Drawing.SystemColors.Control;
            this.Fichiers.Controls.Add(this.label3);
            this.Fichiers.Controls.Add(this.CheminImage);
            this.Fichiers.Controls.Add(this.ChercherDXF);
            this.Fichiers.Controls.Add(this.ChercherImage);
            this.Fichiers.Controls.Add(this.CheminDossier);
            this.Fichiers.Controls.Add(this.label4);
            this.Fichiers.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fichiers.Location = new System.Drawing.Point(12, 718);
            this.Fichiers.Name = "Fichiers";
            this.Fichiers.Size = new System.Drawing.Size(594, 183);
            this.Fichiers.TabIndex = 32;
            this.Fichiers.TabStop = false;
            this.Fichiers.Text = "Fichiers";
            // 
            // Couleur
            // 
            this.Couleur.Controls.Add(this.AppliquerBleu);
            this.Couleur.Controls.Add(this.AppliquerVert);
            this.Couleur.Controls.Add(this.AppliquerRouge);
            this.Couleur.Controls.Add(this.AppliquerLuminosite);
            this.Couleur.Controls.Add(this.label14);
            this.Couleur.Controls.Add(this.label13);
            this.Couleur.Controls.Add(this.label12);
            this.Couleur.Controls.Add(this.label11);
            this.Couleur.Controls.Add(this.Reinitialiser);
            this.Couleur.Controls.Add(this.BoxBleu);
            this.Couleur.Controls.Add(this.pictureBox10);
            this.Couleur.Controls.Add(this.pictureBox11);
            this.Couleur.Controls.Add(this.BoxVert);
            this.Couleur.Controls.Add(this.pictureBox7);
            this.Couleur.Controls.Add(this.pictureBox8);
            this.Couleur.Controls.Add(this.BoxRouge);
            this.Couleur.Controls.Add(this.pictureBox4);
            this.Couleur.Controls.Add(this.pictureBox5);
            this.Couleur.Controls.Add(this.BoxLuminosite);
            this.Couleur.Controls.Add(this.pictureBox1);
            this.Couleur.Controls.Add(this.pictureBox2);
            this.Couleur.Location = new System.Drawing.Point(612, 12);
            this.Couleur.Name = "Couleur";
            this.Couleur.Size = new System.Drawing.Size(587, 867);
            this.Couleur.TabIndex = 33;
            this.Couleur.TabStop = false;
            this.Couleur.Text = "Gestion des couleurs";
            // 
            // AppliquerBleu
            // 
            this.AppliquerBleu.Location = new System.Drawing.Point(257, 783);
            this.AppliquerBleu.Name = "AppliquerBleu";
            this.AppliquerBleu.Size = new System.Drawing.Size(75, 23);
            this.AppliquerBleu.TabIndex = 47;
            this.AppliquerBleu.Text = "Appliquer";
            this.AppliquerBleu.UseVisualStyleBackColor = true;
            // 
            // AppliquerVert
            // 
            this.AppliquerVert.Location = new System.Drawing.Point(257, 587);
            this.AppliquerVert.Name = "AppliquerVert";
            this.AppliquerVert.Size = new System.Drawing.Size(75, 23);
            this.AppliquerVert.TabIndex = 46;
            this.AppliquerVert.Text = "Appliquer";
            this.AppliquerVert.UseVisualStyleBackColor = true;
            // 
            // AppliquerRouge
            // 
            this.AppliquerRouge.Location = new System.Drawing.Point(275, 391);
            this.AppliquerRouge.Name = "AppliquerRouge";
            this.AppliquerRouge.Size = new System.Drawing.Size(75, 23);
            this.AppliquerRouge.TabIndex = 45;
            this.AppliquerRouge.Text = "Appliquer";
            this.AppliquerRouge.UseVisualStyleBackColor = true;
            // 
            // AppliquerLuminosite
            // 
            this.AppliquerLuminosite.Location = new System.Drawing.Point(313, 189);
            this.AppliquerLuminosite.Name = "AppliquerLuminosite";
            this.AppliquerLuminosite.Size = new System.Drawing.Size(75, 23);
            this.AppliquerLuminosite.TabIndex = 44;
            this.AppliquerLuminosite.Text = "Appliquer";
            this.AppliquerLuminosite.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(213, 784);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 18);
            this.label14.TabIndex = 43;
            this.label14.Text = "Bleu";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(213, 588);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(38, 18);
            this.label13.TabIndex = 42;
            this.label13.Text = "Vert";
            this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(212, 392);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 18);
            this.label12.TabIndex = 41;
            this.label12.Text = "Rouge";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(211, 189);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(96, 20);
            this.label11.TabIndex = 40;
            this.label11.Text = "Luminosité";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // BoxBleu
            // 
            this.BoxBleu.BackColor = System.Drawing.Color.White;
            this.BoxBleu.Location = new System.Drawing.Point(6, 612);
            this.BoxBleu.Name = "BoxBleu";
            this.BoxBleu.Size = new System.Drawing.Size(575, 166);
            this.BoxBleu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BoxBleu.TabIndex = 37;
            this.BoxBleu.TabStop = false;
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.White;
            this.pictureBox10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox10.Location = new System.Drawing.Point(6, 784);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(18, 18);
            this.pictureBox10.TabIndex = 38;
            this.pictureBox10.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackColor = System.Drawing.Color.Blue;
            this.pictureBox11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox11.Location = new System.Drawing.Point(563, 784);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(18, 18);
            this.pictureBox11.TabIndex = 39;
            this.pictureBox11.TabStop = false;
            // 
            // BoxVert
            // 
            this.BoxVert.BackColor = System.Drawing.Color.White;
            this.BoxVert.Location = new System.Drawing.Point(6, 416);
            this.BoxVert.Name = "BoxVert";
            this.BoxVert.Size = new System.Drawing.Size(575, 166);
            this.BoxVert.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BoxVert.TabIndex = 34;
            this.BoxVert.TabStop = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.White;
            this.pictureBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox7.Location = new System.Drawing.Point(6, 588);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(18, 18);
            this.pictureBox7.TabIndex = 35;
            this.pictureBox7.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Green;
            this.pictureBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox8.Location = new System.Drawing.Point(563, 588);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(18, 18);
            this.pictureBox8.TabIndex = 36;
            this.pictureBox8.TabStop = false;
            // 
            // BoxRouge
            // 
            this.BoxRouge.BackColor = System.Drawing.Color.White;
            this.BoxRouge.Location = new System.Drawing.Point(6, 220);
            this.BoxRouge.Name = "BoxRouge";
            this.BoxRouge.Size = new System.Drawing.Size(575, 166);
            this.BoxRouge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.BoxRouge.TabIndex = 31;
            this.BoxRouge.TabStop = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.White;
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(6, 392);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(18, 18);
            this.pictureBox4.TabIndex = 32;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Red;
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox5.Location = new System.Drawing.Point(563, 392);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(18, 18);
            this.pictureBox5.TabIndex = 33;
            this.pictureBox5.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.ListePoincons);
            this.groupBox1.Controls.Add(this.ValiderPoincon);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.LargeurImage);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.HauteurImage);
            this.groupBox1.Controls.Add(this.TypeCarroyage);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.Jeu);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1205, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 199);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Paramètres de poinçonnage";
            // 
            // VignetteImage
            // 
            this.VignetteImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VignetteImage.Location = new System.Drawing.Point(6, 12);
            this.VignetteImage.Name = "VignetteImage";
            this.VignetteImage.Size = new System.Drawing.Size(600, 700);
            this.VignetteImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.VignetteImage.TabIndex = 37;
            this.VignetteImage.TabStop = false;
            // 
            // ControleVignette
            // 
            this.ControleVignette.Controls.Add(this.MasquerVignette);
            this.ControleVignette.Controls.Add(this.AfficherVignette);
            this.ControleVignette.Location = new System.Drawing.Point(1284, 242);
            this.ControleVignette.Name = "ControleVignette";
            this.ControleVignette.Size = new System.Drawing.Size(116, 66);
            this.ControleVignette.TabIndex = 38;
            this.ControleVignette.TabStop = false;
            this.ControleVignette.Text = "Vignette";
            // 
            // MasquerVignette
            // 
            this.MasquerVignette.AutoSize = true;
            this.MasquerVignette.Location = new System.Drawing.Point(33, 43);
            this.MasquerVignette.Name = "MasquerVignette";
            this.MasquerVignette.Size = new System.Drawing.Size(66, 17);
            this.MasquerVignette.TabIndex = 1;
            this.MasquerVignette.Text = "Masquer";
            this.MasquerVignette.UseVisualStyleBackColor = true;
            this.MasquerVignette.CheckedChanged += new System.EventHandler(this.MasquerVignette_CheckedChanged);
            // 
            // AfficherVignette
            // 
            this.AfficherVignette.AutoSize = true;
            this.AfficherVignette.Checked = true;
            this.AfficherVignette.Location = new System.Drawing.Point(33, 19);
            this.AfficherVignette.Name = "AfficherVignette";
            this.AfficherVignette.Size = new System.Drawing.Size(61, 17);
            this.AfficherVignette.TabIndex = 0;
            this.AfficherVignette.TabStop = true;
            this.AfficherVignette.Text = "Afficher";
            this.AfficherVignette.UseVisualStyleBackColor = true;
            this.AfficherVignette.CheckedChanged += new System.EventHandler(this.AfficherVignette_CheckedChanged);
            // 
            // Formulaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1605, 912);
            this.Controls.Add(this.ControleVignette);
            this.Controls.Add(this.VignetteImage);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Couleur);
            this.Controls.Add(this.Fichiers);
            this.Controls.Add(this.VisualiserPoincons);
            this.Controls.Add(this.Lancer);
            this.Name = "Formulaire";
            this.Text = "Poinçonner une image";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Formulaire_FormClosing);
            this.Load += new System.EventHandler(this.Formulaire_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxLuminosite)).EndInit();
            this.Fichiers.ResumeLayout(false);
            this.Fichiers.PerformLayout();
            this.Couleur.ResumeLayout(false);
            this.Couleur.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BoxBleu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxVert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxRouge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.VignetteImage)).EndInit();
            this.ControleVignette.ResumeLayout(false);
            this.ControleVignette.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ListePoincons;
        private System.Windows.Forms.Button Lancer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox LargeurImage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox TypeCarroyage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox HauteurImage;
        private System.Windows.Forms.TextBox Jeu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button ValiderPoincon;
        private System.Windows.Forms.Button VisualiserPoincons;
        private System.Windows.Forms.Button Reinitialiser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox BoxLuminosite;
        private System.Windows.Forms.GroupBox Fichiers;
        private System.Windows.Forms.GroupBox Couleur;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox BoxBleu;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.PictureBox BoxVert;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox BoxRouge;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.PictureBox VignetteImage;
        private System.Windows.Forms.Button AppliquerBleu;
        private System.Windows.Forms.Button AppliquerVert;
        private System.Windows.Forms.Button AppliquerRouge;
        private System.Windows.Forms.Button AppliquerLuminosite;
        private System.Windows.Forms.GroupBox ControleVignette;
        private System.Windows.Forms.RadioButton MasquerVignette;
        private System.Windows.Forms.RadioButton AfficherVignette;
    }
}

