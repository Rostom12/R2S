using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace R2S
{
    public partial class Connexion : Form
    {
        public Connexion()
        {
            InitializeComponent();
        }

        // Appel de la classe database pour le traitement en BDD
        database db = new database();

        private void btn_connexion_Click(object sender, EventArgs e)
        {
            string strQuery;
            string v1 = "admin";
            string v2 = "21232f297a57a5a743894a0e4a801fc3";

            // Conditions pour vérifier l'entrée de donnée dans les champs
            if (txt_login.Text != "" && txt_password.Text != "")
            {
                try
                {
                    db.dbConnect();
                    // Chaine de requete pour la vérification des utilisateurs
                    strQuery = "SELECT utilisateur.login, utilisateur.password, utilisateur.id, utilisateur.id_groupe_utilisateur, utilisateur.id_ligue, utilisateur.id_salle, utilisateur. nom, utilisateur.prenom FROM utilisateur";
                    if (db.userCertif(strQuery, txt_login, txt_password) == 2)
                    {
                        Accueil acceuil = new Accueil(db.dbQuery(strQuery + " WHERE utilisateur.login = " + '"' + v1 + '"' + " && utilisateur.password = " + '"' + v2 + '"' + ";"));
                        this.Hide();
                        acceuil.Show();
                        acceuil.FormClosed += (s, args) => this.Show();
                    }
                    if (db.userCertif(strQuery, txt_login, txt_password) == 1)
                    {
                        Administrateur administrateur = new Administrateur();
                        this.Hide();
                        administrateur.Show();
                        administrateur.FormClosed += (s, args) => this.Show();
                    }
                    if (db.userCertif(strQuery, txt_login, txt_password) == 0)
                    {
                        MessageBox.Show("Informations de connexion incorrecte.", "Attention");
                    }
                    db.dbDisconnect();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Un probleme de connexion est survenu, contactez votre administrateur réseau.", "Attention");
                }
            }
            else
            {
                MessageBox.Show("Veuillez renseigner votre nom de compte ou votre mot de passe.", "Attention");
            }
        }
    }
}
