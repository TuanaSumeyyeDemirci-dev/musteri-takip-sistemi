USE [takip];

DELETE FROM [dbo].[musteri];

DBCC CHECKIDENT ('dbo.musteri', RESEED, 0);