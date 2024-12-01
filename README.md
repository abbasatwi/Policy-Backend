
Description:
In this backend api I have implemented Crud operations on the policy entity, I have used jwt token for authentication, I have configured the app to use one role (‘User’) since there is no admin role, and I have created the entities (Policy Type, Policy Member, Member Claims) for design only and did not implement crud on it, I have used it to make relations between the tables only. I have implemented repository pattern for separating the data access and business logic and controller (repository, service, controller) where i have secured the api and handled erros.

## Technologies Used

- **[Language]**: C#
- **[Framework]**: .NET 8.0
- **Database**: Microsoft SQL Server
- **Authentication**: [JWT]

---
### Installation

Clone the repository:
   ```bash
   git clone https://github.com/abbasatwi/Policy-Backend.git


Dependencies: 
   > Microsoft.AspNetCore.Authentication.JwtBearer          8.0.11      
   > Microsoft.AspNetCore.Identity.EntityFrameworkCore      8.0.11       
   > Microsoft.EntityFrameworkCore                          9.0.0       
   > Microsoft.EntityFrameworkCore.SqlServer                9.0.0         
   > Microsoft.EntityFrameworkCore.Tools                    9.0.0       
   > Microsoft.Extensions.DependencyInjection               9.0.0       
   > Swashbuckle.AspNetCore                                 7.1.0       


Steps to run the Api locally: 
1. Right click on the solution and click restore nugget packages.
2. Adjust Db connection string in the app settings.json
3- Build Solution
4. Run update-database in the package manager console
5. Run these scripts one by one in order to seed the database with some static data : 
for policy types : 

SET IDENTITY_INSERT [APIDB].[dbo].PolicyTypes ON;

INSERT INTO [APIDB].[dbo].PolicyTypes (Id, Name, Description) VALUES
(1, 'Health', 'Health-related policies for individuals and families'),
(2, 'Vehicle', 'Insurance coverage for cars, motorcycles, and other vehicles'),
(3, 'Property', 'Coverage for homes, offices, and other properties'),
(4, 'Life', 'Life insurance plans for long-term benefits');

SET IDENTITY_INSERT [APIDB].[dbo].PolicyTypes OFF;
 
For policy members : 
SET IDENTITY_INSERT [APIDB].[dbo].PolicyMembers ON;

INSERT INTO [APIDB].[dbo].PolicyMembers (Id, Name, Email) VALUES
(1, 'John Doe', 'john.doe@example.com'),
(2, 'Jane Smith', 'jane.smith@example.com'),
(3, 'Mark Taylor', 'mark.taylor@example.com'),
(4, 'Lucy Brown', 'lucy.brown@example.com'),
(5, 'Emma Wilson', 'emma.wilson@example.com');

SET IDENTITY_INSERT [APIDB].[dbo].PolicyMembers OFF;

For policies: 

SET IDENTITY_INSERT [APIDB].[dbo].Policies ON;

INSERT INTO [APIDB].[dbo].Policies (Id, Name, Description, CreationDate, EffectiveDate, ExpiryDate, PolicyTypeId) VALUES
(1, 'John Health Plan', 'Health insurance coverage for John Doe and family', '2024-11-01', '2024-11-15', '2025-11-15', 1),
(2, 'Jane Vehicle Coverage', 'Comprehensive vehicle insurance for Jane Smith', '2024-10-01', '2024-10-15', '2025-10-15', 2),
(3, 'Mark Property Shield', 'Insurance for Mark Taylor’s residential property', '2024-09-01', '2024-09-15', '2025-09-15', 3);

SET IDENTITY_INSERT [APIDB].[dbo].Policies OFF;

For member claims : 

SET IDENTITY_INSERT [APIDB].[dbo].MemberClaims ON;

INSERT INTO [APIDB].[dbo].MemberClaims (Id, PolicyId, PolicyMemberId, ClaimDate, ClaimAmount) VALUES
(1, 1, 1, '2024-11-15', 500.00),
(2, 2, 2, '2024-11-16', 750.00),
(3, 1, 3, '2024-11-17', 1000.00);

SET IDENTITY_INSERT [APIDB].[dbo].MemberClaims OFF;


