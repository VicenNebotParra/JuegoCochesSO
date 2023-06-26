DROP DATABASE IF EXISTS M8_BBDDJuego;
CREATE DATABASE M8_BBDDJuego;
USE M8_BBDDJuego;

CREATE TABLE jugador(
	id INT PRIMARY KEY NOT NULL,
	username VARCHAR(25),
	passwd VARCHAR(25)
)ENGINE=InnoDB;

CREATE TABLE partida(
	idpartida INT PRIMARY KEY NOT NULL,
	ganador VARCHAR(25),
	local VARCHAR(25),
	visitante VARCHAR(25),
	ciudad VARCHAR(25)
)ENGINE=InnoDB;

CREATE TABLE CLASIFICACION(
    jugador_id INT NOT NULL,
    ultima_partida INT NOT NULL,
    posicion INT,
    FOREIGN KEY(jugador_id) REFERENCES jugador(id),
    FOREIGN KEY(ultima_partida) REFERENCES partida(idpartida)
)ENGINE=InnoDB;


INSERT INTO jugador VALUES(1, 'antoniokiller', 'patata');
INSERT INTO jugador VALUES(2, 'juandestroyer', 'fresasconnata');
INSERT INTO jugador VALUES(3, 'vicenmessi', 'messi');
INSERT INTO jugador VALUES(4, 'luisdescalzo', 'ferrari');
INSERT INTO jugador VALUES(5, 'miguelitofrifaier', 'gucci');
INSERT INTO jugador VALUES(6, 'lewandowsky', 'pichichi');

INSERT INTO partida VALUES(1, 'antoniokiller', 'antoniokiller', 'juandestroyer', 'barcelona' );
INSERT INTO partida VALUES(2, 'luisdescalzo', 'miguelitofrifaier', 'luisdescalzo', 'castefa' );
INSERT INTO partida VALUES(3, 'vicenmessi', 'vicenmessi', 'antoniokiller', 'cadiz' );
INSERT INTO partida VALUES(4, 'lewandowsky', 'lewandowsky', 'luisdescalzo', 'varsovia' );
INSERT INTO partida VALUES(5, 'miguelitofrifaier', 'juandestroyer', 'miguelitofrifaier', 'amsterdam' );
INSERT INTO partida VALUES(6, 'luisdescalzo', 'luisdescalzo', 'juandestroyer', 'sidney' );
INSERT INTO partida VALUES(7, 'miguelitofrifaier', 'antoniokiller', 'miguelitofrifaier', 'moscu' );



