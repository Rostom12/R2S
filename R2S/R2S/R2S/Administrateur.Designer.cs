namespace R2S
{
    partial class Administrateur
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_admin_salarie = new System.Windows.Forms.Label();
            this.btn_admin_salarie_add = new System.Windows.Forms.Button();
            this.btn_admin_salarie_remove = new System.Windows.Forms.Button();
            this.btn_admin_salarie_modif = new System.Windows.Forms.Button();
            this.data_admin_salarie = new System.Windows.Forms.DataGridView();
            this.Numéro_salarié = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prénom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ligue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Salle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_admin_ligue = new System.Windows.Forms.DataGridView();
            this.Numéro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Intitulé = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.data_admin_salle = new System.Windows.Forms.DataGridView();
            this.Numéro_salle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Localisation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_admin_ligue = new System.Windows.Forms.Label();
            this.lbl_admin_salle = new System.Windows.Forms.Label();
            this.btn_admin_salle_modif = new System.Windows.Forms.Button();
            this.btn_admin_salle_remove = new System.Windows.Forms.Button();
            this.btn_admin_salle_add = new System.Windows.Forms.Button();
            this.btn_admin_ligue_modif = new System.Windows.Forms.Button();
            this.btn_admin_ligue_suppr = new System.Windows.Forms.Button();
            this.btn_admin_ligue_add = new System.Windows.Forms.Button();
            this.btn_admin_deconnexion = new System.Windows.Forms.Button();
            this.btn_admin_refresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.data_admin_salarie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_admin_ligue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_admin_salle)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_admin_salarie
            // 
            this.lbl_admin_salarie.AutoSize = true;
            this.lbl_admin_salarie.Location = new System.Drawing.Point(12, 9);
            this.lbl_admin_salarie.Name = "lbl_admin_salarie";
            this.lbl_admin_salarie.Size = new System.Drawing.Size(101, 13);
            this.lbl_admin_salarie.TabIndex = 1;
            this.lbl_admin_salarie.Text = "Gestion des salariés";
            // 
            // btn_admin_salarie_add
            // 
            this.btn_admin_salarie_add.Location = new System.Drawing.Point(12, 412);
            this.btn_admin_salarie_add.Name = "btn_admin_salarie_add";
            this.btn_admin_salarie_add.Size = new System.Drawing.Size(71, 37);
            this.btn_admin_salarie_add.TabIndex = 2;
            this.btn_admin_salarie_add.Text = "Ajouter";
            this.btn_admin_salarie_add.UseVisualStyleBackColor = true;
            this.btn_admin_salarie_add.Click += new System.EventHandler(this.btn_admin_salarie_add_Click);
            // 
            // btn_admin_salarie_remove
            // 
            this.btn_admin_salarie_remove.Location = new System.Drawing.Point(592, 412);
            this.btn_admin_salarie_remove.Name = "btn_admin_salarie_remove";
            this.btn_admin_salarie_remove.Size = new System.Drawing.Size(71, 37);
            this.btn_admin_salarie_remove.TabIndex = 3;
            this.btn_admin_salarie_remove.Text = "Supprimer";
            this.btn_admin_salarie_remove.UseVisualStyleBackColor = true;
            this.btn_admin_salarie_remove.Click += new System.EventHandler(this.btn_admin_salarie_remove_Click);
            // 
            // btn_admin_salarie_modif
            // 
            this.btn_admin_salarie_modif.Location = new System.Drawing.Point(89, 412);
            this.btn_admin_salarie_modif.Name = "btn_admin_salarie_modif";
            this.btn_admin_salarie_modif.Size = new System.Drawing.Size(71, 37);
            this.btn_admin_salarie_modif.TabIndex = 4;
            this.btn_admin_salarie_modif.Text = "Modifier";
            this.btn_admin_salarie_modif.UseVisualStyleBackColor = true;
            this.btn_admin_salarie_modif.Click += new System.EventHandler(this.btn_admin_salarie_modif_Click);
            // 
            // data_admin_salarie
            // 
            this.data_admin_salarie.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
            this.data_admin_salarie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_admin_salarie.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numéro_salarié,
            this.Nom,
            this.Prénom,
            this.Ligue,
            this.Salle});
            this.data_admin_salarie.Location = new System.Drawing.Point(12, 25);
            this.data_admin_salarie.MultiSelect = false;
            this.data_admin_salarie.Name = "data_admin_salarie";
            this.data_admin_salarie.ReadOnly = true;
            this.data_admin_salarie.RowHeadersWidth = 51;
            this.data_admin_salarie.Size = new System.Drawing.Size(652, 381);
            this.data_admin_salarie.TabIndex = 5;
            // 
            // Numéro_salarié
            // 
            this.Numéro_salarié.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Numéro_salarié.HeaderText = "Numéro";
            this.Numéro_salarié.MinimumWidth = 6;
            this.Numéro_salarié.Name = "Numéro_salarié";
            this.Numéro_salarié.ReadOnly = true;
            this.Numéro_salarié.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Numéro_salarié.Visible = false;
            // 
            // Nom
            // 
            this.Nom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nom.HeaderText = "Nom";
            this.Nom.MinimumWidth = 6;
            this.Nom.Name = "Nom";
            this.Nom.ReadOnly = true;
            this.Nom.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Prénom
            // 
            this.Prénom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Prénom.HeaderText = "Prénom";
            this.Prénom.MinimumWidth = 6;
            this.Prénom.Name = "Prénom";
            this.Prénom.ReadOnly = true;
            this.Prénom.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Ligue
            // 
            this.Ligue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ligue.HeaderText = "Ligue";
            this.Ligue.MinimumWidth = 6;
            this.Ligue.Name = "Ligue";
            this.Ligue.ReadOnly = true;
            this.Ligue.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Salle
            // 
            this.Salle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Salle.HeaderText = "Salle";
            this.Salle.MinimumWidth = 6;
            this.Salle.Name = "Salle";
            this.Salle.ReadOnly = true;
            this.Salle.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // data_admin_ligue
            // 
            this.data_admin_ligue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_admin_ligue.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numéro,
            this.Intitulé});
            this.data_admin_ligue.Location = new System.Drawing.Point(670, 25);
            this.data_admin_ligue.MultiSelect = false;
            this.data_admin_ligue.Name = "data_admin_ligue";
            this.data_admin_ligue.ReadOnly = true;
            this.data_admin_ligue.RowHeadersWidth = 51;
            this.data_admin_ligue.Size = new System.Drawing.Size(245, 129);
            this.data_admin_ligue.TabIndex = 6;
            // 
            // Numéro
            // 
            this.Numéro.HeaderText = "Numéro";
            this.Numéro.MinimumWidth = 6;
            this.Numéro.Name = "Numéro";
            this.Numéro.ReadOnly = true;
            this.Numéro.Visible = false;
            this.Numéro.Width = 125;
            // 
            // Intitulé
            // 
            this.Intitulé.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Intitulé.HeaderText = "Intitulé";
            this.Intitulé.MinimumWidth = 6;
            this.Intitulé.Name = "Intitulé";
            this.Intitulé.ReadOnly = true;
            // 
            // data_admin_salle
            // 
            this.data_admin_salle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_admin_salle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numéro_salle,
            this.Localisation});
            this.data_admin_salle.Location = new System.Drawing.Point(670, 284);
            this.data_admin_salle.MultiSelect = false;
            this.data_admin_salle.Name = "data_admin_salle";
            this.data_admin_salle.ReadOnly = true;
            this.data_admin_salle.RowHeadersWidth = 51;
            this.data_admin_salle.Size = new System.Drawing.Size(245, 122);
            this.data_admin_salle.TabIndex = 7;
            // 
            // Numéro_salle
            // 
            this.Numéro_salle.HeaderText = "Numéro de salle";
            this.Numéro_salle.MinimumWidth = 6;
            this.Numéro_salle.Name = "Numéro_salle";
            this.Numéro_salle.ReadOnly = true;
            this.Numéro_salle.Visible = false;
            this.Numéro_salle.Width = 125;
            // 
            // Localisation
            // 
            this.Localisation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Localisation.HeaderText = "Localisation";
            this.Localisation.MinimumWidth = 6;
            this.Localisation.Name = "Localisation";
            this.Localisation.ReadOnly = true;
            // 
            // lbl_admin_ligue
            // 
            this.lbl_admin_ligue.AutoSize = true;
            this.lbl_admin_ligue.Location = new System.Drawing.Point(667, 9);
            this.lbl_admin_ligue.Name = "lbl_admin_ligue";
            this.lbl_admin_ligue.Size = new System.Drawing.Size(93, 13);
            this.lbl_admin_ligue.TabIndex = 8;
            this.lbl_admin_ligue.Text = "Gestion des ligues";
            // 
            // lbl_admin_salle
            // 
            this.lbl_admin_salle.AutoSize = true;
            this.lbl_admin_salle.Location = new System.Drawing.Point(667, 268);
            this.lbl_admin_salle.Name = "lbl_admin_salle";
            this.lbl_admin_salle.Size = new System.Drawing.Size(92, 13);
            this.lbl_admin_salle.TabIndex = 9;
            this.lbl_admin_salle.Text = "Gestion des salles";
            // 
            // btn_admin_salle_modif
            // 
            this.btn_admin_salle_modif.Location = new System.Drawing.Point(747, 412);
            this.btn_admin_salle_modif.Name = "btn_admin_salle_modif";
            this.btn_admin_salle_modif.Size = new System.Drawing.Size(71, 37);
            this.btn_admin_salle_modif.TabIndex = 12;
            this.btn_admin_salle_modif.Text = "Modifier";
            this.btn_admin_salle_modif.UseVisualStyleBackColor = true;
            this.btn_admin_salle_modif.Click += new System.EventHandler(this.btn_admin_salle_modif_Click);
            // 
            // btn_admin_salle_remove
            // 
            this.btn_admin_salle_remove.Location = new System.Drawing.Point(844, 412);
            this.btn_admin_salle_remove.Name = "btn_admin_salle_remove";
            this.btn_admin_salle_remove.Size = new System.Drawing.Size(71, 37);
            this.btn_admin_salle_remove.TabIndex = 11;
            this.btn_admin_salle_remove.Text = "Supprimer";
            this.btn_admin_salle_remove.UseVisualStyleBackColor = true;
            this.btn_admin_salle_remove.Click += new System.EventHandler(this.btn_admin_salle_remove_Click);
            // 
            // btn_admin_salle_add
            // 
            this.btn_admin_salle_add.Location = new System.Drawing.Point(670, 412);
            this.btn_admin_salle_add.Name = "btn_admin_salle_add";
            this.btn_admin_salle_add.Size = new System.Drawing.Size(71, 37);
            this.btn_admin_salle_add.TabIndex = 10;
            this.btn_admin_salle_add.Text = "Ajouter";
            this.btn_admin_salle_add.UseVisualStyleBackColor = true;
            this.btn_admin_salle_add.Click += new System.EventHandler(this.btn_admin_salle_add_Click);
            // 
            // btn_admin_ligue_modif
            // 
            this.btn_admin_ligue_modif.Location = new System.Drawing.Point(747, 160);
            this.btn_admin_ligue_modif.Name = "btn_admin_ligue_modif";
            this.btn_admin_ligue_modif.Size = new System.Drawing.Size(71, 37);
            this.btn_admin_ligue_modif.TabIndex = 15;
            this.btn_admin_ligue_modif.Text = "Modifier";
            this.btn_admin_ligue_modif.UseVisualStyleBackColor = true;
            this.btn_admin_ligue_modif.Click += new System.EventHandler(this.btn_admin_ligue_modif_Click);
            // 
            // btn_admin_ligue_suppr
            // 
            this.btn_admin_ligue_suppr.Location = new System.Drawing.Point(844, 160);
            this.btn_admin_ligue_suppr.Name = "btn_admin_ligue_suppr";
            this.btn_admin_ligue_suppr.Size = new System.Drawing.Size(71, 37);
            this.btn_admin_ligue_suppr.TabIndex = 14;
            this.btn_admin_ligue_suppr.Text = "Supprimer";
            this.btn_admin_ligue_suppr.UseVisualStyleBackColor = true;
            this.btn_admin_ligue_suppr.Click += new System.EventHandler(this.btn_admin_ligue_suppr_Click);
            // 
            // btn_admin_ligue_add
            // 
            this.btn_admin_ligue_add.Location = new System.Drawing.Point(670, 160);
            this.btn_admin_ligue_add.Name = "btn_admin_ligue_add";
            this.btn_admin_ligue_add.Size = new System.Drawing.Size(71, 37);
            this.btn_admin_ligue_add.TabIndex = 13;
            this.btn_admin_ligue_add.Text = "Ajouter";
            this.btn_admin_ligue_add.UseVisualStyleBackColor = true;
            this.btn_admin_ligue_add.Click += new System.EventHandler(this.btn_admin_ligue_add_Click);
            // 
            // btn_admin_deconnexion
            // 
            this.btn_admin_deconnexion.Location = new System.Drawing.Point(824, 476);
            this.btn_admin_deconnexion.Name = "btn_admin_deconnexion";
            this.btn_admin_deconnexion.Size = new System.Drawing.Size(91, 37);
            this.btn_admin_deconnexion.TabIndex = 16;
            this.btn_admin_deconnexion.Text = "Déconnexion";
            this.btn_admin_deconnexion.UseVisualStyleBackColor = true;
            this.btn_admin_deconnexion.Click += new System.EventHandler(this.btn_admin_deconnexion_Click);
            // 
            // btn_admin_refresh
            // 
            this.btn_admin_refresh.Location = new System.Drawing.Point(12, 476);
            this.btn_admin_refresh.Name = "btn_admin_refresh";
            this.btn_admin_refresh.Size = new System.Drawing.Size(91, 37);
            this.btn_admin_refresh.TabIndex = 17;
            this.btn_admin_refresh.Text = "Actualiser";
            this.btn_admin_refresh.UseVisualStyleBackColor = true;
            this.btn_admin_refresh.Click += new System.EventHandler(this.btn_admin_refresh_Click);
            // 
            // Administrateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 525);
            this.Controls.Add(this.btn_admin_refresh);
            this.Controls.Add(this.btn_admin_deconnexion);
            this.Controls.Add(this.btn_admin_ligue_modif);
            this.Controls.Add(this.btn_admin_ligue_suppr);
            this.Controls.Add(this.btn_admin_ligue_add);
            this.Controls.Add(this.btn_admin_salle_modif);
            this.Controls.Add(this.btn_admin_salle_remove);
            this.Controls.Add(this.btn_admin_salle_add);
            this.Controls.Add(this.lbl_admin_salle);
            this.Controls.Add(this.lbl_admin_ligue);
            this.Controls.Add(this.data_admin_salle);
            this.Controls.Add(this.data_admin_ligue);
            this.Controls.Add(this.data_admin_salarie);
            this.Controls.Add(this.btn_admin_salarie_modif);
            this.Controls.Add(this.btn_admin_salarie_remove);
            this.Controls.Add(this.btn_admin_salarie_add);
            this.Controls.Add(this.lbl_admin_salarie);
            this.MaximumSize = new System.Drawing.Size(942, 564);
            this.MinimumSize = new System.Drawing.Size(942, 564);
            this.Name = "Administrateur";
            this.Text = "Administrateur";
            this.Shown += new System.EventHandler(this.Administrateur_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Administrateur_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.data_admin_salarie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_admin_ligue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.data_admin_salle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbl_admin_salarie;
        private System.Windows.Forms.Button btn_admin_salarie_add;
        private System.Windows.Forms.Button btn_admin_salarie_remove;
        private System.Windows.Forms.Button btn_admin_salarie_modif;
        private System.Windows.Forms.DataGridView data_admin_ligue;
        private System.Windows.Forms.DataGridView data_admin_salle;
        private System.Windows.Forms.Label lbl_admin_ligue;
        private System.Windows.Forms.Label lbl_admin_salle;
        private System.Windows.Forms.Button btn_admin_salle_modif;
        private System.Windows.Forms.Button btn_admin_salle_remove;
        private System.Windows.Forms.Button btn_admin_salle_add;
        private System.Windows.Forms.Button btn_admin_ligue_modif;
        private System.Windows.Forms.Button btn_admin_ligue_suppr;
        private System.Windows.Forms.Button btn_admin_ligue_add;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numéro_salarié;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prénom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ligue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Salle;
        internal System.Windows.Forms.DataGridView data_admin_salarie;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numéro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Intitulé;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numéro_salle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Localisation;
        private System.Windows.Forms.Button btn_admin_deconnexion;
        private System.Windows.Forms.Button btn_admin_refresh;
    }
}