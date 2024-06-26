 --Inserindo as raças na tabela dbo.Raca
--INSERT INTO dbo.Raca (Nome, LocalizacaoGeografica, HabilidadeRacial, EstaExtinta) 
--VALUES ('Humano', 'Gondor', 'Versatilidade', 0);

--INSERT INTO dbo.Raca (Nome, LocalizacaoGeografica, HabilidadeRacial, EstaExtinta) 
--VALUES ('Elfo', 'Floresta de Lothlórien', 'Visão Noturna', 0);

--INSERT INTO dbo.Raca (Nome, LocalizacaoGeografica, HabilidadeRacial, EstaExtinta) 
--VALUES ('Anão', 'Montanhas da Terra-média', 'Força e Resiliência', 0);

--INSERT INTO dbo.Raca (Nome, LocalizacaoGeografica, HabilidadeRacial, EstaExtinta) 
--VALUES ('Hobbit', 'Condado', 'Discrição e Agilidade', 0);

--INSERT INTO dbo.Raca (Nome, LocalizacaoGeografica, HabilidadeRacial, EstaExtinta) 
--VALUES ('Orc', 'Mordor', 'Ferocidade e Resistência', 0);

--INSERT INTO dbo.Raca (Nome, LocalizacaoGeografica, HabilidadeRacial, EstaExtinta) 
--VALUES ('Uruk-hai', 'Isengard', 'Força Bruta', 0);

--INSERT INTO dbo.Raca (Nome, LocalizacaoGeografica, HabilidadeRacial, EstaExtinta) 
--VALUES ('Troll', 'Montanhas da Sombra', 'Força Descomunal', 0);

--INSERT INTO dbo.Raca (Nome, LocalizacaoGeografica, HabilidadeRacial, EstaExtinta) 
--VALUES ('Ent', 'Floresta de Fangorn', 'Controle da Natureza', 0);

--INSERT INTO dbo.Raca (Nome, LocalizacaoGeografica, HabilidadeRacial, EstaExtinta) 
--VALUES ('Maiar', 'Valinor', 'Poder Mágico', 0);

--INSERT INTO dbo.Raca (Nome, LocalizacaoGeografica, HabilidadeRacial, EstaExtinta) 
--VALUES ('Dragão', 'Erebor', 'Fogo e Voo', 1);

---- Inserindo os personagens na tabela dbo.Personagem
INSERT INTO dbo.Personagem (Nome, IdRaca, Profissao, Idade, Altura, EstaVivo, DataDoCadastro) VALUES ('Aragorn', 1, 1, 87, 198, 1, '20110618 10:34:09 AM');
INSERT INTO dbo.Personagem (Nome, IdRaca, Profissao, Idade, Altura, EstaVivo, DataDoCadastro) VALUES ('Legolas', 2, 2, 2931, 183, 1, '20120618 11:34:09 AM');
INSERT INTO dbo.Personagem (Nome, IdRaca, Profissao, Idade, Altura, EstaVivo, DataDoCadastro) VALUES ('Gimli', 3, 1, 139, 137, 1, '20130618 12:34:09 PM');
INSERT INTO dbo.Personagem (Nome, IdRaca, Profissao, Idade, Altura, EstaVivo, DataDoCadastro) VALUES ('Gandalf', 9, 3, 0, 175, 1, '20140618 01:34:09 PM');
INSERT INTO dbo.Personagem (Nome, IdRaca, Profissao, Idade, Altura, EstaVivo, DataDoCadastro) VALUES ('Frodo', 4, 4, 50, 106, 1, '20150618 02:34:09 PM');
INSERT INTO dbo.Personagem (Nome, IdRaca, Profissao, Idade, Altura, EstaVivo, DataDoCadastro) VALUES ('Sam', 4, 5, 38, 106, 1, '20160618 03:34:09 PM');
INSERT INTO dbo.Personagem (Nome, IdRaca, Profissao, Idade, Altura, EstaVivo, DataDoCadastro) VALUES ('Boromir', 1, 1, 41, 190, 0, '20170618 04:34:09 PM');
INSERT INTO dbo.Personagem (Nome, IdRaca, Profissao, Idade, Altura, EstaVivo, DataDoCadastro) VALUES ('Merry', 4, 6, 36, 104, 1, '20180618 05:34:09 PM');
INSERT INTO dbo.Personagem (Nome, IdRaca, Profissao, Idade, Altura, EstaVivo, DataDoCadastro) VALUES ('Pippin', 4, 6, 28, 101, 1, '20190618 06:34:09 PM');
INSERT INTO dbo.Personagem (Nome, IdRaca, Profissao, Idade, Altura, EstaVivo, DataDoCadastro) VALUES ('Gollum', 4, 15, 589, 98, 0, '20200618 07:34:09 PM');
INSERT INTO dbo.Personagem (Nome, IdRaca, Profissao, Idade, Altura, EstaVivo, DataDoCadastro) VALUES ('Éowyn', 1, 10, 24, 170, 1, '20210618 08:34:09 PM');
INSERT INTO dbo.Personagem (Nome, IdRaca, Profissao, Idade, Altura, EstaVivo, DataDoCadastro) VALUES ('Faramir', 1, 11, 36, 185, 1, '20220618 09:34:09 PM');
INSERT INTO dbo.Personagem (Nome, IdRaca, Profissao, Idade, Altura, EstaVivo, DataDoCadastro) VALUES ('Théoden', 1, 7, 71, 178, 0, '20230618 10:34:09 PM');
INSERT INTO dbo.Personagem (Nome, IdRaca, Profissao, Idade, Altura, EstaVivo, DataDoCadastro) VALUES ('Saruman', 9, 3, 0, 183, 0, '20240618 11:34:09 PM');
INSERT INTO dbo.Personagem (Nome, IdRaca, Profissao, Idade, Altura, EstaVivo, DataDoCadastro) VALUES ('Galadriel', 2, 8, 8372, 175, 1, '20250618 12:34:09 AM');
INSERT INTO dbo.Personagem (Nome, IdRaca, Profissao, Idade, Altura, EstaVivo, DataDoCadastro) VALUES ('Elrond', 9, 9, 6518, 188, 1, '20260618 01:34:09 AM');
INSERT INTO dbo.Personagem (Nome, IdRaca, Profissao, Idade, Altura, EstaVivo, DataDoCadastro) VALUES ('Arwen', 2, 12, 2778, 175, 1, '20270618 02:34:09 AM');
INSERT INTO dbo.Personagem (Nome, IdRaca, Profissao, Idade, Altura, EstaVivo, DataDoCadastro) VALUES ('Bilbo', 4, 6, 129, 107, 0, '20280618 03:34:09 AM');
INSERT INTO dbo.Personagem (Nome, IdRaca, Profissao, Idade, Altura, EstaVivo, DataDoCadastro) VALUES ('Treebeard', 8, 13, 0, 457, 1, '20290618 04:34:09 AM');
INSERT INTO dbo.Personagem (Nome, IdRaca, Profissao, Idade, Altura, EstaVivo, DataDoCadastro) VALUES ('Éomer', 1, 14, 29, 190, 1, '20300618 05:34:09 AM');


SELECT * FROM dbo.Personagem;