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
    public partial class modifLigueSalle : Form
    {
        database db = new database();
        string[,] verifIntitule;
        string[,] returnValue;
        bool intituleNonUnique = false;
        public modifLigueSalle(string [,] tabDonnee)
        {
            InitializeComponent();
            returnValue = new string[1, 3];
            txt_modif_ligueSalle.Text = tabDonnee[0, 1];
            returnValue[0, 1] = tabDonnee[0, 0];
        }

        private void btn_modif_ligue_ok_Click(object sender, EventArgs e)
        {
            db.dbConnect();

            if (txt_modif_ligueSalle.Text != "")
            {
                // Vérification de l'unicité de l'intitule de la ligue à créer ou modifier
                verifIntitule = db.dbQuery("SELECT l.id, l.intitule FROM ligue l;");
                for (int i = 0; i < verifIntitule.GetLength(0); i++)
                {
                    if (txt_modif_ligueSalle.Text == verifIntitule[i, 0])
                    {
                        intituleNonUnique = true;
                    }
                }
                returnValue[0, 2] = txt_modif_ligueSalle.Text;
                // VERIFIER LES DEUX IF CI-DESSOUS ---------------->
                if (this.Text == "Modifier Ligue")
                {
                    // Envoi dans le switch de la requete de modification.
                    returnValue[0, 0] = "modifLigue";
                    db.updateDB(returnValue);
                    db.dbDisconnect();
                    this.Close();
                    this.Dispose();
                }
                if (this.Text == "Ajouter Ligue")
                {
                    if (!intituleNonUnique)
                    {
                        // Envoi dans le switch de la requete de création.
                        returnValue[0, 0] = "ajoutLigue";
                        db.updateDB(returnValue);
                        db.dbDisconnect();
                        this.Close();
                        this.Dispose();
                    }
                }
                if (this.Text == "Ajouter Salle")
                {
                    // Envoi dans le switch de db
                    returnValue[0, 0] = "ajoutSalle";
                    db.updateDB(returnValue);
                    db.dbDisconnect();
                    this.Close();
                    this.Dispose();
                }
                if (this.Text == "Modifier Salle")
                {
                    returnValue[0, 0] = "modifSalle";
                    db.updateDB(returnValue);
                    db.dbDisconnect();
                    this.Close();
                    this.Dispose();
                }
            }
            else
            {
                if (this.Text == "Ajouter Ligue" || this.Text == "Modifier Ligue")
                {
                    MessageBox.Show("Le champs intitulé de votre ligue ne peux être vide", "Attention");
                }
                else
                {
                    MessageBox.Show("Le champs localisation de votre salle ne peux être vide", "Attention");
                }
                
            }

            db.dbDisconnect();
        }

        private void btn_modif_ligue_cancel_Click(object sender, EventArgs e)
        {
            // Fermeture sans envoi en BDD
            this.Close();
            this.Dispose();
        }

        private void modifLigueSalle_Load(object sender, EventArgs e)
        {
            if (this.Text == "Ajouter Salle" || this.Text == "Modifier Salle")
            {
                lbl_modif_ligueSalle.Text = "Localisation de la salle :";
            }
        }
    }
}
