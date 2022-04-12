Dictionnaire des données
========================

* **Structure de la table `utilisateur`**
	- id : -
	- nom, prenom : Minimum de données personnelles afin de s'assurer de l'identité de la personne
	- login, password : Informations de connexion
	- id_groupe_utilisateur : Fait le lien entre les droits et l'utilisateur
	- id_salle : Fait le lien entre l'utilisateur et les salles (pour la recherche)
* **Structure de la table `groupe_utilisateur`**
	- id : -
	- groupe_utilisateur : Dénomination (Administrateur, Directeur de Ligue, Salarié)
* **Structure de la table `reservation`**
	- id : - 
	- raison : Intitulee de la reservation 
	- date : Date de la reservation
	- demi_journee : Demi-journee ou journee complete (Journee complete = 0, matin = 1, apres-midi = 2)
	- id_utilisateur : Fait le lien entre l'utilisateur et la reservation
	- id_salle : Fait le lien entre la salle de reunion et la reservation
* **Structure de la table `salle`**
	- id : - 
	- localisation : Localisation de la salle de reunion