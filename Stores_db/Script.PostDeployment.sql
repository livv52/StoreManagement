/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO Salesperson (Firstname,Lastname,Description) VALUES ('Livia', 'Anghel', 'Excellent in power trading');
INSERT INTO Salesperson (Firstname,Lastname,Description) VALUES ('Vlad', 'Gurgu', 'Good management of food');
INSERT INTO Salesperson (Firstname,Lastname,Description) VALUES ('Oliver', 'Queen', 'Excellent saler in IT devices');
INSERT INTO Salesperson (Firstname,Lastname,Description) VALUES ('Thomas', 'Nile', 'Sales in automotive');
INSERT INTO Salesperson (Firstname,Lastname,Description) VALUES ('John', 'Snow', 'Sales in movies');
INSERT INTO Salesperson (Firstname,Lastname,Description) VALUES ('Kira', 'Lile', 'Sales in make-up products');

INSERT INTO District(Name) VALUES ('West Denmark');
INSERT INTO District(Name) VALUES ('East Denmark');
INSERT INTO District(Name) VALUES ('North Denmark');
INSERT INTO District(Name) VALUES ('South Denmark');
INSERT INTO District(Name) VALUES ('West London');
INSERT INTO District(Name) VALUES ('South London');

INSERT INTO Store(Name,DistrictId) VALUES ('Fakta',1);
INSERT INTO  Store(Name,DistrictId) VALUES ('Fotex',2);
INSERT INTO  Store(Name,DistrictId) VALUES ('Lego',3);
INSERT INTO  Store(Name,DistrictId) VALUES ('Gigantium',4);
INSERT INTO  Store(Name,DistrictId) VALUES ('Sephora',5);
INSERT INTO  Store(Name,DistrictId) VALUES ('Volvo',6);
INSERT INTO  Store(Name,DistrictId) VALUES ('Lidl',1);
INSERT INTO  Store(Name,DistrictId) VALUES ('Rema',1);
INSERT INTO  Store(Name,DistrictId) VALUES ('Magic Computers',2);
INSERT INTO  Store(Name,DistrictId) VALUES ('Stofa',3);

INSERT INTO DistrictSalesperson (SPId,DistrictId,Position) VALUES (2,1,'Secondary');
INSERT INTO DistrictSalesperson (SPId,DistrictId,Position) VALUES (1,1,'Primary');
INSERT INTO DistrictSalesperson (SPId,DistrictId,Position) VALUES (2,6,'Secondary');
INSERT INTO DistrictSalesperson (SPId,DistrictId,Position) VALUES (2,2,'Primary');
INSERT INTO DistrictSalesperson (SPId,DistrictId,Position) VALUES (3,4,'Primary');
INSERT INTO DistrictSalesperson (SPId,DistrictId,Position) VALUES (3,5,'Secondary');
INSERT INTO DistrictSalesperson (SPId,DistrictId,Position) VALUES (4,5,'Secondary');
INSERT INTO DistrictSalesperson (SPId,DistrictId,Position) VALUES (4,3,'Primary');
INSERT INTO DistrictSalesperson (SPId,DistrictId,Position) VALUES (5,6,'Primary');
INSERT INTO DistrictSalesperson (SPId,DistrictId,Position) VALUES (6,5,'Primary');




