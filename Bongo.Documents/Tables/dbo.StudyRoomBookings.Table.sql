USE [Bongo]
GO
/****** Object:  Table [dbo].[StudyRoomBookings]    Script Date: 01-06-2025 06:43:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudyRoomBookings](
	[BookingId] [int] IDENTITY(1,1) NOT NULL,
	[StudyRoomId] [int] NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Date] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_StudyRoomBookings] PRIMARY KEY CLUSTERED 
(
	[BookingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
