CREATE TABLE [dbo].[Clients] (
    [id]        INT          NOT NULL,
    [firstName] VARCHAR (50) NOT NULL,
    [LastName]  VARCHAR (50) NOT NULL,
    [phone]     VARCHAR (10) NOT NULL,
    [kind]      CHAR (1)     NOT NULL,
    [BirthDate] DATETIME     NOT NULL,
    CONSTRAINT [Clients_pk] PRIMARY KEY CLUSTERED ([id] ASC),
    CONSTRAINT [check_kind1] CHECK ([kind]='f' OR [kind]='m')
);

CREATE TABLE [dbo].[Dietitians] (
    [id]        INT           NOT NULL,
    [firstName] VARCHAR (50)  NOT NULL,
    [LastName]  VARCHAR (50)  NOT NULL,
    [email]     VARCHAR (25)  NULL,
    [phone]     VARCHAR (10)  NOT NULL,
    [kind]      VARCHAR (255) NOT NULL,
    CONSTRAINT [Dietitians_pk] PRIMARY KEY CLUSTERED ([id] ASC),
    CHECK ([email] like '_%@%.%'),
    CONSTRAINT [check_kind] CHECK ([kind]='m' OR [kind]='f')
);

CREATE TABLE [dbo].[Meetings] (
    [code]       INT            IDENTITY (1, 1) NOT NULL,
    [dieticanId] INT            NOT NULL,
    [clientId]   INT            NOT NULL,
    [status]     NVARCHAR (255) NOT NULL,
    [date]       DATETIME       NOT NULL,
    [hour]       TIME (7)       NOT NULL,
    CONSTRAINT [Meetings_pk] PRIMARY KEY CLUSTERED ([code] ASC),
    CONSTRAINT [clientsId_fk] FOREIGN KEY ([clientId]) REFERENCES [dbo].[Clients] ([id]),
    CONSTRAINT [dieticanId_fk] FOREIGN KEY ([dieticanId]) REFERENCES [dbo].[Dietitians] ([id])
);
CREATE TABLE [dbo].[WorkHours] (
    [dayInTheWeek] INT      NOT NULL,
    [dieticanId]   INT      NOT NULL,
    [startHour]    TIME (7) NOT NULL,
    [endHour]      TIME (7) NOT NULL,
    CONSTRAINT [dieticanId_fk2] FOREIGN KEY ([dieticanId]) REFERENCES [dbo].[Dietitians] ([id]),
    CONSTRAINT [check_dayInTheWeek] CHECK ([dayInTheWeek]>=(1) AND [dayInTheWeek]<=(5))
);
