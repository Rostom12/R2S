using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace R2S
{   
    class database
    {
        // Appel de la classe password pour les hachages :
        // On créer la chaine de caractère de connexion à la BDD
        static string strConnection = "server=127.0.0.1;password='';uid=root;database=r2s";
        // Instanciation des différentes variables nécessaire au SQL.
        MySqlConnection sqlConnection = new MySqlConnection(strConnection);
        MySqlCommand sqlCommand = new MySqlCommand();
        MySqlDataReader sqlDataR;
        MySqlTransaction sqlTransaction;
        public database()
        {

        }

        public void dbConnect()
        {
            try
            {
                // Connexion SQL a la base de donnée
                sqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Attention");
            }
        }

        public void dbDisconnect()
        {
            sqlConnection.Close();
        }

        public int userCertif(string strQuery, TextBox tbLogin, TextBox tbPassword)
        {
            int connecte = 0;
            // Set des valeurs de sqlCommand pour créer le lecteur sqlDataR
            try
            {
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = strQuery;
                // Mettre un booléen pour gérer le cas ou la chaine de connexion à la db est fausse
                sqlDataR = sqlCommand.ExecuteReader();
                // Boucle pour lire toutes les lignes de la bdd
                while (sqlDataR.Read())
                {
                    if (sqlDataR.GetValue(0).ToString() == tbLogin.Text && sqlDataR.GetValue(1).ToString() == GetHashPassword(tbPassword.Text) && sqlDataR.GetValue(3).ToString() == "2")
                    {
                        connecte = 2;
                        break;
                    }
                    if (sqlDataR.GetValue(0).ToString() == tbLogin.Text && sqlDataR.GetValue(1).ToString() == GetHashPassword(tbPassword.Text) && sqlDataR.GetValue(3).ToString() == "1")
                    {
                        connecte = 1;
                        break;
                    }
                }
                sqlDataR.Dispose();
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Errreur de connexion", "Attention");
                connecte = -1;
            }
            return connecte;
        }

        public int numRow(string strQuery)
        {
            // Attention : ne fonctionne pas avec les insert into -> rajouter une condition
            int x;
            // Boucle pour modifier la requete
            for (int i = 0; i < strQuery.Count(); i++)
            {
                if (strQuery[i].ToString() == " ")
                {
                    if (strQuery.Substring(i,2) == " *")
                    {
                        strQuery = "SELECT count(*) " + strQuery.Substring(i+2, (strQuery.Length - i-2));
                        break;
                    }
                    strQuery = "SELECT count(*)," + strQuery.Substring(i, (strQuery.Length - i));
                    break;
                }
            }
            // Etablissement de la requete
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = strQuery;
            sqlDataR = sqlCommand.ExecuteReader();
            sqlDataR.Read();
            // Fonctionne si il n'y a qu'une seule ligne ?
            x = sqlDataR.GetInt32(0);
            // Libération de la requete
            sqlCommand.Dispose();
            sqlDataR.Dispose();
            return x;
        }
        public string[,] dbQuery(string strQuery)
        {
            int y = numRow(strQuery);
            // On crée la connection a la base de donnée avec la requete nécessaire en paramètre
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = strQuery;
            sqlDataR = sqlCommand.ExecuteReader();

            // On créé le tableau adapté a la taille de la requete
            // A mettre ce chiffre dans le tableau
            string[,] queryReturn = new string[y, sqlDataR.FieldCount];
            int x = 0;
            while (sqlDataR.Read())
            {
                for (int i = 0; i < sqlDataR.FieldCount; i++)
                {
                    queryReturn[x, i] = sqlDataR.GetValue(i).ToString();
                }
                x++;
            }
            sqlDataR.Dispose();
            sqlCommand.Dispose();
            return queryReturn;
        }

        public string GetHashPassword(string input)
        {
            string strPassword;

            // Création de l'objet de hachage
            MD5 md5 = MD5.Create();
            // Encodage UTF-8 de la valeur input 
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            // Boucle pour accrémenter le stringbuilder avec les bytes de data
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Passation du builder dans une variable qu'on retourne
            strPassword = sBuilder.ToString();
            // Décharge des données de la classe
            md5.Dispose();
            sBuilder.Remove(0, sBuilder.Length - 1);
            return strPassword;
        }

        public void ShowData(DataGridView gridView, string query)
        {
            // Vidage de la grille de donnée
            gridView.Rows.Clear();
            // Création de la requete
            string [,] strQuery = dbQuery(query);
            // Double boucle pour créer la datagridview désirée
            for (int i = 0; i < strQuery.GetLength(0); i++)
            {
                gridView.Rows.Add();
                for (int j = 0; j < strQuery.GetLength(1); j++)
                {
                    gridView.Rows[i].Cells[j].Value = strQuery[i, j];
                }
            }
        }

        public void updateDB(string [,] nonQuery)
        {
            // Commencer la transaction
            sqlTransaction = sqlConnection.BeginTransaction();
            // Essayer les étapes
            try
            {
                sqlCommand.Connection = sqlConnection;
                // Affectation de la transaction a notre commande
                sqlCommand.Transaction = sqlTransaction;
                // Choix du texte de la requete en fonction du tableau recu
                /* Case 0 du tableau -> case du switch
                 * Case 1 du tableau -> id de la donnée
                 */
                switch (nonQuery[0,0])
                {
                    case "modifUser":
                        sqlCommand.CommandText = "UPDATE utilisateur " +
                                                "SET nom = " + '"'+nonQuery[0, 2]+ '"' + ", prenom = " + '"' + nonQuery[0, 3] +
                                                '"' + ", login = " + '"' + nonQuery[0, 4] + '"' + ", password = " + '"' + nonQuery[0, 5] + '"' + 
                                                 ((nonQuery[0, 6] == null || nonQuery[0, 6] == "") ? "" : ", id_ligue = " + '"' + nonQuery[0, 6] + '"')  + ((nonQuery[0, 7] == null || nonQuery[0, 7] == "") ? "" : ", id_salle = " + '"' + nonQuery[0, 7] + '"')  + 
                                                " WHERE utilisateur.id = " + '"' + nonQuery[0, 1] + '"' + ";";
                        break;
                    case "ajoutUser":
                        sqlCommand.CommandText = "INSERT INTO utilisateur(nom, prenom, login, password " +
                                                ((nonQuery[0, 6] == null || nonQuery[0, 6] == "") ? "" : ", id_ligue") +
                                                ((nonQuery[0, 7] == null || nonQuery[0, 7] == "") ? "" : ", id_salle") +
                                                ", id_groupe_utilisateur) " +
                                                "VALUES (" + '"' + nonQuery[0, 2] + '"' + ", " + '"' + nonQuery[0, 3] + '"' + ", " +
                                                '"' + nonQuery[0, 4] + '"' + ", " + '"' + nonQuery[0, 5] + '"' +
                                                ((nonQuery[0, 6] == null || nonQuery[0, 6] == "") ? "" : ", "+'"' + nonQuery[0, 6] + '"') +
                                                ((nonQuery[0, 7] == null || nonQuery[0, 7] == "") ? "" : ", "+'"' + nonQuery[0, 7] + '"') +
                                                ", " + '"' + 2 + '"' + ");";
                        break;
                    case "supprSalarie": 
                        sqlCommand.CommandText = "DELETE FROM reservation WHERE reservation.id_utilisateur = " + '"' + nonQuery[0, 1] + '"' + ";";
                        sqlCommand.ExecuteNonQuery(); // Suppression des réservations de l'utilisateur
                        sqlCommand.CommandText = "DELETE FROM utilisateur " +
                                                "WHERE utilisateur.id = " + '"' + nonQuery[0, 1] + '"' + ";";
                        break;
                    case "ajoutLigue":
                        sqlCommand.CommandText = "INSERT INTO ligue(intitule) VALUES (" + '"' + nonQuery[0, 2] + '"' + ");";
                        break;
                    case "modifLigue":
                        sqlCommand.CommandText = "UPDATE ligue " +
                                                "SET intitule = " + '"' + nonQuery[0, 2] + '"' +
                                                " WHERE ligue.id = " + '"' + nonQuery[0, 1] + '"' + ";";
                        break;
                    case "supprLigue":
                        sqlCommand.CommandText = "UPDATE utilisateur SET id_ligue = " + "NULL " + 
                                                "WHERE utilisateur.id_ligue = " + '"' + nonQuery[0, 1] + '"' + ";";
                        sqlCommand.ExecuteNonQuery();// Update des utilisateur a la suppression d'une ligue
                        sqlCommand.CommandText = "DELETE FROM ligue " +
                                                "WHERE ligue.id = " + '"' + nonQuery[0, 1] + '"' + ";";
                        break;
                    case "ajoutSalle":
                        sqlCommand.CommandText = "INSERT INTO salle(localisation) VALUES (" + '"' + nonQuery[0, 2] + '"' + ");";
                        break;
                    case "modifSalle":
                        sqlCommand.CommandText = "UPDATE salle " +
                                                "SET localisation = " + '"' + nonQuery[0, 2] + '"' +
                                                " WHERE salle.id = " + '"' + nonQuery[0, 1] + '"' + ";";
                        break;
                    case "supprSalle": 
                        sqlCommand.CommandText = "DELETE FROM reservation WHERE reservation.id_salle = " + '"' + nonQuery[0, 1] + '"' + ";"; 
                        sqlCommand.ExecuteNonQuery();// Suppresion des réservation lié a la salle supprimée
                        sqlCommand.CommandText = "UPDATE utilisateur SET id_salle = " + "NULL " + "WHERE id_salle = " + '"' + nonQuery[0, 1] + '"' + ";";
                        sqlCommand.ExecuteNonQuery();// Update des utilisateurs lié a la salle supprimée
                        sqlCommand.CommandText = "DELETE FROM salle " +
                                                "WHERE salle.id = " + '"' + nonQuery[0, 1] + '"' + ";";
                        break;
                    case "ajoutResa":
                        sqlCommand.CommandText = "INSERT INTO reservation (raison, date_debut, date_fin, id_utilisateur, id_salle) " +
                                                "VALUES (" + '"' + nonQuery[0, 1] + '"' + ", " + '"' + nonQuery[0, 2] + '"' + ", " + '"' + nonQuery[0, 3] + '"' +
                                                ", " + '"' + nonQuery[0, 4] + '"' + ", " + '"' + nonQuery[0, 5] + '"' + ");";
                        break;
                    case "supprResa":
                        sqlCommand.CommandText = "DELETE FROM reservation " +
                                                "WHERE reservation.id = " + '"' + nonQuery[0, 1] + '"' + ";";
                        break;
                    default:
                        MessageBox.Show("Erreur lors de l'écriture. Contactez votre administrateur", "Attention");
                        break;
                }
                // Envoi de la requete en BDD
                sqlCommand.ExecuteNonQuery();
                sqlTransaction.Commit();
            } // Sinon arreter la transaction
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString(), "Attention");
                sqlTransaction.Rollback();
            }
            // Supprimer la commande
            sqlCommand.Dispose();
        }

        public void ajouterSalarie()
        {
            // Création d'un tableau de donnée vide pour initialiser le form d'ajout
            string[,] tabDonnée;
            tabDonnée = new string[1, 8];
            // Création et visualisation du form
            modifSalarie add = new modifSalarie(tabDonnée, "ajout");
            add.Text = "Ajouter salarié";
            add.ShowDialog();
        }
        public void modifierSalarie(string idUser)
        {
            // Ouverture de la connexion
            dbConnect();
            // Création de la fenetre modification avec insertion des informations du salariés selectionné dans la dataGridView
            modifSalarie modif = new modifSalarie(dbQuery("SELECT u.id, u.nom, u.prenom, u.login, u.password, u.id_ligue, u.id_salle " +
                                                            "FROM utilisateur u " +
                                                            "WHERE u.id =" + '"' + idUser + '"' + ";"), "modif");
            modif.Text = "Modifier salarié";
            dbDisconnect();
            modif.ShowDialog();
        }

        public void supprSalarie(string idUser)
        {
            dbConnect();
            supprLigueSalleSalarie supprSalarie = new supprLigueSalleSalarie(dbQuery("SELECT u.id, u.nom, u.prenom " +
                                                                                        "FROM utilisateur u " +
                                                                                        "WHERE u.id = " + '"' + idUser + '"' + ";"));
            supprSalarie.Text = "Supprimer Salarié";
            dbDisconnect();
            supprSalarie.ShowDialog();
        }

        public void ajouterLigue()
        {
            // Création d'un tableau vide pour instancier le form
            string[,] tabDonnee;
            tabDonnee = new string[1, 2];
            // Création et affichage du form
            modifLigueSalle addLigue = new modifLigueSalle(tabDonnee);
            addLigue.Text = "Ajouter Ligue";
            addLigue.ShowDialog();
        }

        public void modifierLigue(string idLigue)
        {
            dbConnect();
            // Création et affichage du form avec comme référence une requete avec comme id cible la ligne du tableau sélectionner
            modifLigueSalle modifLigue = new modifLigueSalle(dbQuery("SELECT l.id, l.intitule " +
                                                        "FROM ligue l " +
                                                        "WHERE l.id = " + '"' + idLigue + '"' + ";"));
            modifLigue.Text = "Modifier Ligue";
            dbDisconnect();
            modifLigue.ShowDialog();
        }

        public void supprLigue(string idLigue)
        {
            dbConnect();
            supprLigueSalleSalarie supprLigue = new supprLigueSalleSalarie(dbQuery("SELECT l.id, l.intitule " +
                                                                                    "FROM ligue l " +
                                                                                    "WHERE l.id = " + '"' + idLigue + '"' + ";"));
            dbDisconnect();
            supprLigue.Text = "Supprimer Ligue";
            supprLigue.ShowDialog();
        }

        public void ajouterSalle()
        {
            // Création d'un tableau vide pour instancier le form
            string[,] tabDonnee;
            tabDonnee = new string[1, 2];
            // Création et affichage du form
            modifLigueSalle ajoutSalle = new modifLigueSalle(tabDonnee);
            ajoutSalle.Text = "Ajouter Salle";
            ajoutSalle.ShowDialog();
        }

        public void modifierSalle(string idSalle)
        {
            dbConnect();
            // Création et affichage du form avec comme référence une requete avec comme id cible la ligne du tableau sélectionner
            modifLigueSalle modifSalle = new modifLigueSalle(dbQuery("SELECT s.id, s.localisation " +
                                                        "FROM salle s " +
                                                        "WHERE s.id = " + '"' + idSalle + '"' + ";"));
            modifSalle.Text = "Modifier Salle";
            dbDisconnect();
            modifSalle.ShowDialog();
        }

        public void supprSalle(string idSalle)
        {
            dbConnect();
            supprLigueSalleSalarie supprSalle = new supprLigueSalleSalarie(dbQuery("SELECT s.id, s.localisation " +
                                                                                    "FROM salle s " +
                                                                                    "WHERE s.id = " + '"' + idSalle + '"' + ";"));
            dbDisconnect();
            supprSalle.Text = "Supprimer Salle";
            supprSalle.ShowDialog();
        }
    }
}
