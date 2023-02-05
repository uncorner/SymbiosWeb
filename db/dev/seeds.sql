USE Symbios
GO

DECLARE @BASE_PATH varchar(200)
SET @BASE_PATH = 'd:\Development\WebSites\Symbios\trunk\db\dev\'

DECLARE @IMAGE_PATH varchar(200)
SET @IMAGE_PATH = @BASE_PATH + 'images\'

DECLARE @APP_PATH varchar(200)
SET @APP_PATH = @BASE_PATH + 'apps\'

DECLARE @INSERT_STRING varchar(5000)

DELETE dbo.Users;
DELETE dbo.Planets
DELETE dbo.Apps;
DELETE dbo.AppFiles;
DELETE dbo.Screenshots;
DELETE dbo.Categories;

-- Categories
INSERT INTO dbo.Categories (Tag, Name)
VALUES ('system', '���������');

INSERT INTO dbo.Categories (Tag, Name)
VALUES ('games', '����');

INSERT INTO dbo.Categories (Tag, Name)
VALUES ('office', '����');

INSERT INTO dbo.Categories (Tag, Name)
VALUES ('other', '������');

-- Screenshots
SET IDENTITY_INSERT dbo.Screenshots ON

SET @INSERT_STRING = 
	'INSERT INTO dbo.Screenshots (Id, ImageData, ThumbData)
	SELECT ''1'' as Id,
	(SELECT * FROM OPENROWSET(BULK ''' + @IMAGE_PATH + 'screenshot1.jpg'', SINGLE_BLOB) as Col) as ImageData,
	(SELECT * FROM OPENROWSET(BULK ''' + @IMAGE_PATH + 'thumbnail1.jpg'', SINGLE_BLOB) as Col) as ThumbData
	UNION
	SELECT ''2'' as Id,
	(SELECT * FROM OPENROWSET(BULK ''' + @IMAGE_PATH + 'screenshot2.jpg'', SINGLE_BLOB) as Col) as ImageData,
	(SELECT * FROM OPENROWSET(BULK ''' + @IMAGE_PATH + 'thumbnail2.jpg'', SINGLE_BLOB) as Col) as ThumbData
	UNION
	SELECT ''3'' as Id,
	(SELECT * FROM OPENROWSET(BULK ''' + @IMAGE_PATH + 'screenshot3.jpg'', SINGLE_BLOB) as Col) as ImageData,
	(SELECT * FROM OPENROWSET(BULK ''' + @IMAGE_PATH + 'thumbnail3.jpg'', SINGLE_BLOB) as Col) as ThumbData
	UNION
	SELECT ''5'' as Id,
	(SELECT * FROM OPENROWSET(BULK ''' + @IMAGE_PATH + 'screenshot5.jpg'', SINGLE_BLOB) as Col) as ImageData,
	(SELECT * FROM OPENROWSET(BULK ''' + @IMAGE_PATH + 'thumbnail5.jpg'', SINGLE_BLOB) as Col) as ThumbData
	UNION
	SELECT ''6'' as Id,
	(SELECT * FROM OPENROWSET(BULK ''' + @IMAGE_PATH + 'screenshot6.jpg'', SINGLE_BLOB) as Col) as ImageData,
	(SELECT * FROM OPENROWSET(BULK ''' + @IMAGE_PATH + 'thumbnail6.jpg'', SINGLE_BLOB) as Col) as ThumbData'
EXEC(@INSERT_STRING)
	
SET IDENTITY_INSERT dbo.Screenshots OFF

-- AppFiles
SET IDENTITY_INSERT dbo.AppFiles ON

SET @INSERT_STRING = 
	'INSERT INTO dbo.AppFiles (Id, FileName, FileData)
	SELECT ''1'' as Id,
	''pdf.sis'' as FileName,
	(SELECT * FROM OPENROWSET(BULK ''' + @APP_PATH + 'app1.sis'', SINGLE_BLOB) as Col) as FileData
	UNION
	SELECT ''2'' as Id,
	''powermp.sis'' as FileName,
	(SELECT * FROM OPENROWSET(BULK ''' + @APP_PATH + 'app2.sis'', SINGLE_BLOB) as Col) as FileData
	UNION
	SELECT ''3'' as Id,
	''emoze.sis'' as FileName,
	(SELECT * FROM OPENROWSET(BULK ''' + @APP_PATH + 'app3.sis'', SINGLE_BLOB) as Col) as FileData
	UNION
	SELECT ''4'' as Id,
	''ramblow.zip'' as FileName,
	(SELECT * FROM OPENROWSET(BULK ''' + @APP_PATH + 'app4.zip'', SINGLE_BLOB) as Col) as FileData
	UNION
	SELECT ''5'' as Id,
	''crazy_taxi.sis'' as FileName,
	(SELECT * FROM OPENROWSET(BULK ''' + @APP_PATH + 'app5.sis'', SINGLE_BLOB) as Col) as FileData
	UNION
	SELECT ''6'' as Id,
	''block_breaker.sis'' as FileName,
	(SELECT * FROM OPENROWSET(BULK ''' + @APP_PATH + 'app6.sis'', SINGLE_BLOB) as Col) as FileData'
EXEC(@INSERT_STRING)
	
SET IDENTITY_INSERT dbo.AppFiles OFF

-- Apps
SET IDENTITY_INSERT dbo.Apps ON

INSERT INTO dbo.Apps (Id, Title, Description, Website, CategoryTag, ScreenshotId, FileId, Created)
	SELECT '1' as Id,
	'PDF - V.1.67' as Title,
	'Pdf - v.1.67 ��������� ��� ��������� ������ Pdf ������� ������� ��������������� ���� �� ���������� nokia 5800. � ������� �� ����� ����� ������ ���� ��������� (Pdf � v.1.75) Pdf - v.1.67 ������������ ������, ������� ������ �������� ������ � ������������� ������, ������� ������������� ������������ ����������� ����������. � ��������� ����� ����������� �� ��������� � Adobe, �������� ���� ����������� ��������� ����� �� ������ � ������ ������. ��������� ��������� �� ���������� �����.'
		as Description,
	'www.pdf.com' as Website,
	'system' as CategoryTag,
	'1' as ScreenshotId,
	'1' as FileId,
	convert(datetime, '2010-09-05 10:23:11', 120) as Created
	UNION
	SELECT '2' as Id,
	'POWERMP3 2_4.1' as Title,
	'Powermp3 - ��������� ������� ������ ������������ ������ ��� ��������� Nokia � Symbian OS. ����� ��������� ���� ��������������, � ��� ����� - ��������� ������������� � �������� �����. ������ ��� Nokia Powermp3 ����� ����� �����, �����, ��������, ��� ������ ����������, 10-�������� ���������� � ������������ ���������� ��������, ���������� �������������� ������.'
		as Description,
	'www.powermp.com' as Website,
	'system' as CategoryTag,
	'2' as ScreenshotId,
	'2' as FileId,
	convert(datetime, '2011-01-15 18:52:42', 120) as Created
	UNION
	SELECT '3' as Id,
	'EMOZE 2.0.83' as Title,
	'��������� ��� Symbian 9 ��� ������ � push-email. Push email � ��� ������ ���������� �������� ����������� �����. ���������� ��������� ��� �� ������������ ��������, ��� � �������� ������ ����������� ����������� ICQ, MSN � �.�. ��� ���� ����������� ��� ����������� ������� ����������� �����. ��� ������ � Emoze ������������ ���������� ����� ������� ������ �� �����-���� �������� ������� � ����������� ����������. ��������� ������������ ������������� � Outlook, �� ����� �������� ���������� ������� ������ ��� �������� �������� � ������������ ������� ������� ������. � ������ ������� ������������ ����������� ������ �������� emoze Ltd. ������������ �������, ��� ������� ����� �������� ����������� � ����� ����� � ��� ����� ����������� � ���������. ��������� ��� ����� ����� � �����, ��� �����.'
		as Description,
	'www.emoze.com' as Website,
	'system' as CategoryTag,
	'3' as ScreenshotId,
	'3' as FileId,
	convert(datetime, '2010-10-07 11:10:15', 120) as Created
	UNION
	SELECT '4' as Id,
	'RAMblow v.1.0' as Title,
	'������ �� ������� ��������� ������������ ����������� ����� ����������� ������ ���������. ��������� ������������� ��������� �������, ���� ����������� ����������� �������� ���������� (���������).

	�����������: 
	- �������������� � ������ ���������� ����������� ������������;
	- ����������� ������������ ���������� ��������� ������ (��� ����������� ���������������� ���������);
	- ����������� ������ ��� ������� ������������ ����������;
	- �������������� ������� ������ ����� ������������� �������;
	- ����������� �������� ������������� ��������;
	- ������ � ������� ������.

	��� ����������� ������ ����� �������'
		as Description,
	'www.ramblow.com' as Website,
	'system' as CategoryTag,
	null as ScreenshotId,
	'4' as FileId,
	convert(datetime, '2011-01-27 09:43:00', 120) as Created
	UNION
	SELECT '5' as Id,
	'Crazy Taxi' as Title,
	'����������� ����� �� ������ �������� ���������� - ����� ���������� �������� � ������ �����, � ����� ������ ������ � ���� ������������. ����� ���� Crazy Taxi �� ���� ������ ��������� ��������� Sega, � ��� �� ����, ��� ����� � ������ ����� GTA �� ��. ����������� ����� �� ��������� ������ � ����� (������� ��������� �� ������ ����� � ���������� �����) ��� ����� ��� ������ ����.
	���� ��� ������ ����: �������� � ���� �� �����. � ������ ������ ������ ������, �� ������ ����� ����� ����� �������������.'
		as Description,
	null as Website,
	'games' as CategoryTag,
	'5' as ScreenshotId,
	'5' as FileId,
	convert(datetime, '2010-10-11 15:17:03', 120) as Created
	UNION
	SELECT '6' as Id,
	'Block Breaker Deluxe 2' as Title,
	'�������� � ����� ������������ � �������� ������������� ���� ��� ��������� Nokia X6! ����������� ����������� ������ ������� � ���������, ������� ����� ������� � ������� �������� �����. ����� � ��������� ������, � ��������, ������������� �������, ��������� ������ � ���� ���������� ����-����. Block Breaker Deluxe �� ���������� ����������, � ��� �������. ������ ����� � ������ ���� ���� �� ����� ���������� � ���� �����!'
		as Description,
	'www.blockbreaker.com' as Website,
	'games' as CategoryTag,
	'6' as ScreenshotId,
	'6' as FileId,
	convert(datetime, '2010-11-23 17:53:12', 120) as Created
	
SET IDENTITY_INSERT dbo.Apps OFF

-- Planets
INSERT INTO dbo.Planets (Name, Description)
	SELECT 'Mercury' as ObjectId,
	'hot' as Description
	UNION
	SELECT 'Venus' as ObjectId,
	'cloudy' as Description
	UNION
	SELECT 'Earth' as ObjectId,
	'home' as Description
	UNION
	SELECT 'Mars' as ObjectId,
	'red' as Description
	UNION
	SELECT 'Jupiter' as ObjectId,
	'giant' as Description
	UNION
	SELECT 'Saturn' as ObjectId,
	'rings' as Description
	UNION
	SELECT 'Uranus' as ObjectId,
	'blue' as Description

-- Users		
INSERT INTO dbo.Users (Name, Password)
VALUES('luke', SUBSTRING(master.dbo.fn_varbintohexstr(HashBytes('SHA1', 'aBC123')), 3, 40));

INSERT INTO dbo.Users (Name, Password)
VALUES('�����', SUBSTRING(master.dbo.fn_varbintohexstr(HashBytes('SHA1', 'mars999')), 3, 40));
