CREATE TABLE [dbo].[Autores_has_libros] (
    [Autores_Id]  INT NOT NULL,
    [Libros_ISBN] INT NOT NULL,
    CONSTRAINT [PK_Autores_has_libros] PRIMARY KEY CLUSTERED ([Autores_Id] ASC, [Libros_ISBN] ASC),
    CONSTRAINT [FK_Autores_has_libros_Autores] FOREIGN KEY ([Autores_Id]) REFERENCES [dbo].[Autores] ([Id]),
    CONSTRAINT [FK_Autores_has_libros_Libros] FOREIGN KEY ([Libros_ISBN]) REFERENCES [dbo].[Libros] ([ISBN])
);


GO
CREATE NONCLUSTERED INDEX [IX_Autores_has_libros_Libros_ISBN]
    ON [dbo].[Autores_has_libros]([Libros_ISBN] ASC);

