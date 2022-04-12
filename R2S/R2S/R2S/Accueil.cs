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
    public partial class Accueil : Form
    {
        private string[,] affichageCalendar1 = new string[12, 4];
        private string[,] affichageCalendar2 = new string[12, 4];
        private string[,] infoConnexion;
        database db = new database();
        public Accueil(string[,] infoSalarie)
        {
            InitializeComponent();
            /* Incrémentation du tableau avec les données de l'utilisateur :
             * 0 -> Login ; 1 -> Password ; 2 -> ID ; 3 -> Droit ;
             * 4 -> ID Ligue ; 5 -> ID Salle; 6 -> Nom ; 7 -> Prénom ;
             */
            infoConnexion = infoSalarie;
            this.affichageCalendrier();
            lbl_identite.Text = lbl_identite.Text + infoConnexion[0, 6] + " " + infoConnexion[0, 7];
            db.dbConnect();
            if (infoConnexion[0,4] != "")
            {
                lbl_ligue.Text = lbl_ligue.Text + db.dbQuery("SELECT l.intitule FROM ligue l WHERE l.id = " + '"' + infoConnexion[0, 4] + '"' + ";")[0, 0];
            }
            else
            {
                lbl_ligue.Text = lbl_ligue.Text + "Non attribuée";
                lbl_ligue.ForeColor = Color.Crimson;
            }
            if (infoConnexion[0, 5] != "")
            {
                lbl_salle.Text = lbl_salle.Text + db.dbQuery("SELECT s.localisation FROM salle s WHERE s.id = " + '"' + infoConnexion[0, 5] + '"' + ";")[0, 0];
            }
            else
            {
                lbl_salle.Text = lbl_salle.Text + "Non attribuée";
                lbl_salle.ForeColor = Color.Crimson;
            }
            db.dbDisconnect();
        }

        public void clickCalendar(object sender, EventArgs e)
        {
            string[,] returnValue = new string[1, 8];
            string[,] infoResaSelect = new string[1, 5];
            bool maResa = false;
            /* Incrémentation du tableau de donnée pour le form de suppression
             * 0 -> raison ; 1 -> Identité du créateur ; 2 -> Salle concernée ; 3 -> Ligue concernée ; 
             * 4 -> Jour ; 5 -> Heure de fin ; 6 -> Heure de début ; 7 -> id_reservation
             */
            // Lien entre le panel cliqué et sa nature pour accès a la méthode backcolor
            Label l = (Label) sender;
            if (l.BackColor == Color.LightGreen) // Selection du créneau horaire
            {
                l.BackColor = Color.LightBlue;
            }
            else if (l.BackColor == Color.LightBlue) // Déselection du créneaux horaire
            {
                l.BackColor = Color.LightGreen;
            }
            else if (l.BackColor == Color.Crimson)// Avertissement, créneau déja existant
            {
                // Boucle pour récupérer l'id, l'heure début et fin, et la date de la reservation selectionnée
                for (int i = int.Parse(tbl_reservation.GetRow(l).ToString()); i > 0; i--)
                {
                    if (tbl_reservation.GetControlFromPosition(int.Parse(tbl_reservation.GetColumn(l).ToString()), i).Text == l.Text && affichageCalendar1[i - 1, 0] != null && int.Parse(tbl_reservation.GetColumn(l).ToString()) == 1)
                    {
                        returnValue[0, 4] = affichageCalendar1[i - 1, 1].Substring(8, 2) + "/" + affichageCalendar1[i - 1, 1].Substring(5, 2) + "/" + affichageCalendar1[i - 1, 1].Substring(0, 4); // Date du jour
                        returnValue[0, 5] = affichageCalendar1[i - 1, 2].Substring(11, 8); // Heure de fin
                        returnValue[0, 6] = affichageCalendar1[i - 1, 1].Substring(11, 8); // Heure de début
                        returnValue[0, 7] = affichageCalendar1[i - 1, 0]; // id de la réservation
                    }
                    else if (tbl_reservation.GetControlFromPosition(int.Parse(tbl_reservation.GetColumn(l).ToString()), i).Text == l.Text && affichageCalendar2[i - 1, 0] != null && int.Parse(tbl_reservation.GetColumn(l).ToString()) == 2)
                    {
                        returnValue[0, 4] = affichageCalendar2[i - 1, 1].Substring(8, 2) + "/" + affichageCalendar2[i - 1, 1].Substring(5, 2) + "/" + affichageCalendar2[i - 1, 1].Substring(0, 4); // Date du jour
                        returnValue[0, 5] = affichageCalendar2[i - 1, 2].Substring(11, 8); // Heure de fin
                        returnValue[0, 6] = affichageCalendar2[i - 1, 1].Substring(11, 8); // Heure de début
                        returnValue[0, 7] = affichageCalendar2[i - 1, 0]; // id de la réservation
                    }
                }
                returnValue[0, 0] = l.Text; // raison de la réservation selectionnée
                db.dbConnect();
                infoResaSelect = db.dbQuery("SELECT u.nom, u.prenom, s.localisation, l.intitule, u.id " +
                                            "FROM reservation r join salle s on r.id_salle = s.id join utilisateur u on u.id_salle = s.id " +
                                            "join ligue l on u.id_ligue = l.id " +
                                            "WHERE r.id_utilisateur = u.id && r.id =" + '"' + returnValue[0, 7] + '"' + ";");
                db.dbDisconnect();
                if (infoResaSelect.Length != 0)
                {
                    returnValue[0, 1] = infoResaSelect[0, 0] + " " + infoResaSelect[0, 1];// Identité du créateur
                    returnValue[0, 2] = infoResaSelect[0, 2]; // Salle concernée
                    returnValue[0, 3] = infoResaSelect[0, 3]; // Ligue concernée
                    if (infoConnexion[0, 2] == infoResaSelect[0, 4])
                    {
                        maResa = true;
                    }

                    modifReservation modifResa = new modifReservation(returnValue, maResa);
                    modifResa.ShowDialog();
                    if (modifResa.DialogResult == DialogResult.OK)
                    {
                        affichageCalendrier();
                    }
                }
                else
                {
                    MessageBox.Show("Utilisateur non identifié, contactez votre administrateur réseau.","Attention");
                }
            }
        }

        private void accueil_calendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            // Appel de la méthode pour afficher sur le tableau la journée selectionner dans le calendrier
            this.affichageCalendrier();
        }

        public void affichageCalendrier()
        {
            Cursor = Cursors.WaitCursor;
            accueil_calendar.Enabled = false;
            // Clean des panel de couleur + clean du tableau de donnée
            int refreshTab = 0;
            for (int j = 1; j < 3; j++)
            {
                for (int i = 1; i < (affichageCalendar1.GetLength(0) + 1); i++)
                {
                    tbl_reservation.GetControlFromPosition(j, i).Text = "";
                    // Conditions pour vérifier si le jour selectionner ou le suivants sont des dimanches
                    if (accueil_calendar.SelectionStart.ToLongDateString().Substring(0, 3) == "dim" && j == 1)
                    {
                        tbl_reservation.GetControlFromPosition(j, i).BackColor = Color.LightGray;
                    }
                    else if (accueil_calendar.SelectionStart.AddDays(1).ToLongDateString().Substring(0, 3) == "dim" && j == 2)
                    {
                        tbl_reservation.GetControlFromPosition(j, i).BackColor = Color.LightGray;
                    }
                    else
                    {
                        tbl_reservation.GetControlFromPosition(j, i).BackColor = Color.LightGreen;
                    }
                    affichageCalendar1[refreshTab, 0] = null;
                    affichageCalendar1[refreshTab, 1] = null;
                    affichageCalendar1[refreshTab, 2] = null;
                    affichageCalendar1[refreshTab, 3] = null;
                    affichageCalendar2[refreshTab, 0] = null;
                    affichageCalendar2[refreshTab, 1] = null;
                    affichageCalendar2[refreshTab, 2] = null;
                    affichageCalendar2[refreshTab, 3] = null;
                    refreshTab++;
                }
                refreshTab = 0;
            }
            string[,] tabQuery;
            // Formatage SQL des dates
            //string dateSQLday1 = accueil_calendar.SelectionStart.ToShortDateString().Substring(7, 2) + "-" + accueil_calendar.SelectionStart.ToShortDateString().Substring(3, 2) + "-" + accueil_calendar.SelectionStart.ToShortDateString().Substring(0, 2);
            string dateSQLday1 = "2022-11-10";
            string dateSQLday2 = "2022-11-11";


            //string dateSQLday2 = accueil_calendar.SelectionStart.AddDays(1).ToShortDateString().Substring(6, 4) + "-" + accueil_calendar.SelectionStart.AddDays(1).ToShortDateString().Substring(3, 2) + "-" + accueil_calendar.SelectionStart.AddDays(1).ToShortDateString().Substring(0, 2);
            // Mise a jour des dates des colonnes
            lbl_jour1.Text = "Date du jour sélectionné : " + accueil_calendar.SelectionStart.ToShortDateString();
            lbl_jour2.Text = "Date du lendemain : " + accueil_calendar.SelectionStart.AddDays(1).ToShortDateString();
            // Requete pour récupérer les réservations des deux jours selectionnés avec comme condition la salle de l'utilisateur
            db.dbConnect();
            tabQuery = db.dbQuery("SELECT id, date_debut, date_fin, raison, id_utilisateur FROM reservation WHERE (DATE(date_debut) = " + '"' + dateSQLday1 + '"' + " || DATE(date_debut) = " + '"' + dateSQLday2 + '"' + ") && " + "id_salle = " + '"' + infoConnexion[0, 5] + '"' + ";");
            db.dbDisconnect();
            // Entrée des datetime dans le tableau d'affichage
            for (int i = 0; i < affichageCalendar1.GetLength(0); i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    affichageCalendar1[i, j] = dateSQLday1 + " " + ((j == 2) ? ((i < 1) ? "0" + (9 + i) : "" + (9 + i)) : ((i <= 1) ? "0" + (8 + i) : "" + (8 + i))) + ":00:00";
                    affichageCalendar2[i, j] = dateSQLday2 + " " + ((j == 2) ? ((i < 1) ? "0" + (9 + i) : "" + (9 + i)) : ((i <= 1) ? "0" + (8 + i) : "" + (8 + i))) + ":00:00";
                }
            }
            // Attribution des id existants
            for (int i = 0; i < tabQuery.GetLength(0); i++)
            {
                for (int j = 0; j < affichageCalendar1.GetLength(0); j++)
                {
                    if (tabQuery[i, 1] == accueil_calendar.SelectionStart.ToShortDateString() + " " + ((j <= 1) ? "0" + (8 + j) : "" + (8 + j)) + ":00:00")
                    {
                        affichageCalendar1[j, 0] = tabQuery[i, 0];
                        affichageCalendar1[j, 2] = dateSQLday1 + " " + tabQuery[i, 2].Substring(11, 2) + ":00:00";
                        affichageCalendar1[j, 3] = tabQuery[i, 3];
                    }
                    if (tabQuery[i, 1] == accueil_calendar.SelectionStart.AddDays(1).ToShortDateString() + " " + ((j <= 1) ? "0" + (8 + j) : "" + (8 + j)) + ":00:00")
                    {
                        affichageCalendar2[j, 0] = tabQuery[i, 0];
                        affichageCalendar2[j, 2] = dateSQLday2 + " " + tabQuery[i, 2].Substring(11, 2) + ":00:00";
                        affichageCalendar2[j, 3] = tabQuery[i, 3];
                    }
                }
            }
            // Affichage des couleurs sur le tableau et des textes si le créneau est réservé
            // ATTENTION LE PROBLEME DE CLIGNOTEMENT DU TABLEAU VIENS DE CETTE BOUCLE :
            
            int indexTab = 0;
            int ecartHeureDay1;
            int ecartHeureDay2;
            for (int i = 1; i < affichageCalendar1.GetLength(0) + 1; i++)
            {
                if (affichageCalendar1[indexTab, 0] != null)
                {
                    ecartHeureDay1 = int.Parse(affichageCalendar1[indexTab, 2].Substring(11, 2)) - int.Parse(affichageCalendar1[indexTab, 1].Substring(11, 2));
                    for (int j = 0; j < ecartHeureDay1; j++)
                    {
                        tbl_reservation.GetControlFromPosition(1, i + j).BackColor = Color.Crimson;
                        tbl_reservation.GetControlFromPosition(1, i + j).Text = affichageCalendar1[indexTab, 3];
                    }
                }
                if (affichageCalendar2[indexTab, 0] != null)
                {
                    ecartHeureDay2 = int.Parse(affichageCalendar2[indexTab, 2].Substring(11, 2)) - int.Parse(affichageCalendar2[indexTab, 1].Substring(11, 2));
                    for (int j = 0; j < ecartHeureDay2; j++)
                    {
                        tbl_reservation.GetControlFromPosition(2, i + j).BackColor = Color.Crimson;
                        tbl_reservation.GetControlFromPosition(2, i + j).Text = affichageCalendar2[indexTab, 3];
                    }
                }
                indexTab++;
                ecartHeureDay1 = 0;
                ecartHeureDay2 = 0;
            }
            Cursor = Cursors.Arrow;
            accueil_calendar.Enabled = true;
        }

        private void btn_reservation_Click(object sender, EventArgs e)
        {
            // Tableau d'envoi de donnée au formulaire de confirmation
            string[,] returnValue = new string[1, 8];
            int debut = 0;
            int fin = 0;
            bool dejaReserve = false;
            /* Incrémentation du tableau returnValue a envoyer pour la confirmation:
             * O -> Nom et prénom du créateur de la réservation ; 1 -> Salle ; 2 -> Ligue ;
             * 3 -> Jour ; 4 -> Heure de début ; 5 -> Heure de fin ; 6 -> id user ; 7 -> id_salle ;
             */
            if (infoConnexion[0,5] != "" && infoConnexion[0, 4] != "")
            {
                db.dbConnect();
                returnValue[0, 0] = infoConnexion[0, 6] + " " + infoConnexion[0, 7];
                returnValue[0, 1] = db.dbQuery("SELECT salle.localisation FROM salle WHERE salle.id = " + '"' + infoConnexion[0, 5] + '"' + ";")[0, 0];
                returnValue[0, 2] = db.dbQuery("SELECT ligue.intitule FROM ligue WHERE ligue.id = " + '"' + infoConnexion[0, 4] + '"' + ";")[0, 0];
                returnValue[0, 6] = infoConnexion[0, 2];
                returnValue[0, 7] = infoConnexion[0, 5];
                db.dbDisconnect();
                // Systeme de boucle pour checker les créneaux selectionnés
                // Et création du tableau pour le form de confirmation
                for (int i = 1; i < 3; i++)
                {
                    if (returnValue[0, 4] == null && returnValue[0, 5] == null)
                    {
                        for (int j = 1; j < (affichageCalendar1.GetLength(0) + 1); j++)
                        {
                            if (tbl_reservation.GetControlFromPosition(i, j).BackColor == Color.LightBlue)
                            {
                                if (i == 1)
                                {
                                    // Retour du jour
                                    returnValue[0, 3] = affichageCalendar1[j - 1, 1].Substring(0, 10);
                                    // Retour de l'heure de début de jour J
                                    returnValue[0, 4] = affichageCalendar1[j - 1, 1].Substring(11, 8);
                                    debut = j;
                                    break;
                                }
                                else if (i == 2)
                                {
                                    // Retour du jour
                                    returnValue[0, 3] = affichageCalendar2[j - 1, 1].Substring(0, 10);
                                    // Retour de l'heure de début de j+1
                                    returnValue[0, 4] = affichageCalendar2[j - 1, 1].Substring(11, 8);
                                    debut = j;
                                    break;
                                }
                            }
                        }
                        for (int h = affichageCalendar1.GetLength(0); h > 0; h--)
                        {
                            if (tbl_reservation.GetControlFromPosition(i, h).BackColor == Color.LightBlue)
                            {
                                if (i == 1)
                                {
                                    // Retour de l'heure de fin de jour J
                                    returnValue[0, 5] = affichageCalendar1[h - 1, 2].Substring(11, 8);
                                    fin = h;
                                    break;
                                }
                                else if (i == 2)
                                {
                                    // Retour de l'heure de fin de J+1
                                    returnValue[0, 5] = affichageCalendar2[h - 1, 2].Substring(11, 8);
                                    fin = h;
                                    break;
                                }
                            }
                        }
                    }
                }
                // Boucle pour vérifier si il existe un créneau déja réservé entre les créneaux selectionné :
                for (int i = (debut + 1); i < fin; i++)
                {
                    if (returnValue[0, 3] == accueil_calendar.SelectionStart.ToShortDateString().Substring(6, 4) + "-" + accueil_calendar.SelectionStart.ToShortDateString().Substring(3, 2) + "-" + accueil_calendar.SelectionStart.ToShortDateString().Substring(0, 2))
                    {
                        if (tbl_reservation.GetControlFromPosition(1, i).BackColor == Color.Crimson)
                        {
                            dejaReserve = true;
                            break;
                        }
                    }
                    else if (returnValue[0, 3] == accueil_calendar.SelectionStart.AddDays(1).ToShortDateString().Substring(6, 4) + "-" + accueil_calendar.SelectionStart.AddDays(1).ToShortDateString().Substring(3, 2) + "-" + accueil_calendar.SelectionStart.AddDays(1).ToShortDateString().Substring(0, 2))
                    {
                        if (tbl_reservation.GetControlFromPosition(2, i).BackColor == Color.Crimson)
                        {
                            dejaReserve = true;
                            break;
                        }
                    }

                }
                // Cas pour gérer si des cases on bien été selectionnés
                if (returnValue[0, 3] != null && returnValue[0, 4] != null && returnValue[0, 5] != null && dejaReserve == false)
                {
                    // Ouverture du form de confirmation
                    Reservation resa = new Reservation(returnValue);
                    resa.ShowDialog();
                    if (resa.DialogResult == DialogResult.OK)
                    {
                        this.affichageCalendrier();
                    }
                }
                else
                {
                    MessageBox.Show((dejaReserve == true) ? "Une réservation a déja été créer dans les horaires selectionnés." : "Veuillez selectionner un créneau horaire.", "Attention");
                }
            }
            else
            {
                MessageBox.Show("Vous n'êtes affecté à aucune salle ou ligue, contactez votre administrateur.", "Attention");
            }
            
        }

        private void btn_deconnexion_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            this.affichageCalendrier();
        }
    }
}
