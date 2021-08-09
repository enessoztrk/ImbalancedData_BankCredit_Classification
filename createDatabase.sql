USE [master]
CREATE DATABASE [nefamak_satis] COLLATE Turkish_CI_AS
GO
USE [nefamak_satis]
GO
CREATE TABLE [dbo].[kategoribilgileri](
	[kategori] [nvarchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[markabilgileri]    Script Date: 8/5/2021 6:15:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[markabilgileri](
	[kategori] [nvarchar](100) NOT NULL,
	[marka] [nvarchar](100) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[müşteri]    Script Date: 8/5/2021 6:15:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[müşteri](
	[sirketadi] [nvarchar](100) NOT NULL,
	[adsoyad] [nvarchar](100) NOT NULL,
	[telefon] [nvarchar](100) NOT NULL,
	[adres] [nvarchar](100) NOT NULL,
	[email] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_müşteri] PRIMARY KEY CLUSTERED 
(
	[sirketadi] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[satis]    Script Date: 8/5/2021 6:15:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[satis](
	[sirketadi] [varchar](100) NOT NULL,
	[adsoyad] [varchar](100) NOT NULL,
	[telefon] [varchar](100) NOT NULL,
	[barkodno] [varchar](100) NOT NULL,
	[urunadi] [varchar](100) NOT NULL,
	[miktari] [int] NOT NULL,
	[satisfiyati] [decimal](18, 2) NOT NULL,
	[toplamfiyati] [decimal](18, 2) NOT NULL,
	[tarih] [datetime] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sepet]    Script Date: 8/5/2021 6:15:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sepet](
	[sirketadi] [varchar](100) NOT NULL,
	[adsoyad] [varchar](100) NOT NULL,
	[telefon] [varchar](100) NOT NULL,
	[barkodno] [varchar](100) NOT NULL,
	[urunadi] [varchar](100) NOT NULL,
	[miktari] [int] NOT NULL,
	[satisfiyati] [decimal](18, 2) NOT NULL,
	[toplamfiyati] [decimal](18, 2) NOT NULL,
	[tarih] [datetime] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_sepet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[urun]    Script Date: 8/5/2021 6:15:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[urun](
	[barkodno] [nvarchar](100) NOT NULL,
	[kategori] [nvarchar](100) NOT NULL,
	[marka] [nvarchar](100) NOT NULL,
	[urunadi] [nvarchar](100) NOT NULL,
	[miktari] [int] NOT NULL,
	[satisfiyati] [decimal](18, 2) NOT NULL,
	[tarih] [datetime] NOT NULL,
 CONSTRAINT [PK_urun] PRIMARY KEY CLUSTERED 
(
	[barkodno] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[kategoribilgileri] ([kategori]) VALUES (N'Gofret Üretim Hatları ')
INSERT [dbo].[kategoribilgileri] ([kategori]) VALUES (N'Mutfak Ekipmanları')
INSERT [dbo].[kategoribilgileri] ([kategori]) VALUES (N'Çikolata Kaplama Hatları')
INSERT [dbo].[kategoribilgileri] ([kategori]) VALUES (N'Oto Besleme - Paketleme Hatları')
INSERT [dbo].[kategoribilgileri] ([kategori]) VALUES (N'Aaaa')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'Gofret Üretim Hatları ', N'AWBO')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'Gofret Üretim Hatları ', N'WSC')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'Gofret Üretim Hatları ', N'CSM')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'Gofret Üretim Hatları ', N'WBC')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'Gofret Üretim Hatları ', N'WCM')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'Gofret Üretim Hatları ', N'WDD')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'Gofret Üretim Hatları ', N'WGM')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'Mutfak Ekipmanları', N'BMP')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'Mutfak Ekipmanları', N'CRP')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'Mutfak Ekipmanları', N'SGM')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'Mutfak Ekipmanları', N'CHP')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'Çikolata Kaplama Hatları', N'CEM')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'Çikolata Kaplama Hatları', N'CCT')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'Oto Besleme - Paketleme Hatları', N'FCS')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'Oto Besleme - Paketleme Hatları', N'RDS')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'Oto Besleme - Paketleme Hatları', N'HSW')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'Oto Besleme - Paketleme Hatları', N'HBM')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'Oto Besleme - Paketleme Hatları', N'OEP')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'Oto Besleme - Paketleme Hatları', N'SFW')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'Oto Besleme - Paketleme Hatları', N'OWM')
INSERT [dbo].[markabilgileri] ([kategori], [marka]) VALUES (N'Aaaa', N'bbb')
INSERT [dbo].[müşteri] ([sirketadi], [adsoyad], [telefon], [adres], [email]) VALUES (N'Anı', N'Veli Çilsal', N'05381573571', N'Ankara', N'anı_landık@gmail.com')
INSERT [dbo].[müşteri] ([sirketadi], [adsoyad], [telefon], [adres], [email]) VALUES (N'Eti', N'Ahmet Firuzhan Kanatlı', N'05125710397', N'Ankara', N'etibiskuvi@gmail.com.tr')
INSERT [dbo].[müşteri] ([sirketadi], [adsoyad], [telefon], [adres], [email]) VALUES (N'Mark Heiz', N'Heiz Roterhhary', N'+9054626325', N'New York', N'heiz_company@gmail.com')
INSERT [dbo].[müşteri] ([sirketadi], [adsoyad], [telefon], [adres], [email]) VALUES (N'Nisanci', N'Samet Nişancı', N'05076517950', N'Erbaa ', N'erbaakalpsamet@gmail.com')
INSERT [dbo].[müşteri] ([sirketadi], [adsoyad], [telefon], [adres], [email]) VALUES (N'Ozturk Company', N'Enes Öztürk', N'05078242160', N'İstanbul', N'enesozturk7038@gmail.com')
INSERT [dbo].[müşteri] ([sirketadi], [adsoyad], [telefon], [adres], [email]) VALUES (N'Ülker', N'Murat Ülker', N'05440579641', N'İstanbul', N'www.ulkerbiskuvi.com.tr')
INSERT [dbo].[satis] ([sirketadi], [adsoyad], [telefon], [barkodno], [urunadi], [miktari], [satisfiyati], [toplamfiyati], [tarih]) VALUES (N'Ozturk Company', N'Enes Öztürk', N'05078242160', N'003', N'Şeker Öğütme', 4, CAST(76000.00 AS Decimal(18, 2)), CAST(304000.00 AS Decimal(18, 2)), CAST(N'2021-08-05T14:38:31.663' AS DateTime))
INSERT [dbo].[satis] ([sirketadi], [adsoyad], [telefon], [barkodno], [urunadi], [miktari], [satisfiyati], [toplamfiyati], [tarih]) VALUES (N'Ozturk Company', N'Enes Öztürk', N'05078242160', N'004', N'Çikolata Üretim', 1, CAST(35000.00 AS Decimal(18, 2)), CAST(35000.00 AS Decimal(18, 2)), CAST(N'2021-08-05T14:38:31.667' AS DateTime))
INSERT [dbo].[satis] ([sirketadi], [adsoyad], [telefon], [barkodno], [urunadi], [miktari], [satisfiyati], [toplamfiyati], [tarih]) VALUES (N'Ozturk Company', N'Enes Öztürk', N'05078242160', N'02', N'Gofret Tabaka Soğutma', 1, CAST(25000.00 AS Decimal(18, 2)), CAST(25000.00 AS Decimal(18, 2)), CAST(N'2021-08-05T14:38:31.670' AS DateTime))
INSERT [dbo].[satis] ([sirketadi], [adsoyad], [telefon], [barkodno], [urunadi], [miktari], [satisfiyati], [toplamfiyati], [tarih]) VALUES (N'Ozturk Company', N'Enes Öztürk', N'05078242160', N'004', N'Çikolata Üretim', 2, CAST(35000.00 AS Decimal(18, 2)), CAST(70000.00 AS Decimal(18, 2)), CAST(N'2021-08-05T14:38:31.673' AS DateTime))
INSERT [dbo].[satis] ([sirketadi], [adsoyad], [telefon], [barkodno], [urunadi], [miktari], [satisfiyati], [toplamfiyati], [tarih]) VALUES (N'Ozturk Company', N'Enes Öztürk', N'05078242160', N'0002', N'Çikolata Soğutma', 1, CAST(40500.00 AS Decimal(18, 2)), CAST(40500.00 AS Decimal(18, 2)), CAST(N'2021-08-05T14:38:31.673' AS DateTime))
INSERT [dbo].[satis] ([sirketadi], [adsoyad], [telefon], [barkodno], [urunadi], [miktari], [satisfiyati], [toplamfiyati], [tarih]) VALUES (N'Ozturk Company', N'Enes Öztürk', N'05078242160', N'03', N'Krema Sürme', 1, CAST(39000.00 AS Decimal(18, 2)), CAST(39000.00 AS Decimal(18, 2)), CAST(N'2021-08-05T14:38:31.677' AS DateTime))
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [satisfiyati], [tarih]) VALUES (N'00001', N'Oto Besleme - Paketleme Hatları', N'FCS', N'Besleme Konveyörü', 2, CAST(12000.00 AS Decimal(18, 2)), CAST(N'2021-07-28T11:26:29.770' AS DateTime))
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [satisfiyati], [tarih]) VALUES (N'00002', N'Oto Besleme - Paketleme Hatları', N'RDS', N'Yatay Dağılım Sistemi', 5, CAST(79000.00 AS Decimal(18, 2)), CAST(N'2021-07-26T10:09:55.457' AS DateTime))
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [satisfiyati], [tarih]) VALUES (N'00003', N'Oto Besleme - Paketleme Hatları', N'HSW', N'Yüksek Hızlı Sarıcı', 6, CAST(68000.00 AS Decimal(18, 2)), CAST(N'2021-07-26T10:10:31.423' AS DateTime))
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [satisfiyati], [tarih]) VALUES (N'00004', N'Oto Besleme - Paketleme Hatları', N'HBM', N'Yatay Kutu Hareketi Sarıcı', 7, CAST(76000.00 AS Decimal(18, 2)), CAST(N'2021-07-26T10:11:06.593' AS DateTime))
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [satisfiyati], [tarih]) VALUES (N'00005', N'Oto Besleme - Paketleme Hatları', N'OEP', N'Kenar Paketleme', 9, CAST(96000.00 AS Decimal(18, 2)), CAST(N'2021-07-26T10:11:36.350' AS DateTime))
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [satisfiyati], [tarih]) VALUES (N'00006', N'Oto Besleme - Paketleme Hatları', N'SFW', N'Servo Akışı', 1, CAST(64000.00 AS Decimal(18, 2)), CAST(N'2021-07-26T10:12:15.317' AS DateTime))
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [satisfiyati], [tarih]) VALUES (N'00007', N'Oto Besleme - Paketleme Hatları', N'OWM', N'Ambalaj ', 1, CAST(36000.00 AS Decimal(18, 2)), CAST(N'2021-07-26T10:12:51.413' AS DateTime))
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [satisfiyati], [tarih]) VALUES (N'0001', N'Çikolata Kaplama Hatları', N'CEM', N'Çikolata Kaplama', 4, CAST(56000.00 AS Decimal(18, 2)), CAST(N'2021-07-26T10:06:40.067' AS DateTime))
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [satisfiyati], [tarih]) VALUES (N'0002', N'Çikolata Kaplama Hatları', N'CCT', N'Çikolata Soğutma', -1, CAST(45000.00 AS Decimal(18, 2)), CAST(N'2021-07-26T10:08:11.910' AS DateTime))
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [satisfiyati], [tarih]) VALUES (N'001', N'Mutfak Ekipmanları', N'BMP', N'Hamur Karıştırma', -2, CAST(48000.00 AS Decimal(18, 2)), CAST(N'2021-07-26T10:04:30.640' AS DateTime))
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [satisfiyati], [tarih]) VALUES (N'002', N'Mutfak Ekipmanları', N'CRP', N'Krema Üretim ', 3, CAST(55000.00 AS Decimal(18, 2)), CAST(N'2021-07-26T10:05:07.583' AS DateTime))
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [satisfiyati], [tarih]) VALUES (N'003', N'Mutfak Ekipmanları', N'SGM', N'Şeker Öğütme', -9, CAST(76000.00 AS Decimal(18, 2)), CAST(N'2021-07-26T10:05:32.300' AS DateTime))
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [satisfiyati], [tarih]) VALUES (N'004', N'Mutfak Ekipmanları', N'CHP', N'Çikolata Üretim', -8, CAST(35000.00 AS Decimal(18, 2)), CAST(N'2021-07-26T10:06:03.823' AS DateTime))
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [satisfiyati], [tarih]) VALUES (N'01', N'Gofret Üretim Hatları ', N'AWBO', N'Gofret Fırını', 4, CAST(60000.00 AS Decimal(18, 2)), CAST(N'2021-07-26T09:59:33.653' AS DateTime))
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [satisfiyati], [tarih]) VALUES (N'02', N'Gofret Üretim Hatları ', N'WSC', N'Gofret Tabaka Soğutma', -3, CAST(25000.00 AS Decimal(18, 2)), CAST(N'2021-07-26T10:00:11.330' AS DateTime))
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [satisfiyati], [tarih]) VALUES (N'03', N'Gofret Üretim Hatları ', N'CSM', N'Krema Sürme', 2, CAST(39000.00 AS Decimal(18, 2)), CAST(N'2021-07-26T10:00:43.240' AS DateTime))
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [satisfiyati], [tarih]) VALUES (N'04', N'Gofret Üretim Hatları ', N'WBC', N'Katlı Gofret Soğutma', 3, CAST(26000.00 AS Decimal(18, 2)), CAST(N'2021-07-26T10:01:19.800' AS DateTime))
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [satisfiyati], [tarih]) VALUES (N'05', N'Gofret Üretim Hatları ', N'WCM', N'Gofret Kesme', 7, CAST(67000.00 AS Decimal(18, 2)), CAST(N'2021-07-26T10:01:56.007' AS DateTime))
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [satisfiyati], [tarih]) VALUES (N'06', N'Gofret Üretim Hatları ', N'WDD', N'Wafer Dağıtım', 3, CAST(42000.00 AS Decimal(18, 2)), CAST(N'2021-07-26T10:02:35.130' AS DateTime))
INSERT [dbo].[urun] ([barkodno], [kategori], [marka], [urunadi], [miktari], [satisfiyati], [tarih]) VALUES (N'07', N'Gofret Üretim Hatları ', N'WGM', N'Gofret Atık Öğütme', 7, CAST(70000.00 AS Decimal(18, 2)), CAST(N'2021-07-26T10:03:38.063' AS DateTime))