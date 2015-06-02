CREATE TABLE HistoricoAtendimento
(
 IdHistorico INT IDENTITY(1, 1) PRIMARY KEY,
 Chamado INT FOREIGN KEY (Chamado) REFERENCES Chamados (IdChamado),
 Descricao VARCHAR(255) NOT NULL,
 Data DATETIME NOT NULL
)