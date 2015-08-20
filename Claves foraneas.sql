ALTER TABLE [dbo].[Cargo]
    ADD CONSTRAINT [FK_Personal_Cargo_1] FOREIGN KEY ([IdCargo]) REFERENCES [dbo].[Personal] ([IdPersonal]);

ALTER TABLE [dbo].[Funcion]
    ADD CONSTRAINT [FK_Cargo_Funcion_1] FOREIGN KEY ([IdFuncion]) REFERENCES [dbo].[Cargo] ([IdCargo]);

ALTER TABLE [dbo].[Funcion]
    ADD CONSTRAINT [FK_Funcion_SituacionRevista_1] FOREIGN KEY ([SituacionRevista]) REFERENCES [dbo].[SituacionRevista] ([IdSituacionRevista]);

ALTER TABLE [dbo].[Funcion]
    ADD CONSTRAINT [FK_Funcion_Tarea_1] FOREIGN KEY ([Tarea]) REFERENCES [dbo].[Tarea] ([IdTarea]);

ALTER TABLE [dbo].[Inasistencia]
    ADD CONSTRAINT [FK_Inasistencia_Personal_1] FOREIGN KEY ([IdPersonal]) REFERENCES [dbo].[Personal] ([IdPersonal]);

ALTER TABLE [dbo].[Telefono]
    ADD CONSTRAINT [FK_Telefono_Personal_1] FOREIGN KEY ([IdPersonal]) REFERENCES [dbo].[Personal] ([IdPersonal]);

ALTER TABLE [dbo].[Telefono]
    ADD CONSTRAINT [FK_Telefono_TipoTelefono_1] FOREIGN KEY ([Tipo]) REFERENCES [dbo].[TipoTelefono] ([IdTipoTelefono]);

ALTER TABLE [dbo].[Titulo]
    ADD CONSTRAINT [FK_Titulo_Personal_1] FOREIGN KEY ([IdTitulo]) REFERENCES [dbo].[Personal] ([IdPersonal]);

Go;