using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace R2S
{
    public partial class modifReservation : Form
    {
        string[,] envoiBDD = new string[1, 2];
        database db = new database();
        public modifReservation(string [,] input, bool btn)
        {
            InitializeComponent();
            /* Incrémentation du tableau de donnée pour le form de suppression
             * 0 -> raison ; 1 -> Identité du créateur ; 2 -> Salle concernée ; 3 -> Ligue concernée ; 
             * 4 -> Jour ; 5 -> Heure de fin ; 6 -> Heure de début ; 7 -> id_reservation
             */

            lbl_nom_result.Text = input[0, 1];
            lbl_ligue_result.Text = input[0, 3];
            lbl_raison_result.Text = input[0, 0];
            lbl_salle_result.Text = input[0, 2];
            lbl_heure_debut_result.Text = input[0, 6];
            lbl_heure_fin_result.Text = input[0, 5];
            lbl_jour_result.Text = input[0, 4];
            envoiBDD[0, 1] = input[0, 7];

            // Si c'est vrai, la réservation appartient a l'employé
            if (btn)
            {
                btn_return.Visible = false;
            }
            else
            {
                btn_cancel.Visible = false;
                btn_suppr.Visible = false;
            }
        }

        private void btn_return_Click(object sender, EventArgs e)
        {
            // Retour de la part des utilisateur qui regarde seulement le détail
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            this.Dispose();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            // Retour sans envoi en BDD de la part du propriétaire de la réservation
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            this.Dispose();
        }

        private void btn_suppr_Click(object sender, EventArgs e)
        {
            // Envoit en BDD et fermeture
            envoiBDD[0, 0] = "supprResa";
            db.dbConnect();
            db.updateDB(envoiBDD);
            db.dbDisconnect();
            this.DialogResult = DialogResult.OK;
            this.Close();
            this.Dispose();
        }
    }
}
