#------------------------------------------------------------
#        Script MySQL.
#------------------------------------------------------------


#------------------------------------------------------------
# Table: groupe_utilisateur
#------------------------------------------------------------

CREATE TABLE groupe_utilisateur(
        id                 Int  Auto_increment  NOT NULL ,
        groupe_utilisateur Varchar (50) NOT NULL
	,CONSTRAINT groupe_utilisateur_PK PRIMARY KEY (id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: salle
#------------------------------------------------------------

CREATE TABLE salle(
        id           Int  Auto_increment  NOT NULL ,
        localisation Varchar (50) NOT NULL
	,CONSTRAINT salle_PK PRIMARY KEY (id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: ligue
#------------------------------------------------------------

CREATE TABLE ligue(
        id       Int  Auto_increment  NOT NULL ,
        intitule Varchar (50) NOT NULL
	,CONSTRAINT ligue_PK PRIMARY KEY (id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: utilisateur
#------------------------------------------------------------

CREATE TABLE utilisateur(
        id                    Int  Auto_increment  NOT NULL ,
        nom                   Varchar (50) NOT NULL ,
        prenom                Varchar (50) NOT NULL ,
        login                 Varchar (50) NOT NULL ,
        password              Varchar (50) NOT NULL ,
        id_groupe_utilisateur Int NOT NULL ,
        id_salle              Int ,
        id_ligue              Int
	,CONSTRAINT utilisateur_PK PRIMARY KEY (id)

	,CONSTRAINT utilisateur_groupe_utilisateur_FK FOREIGN KEY (id_groupe_utilisateur) REFERENCES groupe_utilisateur(id)
	,CONSTRAINT utilisateur_salle0_FK FOREIGN KEY (id_salle) REFERENCES salle(id)
	,CONSTRAINT utilisateur_ligue1_FK FOREIGN KEY (id_ligue) REFERENCES ligue(id)
)ENGINE=InnoDB;


#------------------------------------------------------------
# Table: reservation
#------------------------------------------------------------

CREATE TABLE reservation(
        id             Int  Auto_increment  NOT NULL ,
        raison         Varchar (50) NOT NULL ,
        date           Date NOT NULL ,
        demi_journee   Int NOT NULL ,
        id_utilisateur Int NOT NULL ,
        id_salle       Int NOT NULL
	,CONSTRAINT reservation_PK PRIMARY KEY (id)

	,CONSTRAINT reservation_utilisateur_FK FOREIGN KEY (id_utilisateur) REFERENCES utilisateur(id)
	,CONSTRAINT reservation_salle0_FK FOREIGN KEY (id_salle) REFERENCES salle(id)
)ENGINE=InnoDB;

