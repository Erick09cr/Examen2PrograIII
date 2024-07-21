CREATE DATABASE votaciones

USE Votaciones;
GO


CREATE TABLE Candidatos (
    IdCandidato INT PRIMARY KEY IDENTITY,
    Cedula NVARCHAR(20) NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    PartidoPolitico NVARCHAR(100) NOT NULL,
    CONSTRAINT UQ_Cedula_Candidatos UNIQUE (Cedula)
   
);
GO



CREATE TABLE Votantes (
    IdVotante INT PRIMARY KEY IDENTITY,
    Cedula NVARCHAR(20) NOT NULL,
    Nombre NVARCHAR(100) NOT NULL,
    Edad INT NOT NULL CHECK (Edad >= 18),
    CONSTRAINT UQ_Cedula_Votantes UNIQUE (Cedula)
    
);
GO


CREATE TABLE Votos (
    IdVoto INT PRIMARY KEY IDENTITY,
    IdVotante INT NOT NULL,
    IdCandidato INT NOT NULL,
    FechaVoto DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Votos_Votantes FOREIGN KEY (IdVotante) REFERENCES Votantes(IdVotante),
    CONSTRAINT FK_Votos_Candidatos FOREIGN KEY (IdCandidato) REFERENCES Candidatos(IdCandidato)
    
);
GO

CREATE TABLE ResultadosEleccion (
    IdResultado INT PRIMARY KEY IDENTITY,
    Candidato NVARCHAR(100) NOT NULL,
    VotosObtenidos INT NOT NULL,
    PorcentajeVotos DECIMAL(5, 2) NOT NULL,
    FechaCalculo DATETIME NOT NULL DEFAULT GETDATE()
);
GO
