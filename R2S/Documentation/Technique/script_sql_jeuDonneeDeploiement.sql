-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  mer. 29 novembre 2022 à 14:00
-- Version du serveur :  5.7.26
-- Version de PHP :  7.2.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `r2s`
--

-- --------------------------------------------------------

--
-- Structure de la table `groupe_utilisateur`
--

DROP TABLE IF EXISTS `groupe_utilisateur`;
CREATE TABLE IF NOT EXISTS `groupe_utilisateur` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `groupe_utilisateur` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `groupe_utilisateur`
--

INSERT INTO `groupe_utilisateur` (`id`, `groupe_utilisateur`) VALUES
(1, 'admin'),
(2, 'salarie');

-- --------------------------------------------------------

--
-- Structure de la table `ligue`
--

DROP TABLE IF EXISTS `ligue`;
CREATE TABLE IF NOT EXISTS `ligue` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `intitule` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `reservation`
--

DROP TABLE IF EXISTS `reservation`;
CREATE TABLE IF NOT EXISTS `reservation` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `raison` varchar(50) NOT NULL,
  `date_debut` datetime NOT NULL,
  `date_fin` datetime NOT NULL,
  `id_utilisateur` int(11) NOT NULL,
  `id_salle` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `reservation_utilisateur_FK` (`id_utilisateur`),
  KEY `reservation_salle0_FK` (`id_salle`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `salle`
--

DROP TABLE IF EXISTS `salle`;
CREATE TABLE IF NOT EXISTS `salle` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `localisation` varchar(50) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- Structure de la table `utilisateur`
--

DROP TABLE IF EXISTS `utilisateur`;
CREATE TABLE IF NOT EXISTS `utilisateur` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) NOT NULL,
  `prenom` varchar(50) NOT NULL,
  `login` varchar(50) NOT NULL,
  `password` varchar(50) NOT NULL,
  `id_groupe_utilisateur` int(11) NOT NULL,
  `id_salle` int(11) DEFAULT NULL,
  `id_ligue` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `utilisateur_groupe_utilisateur_FK` (`id_groupe_utilisateur`),
  KEY `utilisateur_salle0_FK` (`id_salle`),
  KEY `utilisateur_ligue1_FK` (`id_ligue`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `utilisateur`
--

INSERT INTO `utilisateur` (`id`, `nom`, `prenom`, `login`, `password`, `id_groupe_utilisateur`, `id_salle`, `id_ligue`) VALUES
(1, 'admin', 'admin', 'admin', '21232f297a57a5a743894a0e4a801fc3', 1, NULL, NULL);

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `reservation`
--
ALTER TABLE `reservation`
  ADD CONSTRAINT `reservation_salle0_FK` FOREIGN KEY (`id_salle`) REFERENCES `salle` (`id`),
  ADD CONSTRAINT `reservation_utilisateur_FK` FOREIGN KEY (`id_utilisateur`) REFERENCES `utilisateur` (`id`);

--
-- Contraintes pour la table `utilisateur`
--
ALTER TABLE `utilisateur`
  ADD CONSTRAINT `utilisateur_groupe_utilisateur_FK` FOREIGN KEY (`id_groupe_utilisateur`) REFERENCES `groupe_utilisateur` (`id`),
  ADD CONSTRAINT `utilisateur_ligue1_FK` FOREIGN KEY (`id_ligue`) REFERENCES `ligue` (`id`),
  ADD CONSTRAINT `utilisateur_salle0_FK` FOREIGN KEY (`id_salle`) REFERENCES `salle` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
