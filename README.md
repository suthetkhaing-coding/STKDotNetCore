# STKDotNetCore

Clear git local cache

git rm -r --cached .
git add .
git commit -am 'git cache cleared'
git push
https://medium.com/@buttertechn/qa-testing-what-is-dev-sit-uat-prod-ac97965ce4f

EF Core

Code First
Database First
https://www.entityframeworktutorial.net/efcore/create-model-for-existing-database-in-ef-core.aspx

Scaffold-DbContext "Server=.;Database=DotNetTrainingBatch4;User ID=sa;Password=sasa@123;TrustServerCertificate=True;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context
UI + Business Logic + Data Access + Db Mobile, Web => API => Database C# => Db

STKDotNetCore (Folder Structure)

STKDotNetCore.ConsoleApp
STKDotNetCore.RestApi
 Console App
 Ado.Net CRUD
 Dapper CRUD
 EFCore
 ASP.NET Core Web API Blog CRUD, Console App Folder Structure
 ASP.NET Core Web API Dapper CRUD
 ASP.NET Core Web API Ado.Net CRUD, Dapper Custom Service, Ado.Net Custom Service
 Layered (N-Layer) Architecture, Burma Project Idea Discussion For API, Burma Project Idea JSON data to API
 Console App CRUD with API using HttpClient & RestClient (RestSharp)
!Alter Text

.net framework (1, 4.8.1) .net core (1, 3.1) .net (5, 9)

MVC Model View Controller

Controller => Processing => View(Model == Dto) => UI (cshtml)



Submit

AsNoTracking

Ajax

ViewBag, ViewData, TempData, Session

Dependency Inject with Order

1 2 3 - update 8 4 - update 9 5 6 x 7 x

Commit / Uncommit

select * from Tbl_Blog with (nolock)

https://github.com/chartjs/Chart.js/blob/master/docs/scripts/utils.js

Client A => Push Client B => Receive

Dashboard Page

Client A

Product => [Server => Add Product (changes) => Server Client All] => Changes =>

Scaffold-DbContext "Server=HO-1-091\MSSQLSERVERS;Database=STKDotNetCoreDb;User ID=sa;Password=Ami123!@#;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context AppDbContext

dotnet ef dbcontext scaffold "Server=HO-1-091\MSSQLSERVERS;Database=STKDotNetCoreDb;User Id=sa;Password=Ami123!@#;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -o Models -c AppDbContext -f

dotnet tool install --global dotnet-ef --version 8
Git Commit Message Prefixes
feat: New feature (e.g., feat: add user login functionality).
fix: Bug fix (e.g., fix: resolve issue with user login).
chore: Maintenance tasks (e.g., chore: update dependencies).
docs: Documentation changes (e.g., docs: update README).
style: Code formatting changes (e.g., style: format code).
refactor: Code refactoring (e.g., refactor: streamline user flow).
perf: Performance improvements (e.g., perf: optimize dashboard load).
test: Adding or updating tests (e.g., test: add unit tests for login).
build: Build system changes (e.g., build: update webpack).
ci: CI configuration changes (e.g., ci: add GitHub Actions).
revert: Reverting previous commits (e.g., revert: revert commit abc1234).
merge: Merging branches (e.g., merge: merge branch 'feature-branch').
hotfix: Quick fixes for critical issues (e.g., hotfix: correct typo).

Example Commit Messages
feat: add search functionality to navbar
`fix:
