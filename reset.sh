rm db/app.db
rm -rf lib/Migrations
dotnet ef migrations add Initial --project lib
dotnet ef database update --project lib
