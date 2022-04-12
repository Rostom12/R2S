namespace R2S
{
    partial class modifLigueSalle
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
            this.lbl_modif_ligueSalle = new System.Windows.Forms.Label();
            this.txt_modif_ligueSalle = new System.Windows.Forms.TextBox();
            this.btn_modif_ligueSalle_ok = new System.Windows.Forms.Button();
            this.btn_modif_ligueSalle_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_modif_ligueSalle
            // 
            this.lbl_modif_ligueSalle.AutoSize = true;
            this.lbl_modif_ligueSalle.Location = new System.Drawing.Point(66, 45);
            this.lbl_modif_ligueSalle.Name = "lbl_modif_ligueSalle";
            this.lbl_modif_ligueSalle.Size = new System.Drawing.Size(126, 17);
            this.lbl_modif_ligueSalle.TabIndex = 0;
            this.lbl_modif_ligueSalle.Text = "Intitulé de la ligue :";
            // 
            // txt_modif_ligueSalle
            // 
            this.txt_modif_ligueSalle.Location = new System.Drawing.Point(69, 74);
            this.txt_modif_ligueSalle.Name = "txt_modif_ligueSalle";
            this.txt_modif_ligueSalle.Size = new System.Drawing.Size(239, 22);
            this.txt_modif_ligueSalle.TabIndex = 1;
            // 
            // btn_modif_ligueSalle_ok
            // 
            this.btn_modif_ligueSalle_ok.Location = new System.Drawing.Point(69, 120);
            this.btn_modif_ligueSalle_ok.Name = "btn_modif_ligueSalle_ok";
            this.btn_modif_ligueSalle_ok.Size = new System.Drawing.Size(113, 30);
            this.btn_modif_ligueSalle_ok.TabIndex = 2;
            this.btn_modif_ligueSalle_ok.Text = "Confirmer";
            this.btn_modif_ligueSalle_ok.UseVisualStyleBackColor = true;
            this.btn_modif_ligueSalle_ok.Click += new System.EventHandler(this.btn_modif_ligue_ok_Click);
            // 
            // btn_modif_ligueSalle_cancel
            // 
            this.btn_modif_ligueSalle_cancel.Location = new System.Drawing.Point(195, 120);
            this.btn_modif_ligueSalle_cancel.Name = "btn_modif_ligueSalle_cancel";
            this.btn_modif_ligueSalle_cancel.Size = new System.Drawing.Size(113, 30);
            this.btn_modif_ligueSalle_cancel.TabIndex = 3;
            this.btn_modif_ligueSalle_cancel.Text = "Annuler";
            this.btn_modif_ligueSalle_cancel.UseVisualStyleBackColor = true;
            this.btn_modif_ligueSalle_cancel.Click += new System.EventHandler(this.btn_modif_ligue_cancel_Click);
            // 
            // modifLigueSalle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 196);
            this.Controls.Add(this.btn_modif_ligueSalle_cancel);
            this.Controls.Add(this.btn_modif_ligueSalle_ok);
            this.Controls.Add(this.txt_modif_ligueSalle);
            this.Controls.Add(this.lbl_modif_ligueSalle);
            this.MaximumSize = new System.Drawing.Size(401, 243);
            this.MinimumSize = new System.Drawing.Size(401, 243);
            this.Name = "modifLigueSalle";
            this.Text = "modifLigueSalle";
            this.Load += new System.EventHandler(this.modifLigueSalle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_modif_ligueSalle;
        private System.Windows.Forms.TextBox txt_modif_ligueSalle;
        private System.Windows.Forms.Button btn_modif_ligueSalle_ok;
        private System.Windows.Forms.Button btn_modif_ligueSalle_cancel;
    }
}