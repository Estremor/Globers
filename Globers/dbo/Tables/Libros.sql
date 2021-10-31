CREATE TABLE [dbo].[Libros] (
    [ISBN]           INT          IDENTITY (1, 1) NOT NULL,
    [Editoriales_id] INT          NOT NULL,
    [Titulo]         VARCHAR (45) NOT NULL,
    [Sipnosis]       TEXT         NOT NULL,
    [N_paginas]      VARCHAR (45) NOT NULL,
    CONSTRAINT [PK_Libros] PRIMARY KEY CLUSTERED ([ISBN] ASC),
    CONSTRAINT [FK_Libros_Editoriales] FOREIGN KEY ([Editoriales_id]) REFERENCES [dbo].[Editoriales] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Libros_Editoriales_id]
    ON [dbo].[Libros]([Editoriales_id] ASC);

