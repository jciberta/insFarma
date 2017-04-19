
CREATE DATABASE FIP
USE FIP

/* V:0 Taula inicial. S'ha de fer a mà! */
/*
CREATE DATABASE nom

USE nom

CREATE TABLE SISTEMA 
(
	sistema_id           INT NOT NULL,
	VersioDB             INT NULL,

	CONSTRAINT SistemaPK PRIMARY KEY (sistema_id)
)

INSERT INTO SISTEMA (sistema_id, VersioDB) VALUES (1, 0)
*/

/* V:1 16/12/21 Taula SISTEMA */
ALTER TABLE SISTEMA ADD
	nom_comercial        VARCHAR(50),
	nif                  VARCHAR(20),
	nom_fiscal           VARCHAR(50),
	codi_postal          INT NULL,
	adresa               VARCHAR(50) NULL,
	poblacio             VARCHAR(50) NULL,
	provincia            VARCHAR(50) NULL,
	pais                 VARCHAR(20) NULL,
	contacte             VARCHAR(50) NULL,
	telefon1             VARCHAR(20),
	telefon2             VARCHAR(20),
	mobil1               VARCHAR(20),
	mobil2               VARCHAR(20),
	fax                  VARCHAR(20),
	web                  VARCHAR(50) NULL,
	email                VARCHAR(50) NULL,
	observacions         TEXT NULL


/* V:100 16/12/21 Taula COMPTADOR */
CREATE TABLE COMPTADOR 
(
	taula                VARCHAR(50) NOT NULL,
	id                   INT,

	CONSTRAINT INTPK PRIMARY KEY (taula)
)


/* V:101 16/12/21 Taula USUARIS */
CREATE TABLE USUARIS 
(
	usuari_id            INT NOT NULL,
	usuari               VARCHAR(20) NOT NULL,
	paraula_clau         VARCHAR(100),
	nom_complet          VARCHAR(100),
	descripcio           VARCHAR(100),
	
	CONSTRAINT UsuariPK PRIMARY KEY (usuari_id)
)


/* V:110 16/12/21 Taula PAIS */
CREATE TABLE PAIS 
(
	/* PA */
	pais_id              INT NOT NULL,
	nom                  VARCHAR(100) NOT NULL,

	CONSTRAINT PaisPK PRIMARY KEY (pais_id)
)


/* V:111 16/12/21 Taula PROVINCIA */
CREATE TABLE PROVINCIA 
(
	/* PRV */
	provincia_id         INT NOT NULL,
	codi                 INT NULL,
	nom                  VARCHAR(20) NULL,
	nom_ca               VARCHAR(20) NULL,
	nom_es               VARCHAR(20) NULL,
	pais_id              INT NOT NULL,
	
	CONSTRAINT ProvinciaPK PRIMARY KEY (provincia_id),
	CONSTRAINT PRV_PaisFK FOREIGN KEY (pais_id) REFERENCES PAIS(pais_id)
)


/* V:112 16/12/21 Taula POBLACIO */
CREATE TABLE POBLACIO 
(
	/* PBL */
	poblacio_id          INT NOT NULL,
	provincia_id         INT,
	nom                  VARCHAR(100) NULL,
	codi_postal          char(5) NULL,

	CONSTRAINT PoblacioPK PRIMARY KEY (poblacio_id),
	CONSTRAINT PBL_ProvinciaFK FOREIGN KEY (provincia_id) REFERENCES PROVINCIA(provincia_id)
)


/* V:115 16/12/21 Taula FORMA_PAGAMENT */
CREATE TABLE FORMA_PAGAMENT 
(
	/* FPG */
	forma_pagament_id		INT IDENTITY,
	descripcio				VARCHAR(50),
	numero_venciments		INT NULL,
	dies_primer_venciment	INT NULL,
	tipus_venciment      	CHAR(3), /* DDF: Dia(es) data factura, DFX: Dia fix, UDM: Últim dia de mes */
	dies_entre_venciments	INT NULL,
	tipus_interval       	CHAR(1), /* Dia, Mes */
	tipus_document       	CHAR(1) /* Rebut, Gir, Altres */

	CONSTRAINT FormaPagamentPK PRIMARY KEY (forma_pagament_id)
)


/* V:120 Taula FAMILIA_ARTICLE */
CREATE TABLE FAMILIA_ARTICLE 
(
	familia_article_id   INT IDENTITY,
	descripcio           VARCHAR(50),

	CONSTRAINT FamiliaArticlePK PRIMARY KEY (familia_article_id)
)


/* V:121 Taula MARCA_ARTICLE */
CREATE TABLE MARCA_ARTICLE 
(
	marca_article_id     INT IDENTITY,
	descripcio           VARCHAR(50),

	CONSTRAINT MarcaArticlePK PRIMARY KEY (marca_article_id)
)


/* V:122 Taula IMPOST */
-- =============================================
-- Data: 10/03/07
CREATE TABLE IMPOST 
(
	impost_id            INT NOT NULL,
	descripcio           VARCHAR(20),
	data_inicial_vigencia datetime NULL,
	tipus_impost_actual  FLOAT,
	
	CONSTRAINT ImpostPK PRIMARY KEY (impost_id)
)


/* V:200 Taula CLASSIFICACIO_AGENDA */
-- =============================================
-- Data: 10/03/07
CREATE TABLE CLASSIFICACIO_AGENDA 
(
	classificacio_agenda_id 	INT NOT NULL,
	nom                  		VARCHAR(50),
	
	CONSTRAINT ClassificacioAgendaPK PRIMARY KEY (classificacio_agenda_id)
)


/* V:201 Taula AGENDA */
-- =============================================
-- Data: 10/03/07
CREATE TABLE AGENDA 
(
	/* AG */
	agenda_id            INT IDENTITY,
	nom_comercial        VARCHAR(50),
	nif                  VARCHAR(20),
	nom_fiscal           VARCHAR(50),
	codi_postal          int NULL,
	poblacio             VARCHAR(50) NULL,
	adresa               VARCHAR(50) NULL,
	provincia            VARCHAR(50) NULL,
	pais                 VARCHAR(20) NULL,
	contacte             VARCHAR(50) NULL,
	telefon1             VARCHAR(20),
	telefon2             VARCHAR(20),
	mobil1               VARCHAR(20),
	mobil2               VARCHAR(20),
	fax                  VARCHAR(20),
	web                  VARCHAR(50) NULL,
	email                VARCHAR(50) NULL,
	observacions         text NULL,
	compte_bancari_id    INT,
	forma_pagament_id    INT,
	es_client            bit,
	es_proveidor         bit,
	es_operari 			bit, 
	classificacio_agenda_id INT,
	preu_hora_normal 	FLOAT, 
	preu_hora_extra 	FLOAT, 
	preu_hora_festiva 	FLOAT, 
	preu_hora_nocturna 	FLOAT	

	CONSTRAINT AgendaPK PRIMARY KEY (agenda_id),
	CONSTRAINT AG_ClassificacioAgendaFK FOREIGN KEY (classificacio_agenda_id) REFERENCES CLASSIFICACIO_AGENDA(classificacio_agenda_id),
	CONSTRAINT AG_FormaPagamentFK FOREIGN KEY (forma_pagament_id) REFERENCES FORMA_PAGAMENT(forma_pagament_id)
)


/* V:216 Taula ARTICLE */
-- =============================================
-- Data: 10/03/07
CREATE TABLE ARTICLE 
(
	/* A */
	article_id           INT IDENTITY,
	familia_article_id   INT,
	marca_article_id     INT,
	referencia           VARCHAR(20),
	referencia_alternativa VARCHAR(20),
	descripcio           VARCHAR(50),
	data_alta			DATETIME,
	preu_venda           FLOAT,
	tipus_FLOAT           char(1) NULL,
	FLOAT_FLOAT     FLOAT,
	FLOAT_cost            FLOAT,
	impost_id            INT,
	estoc_minim          int NULL,
	estoc_maxim          int NULL,
	ubicacio             varchar(20) NULL,
	estoc                int NULL,
	control_estoc        bit,
	agenda_id            INT,
	
	CONSTRAINT ArticlePK 		PRIMARY KEY (article_id),
	CONSTRAINT A_FamiliaArticleFK 	FOREIGN KEY (familia_article_id) 	REFERENCES FAMILIA_ARTICLE(familia_article_id),
	CONSTRAINT A_MarcaArticleFK 	FOREIGN KEY (marca_article_id) 		REFERENCES MARCA_ARTICLE(marca_article_id),
	CONSTRAINT A_AgendaFK 		FOREIGN KEY (agenda_id) 		REFERENCES AGENDA(agenda_id),
	CONSTRAINT A_ImpostFK 		FOREIGN KEY (impost_id) 		REFERENCES IMPOST(impost_id)
)












------------------- STOP --------------
use FIP
select * from SISTEMA









/* V:217 Taula ALBARA_VENDA */
-- =============================================
-- Data: 10/03/07
CREATE TABLE ALBARA_VENDA 
(
	/* AV */
	albara_venda_id      INT NOT NULL,
	exercici             int NULL,
	factura_venda_id     INT,
	numero_factura       int NULL,
	exercici_factura     int NULL,
	import               FLOAT,
	descompte            FLOAT,
	comentari            text NULL,
	data_hora            datetime NULL,
	agenda_id            INT,

	CONSTRAINT AlbaraVendaPK 	PRIMARY KEY (albara_venda_id),
	CONSTRAINT AV_AgendaFK 		FOREIGN KEY (agenda_id) 		REFERENCES AGENDA(agenda_id)
)
      

/* V:218 Taula ALBARA_VENDA_ARTICLE */
-- =============================================
-- Data: 10/03/07
CREATE TABLE ALBARA_VENDA_ARTICLE 
(
	/* AVA */
	albara_venda_article_id INT NOT NULL,
	albara_venda_id      INT,
	linia                int NULL,
	article_id           INT,
	referencia           VARCHAR(20),
	descripcio           VARCHAR(50),
	unitats              int NULL,
	FLOAT_venda           FLOAT,
	descompte_venda      FLOAT,
	impost               FLOAT,
	regim                FLOAT,
	FLOAT_cost            FLOAT,
	euneg                bit,

	CONSTRAINT AlbaraVendaArticlePK PRIMARY KEY (albara_venda_article_id),
	CONSTRAINT AVA_AlbaraVendaFK 	FOREIGN KEY (albara_venda_id) 	REFERENCES ALBARA_VENDA(albara_venda_id),
	CONSTRAINT AVA_ArticleFK 	FOREIGN KEY (article_id) 	REFERENCES ARTICLE(article_id)
)


/* V:219 Índex AG_es_clientIX */
-- =============================================
-- Data: 10/03/07
CREATE INDEX AVA_albara_vendaIX ON ALBARA_VENDA_ARTICLE (albara_venda_id)


/* V:220 Taula VENDA_ENTRADA */
-- =============================================
-- Data: 10/03/07
CREATE TABLE VENDA_ENTRADA 
(
	/* VE */
	venda_entrada_id     INT NOT NULL,
	tipus_entrada_id     INT,
	data_hora            datetime NOT NULL,
	quantitat            int NOT NULL,
	numeracio            VARCHAR(50),
	FLOAT_unitat          FLOAT,
	codi_postal          VARCHAR(20),
	FLOAT_total           FLOAT,
	poblacio             VARCHAR(50),
	pais_id              INT,
	albara_venda_id      INT,
	enquesta             int NULL,
	enquesta_altres      VARCHAR(50),

	CONSTRAINT VendaEntradaPK PRIMARY KEY (venda_entrada_id),
	CONSTRAINT VE_TipusEntradaFK FOREIGN KEY (tipus_entrada_id) REFERENCES TIPUS_ENTRADA(tipus_entrada_id),
	CONSTRAINT VE_AlbaraVendaFK FOREIGN KEY (albara_venda_id) REFERENCES ALBARA_VENDA(albara_venda_id),
	CONSTRAINT VE_PaisFK FOREIGN KEY (pais_id) REFERENCES PAIS(pais_id)
)


/* V:221 Taula MOVIMENT_ARTICLE */
-- =============================================
-- Data: 10/03/07
CREATE TABLE MOVIMENT_ARTICLE 
(
	/* MOVA */
	moviment_article_id  INT NOT NULL,
	tipus                char(2) NOT NULL,
	identificador        int NULL,
	usuari_id            INT NOT NULL,
	data_hora            datetime NOT NULL,
	article_id           INT NOT NULL,
	descripcio           VARCHAR(50) NOT NULL,
	estoc_anterior       int NOT NULL,
	estoc_actual         int NOT NULL,
	diferencia           int NOT NULL,

	CONSTRAINT MovimentArticlePK 	PRIMARY KEY (moviment_article_id),
	CONSTRAINT MOVA_ArticleFK 	FOREIGN KEY (article_id) 	REFERENCES ARTICLE(article_id)
)



/* V:224 Clau forànea SIS_ImpostFK */
-- =============================================
-- Data: 10/03/07
ALTER TABLE SISTEMA 
	ADD CONSTRAINT SIS_ImpostFK FOREIGN KEY (impost_id) REFERENCES IMPOST(impost_id)


/* V:224 Clau forànea SIS_FormaPagamentFK */
-- =============================================
-- Data: 10/03/07
ALTER TABLE SISTEMA
       ADD CONSTRAINT SIS_FormaPagamentFK FOREIGN KEY (forma_pagament_id) REFERENCES FORMA_PAGAMENT(forma_pagament_id)


/* V:224 Clau forànea SIS_ClientVendaMenorFK */
-- =============================================
-- Data: 10/03/07
ALTER TABLE SISTEMA
       ADD CONSTRAINT SIS_ClientVendaMenorFK FOREIGN KEY (client_venda_menor) REFERENCES AGENDA(agenda_id)





/* V:1004 Subgrup d'imformes */
-- =============================================
-- Data: 05/02/07
alter table llistats add subgrup_llistat int


/* V:1005 Taula ALBARA_COMPRA */
-- =============================================
-- Data: 07/02/07
CREATE TABLE ALBARA_COMPRA 
(
	/* AC */
	albara_compra_id     INT NOT NULL,
	agenda_id            INT,
	import               FLOAT,
	descompte            FLOAT,
	comentari            text NULL,
	data_hora            datetime NULL,

	CONSTRAINT AlbaraCompraPK 	PRIMARY KEY (albara_compra_id),
	CONSTRAINT AC_AgendaFK 		FOREIGN KEY (agenda_id) 	REFERENCES AGENDA(agenda_id)
)


/* V:1006 Taula ALBARA_COMPRA_ARTICLE */
-- =============================================
-- Data: 07/02/07
CREATE TABLE ALBARA_COMPRA_ARTICLE 
(
	/* ACA */
	albara_compra_article_id 	INT NOT NULL,
	albara_compra_id     INT,
	linia                int NULL,
	article_id           INT,
	referencia           Referència_article,
	descripcio           VARCHAR(50),
	unitats              int NULL,
	FLOAT_compra          FLOAT,
	descompte_compra     FLOAT,
	impost               FLOAT,
	regim                FLOAT,
	FLOAT_total           FLOAT,

	CONSTRAINT AlbaraCompraArticlePK 	PRIMARY KEY (albara_compra_article_id),
	CONSTRAINT ACA_AlbaraCompraFK 		FOREIGN KEY (albara_compra_id) 	REFERENCES ALBARA_COMPRA(albara_compra_id),
	CONSTRAINT ACA_ArticleFK 		FOREIGN KEY (article_id) 	REFERENCES ARTICLE(article_id)
)


/* V:1007 Taula COMPTADOR */
-- =============================================
-- Data: 13/02/07
ALTER TABLE INT ADD alies VARCHAR(10)


/* V:1037 Taula COMANDA */
-- =============================================
-- Data: 19/04/07
CREATE TABLE COMANDA 
(
	/* CO */
	comanda_id    	INT NOT NULL,
	agenda_id       INT,
	estat		char(1), /* E: elaboració, P: pendent, R: rebuda, A: anul·lada */
	import          FLOAT,
	descompte       FLOAT,
	comentari       text NULL,
	data_hora       datetime NULL,

	CONSTRAINT ComandaPK 	PRIMARY KEY (comanda_id),
	CONSTRAINT CO_AgendaFK FOREIGN KEY (agenda_id) REFERENCES AGENDA(agenda_id)
)


/* V:1038 Taula COMANDA_ARTICLE */
-- =============================================
-- Data: 19/04/07
CREATE TABLE COMANDA_ARTICLE 
(
	/* COA */
	comanda_article_id   INT NOT NULL,
	comanda_id     	     INT,
	linia                int NULL,
	article_id           INT,
	referencia           Referència_article,
	descripcio           VARCHAR(50),
	unitats              int NULL,
	FLOAT_compra          FLOAT,
	descompte_compra     FLOAT,
	impost               FLOAT,
	regim                FLOAT,
	FLOAT_total           FLOAT,

	CONSTRAINT ComandaArticlePK 	PRIMARY KEY (comanda_article_id),
	CONSTRAINT COA_ComandaFK 	FOREIGN KEY (comanda_id) REFERENCES COMANDA(comanda_id),
	CONSTRAINT COA_ArticleFK 	FOREIGN KEY (article_id) REFERENCES ARTICLE(article_id)
)






/* V:1048 Modifica Taula FORMA_PAGAMENT */
-- =============================================
-- Data: 14/07/07
ALTER TABLE FORMA_PAGAMENT DROP COLUMN tipus_venciment, tipus_interval, tipus_document


/* V:1049 Modifica Taula FORMA_PAGAMENT */
-- =============================================
-- Data: 14/07/07
ALTER TABLE FORMA_PAGAMENT ADD 
	tipus_venciment      	char(3), /* DDF: Dia(es) data factura, DFX: Dia fix, UDM: Últim dia de mes */
	tipus_interval       	char(1), /* Dia, Mes */
	tipus_document       	char(1) /* Rebut, Gir, Altres */


/* V:1050 Modifica Taula AGENDA */
-- =============================================
-- Data: 17/07/07

ALTER TABLE AGENDA ALTER COLUMN adresa VARCHAR(255)




/* V:1086 Taula INT_EXERCICI */
-- =============================================
-- Data: 9/11/09
CREATE TABLE INT_EXERCICI 
(
	/* COMPTEX */
	exercici 	int,
	ultima_factura_venda	int,
	ultima_factura_compra	int,
	ultim_albara_venda	int,
	ultim_albara_compra	int,
	ultima_comanda_venda	int,
	ultima_comanda_compra	int,

	CONSTRAINT INTExerciciPK 	PRIMARY KEY (exercici)
) 


/* V:1087 Taula ALBARA_VENDA_DETALL */
-- =============================================
-- Data: 13/11/09
CREATE TABLE ALBARA_VENDA_DETALL 
(
	/* AVD */
	albara_venda_detall_id 	int NOT NULL,
	albara_venda_id      	int NOT NULL,
	linia                	int,
	article_id           	int,
	referencia           	varchar(20),
	descripcio           	varchar(50),
	unitats              	int,
	FLOAT_venda           	float,
	descompte_venda      	float,
	impost               	float,
	regim                	float,
	FLOAT_cost            	float,

	CONSTRAINT AlbaraVendaDetallPK 	PRIMARY KEY (albara_venda_detall_id),
	CONSTRAINT AVD_AlbaraVendaFK 	FOREIGN KEY (albara_venda_id) 	REFERENCES ALBARA_VENDA(albara_venda_id)
)



/* V:1089 Modifica taula ALBARA_VENDA */
-- =============================================
-- Data: 13/11/09
ALTER TABLE ALBARA_VENDA 
	ALTER COLUMN import decimal(10, 2)


/* V:1090 Modifica taula ALBARA_VENDA */
-- =============================================
-- Data: 13/11/09
ALTER TABLE ALBARA_VENDA 
	ALTER COLUMN descompte decimal(10, 2)


/* V:1092 taula FACTURA_VENDA */
-- =============================================
-- Data: 13/11/09
CREATE TABLE FACTURA_VENDA
(
	/* FV */
	exercici 			int NOT NULL,
	numero_factura		int NOT NULL,
	data 				datetime NOT NULL,
	client_id 			int,
	nom 				varchar(50),
	nif 				varchar(20),
	adresa 				varchar(50),
	codi_postal 		int NULL,
	poblacio 			varchar(50),
	provincia			varchar(50),
	descripcio_forma_pagament varchar(50),
	import_total 		decimal(10, 2),
	comentari           text NULL,

	CONSTRAINT FacturaVendaPK 	PRIMARY KEY (exercici, numero_factura),
	CONSTRAINT FV_AgendaFK 		FOREIGN KEY (client_id) 		REFERENCES AGENDA(agenda_id)
) 


/* V:1093 Modifica taula ALBARA_VENDA */
-- =============================================
-- Data: 13/11/09
ALTER TABLE ALBARA_VENDA 
	DROP COLUMN factura_venda_id


/* V:1094 Modifica taula ALBARA_VENDA */
-- =============================================
-- Data: 13/11/09
ALTER TABLE ALBARA_VENDA 
	ADD CONSTRAINT AV_FacturaVendaFK FOREIGN KEY (exercici_factura, numero_factura)	REFERENCES FACTURA_VENDA(exercici, numero_factura)


/* V:1095 05/12/09 Modifica taula ALBARA_VENDA */
ALTER TABLE ALBARA_VENDA 
	ADD numero_albara int

/* V:1096 05/12/09 Modifica taula ALBARA_VENDA */
UPDATE ALBARA_VENDA SET exercici=year(data_hora), numero_albara=albara_venda_id

/* V:1097 05/12/09 Modifica taula ALBARA_VENDA */
ALTER TABLE ALBARA_VENDA 
	ALTER COLUMN exercici INT NOT NULL

/* V:1098 05/12/09 Modifica taula ALBARA_VENDA */
ALTER TABLE ALBARA_VENDA 
	ALTER COLUMN numero_albara INT NOT NULL

/* V:1099 05/12/09 Modifica taula ALBARA_VENDA */
ALTER TABLE ALBARA_VENDA 
	ADD CONSTRAINT AV_ExerciciNumeroUQ UNIQUE (exercici, numero_albara)



/* V:1105 05/01/10 Taula FACTURA_VENDA_DETALL */
CREATE TABLE FACTURA_VENDA_DETALL 
(
	/* FVD */
	factura_venda_detall_id int IDENTITY,
	exercici_factura		int NOT NULL,
	numero_factura			int NOT NULL,
	linia                	int,
	article_id           	int,
	referencia           	varchar(20),
	descripcio           	varchar(50),
	unitats              	int,
	FLOAT_venda           	float,
	descompte_venda      	float,

	CONSTRAINT FacturaVendaDetallPK PRIMARY KEY (factura_venda_detall_id),
	CONSTRAINT FVD_FacturaVendaFK 	FOREIGN KEY (exercici_factura, numero_factura) 	REFERENCES FACTURA_VENDA(exercici, numero_factura)
)
