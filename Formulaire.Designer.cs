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
            this.VignetteImage = new System.Windows.Forms.PictureBox();
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
            this.BoxHistogram = new System.Windows.Forms.PictureBox();
            this.ValiderPoincon = new System.Windows.Forms.Button();
            this.VisualiserZones = new System.Windows.Forms.Button();
            this.Reinitialiser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.VignetteImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxHistogram)).BeginInit();
            this.SuspendLayout();
            // 
            // VignetteImage
            // 
            this.VignetteImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VignetteImage.Location = new System.Drawing.Point(12, 12);
            this.VignetteImage.Name = "VignetteImage";
            this.VignetteImage.Size = new System.Drawing.Size(550, 614);
            this.VignetteImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.VignetteImage.TabIndex = 0;
            this.VignetteImage.TabStop = false;
            // 
            // OuvrirFichierImage
            // 
            this.OuvrirFichierImage.Filter = "Fichier image (*.jpg, *.png, *.gif, *.tif, *.bmp)|*.jpg;*.gif;*.png;*.tif;*.tiff;" +
    "*.jpeg;*.bmp|Tout les fichiers (*.*)|*.*";
            // 
            // CheminImage
            // 
            this.CheminImage.Location = new System.Drawing.Point(637, 35);
            this.CheminImage.Name = "CheminImage";
            this.CheminImage.Size = new System.Drawing.Size(537, 20);
            this.CheminImage.TabIndex = 2;
            this.CheminImage.TextChanged += new System.EventHandler(this.CheminImage_TextChanged);
            // 
            // ChercherImage
            // 
            this.ChercherImage.Location = new System.Drawing.Point(637, 61);
            this.ChercherImage.Name = "ChercherImage";
            this.ChercherImage.Size = new System.Drawing.Size(75, 23);
            this.ChercherImage.TabIndex = 3;
            this.ChercherImage.Text = "Parcourir";
            this.ChercherImage.UseVisualStyleBackColor = true;
            this.ChercherImage.Click += new System.EventHandler(this.ChercherImage_Click);
            // 
            // CheminDossier
            // 
            this.CheminDossier.Location = new System.Drawing.Point(637, 136);
            this.CheminDossier.Name = "CheminDossier";
            this.CheminDossier.Size = new System.Drawing.Size(537, 20);
            this.CheminDossier.TabIndex = 5;
            this.CheminDossier.TextChanged += new System.EventHandler(this.CheminDossier_TextChanged);
            // 
            // ChercherDXF
            // 
            this.ChercherDXF.Location = new System.Drawing.Point(637, 162);
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
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(633, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(293, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Sélectionnez l\'image à poinçonner :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(633, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(274, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Sélectionnez le dossier d\'export :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(633, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(466, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Liste des diamètres de poinçons séparés par un espace :";
            // 
            // ListePoincons
            // 
            this.ListePoincons.Location = new System.Drawing.Point(637, 233);
            this.ListePoincons.Name = "ListePoincons";
            this.ListePoincons.Size = new System.Drawing.Size(462, 20);
            this.ListePoincons.TabIndex = 12;
            this.ListePoincons.TextChanged += new System.EventHandler(this.ListePoincons_TextChanged);
            // 
            // Lancer
            // 
            this.Lancer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lancer.Location = new System.Drawing.Point(758, 583);
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
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(633, 433);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "Largeur de l\'image :";
            // 
            // LargeurImage
            // 
            this.LargeurImage.Location = new System.Drawing.Point(806, 435);
            this.LargeurImage.Name = "LargeurImage";
            this.LargeurImage.Size = new System.Drawing.Size(138, 20);
            this.LargeurImage.TabIndex = 15;
            this.LargeurImage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.LargeurImage.TextChanged += new System.EventHandler(this.LargeurImage_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(1051, 414);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "Type de carroyage :";
            // 
            // TypeCarroyage
            // 
            this.TypeCarroyage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TypeCarroyage.FormattingEnabled = true;
            this.TypeCarroyage.ItemHeight = 20;
            this.TypeCarroyage.Items.AddRange(new object[] {
            "Carré",
            "Hexagonal"});
            this.TypeCarroyage.Location = new System.Drawing.Point(1055, 437);
            this.TypeCarroyage.Name = "TypeCarroyage";
            this.TypeCarroyage.Size = new System.Drawing.Size(120, 44);
            this.TypeCarroyage.TabIndex = 17;
            this.TypeCarroyage.SelectedIndexChanged += new System.EventHandler(this.TypeCarroyage_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(630, 461);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Hauteur de l\'image :";
            // 
            // HauteurImage
            // 
            this.HauteurImage.Location = new System.Drawing.Point(806, 461);
            this.HauteurImage.Name = "HauteurImage";
            this.HauteurImage.Size = new System.Drawing.Size(134, 20);
            this.HauteurImage.TabIndex = 19;
            this.HauteurImage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.HauteurImage.TextChanged += new System.EventHandler(this.HauteurImage_TextChanged);
            // 
            // Jeu
            // 
            this.Jeu.Location = new System.Drawing.Point(891, 409);
            this.Jeu.Name = "Jeu";
            this.Jeu.Size = new System.Drawing.Size(53, 20);
            this.Jeu.TabIndex = 21;
            this.Jeu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Jeu.TextChanged += new System.EventHandler(this.Jeu_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(633, 409);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Jeu mini entre deux poinçons :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(950, 412);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "mm";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(950, 438);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "mm";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(946, 464);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 13);
            this.label10.TabIndex = 24;
            this.label10.Text = "mm";
            // 
            // BoxHistogram
            // 
            this.BoxHistogram.BackColor = System.Drawing.Color.White;
            this.BoxHistogram.Location = new System.Drawing.Point(637, 269);
            this.BoxHistogram.Name = "BoxHistogram";
            this.BoxHistogram.Size = new System.Drawing.Size(537, 125);
            this.BoxHistogram.TabIndex = 25;
            this.BoxHistogram.TabStop = false;
            // 
            // ValiderPoincon
            // 
            this.ValiderPoincon.Location = new System.Drawing.Point(1105, 231);
            this.ValiderPoincon.Name = "ValiderPoincon";
            this.ValiderPoincon.Size = new System.Drawing.Size(75, 23);
            this.ValiderPoincon.TabIndex = 26;
            this.ValiderPoincon.Text = "Valider";
            this.ValiderPoincon.UseVisualStyleBackColor = true;
            this.ValiderPoincon.Click += new System.EventHandler(this.ValiderPoincon_Click);
            // 
            // VisualiserZones
            // 
            this.VisualiserZones.Location = new System.Drawing.Point(637, 519);
            this.VisualiserZones.Name = "VisualiserZones";
            this.VisualiserZones.Size = new System.Drawing.Size(193, 23);
            this.VisualiserZones.TabIndex = 27;
            this.VisualiserZones.Text = "Visualiser les zones dans l\'aperçu";
            this.VisualiserZones.UseVisualStyleBackColor = true;
            this.VisualiserZones.Click += new System.EventHandler(this.VisualiserZones_Click);
            // 
            // Reinitialiser
            // 
            this.Reinitialiser.Location = new System.Drawing.Point(852, 519);
            this.Reinitialiser.Name = "Reinitialiser";
            this.Reinitialiser.Size = new System.Drawing.Size(121, 23);
            this.Reinitialiser.TabIndex = 28;
            this.Reinitialiser.Text = "Reinitialiser";
            this.Reinitialiser.UseVisualStyleBackColor = true;
            // 
            // Formulaire
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1276, 638);
            this.Controls.Add(this.Reinitialiser);
            this.Controls.Add(this.VisualiserZones);
            this.Controls.Add(this.ValiderPoincon);
            this.Controls.Add(this.BoxHistogram);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.Jeu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HauteurImage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TypeCarroyage);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LargeurImage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Lancer);
            this.Controls.Add(this.ListePoincons);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ChercherDXF);
            this.Controls.Add(this.CheminDossier);
            this.Controls.Add(this.ChercherImage);
            this.Controls.Add(this.CheminImage);
            this.Controls.Add(this.VignetteImage);
            this.Name = "Formulaire";
            this.Text = "Poinçonner une image";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Formulaire_FormClosing);
            this.Load += new System.EventHandler(this.Formulaire_Load);
            ((System.ComponentModel.ISupportInitialize)(this.VignetteImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BoxHistogram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox VignetteImage;
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
        private System.Windows.Forms.PictureBox BoxHistogram;
        private System.Windows.Forms.Button ValiderPoincon;
        private System.Windows.Forms.Button VisualiserZones;
        private System.Windows.Forms.Button Reinitialiser;
    }
}

