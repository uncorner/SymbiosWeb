/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2005                    */
/* Created on:     02.03.2011 23:28:08                          */
/*==============================================================*/


alter table Apps
   drop constraint FK_APPS_REFERENCE_CATEGORI
go

alter table Apps
   drop constraint FK_APPS_REFERENCE_SCREENSH
go

alter table Apps
   drop constraint FK_APPS_REFERENCE_APPFILES
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AppFiles')
            and   type = 'U')
   drop table AppFiles
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Apps')
            and   type = 'U')
   drop table Apps
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Categories')
            and   type = 'U')
   drop table Categories
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Planets')
            and   type = 'U')
   drop table Planets
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Screenshots')
            and   type = 'U')
   drop table Screenshots
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Users')
            and   type = 'U')
   drop table Users
go

/*==============================================================*/
/* Table: AppFiles                                              */
/*==============================================================*/
create table AppFiles (
   Id                   int                  identity,
   FileData             varbinary(MAX)       not null,
   FileName             varchar(100)         not null,
   constraint PK_APPFILES primary key (Id)
)
go

/*==============================================================*/
/* Table: Apps                                                  */
/*==============================================================*/
create table Apps (
   Id                   int                  identity,
   Title                varchar(50)          not null,
   Description          varchar(800)         null,
   Website              varchar(50)          null,
   CategoryTag          varchar(15)          not null,
   ScreenshotId         int                  null,
   FileId               int                  not null,
   Created              datetime             not null,
   constraint PK_APPS primary key (Id)
)
go

/*==============================================================*/
/* Table: Categories                                            */
/*==============================================================*/
create table Categories (
   Tag                  varchar(15)          not null,
   Name                 varchar(50)          not null,
   constraint PK_CATEGORIES primary key (Tag)
)
go

/*==============================================================*/
/* Table: Planets                                               */
/*==============================================================*/
create table Planets (
   Name                 varchar(20)          not null,
   Description          varchar(100)         null,
   constraint PK_PLANETS primary key (Name)
)
go

/*==============================================================*/
/* Table: Screenshots                                           */
/*==============================================================*/
create table Screenshots (
   Id                   int                  identity,
   ImageData            varbinary(MAX)       not null,
   ThumbData            varbinary(MAX)       not null,
   constraint PK_SCREENSHOTS primary key (Id)
)
go

/*==============================================================*/
/* Table: Users                                                 */
/*==============================================================*/
create table Users (
   Id                   int                  identity,
   Name                 varchar(20)          collate Cyrillic_General_CS_AS not null,
   Password             varchar(100)         not null,
   constraint PK_USERS primary key (Id)
)
go

alter table Apps
   add constraint FK_APPS_REFERENCE_CATEGORI foreign key (CategoryTag)
      references Categories (Tag)
go

alter table Apps
   add constraint FK_APPS_REFERENCE_SCREENSH foreign key (ScreenshotId)
      references Screenshots (Id)
go

alter table Apps
   add constraint FK_APPS_REFERENCE_APPFILES foreign key (FileId)
      references AppFiles (Id)
go

