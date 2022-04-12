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
    public partial class modifSalarie : Form
    {
        database db = new database();
        private string[,] verifLogin;
        private string[,] listLigue;
        private string[,] listSalle;
        private bool loginNonUnique = false;
        private string [,] returnValue;
        int index_ligue = -1;
        int index_salle = -1;
        public modifSalarie(string [,] tabDonnees, string type)
        {
            InitializeComponent();
            returnValue = new string[1, 8];
            // Incrémentation des valeurs du formulaire avec les données du salariés choisi
            txt_add_nom.Text = tabDonnees[0, 1];
            txt_add_prenom.Text = tabDonnees[0, 2];
            txt_add_login.Text = tabDonnees[0, 3];
            txt_add_password.Text = tabDonnees[0, 4];
            returnValue[0, 5] = tabDonnees[0, 4];

            db.dbConnect();
            // Création des listes des ligues et des salles en listBox
            cho_add_ligue.Items.Clear();
            cho_add_salle.Items.Clear();
            listLigue = db.dbQuery("SELECT l.id, l.intitule FROM ligue l;");
            listSalle = db.dbQuery("SELECT s.id, s.localisation FROM salle s;");
            for (int i = 0; i < listLigue.GetLength(0); i++)
            {
                cho_add_ligue.Items.Add(listLigue[i, 1]);
            }
            for (int i = 0; i < listSalle.GetLength(0); i++)
            {
                cho_add_salle.Items.Add(listSalle[i, 1]);
            }
            db.dbDisconnect();

            // Recherche de la ligue du salarié dans la listbox
            for (int i = 0; i < listLigue.GetLength(0); i++)
            {
                if (listLigue[i, 0] == tabDonnees[0, 5])
                {
                    index_ligue = cho_add_ligue.FindString(listLigue[i, 1]);
                }
            }
            // Selection de l'objet ou message d'erreur
            if (type == "modif" && index_ligue == -1)
            {
                MessageBox.Show("Le salarié ne possède pas de ligue.", "Attention");
            }
            else if(type == "modif")
            {
                cho_add_ligue.SetSelected(index_ligue, true);
            }
            // Recherche de la salle du salarié dans la listBox
            for (int i = 0; i < listSalle.GetLength(0); i++)
            {
                if (listSalle[i, 0] == tabDonnees[0, 6])
                {
                    index_salle = cho_add_salle.FindString(listSalle[i, 1]);
                }
            }
            // Selection de l'objet ou message d'erreur
            if (type == "modif" && index_salle == -1)
            {
                MessageBox.Show("Le salarié ne possède pas de salle.", "Attention");
            }
            else if(type == "modif")
            {
                cho_add_salle.SetSelected(index_salle, true);
            }
            
            // Stockage de l'id du salarié dans le tableau de renvoi
            
            returnValue[0, 1] = tabDonnees[0, 0];
        }

        private void btn_add_confirm_Click(object sender, EventArgs e)
        {
            db.dbConnect();
            if (txt_add_password.Text != "" && txt_add_nom.Text != "" && txt_add_prenom.Text != "" && txt_add_login.Text != "")
            {
                // Vérification des logins existants par une boucle 
                verifLogin = db.dbQuery("SELECT u.login FROM utilisateur u;");
                for (int i = 0; i < verifLogin.GetLength(0); i++)
                {
                    if (txt_add_login.Text == verifLogin[i, 0])
                    {
                        loginNonUnique = true;
                    }
                }
                // Ajout des valeurs de champs au tableau de retour
                this.returnValue[0, 2] = txt_add_nom.Text;
                this.returnValue[0, 3] = txt_add_prenom.Text;
                this.returnValue[0, 4] = txt_add_login.Text;
                // Vérification du changement de mot de passe
                if (txt_add_password.Text != returnValue[0,5])
                {
                    this.returnValue[0, 5] = db.GetHashPassword(txt_add_password.Text);
                }
                // Aller chercher l'id de la ligue et de la salle pour les rajouter a l'employé :
                if (cho_add_salle.SelectedItem != null)
                {
                    for (int i = 0; i < listSalle.GetLength(0); i++)
                    {
                        if (cho_add_salle.SelectedItem.ToString() == listSalle[i, 1])
                        {
                            this.returnValue[0, 7] = listSalle[i, 0];
                        }
                    }
                }
                if (cho_add_ligue.SelectedItem != null)
                {
                    for (int i = 0; i < listLigue.GetLength(0); i++)
                    {
                        if (cho_add_ligue.SelectedItem.ToString() == listLigue[i, 1])
                        {
                            this.returnValue[0, 6] = listLigue[i, 0];
                        }
                    }
                }
                if (!loginNonUnique)// Si le login est unique alors :
                {
                    // Si on ajoute le salarié
                    if (this.Text == "Ajouter salarié")
                    {
                        // Ajout d'utilisateur
                        returnValue[0, 0] = "ajoutUser";
                        db.updateDB(returnValue);
                        this.Close();
                        this.Dispose();
                    }
                    // Si on modifier le salarié
                    if (this.Text == "Modifier salarié")
                    {
                        // Modification de l'utilisateur
                        returnValue[0, 0] = "modifUser";
                        db.updateDB(returnValue);
                        this.Close();
                        this.Dispose();
                    }
                }
                else
                {
                    MessageBox.Show("Ce login existe déja.", "Attention");
                    loginNonUnique = false;
                } 
            }
            else
            {
                MessageBox.Show("Les valeurs des champs Nom, Prénom, Login et Password ne peuvent être vides.", "Attention");
            }
            db.dbDisconnect();
        }

        private void btn_add_annule_Click(object sender, EventArgs e)
        {
            // Fermeture sans envoi en bdd
            this.Close();
            this.Dispose();
        }
    }
}
